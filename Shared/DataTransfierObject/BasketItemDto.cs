using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransfierObject
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(0.1,double.MaxValue, ErrorMessage = "Price must be greater than zero!!")]
        public decimal Price { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Qauntity must contain one at least!!")]
        public int Quantity { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
