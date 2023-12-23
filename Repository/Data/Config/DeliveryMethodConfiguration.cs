using Entities.Order_Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Config
{
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(d => d.Cost).HasColumnType("decimal(18,2)");
            builder.HasData(
                new DeliveryMethod()
                {
                    Id = 1,
                    ShortName = "UPS1",
                    Description = "Fastest delivery time",
                    DeliveryTIme = "1-2 Days",
                    Cost = 10
                },
                new DeliveryMethod()
                {
                    Id = 2,
                    ShortName="UPS2",
                    Description="Get it within 5 days",
                    DeliveryTIme="2-5 Days",
                    Cost=5
                },
                new DeliveryMethod()
                {
                    Id = 3,
                    ShortName = "UPS3",
                    Description = "Slower but cheap",
                    DeliveryTIme = "5-10 Days",
                    Cost = 2
                },
                new DeliveryMethod()
                {
                    Id = 4,
                    ShortName = "FREE",
                    Description = "Free! You get what you pay for",
                    DeliveryTIme = "1-2 Weeks",
                    Cost = 0
                }

            );

        }
    }
}
