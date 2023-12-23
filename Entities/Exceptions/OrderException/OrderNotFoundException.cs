using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.OrderException
{
    public sealed class OrderNotFoundException  : Exception
    {
        public OrderNotFoundException(Guid orderId): 
            base($"The orderId with id: {orderId} doesn't exist in the database.")
        { }
    }
}
