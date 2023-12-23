using Entities.Models;
using Shared.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAgentRepository
    {
        Task<PagedList<Agent>> GetAllAgents(AgentParameter agentParameter, bool trackChanges);
        Task<Agent> GetAgent(Guid id, bool trackChanges);
        void CreateAgent(Agent agent);
        void DeleteAgent(Agent agent);
        void UpdateAgent(Agent agent);
    }
}
