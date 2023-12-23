using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository
{
    public class StoreContextSeed /*: DbContext*/
    {
        public static async Task SeedAsync(RepositoryContext context, ILoggerManager loggerManager)
        {
			try
			{
                if(!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Repository/Data/DataSeed/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach (var brand in brands)
                        context.Set<ProductBrand>().Add(brand);

                    await context.SaveChangesAsync();
                }
                if (!context.ProductTypes.Any())
                {
                    var typesData= File.ReadAllText("../Repository/Data/DataSeed/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var type in types)
                        context.Set<ProductType>().Add(type);

                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../Repository/Data/DataSeed/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);
                    foreach (var product in products)
                        context.Set<Product>().Add(product);
                    await context.SaveChangesAsync();
                }
                if(!context.Clients.Any())
                {
                    var clientData = File.ReadAllText("../Repository/Data/Dataseed/clients.json");
                    var clients = JsonSerializer.Deserialize<List<Client>>(clientData);
                    foreach (var client in clients)
                        context.Set<Client>().Add(client);
                    await context.SaveChangesAsync();
                }
                if (!context.ClientTypes.Any())
                {
                    var clientTypeData = File.ReadAllText("../Repository/Data/Dataseed/clientType.json");
                    var types = JsonSerializer.Deserialize<List<ClientType>>(clientTypeData);
                    foreach (var type in types)
                        context.Set<ClientType>().Add(type);
                    await context.SaveChangesAsync();
                }
                
            }
			catch (Exception ex)
			{
                 loggerManager.LogError(ex.Message);
			}
        }
    }
}
