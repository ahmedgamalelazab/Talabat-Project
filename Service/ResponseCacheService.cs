using Service.Contracts;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDatabase _database;
        public ResponseCacheService(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan time)
        {
            // i check if response is null and return null
            if (response == null) return;
            /// in front end i store object like CamelCase
            var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            // serialize response to cacheing and set it to database redis 
            var serializedResponse = JsonSerializer.Serialize(response, options);
            await _database.StringSetAsync(cacheKey, serializedResponse, time);
        }

        public async Task<string> GetCachedResponseAsync(string cacheKey)
        {
            var cachedResponse = await _database.StringGetAsync(cacheKey);
            // cachedResponse is return RedisValue and its struct and it not return null so must return null like code bellow
            if (cachedResponse.IsNullOrEmpty) return null;

            return cachedResponse;
        }
    }
}
