using Entities.Models;
using Shared.DataTransfierObject;
using Shared.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IAgentService
    {
        Task<(IEnumerable<AgentDto> agents, MetaData metaData)> GetAllAgent(AgentParameter agentParameter, bool trackChages);
        Task<AgentDto> GetAgentAsync(Guid agentId, bool trackChages);
        Task<AgentDto> CreateAgentAsync(AgentForCreatingDto agent);
        Task DeleteAgentAsync(Guid id, bool trackChanges);
        Task UpdateAgentAsync(Guid id, AgentsForUpdateDto agentsForUpdate, bool trackChanges);
    }
}
