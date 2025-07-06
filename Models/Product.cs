
namespace AB.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Sizes { get; set; } // e.g., "Small,Medium,Large"
        public string Colors { get; set; } // e.g., "Red,Blue,Green"
        public string Category { get; set; } // e.g., "Satin Bonnets"
        public int prodQuantity { get; set; }
    }

}