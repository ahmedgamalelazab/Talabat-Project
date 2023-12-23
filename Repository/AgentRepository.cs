using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentions;
using Shared.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /*public class AgentRepository : RepositoryBase<Agent>, IAgentRepository
    {
        public AgentRepository(RepositoryContext context):base(context) { }

        public async Task<PagedList<Agent>> GetAllAgents(AgentParameter agentParameter, bool trackChanges)
        {
            var agents = await FindAll(trackChanges)
                .Search(agentParameter.SearchTerm)
                .Skip((agentParameter.PageNumber - 1) * agentParameter.PageSize)
                .Take(agentParameter.PageSize)
                .OrderBy(A => A.Name)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Agent>(agents, count, agentParameter.PageNumber, agentParameter.PageSize);
        }

        public async Task<Agent> GetAgent(Guid id, bool trackChanges) =>
            await FindByCondition(a => a.AgentId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void CreateAgent(Agent agent) =>  Create(agent);

        public void DeleteAgent(Agent agent) => Delete(agent);

        public void UpdateAgent(Agent agent) => Update(agent);
    }*/
}
