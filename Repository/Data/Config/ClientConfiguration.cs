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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(p => p.ClientType).WithMany().HasForeignKey(p => p.ClientTypeId);
            builder.HasMany(p => p.Products).WithOne();
            builder.Property(c => c.Avaraible)
                .HasConversion(
                    CAvaraible => CAvaraible.ToString(), // this line i store in db
                    CAvaraible => (Avaraible)Enum.Parse(typeof(Avaraible), CAvaraible)  // this line i Retrieve avaraible from db
                );
            
            builder.HasData(
                new Client
                {
                    Id = 1,
                    Name = "AngularForLearning",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    PictureUrl = "images/clients/OIP (1).gif",
                    StartWork = "10 AM",
                    EndWork = "10 PM",
                    NoOfBranch = 2,
                    Website = "http://Angular.com",
                    PhoneNum = "01023423523",
                    MinOrder = 50,
                    Avaraible = 0,
                    ClientTypeId= 1
                },
                new Client
                {
                    Id = 2,
                    Name = "AngularForLearning",
                    Description= "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    PictureUrl = "images/clients/OIP (2).gif",
                    StartWork = "10 AM",
                    EndWork = "10 PM",
                    NoOfBranch= 2,
                    Website = "http://Angular.com",
                    PhoneNum = "01023423523",
                    MinOrder = 50,
                    Avaraible = (Avaraible)1,
                    ClientTypeId = 2
                },
                new Client
                {
                    Id = 3,
                    Name = "AngularForLearning",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    PictureUrl= "images/clients/restaurant-logo-mr-bolat.png",
                    StartWork= "10 AM",
                    EndWork = "10 PM",
                    NoOfBranch= 2,
                    Website = "http://Angular.com",
                    PhoneNum = "01023423523",
                    MinOrder= 50,
                    Avaraible = 0,
                    ClientTypeId = 3
                }
            );
        }
    }
}
