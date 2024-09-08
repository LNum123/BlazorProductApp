using BlazorProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorProduct.Api.Models
{
    public class ProductRespository : IProductRepository
    {
        private readonly AppDbContext appDbContext;

        public ProductRespository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var result = await appDbContext.Products.AddAsync(product);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Product> DeleteProduct(Guid productId)
        {
            var result = await appDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if(result != null)
            {
                appDbContext.Products.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }


        public async Task<Product> GetProduct(Guid productId)
        {
            return await appDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<Product> GetProductByModel(string Model)
        {
            return await appDbContext.Products
                .FirstOrDefaultAsync(p => p.Model == Model);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await appDbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> Search(string name, int? quantity)
        {
            IQueryable<Product> query = appDbContext.Products;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            if(quantity != null)
            {
                query = query.Where(p => p.Quantity == quantity);
            }

            return await query.ToListAsync();
        }


        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await appDbContext.Products
                .FirstOrDefaultAsync(p => product.Id == p.Id);

            if (result != null)
            {
                result.Name = product.Name;
                result.PartNumber = product.PartNumber;
                result.Price = product.Price;
                result.Quantity = product.Quantity;
                result.DateTimeCaptured = product.DateTimeCaptured;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
