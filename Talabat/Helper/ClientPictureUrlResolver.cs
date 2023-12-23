using AutoMapper;
using Entities.Models;

using Shared.DataTransfierObject;

namespace Talabat.Helper
{
    public class ClientPictureUrlResolver : IValueResolver<Client, ClientDto, string>
    {
        public IConfiguration _configuration;

        public ClientPictureUrlResolver(IConfiguration configuration)
        {
            _configuration=configuration;
        }

        public string Resolve(Client source, ClientDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["BaseApiUrl"]}/{source.PictureUrl}";
            return null;
        }
    }
}
