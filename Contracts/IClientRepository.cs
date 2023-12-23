using Entities.Models;
using Shared.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IClientRepository
    {
        Task<Client> GetClientSpecById(ISpecification<Client> specification);
        Task<IReadOnlyList<Client>> GetAllClientSpec(ISpecification<Client> specification);
        IReadOnlyList<Client> GetClientsByAddress(string address);
        Task<PagedList<Client>> GetAllClients(CLientParameter cLientParameter, bool trackChanges);
        Task<Client> GetClient(int id, bool trackChanges);
        void CreateClient(Client client);
        void DeleteClient(Client client);
        void UpdateClient(Client client);
    }
}
