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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(o => o.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.OwnsOne(o => o.ShappingAddress, NP => NP.WithOwner());
            builder.Property(o => o.OrderStatus).HasConversion(
                OStatus => OStatus.ToString(),
                OStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), OStatus)
                );
            //save in databeas as streing and retrev as (integer)=> enum 
            builder.Property(o => o.SubTotal).HasColumnName("decimal(18,2)");

        }
    }
}
