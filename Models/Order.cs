namespace AB.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } // Customer's full name
        public string Email { get; set; } // Customer's email
        public string Phone { get; set; } // Customer's phone number

        // Address Fields
        public string StreetAddress { get; set; } // Optional field
        public string VillageOrSuburb { get; set; } // Required field
        public string City { get; set; } // Required field
        public string AreaCode { get; set; } // Required field

        // Special Instructions
        public string SpecialInstructions { get; set; } // Optional field for additional details

        public decimal TotalAmount { get; set; } // Final total amount after shipping and discount
        public int ShippingOptionId { get; set; } // Selected shipping option
        public decimal ShippingFee { get; set; } // Shipping fee applied
        public string DiscountCode { get; set; } // Applied discount code
        public decimal DiscountAmount { get; set; } // Total discount amount applied
        public DateTime OrderDate { get; set; } // Date of order

        // Add these properties
        public string Status { get; set; } // e.g., Pending, Completed, Failed
        public string TransactionId { get; set; } // Payment gateway transaction ID
        public string PaymentMethod { get; set; } // DirectDeposit or PayFast
    }
}
