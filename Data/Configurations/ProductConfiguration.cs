using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOfManyThings.Data.Models;

namespace ShopOfManyThings.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Industrial Toaster", Price = 250, Category = "Toasters", Description = "Heavy-duty toaster for industrial kitchens" },
                new Product { Id = 2, Name = "Brick Pallet", Price = 1500, Category = "Construction", Description = "A full pallet of red clay bricks" },
                new Product { Id = 3, Name = "Chainsaw", Price = 600, Category = "Construction", Description = "Gas-powered chainsaw, 20-inch blade" },
                new Product { Id = 4, Name = "Steel Beams", Price = 3000, Category = "Construction", Description = "Load-bearing I-beams, 6m length" },
                new Product { Id = 5, Name = "Concrete Mixer", Price = 1200, Category = "Construction", Description = "Portable concrete mixer, 150L capacity" },
                new Product { Id = 6, Name = "Flag of Nauru", Price = 35, Category = "Countries", Description = "Official flag, 90x150 cm" },
                new Product { Id = 7, Name = "Sovereignty of Liechtenstein", Price = 750000000, Category = "Countries", Description = "Hypothetical offer. Buyer assumes all risks." },
                new Product { Id = 8, Name = "Portable Nuclear Generator", Price = 1000000, Category = "Construction", Description = "Unauthorized black-market energy solution" },
                new Product { Id = 9, Name = "Bag of Cement", Price = 10, Category = "Construction", Description = "25kg cement mix bag" },
                new Product { Id = 10, Name = "Toaster (Used)", Price = 15, Category = "Toasters", Description = "Half-melted chrome toaster, maybe works" }
            );
        }
    }
}
