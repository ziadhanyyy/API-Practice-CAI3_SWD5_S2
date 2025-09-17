using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog_API.Models.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Content { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
     
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
