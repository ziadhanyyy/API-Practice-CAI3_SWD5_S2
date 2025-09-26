using System.ComponentModel.DataAnnotations;

namespace Shop_API.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //Navigation property
        public ICollection<Product> Products { get; set; }=new List<Product>();


    }
}
