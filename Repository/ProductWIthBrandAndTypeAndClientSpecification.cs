using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductWithBrandAndTypeAndClientSpecification : BaseSpecification<Product>
    {
        public ProductWithBrandAndTypeAndClientSpecification()
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }
        public ProductWithBrandAndTypeAndClientSpecification(int id):base(p => p.Id == id)
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }
    }
}
