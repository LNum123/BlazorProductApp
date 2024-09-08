using BlazorProduct.Api.Models;
using BlazorProduct.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BlazorProduct.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                return Ok(await productRepository.GetProducts());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            try
            {
               var result = await productRepository.GetProduct(id);

                if (result == null) 
                { 
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product is null.");
                }

                //var existingModel = productRepository.GetProductByModel(product.Model);

                //if (existingModel != null)
                //{
                //    return BadRequest($"Product Model '{product.Model}' has already been registered.");
                //}

                var createProduct = await productRepository.AddProduct(product);
                return CreatedAtAction(nameof(GetProduct), new { id = createProduct.Id }, createProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating product: {ex.Message}");
            }
        }




        [HttpPut()]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            try
            {
                //if (id != product.Id)
                //    return BadRequest("Product ID mismatch");

                var updateProduct = await productRepository.GetProduct(product.Id);

                if (updateProduct == null)
                {
                    return NotFound($"Product with Id = {product.Id} is not found");
                }

                return await productRepository.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error updating data \n Error: {ex.Message} ");
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<Product>> DeleteProduct(Guid id)
        {
            try
            {
                var deleteProduct = await productRepository.GetProduct(id);

                if (deleteProduct == null)
                {
                    return NotFound($"Product with Id = {id} is not found");
                }

                return await productRepository.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error deleting data  \n Error: {ex.Message}");
            }
        }


        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Product>>> Search(string name, int? quantity)
        {
            try
            {
               var result = await productRepository.Search(name, quantity);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error deleting data  \n Error: {ex.Message}");
            }
        }

    }
}
