using AB.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AB.ViewModels
{
    public class CheckoutViewModel : Order
    {
        public string PaypalClientID { get; set; } = "";
        private string PaypalSecret { get; set; } = "";
        public string PaypalUrl { get; set; } = "";
        public CheckoutViewModel(IConfiguration configuration)
        {
            PaypalClientID = configuration["PaypalSettings:ClientID"]!;
            PaypalSecret = configuration["PaypalSettings:Secret"]!;
            PaypalUrl=configuration["PaypalSettings:Url"]!;

        }
        public void OnGet()
        {

        }
        public CheckoutViewModel() { }
        
        // Cart and total amount
        public List<CartItem> CartItems { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "(R) Total Amount ")]
        public decimal TotalAmount { get; set; }

        // Shipping options and selected shipping
        [Display(Name = "Shipping Options")]
        public List<ShippingOption> ShippingOptions { get; set; }

        [Required(ErrorMessage = "Please select a shipping option.")]
        public int SelectedShippingOptionId { get; set; } // Previously ShippingOptionId

        public decimal ShippingFee { get; set; } // Previously ShippingFee

        // Discount code
        [Display(Name = "Discount Code")]
        public string DiscountCode { get; set; }

        public decimal DiscountAmount { get; set; } // Previously DiscountAmount

        // Customer details
        [Required(ErrorMessage = "Please enter your full name.")]
        [Display(Name = "Full Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter your email address.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        // Address fields
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; } // Optional

        [Required(ErrorMessage = "Please provide a village or suburb.")]
        [Display(Name = "Village/Suburb")]
        public string VillageOrSuburb { get; set; }

        [Required(ErrorMessage = "Please provide a city.")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please provide an area code.")]
        [Display(Name = "Area Code")]
        public string AreaCode { get; set; }

        // Special instructions
        [Display(Name = "Special Instructions")]
        public string SpecialInstructions { get; set; }

        public string PaymentMethod { get; set; } // "DirectDeposit" or "PayFast"
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public string ReferenceInstructions { get; set; }


        // Optional combined address
        [Display(Name = "Full Address")]
        public string Address
        {
            get
            {
                return $"{StreetAddress}, {VillageOrSuburb}, {City}, {AreaCode}";
            }
        }

    }
}
