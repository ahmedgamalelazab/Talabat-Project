using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransfierObject;
using Shared.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.ActionFilters;

namespace Talabat.Presentation.Controllers
{
    /*
    [Route("api/agents")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AgentController(IServiceManager service) => _service=service;
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAgents([FromQuery] AgentParameter agentParameter)
        {
            var pagedResult = await _service.Agent.GetAllAgent(agentParameter, trackChages: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult);
        }

        [HttpGet("{agentId:guid}", Name = "getAgent")]
        public async Task<IActionResult> GetAgentAsync (Guid agentId)
        {
            var agent = _service.Agent.GetAgentAsync(agentId, trackChages: false);
            return Ok(agent);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateAgent([FromBody] AgentForCreatingDto agentForCreating)
        {
            var agent = await _service.Agent.CreateAgentAsync(agentForCreating);
            return CreatedAtRoute("getAgent", new { agentId = agent.AgentId }, agent);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAgent(Guid id)
        {
            await _service.Agent.DeleteAgentAsync(id, trackChanges: false);
            return NoContent();
        }


        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAgent(Guid id,[FromBody] AgentsForUpdateDto updateDto)
        {
            
            await _service.Agent.UpdateAgentAsync(id, updateDto, trackChanges: false);
            return NoContent();
        }
    }   */
}
