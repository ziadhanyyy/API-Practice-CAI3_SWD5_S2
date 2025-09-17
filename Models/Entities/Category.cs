using System.ComponentModel.DataAnnotations;

namespace Blog_API.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
