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
    public class AddressConfiguration : IEntityTypeConfiguration<AddressForClient>
    {
        public void Configure(EntityTypeBuilder<AddressForClient> builder)
        {
            
            builder.HasOne(c => c.Client).WithMany().HasForeignKey(p => p.ClientId);
            builder.HasKey(a => a.Id);
            builder.HasData(
                new AddressForClient
                {
                    Id = 1,
                    Country ="Country 1",
                    City = "City 1",
                    Street = "Street 1",
                    ClientId = 1
                },
                new AddressForClient
                {
                    Id = 2,
                    Country ="Country 1",
                    City = "City 2",
                    Street = "Street 2",
                    ClientId = 1
                }, new AddressForClient
                {
                    Id = 3,
                    Country ="Country 1",
                    City = "City 3",
                    Street = "Street 3",
                    ClientId = 2
                }, new AddressForClient
                {
                    Id = 4,
                    Country ="Country 2",
                    City = "City 1",
                    Street = "Street 2",
                    ClientId = 3
                }, new AddressForClient
                {
                    Id = 5,
                    Country ="Country 1",
                    City = "City 2",
                    Street = "Street 3",
                    ClientId = 3
                }, new AddressForClient
                {
                    Id = 6,
                    Country ="Country 1",
                    City = "City 4",
                    Street = "Street 1",
                    ClientId = 2
                }, new AddressForClient
                {
                    Id = 7,
                    Country ="Country 1",
                    City = "City 4",
                    Street = "Street 4",
                    ClientId = 3
                }, new AddressForClient
                {
                    Id = 8,
                    Country ="Country 1",
                    City = "City 3",
                    Street = "Street 2",
                    ClientId = 2
                }
             ) ;
        }
    }
}
