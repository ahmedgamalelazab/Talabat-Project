using Entities.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Repository.Extentions.Utility;

namespace Repository.Extentions
{
    public static class RepositoryCLientExtentions
    {
        public static IQueryable<Client> Search(this IQueryable<Client> clients, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return clients;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return clients.Where(c => c.Name.ToLower().Contains(lowerCaseTerm));
                /*.Where(c => c.AddressClient.Any(a => a.Country.ToLower().Contains(lowerCaseTerm)))
                .Where(c => c.AddressClient.Any(a => a.City.ToLower().Contains(lowerCaseTerm)))
                .Where(c => c.AddressClient.Any(a => a.Street.ToLower().Contains(lowerCaseTerm)))*/
        }
        

        public static IQueryable<Client> Sort(this IQueryable<Client> clients, string orderByQueryString)
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString))
                return clients.OrderBy(c => c.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Client>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery)) 
                return clients.OrderBy(c => c.Name);

            return clients.OrderBy(orderQuery);
        }
    }
}
