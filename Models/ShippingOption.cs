namespace AB.Models
{
    public class ShippingOption
    {
        public int Id { get; set; }
        public string Name { get; set; } // e.g., "Standard Shipping", "Express Shipping", "Pickup"
        public decimal Cost { get; set; } // Shipping cost
        public bool IsFreeThresholdEnabled { get; set; } // If true, check for free shipping eligibility
        public decimal FreeShippingThreshold { get; set; } // Amount above which shipping is free
        public string AvailableRegions { get; set; } // Comma-separated regions where this option applies
    }
}
