
using Microsoft.AspNetCore.Http;
using Shared.DataTransfierObject;
using Shared.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IClientService
    {
        Task<IReadOnlyList<ClientDto>> GetAllClient();
        Task<ClientDto> GetClientById(int id);

        IReadOnlyList<ClientDto> GetAllClientByAddress(string adderss);
        Task<(IReadOnlyList<ClientDto> clients, MetaData metaData)>
            GetAllClient(CLientParameter cLientParameter, bool trackChanges);
        Task<ClientDto> GetClientAsync(int clientId, bool trackChages);
        Task<ClientDto> CreateClientAsync(ClientForCreatingDto client);
        Task DeleteClientAsync(int id, bool trackChanges);
        Task UpdateClientAsync(int id, ClientForUpdateDto clientUpdate, bool trackChanges);

        
    }
}
