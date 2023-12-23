using AutoMapper;

using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Repository;
using Service.Contracts;
using Stripe.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        /*private readonly Lazy<IAgentService> _agent;*/

        private readonly Lazy<IClientService> _client;


        private readonly Lazy<IProductService> _Product;


        


        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, RepositoryContext context, IConfiguration configuration)
        {
            /*_agent = new Lazy<IAgentService>(() => new AgentService(repository, logger, mapper));*/

            _client = new Lazy<IClientService>(() => new ClientService(repository, logger, mapper));

            
            _Product = new Lazy<IProductService>(() => new ProductService(repository, logger, mapper, context));

           
        }
        /*public IAgentService Agent => _agent.Value;*/
        public IClientService Client => _client.Value;
        public IProductService Product => _Product.Value;
        
    }  
}
