using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Client_WithTypeSpecification : BaseSpecification<Client>
    {
        public Client_WithTypeSpecification()
        {
            Includes.Add(c => c.ClientType);
        }
        public Client_WithTypeSpecification(int id):base(c => c.Id == id)
        {
            Includes.Add(c => c.ClientType);
        }
    }
}
