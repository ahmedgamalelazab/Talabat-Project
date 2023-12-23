using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransfierObject
{
    public record ProductDto (int Id, string Name, string Description, string PictureUrl, decimal Price, int ProductBrandId, string ProductBrand, int ProductTypeId, string ProductType, int ClientId);
        
}
