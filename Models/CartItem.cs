namespace AB.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string SelectedSize { get; set; }
        public string SelectedColor { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId {  get; set; }
    }

}
