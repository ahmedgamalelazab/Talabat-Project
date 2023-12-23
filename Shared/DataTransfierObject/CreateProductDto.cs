using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransfierObject
{
    public sealed record CreateProductDto
    {
        [Required(ErrorMessage = "Product name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
        public string? Name { get; init; }
        [Required(ErrorMessage = "Client description is a required field.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Name is 150 characters.")]
        public string? Description { get; init; }
        [Required(ErrorMessage = "Client picture is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
        public string? PictureUrl { get; init; }
        [Range(double.MinValue, double.MaxValue)]
        public decimal Price { get; init; }
        [Range(double.MinValue, 100)]
        public decimal DisCountPrice { get; init; }
    }
}
