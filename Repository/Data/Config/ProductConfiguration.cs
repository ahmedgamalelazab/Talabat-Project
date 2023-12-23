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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(p => p.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(p => p.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
            builder.HasOne(p => p.Client).WithMany().OnDelete(DeleteBehavior.Cascade).HasForeignKey(p => p.ClientId);


            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name= "Angular Speedster Board 2000",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 200,
                    PictureUrl = "images/products/sb-ang1.png",
                    ProductTypeId = 1,
                    ProductBrandId = 1,
                    ClientId = 2
                },
                new Product
                {
                    Id = 2,
                    Name = "Green Angular Board 3000",
                    Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                    Price = 150,
                    PictureUrl = "images/products/sb-ang2.png",
                    ProductTypeId = 1,
                    ProductBrandId = 1,
                    ClientId = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Core Board Speed Rush 3",
                    Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 180,
                    PictureUrl = "images/products/sb-core1.png",
                    ProductTypeId = 1,
                    ProductBrandId = 2,
                    ClientId = 1
                },
                new Product
                {
                    Id = 4,
                    Name = "Net Core Super Board",
                    Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 300,
                    PictureUrl = "images/products/sb-core2.png",
                    ProductTypeId = 1,
                    ProductBrandId = 2,
                    ClientId = 2
                },
                new Product
                {
                    Id = 5,
                    Name = "React Board Super Whizzy Fast",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 250,
                    PictureUrl = "images/products/sb-react1.png",
                    ProductTypeId = 1,
                    ProductBrandId = 4,
                    ClientId = 1
                },
                new Product
                {
                    Id = 6,
                    Name = "Typescript Entry Board",
                    Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                    Price = 120,
                    PictureUrl = "images/products/sb-ts1.png",
                    ProductTypeId = 1,
                    ProductBrandId = 5,
                    ClientId = 3
                },
                new Product
                {
                    Id = 7,
                    Name = "Core Blue Hat",
                    Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 10,
                    PictureUrl = "images/products/hat-core1.png",
                    ProductTypeId = 2,
                    ProductBrandId = 2,
                    ClientId = 3
                },
                new Product
                {
                    Id = 8,
                    Name = "Green React Woolen Hat",
                    Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 8,
                    PictureUrl = "images/products/hat-react1.png",
                    ProductTypeId = 2,
                    ProductBrandId = 4,
                    ClientId = 2
                },
                new Product 
                {
                    Id = 9,
                    Name = "Purple React Woolen Hat",
                    Description = "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 15,
                    PictureUrl = "images/products/hat-react2.png",
                    ProductTypeId = 2,
                    ProductBrandId = 4,
                    ClientId = 3
                },
                new Product
                {
                    Id = 10,
                    Name = "Blue Code Gloves",
                    Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                    Price = 18,
                    PictureUrl = "images/products/glove-code1.png",
                    ProductTypeId = 4,
                    ProductBrandId = 3,
                    ClientId = 1
                },
                new Product
                {
                    Id = 11,
                    Name = "Green Code Gloves",
                    Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 15,
                    PictureUrl = "images/products/glove-code2.png",
                    ProductTypeId = 4,
                    ProductBrandId = 3,
                    ClientId = 2
                },
                new Product
                {
                    Id = 12,  
                    Name = "Purple React Gloves",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa.",
                    Price = 16,
                    PictureUrl = "images/products/glove-react1.png",
                    ProductTypeId = 4,
                    ProductBrandId = 4,
                    ClientId = 3
                },
                new Product
                {
                    Id = 13,
                    Name = "Green React Gloves",
                    Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 14,
                    PictureUrl = "images/products/glove-react2.png",
                    ProductTypeId = 4,
                    ProductBrandId = 4,
                    ClientId = 3
                },
                new Product
                {
                    Id = 14,
                    Name = "Redis Red Boots",
                    Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 250,
                    PictureUrl = "images/products/boot-redis1.png",
                    ProductTypeId = 3,
                    ProductBrandId  = 6,
                    ClientId = 1
                },
                new Product
                {
                    Id = 15,
                    Name = "Core Red Boots",
                    Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 189.99m,
                    PictureUrl = "images/products/boot-core2.png",
                    ProductTypeId = 3,
                    ProductBrandId = 2,
                    ClientId = 1
                },
                new Product
                {
                    Id = 16,
                    Name = "Core Purple Boots",
                    Description = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 199.99m,
                    PictureUrl = "images/products/boot-core1.png",
                    ProductTypeId = 3,
                    ProductBrandId = 2,
                    ClientId = 3
                },
                new Product
                {
                    Id = 17,
                    Name = "Angular Purple Boots",
                    Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                    Price = 150,
                    PictureUrl = "images/products/boot-ang2.png",
                    ProductTypeId = 3,
                    ProductBrandId = 1,
                    ClientId = 2
                },
                new Product
                {
                    Id = 18,
                    Name = "Angular Blue Boots",
                    Description = "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 180,
                    PictureUrl = "images/products/boot-ang1.png",
                    ProductTypeId = 3,
                    ProductBrandId = 1,
                    ClientId = 2
                }
            );
        }   
    }
}
