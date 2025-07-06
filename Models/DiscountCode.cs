namespace AB.Models
{
    public class DiscountCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; } // Fixed or percentage discount
        public bool IsPercentage { get; set; } // Whether the discount is a percentage
        public bool IsActive { get; set; } // Whether the code is active
    }
}
