using BlazorProduct.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System;

namespace BlazorProduct.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Product> CreateProduct(Product addProduct)
        {
            var response = await httpClient.PostAsJsonAsync("api/Products", addProduct);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Product>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error creating product. Status: {response.StatusCode}, Details: {errorContent}");
            }
        }

        public async Task DeleteProduct(Guid id)
        {
            await httpClient.DeleteAsync($"api/Products/{id}");
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await httpClient.GetFromJsonAsync<Product>($"api/Products/{id}");
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await httpClient.GetFromJsonAsync<Product[]>("api/Products");
        }

        public async Task<Product> UpdateProduct(Product updateProduct)
        {
            var response = await httpClient.PutAsJsonAsync("api/Products", updateProduct);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Product>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error updating product. Status: {response.StatusCode}, Details: {errorContent}");
            }
        }

    }
}
