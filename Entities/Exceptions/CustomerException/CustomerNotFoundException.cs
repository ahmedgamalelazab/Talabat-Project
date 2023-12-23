using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.CustomerException
{
    public sealed class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(Guid customerId) : base($"The with customer id: {customerId} doesn't exist in the database.")
        {
        }
    }
}
