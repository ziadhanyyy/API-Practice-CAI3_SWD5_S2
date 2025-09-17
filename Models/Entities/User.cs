using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Blog_API.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "UserName Is Required")]
        public string UserName { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment>Comments { get; set; } = new List<Comment>();
    }
}
