using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        private readonly Lazy<IClientRepository> _client;
        private readonly Lazy<IProductRepository> _product;
        


        /*private readonly Lazy<ICustomerRepository> _customer;*/

        /*private readonly Lazy<IOrderRepository> _order;
        private readonly Lazy<IOrderProductRepository> _orderProduct;*/




        public RepositoryManager( RepositoryContext context)
        {
            _context = context;

            _product = new Lazy<IProductRepository>(() => new ProductRepository(context));
            
            _client = new Lazy<IClientRepository>(() => new ClientRepository(context)) ;

           /* _agent = new Lazy<IAgentRepository>(() => new AgentRepository(context)) ;*/

            /*_customer= new Lazy<ICustomerRepository>(() => new CustomerRepository(context)) ;*/

            /*_order = new Lazy<IOrderRepository>(() => new OrderRepository(context));*/

            /* _orderProduct = new Lazy<IOrderProductRepository>(() => new OrderProductRepository(context));*/


        }

        /*public IAgentRepository Agent => _agent.Value;*/

        /*public ICustomerRepository Customer => _customer.Value;*/

        public IClientRepository Client => _client.Value;
        public IProductRepository Product => _product.Value;

        /*public IOrderRepository Order => _order.Value;*/

        /*public IOrderProductRepository OrderProduct => _orderProduct.Value;*/


        public async Task SaveAsync() => await _context.SaveChangesAsync();   


    }
}
