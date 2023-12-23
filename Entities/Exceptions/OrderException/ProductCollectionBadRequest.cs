using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.OrderException
{
    public class ProductCollectionBadRequest : BadRequestException
    {
        public ProductCollectionBadRequest():base("product collection sent from client is null.")
        {
            
        }
    }
}
