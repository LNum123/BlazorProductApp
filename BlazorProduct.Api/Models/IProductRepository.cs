using BlazorProduct.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlazorProduct.Api.Models
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Search(string name, int? quantity);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(Guid productId);

        Task<Product> GetProductByModel(string Model);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(Guid productId);
    }
}
