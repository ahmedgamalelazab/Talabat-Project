using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        /*IAgentService Agent { get; }*/
        IClientService Client { get; }
        
        IProductService Product { get; }
        
    }
}
