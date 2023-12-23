using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        IClientRepository Client { get; }
       
        /*IOrderRepository Order { get; }*/
        /*IAgentRepository Agent { get; }
        ICustomerRepository Customer { get; }
        IOrderProductRepository OrderProduct { get; }*/
        Task SaveAsync();
    }
}
