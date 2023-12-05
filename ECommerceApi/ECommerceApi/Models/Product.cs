using System.Text.Json.Serialization;

namespace ECommerceApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public bool IsTrending { get; set; }
        public bool IsBestSelling { get; set; }
        public int CategoryId { get; set; }

        [JsonIgnore]
        public ICollection<OrderDetail> OrderDetails { get; set; }
        [JsonIgnore]
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
