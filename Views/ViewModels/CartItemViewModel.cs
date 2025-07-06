namespace AB.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string SelectedSize { get; set; }
        public string SelectedColor { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; } // Product price
        public double TotalPrice => Quantity * Price; // Computed property for total price
    }
}
