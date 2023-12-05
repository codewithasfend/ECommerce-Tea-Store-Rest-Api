using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        public ICollection<Order> Orders { get; set; }  
    }
}
