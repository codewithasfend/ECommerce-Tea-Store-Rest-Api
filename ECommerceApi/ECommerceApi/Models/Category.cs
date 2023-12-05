using System.Text.Json.Serialization;

namespace ECommerceApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }  

    }
}
