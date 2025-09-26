using System.ComponentModel.DataAnnotations;

namespace Shop_API.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal price { get; set; }

        //Navigation property
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
