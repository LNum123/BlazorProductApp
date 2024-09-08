using BlazorProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorProduct.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
             
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed product table
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "Wireless Mouse",
                Model = "MX1000",
                PartNumber = "WMX1000-123",
                Quantity = 50,
                Price = 29.99M,
                DateTimeCaptured = DateTime.UtcNow,
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "Mechanical Keyboard",
                Model = "MK450",
                PartNumber = "MK450-456",
                Quantity = 30,
                Price = 89.99M,
                DateTimeCaptured = DateTime.UtcNow,
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "Gaming Headset",
                Model = "GH200",
                PartNumber = "GH200-789",
                Quantity = 25,
                Price = 59.99M,
                DateTimeCaptured = DateTime.UtcNow,
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "4K Monitor",
                Model = "UHD27",
                PartNumber = "UHD27-101",
                Quantity = 10,
                Price = 299.99M,
                DateTimeCaptured = DateTime.UtcNow,
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "External Hard Drive",
                Model = "XH1TB",
                PartNumber = "XH1TB-102",
                Quantity = 75,
                Price = 59.99M,
                DateTimeCaptured = DateTime.UtcNow,
            });
        }
    }


}
