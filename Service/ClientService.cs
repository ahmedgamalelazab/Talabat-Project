using AutoMapper;
using Contracts;
using Entities.Exceptions.AgentException;
using Entities.Exceptions.ClientException;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Repository;
using Service.Contracts;
using Shared.DataTransfierObject;
using Shared.RequestFeature;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class ClientService : IClientService
    {
        
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ClientService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        
        public async Task<(IReadOnlyList<ClientDto> clients, MetaData metaData)>
            GetAllClient(CLientParameter cLientParameter, bool trackChanges)
        {
            var clients = await _repository.Client.GetAllClients(cLientParameter, trackChanges);
            var clientWithMetaData = await _repository.Client.GetAllClients(cLientParameter, trackChanges);
            var clientDto = _mapper.Map<IReadOnlyList<ClientDto>>(clientWithMetaData);
            return (clients: clientDto, metaData: clientWithMetaData.MetaData);
        }   

        public IReadOnlyList<ClientDto> GetAllClientByAddress(string address)
        {
            var clients = _repository.Client.GetClientsByAddress(address);
            var clientToReturn = _mapper.Map<IReadOnlyList<ClientDto>>(clients);
            return clientToReturn;
        }

        public async Task<ClientDto> GetClientAsync(int clientId, bool trackChages)
        {
            var client = await _repository.Client.GetClient(clientId, trackChages);
            if (client is null)
                throw new ClientNotFoundException(clientId);

            var clientToReturn = _mapper.Map<ClientDto>(client);
            return clientToReturn;
        }

        public async Task<ClientDto> CreateClientAsync(ClientForCreatingDto client)
        {
            var clientEntity = _mapper.Map<Client>(client);
            
            _repository.Client.CreateClient(clientEntity);
            await _repository.SaveAsync();
            var clientToReturn = _mapper.Map<ClientDto>(clientEntity);
            return clientToReturn;
        }
        
        public async Task DeleteClientAsync(int id, bool trackChanges)
        {
            var clientEntity = await _repository.Client.GetClient(id, trackChanges);
            if (clientEntity is null)
                throw new ClientNotFoundException(id);
            _repository.Client.DeleteClient(clientEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateClientAsync(int id, ClientForUpdateDto clientForUpdate, bool trackChanges)
        {
            var clientEntity = await _repository.Client.GetClient(id, trackChanges);
            if (clientEntity is null)
                throw new ClientNotFoundException(id);
            _mapper.Map(clientForUpdate, clientEntity);
            await _repository.SaveAsync();
        }

        public async Task<IReadOnlyList<ClientDto>> GetAllClient()
        {
            var spec = new Client_WithTypeSpecification();
            var clients = await _repository.Client.GetAllClientSpec(spec);
            var clientToReturn = _mapper.Map<IReadOnlyList<ClientDto>>(clients);
            return clientToReturn;
        }

        public async Task<ClientDto> GetClientById(int id)
        {
            var spec = new Client_WithTypeSpecification(id);
            var client = await _repository.Client.GetClientSpecById(spec);
            var clientToReturn = _mapper.Map<ClientDto>(client);
            return clientToReturn;
        }

        
    }
}
