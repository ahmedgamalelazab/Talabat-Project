using AutoMapper;
using Contracts;
using Entities.Exceptions.AgentException;
using Entities.Exceptions.ClientException;
using Entities.Models;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using Shared.DataTransfierObject;
using Shared.RequestFeature;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /*internal sealed class AgentService : IAgentService
    { 
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AgentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository=repository;
            _logger = logger;
            _mapper=mapper;
        }

        public async Task<(IEnumerable<AgentDto> agents, MetaData metaData)> 
            GetAllAgent( AgentParameter agentParameter, bool trackChages)
        {
            var agents = await _repository.Agent.GetAllAgents(agentParameter, trackChages);
            var agentMetaData =await _repository.Agent.GetAllAgents(agentParameter, trackChages);

            var agentsDto = _mapper.Map<IEnumerable<AgentDto>>(agentMetaData);
            return (agents: agentsDto , metaData: agentMetaData.MetaData);
        }

        public async Task<AgentDto> GetAgentAsync(Guid agentId, bool trackChages)
        {
            var agent = await _repository.Agent.GetAgent(agentId, trackChages);
            if (agent is null)
                throw new ClientNotFoundException(agentId);

            var agentDto = _mapper.Map<AgentDto>(agent);
            return agentDto;
        }


        public async Task<AgentDto> CreateAgentAsync(AgentForCreatingDto agent)
        {
            var agentEntity =  _mapper.Map<Agent>(agent);
            _repository.Agent.CreateAgent(agentEntity);
            await _repository.SaveAsync();
            var agentToReturn = _mapper.Map<AgentDto>(agentEntity);
            return agentToReturn;
        }

        public async Task DeleteAgentAsync(Guid id, bool trackChanges)
        {
            var agent = await _repository.Agent.GetAgent(id, trackChanges);
            if(agent is null)
                throw new ClientNotFoundException(id);
            _repository.Agent.DeleteAgent(agent);
            await _repository.SaveAsync();
        }

        public async Task UpdateAgentAsync(Guid id, AgentsForUpdateDto agentsForUpdate, bool trackChanges)
        {
            var agent = await _repository.Agent.GetAgent(id, trackChanges);
            if (agent is null)
                throw new ClientNotFoundException(id);
            _mapper.Map(agentsForUpdate, agent);
            await _repository.SaveAsync();
        }
    }*/
}
