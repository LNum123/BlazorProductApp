using BlazorProduct.Models.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace BlazorProduct.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Product Name must be provided!")]
        [MinLength(2), ]
        public string Name { get; set; }
        [Required(ErrorMessage = "Product Model must be provided!")]
        public string Model { get; set; }
        [Required]
        [ProductPartNumberValidator]
        public string PartNumber { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTimeCaptured { get; set; } = DateTime.Now;
    }
}
