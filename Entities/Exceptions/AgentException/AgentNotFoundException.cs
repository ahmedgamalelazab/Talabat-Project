using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.AgentException
{
    public class AgentNotFoundException : NotFoundException
    {
        public AgentNotFoundException(Guid agentId) : base($"The Agent with id: {agentId} doesn't exist in the database.")
        {
        }
    }
}
