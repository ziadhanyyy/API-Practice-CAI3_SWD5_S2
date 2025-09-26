using System.ComponentModel.DataAnnotations;

namespace Shop_API.Models.DTOs
{
    public class CategoryDTO
    {
        [Required]
        public string Name { get; set; }
    }
}

