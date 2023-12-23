
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions.ProductException
{
    public sealed class ProductNotFoundException: NotFoundException
    {
        public ProductNotFoundException(int productId) : 
            base($"The productId with id: {productId} doesn't exist in the database.") { }
    }
}
