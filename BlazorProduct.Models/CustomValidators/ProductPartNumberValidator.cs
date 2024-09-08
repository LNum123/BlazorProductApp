using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorProduct.Models.CustomValidators
{
    public class ProductPartNumberValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("Product Part Number is required.");
            }

            string partNumber = value.ToString();

            // Check if the total length exceeds 50 characters
            if (partNumber.Length > 50)
            {
                return new ValidationResult("Product Part Number should not exceed 50 characters.");
            }

            // Split the part number by hyphens
            string[] parts = partNumber.Split('-');

            // Ensure the format has at least two segments
            if (parts.Length < 2)
            {
                return new ValidationResult("Product Part Number should consist of multiple segments separated by hyphens (e.g., 'GM-200-897').");
            }

            // Validate each part for alphanumeric content and non-empty segments
            foreach (string part in parts)
            {
                if (string.IsNullOrWhiteSpace(part) || !part.All(char.IsLetterOrDigit))
                {
                    return new ValidationResult("Each segment of the Product Part Number should be alphanumeric and not empty.");
                }
            }

            return ValidationResult.Success;
        }
    }
}