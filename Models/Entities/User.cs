using System.ComponentModel.DataAnnotations;

namespace Shop_API.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string HashedPassword { get; set; }
    }
}
