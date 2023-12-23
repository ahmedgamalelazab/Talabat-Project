using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Config
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasData(
                new ProductType
                {
                    Id = 1,
                    Name = "Boards"
                },
                new ProductType
                {
                    Id = 2,
                    Name = "Hats"
                },
                new ProductType
                {
                    Id = 3,
                    Name = "Boots"
                }, 
                new ProductType
                {
                    Id = 4,
                    Name = "Gloves"
                }

            );
        }
    }
}
