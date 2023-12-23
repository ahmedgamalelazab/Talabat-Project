using Entities.Models;
using Repository.Extentions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace Repository.Extentions
{
    public static class RepositoryAgentExtentions
    {
        public static IQueryable<Agent> Search(this IQueryable<Agent> clients, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return clients;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return clients.Where(c => c.Name.ToLower().Contains(lowerCaseTerm));
        }


        public static IQueryable<Agent> Sort(this IQueryable<Agent> agents, string orderQuiryString)
        {
            if(string.IsNullOrWhiteSpace(orderQuiryString))
                return agents.OrderBy(a => a.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Agent>(orderQuiryString);

            if(string.IsNullOrWhiteSpace(orderQuery))
                return agents.OrderBy(q => q.Name);

            return agents.OrderBy(orderQuery);
        }
    }
}
