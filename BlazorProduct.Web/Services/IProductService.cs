using BlazorProduct.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProduct.Web.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(Guid id);
        Task<Product> UpdateProduct(Product updateProduct);
        Task<Product> CreateProduct(Product addProduct);
        Task DeleteProduct(Guid id);
    }
}
