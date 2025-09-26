using System.ComponentModel.DataAnnotations;

namespace Shop_API.Models.DTOs
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal price { get; set; }
    }
}
