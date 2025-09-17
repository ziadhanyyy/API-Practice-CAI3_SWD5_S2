using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_API.Models.Entities
{
    public class Comment
    {
        [Key] public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Text { get; set; }
        [ForeignKey("User")]
         public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post{ get; set; }

    }
}
