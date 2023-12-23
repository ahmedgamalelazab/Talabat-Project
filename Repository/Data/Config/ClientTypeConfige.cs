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
    public class ClientTypeConfige : IEntityTypeConfiguration<ClientType>
    {
        public void Configure(EntityTypeBuilder<ClientType> builder)
        {
            builder.HasData(
                new ClientType {
                    Id = 1,
                    Name = "Resturant"
                },
                new ClientType {
                    Id= 2,
                    Name = "Bakery"
                },
                new ClientType {
                    Id = 3,
                    Name = "Super Market"
                });
        }
    }
}
