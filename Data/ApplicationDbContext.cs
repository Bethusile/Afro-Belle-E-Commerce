using AB.Models;
using Microsoft.EntityFrameworkCore;

namespace AB.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShippingOption> ShippingOptions { get; set; } // Add ShippingOptions
        public DbSet<DiscountCode> DiscountCodes { get; set; }     // Add DiscountCodes
        public DbSet<BankDetails> BankDetails { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for ShippingOptions
            modelBuilder.Entity<ShippingOption>().HasData(
                new ShippingOption { Id = 1, Name = "Standard Shipping", Cost = 50, FreeShippingThreshold=1000, AvailableRegions="PE" },
                new ShippingOption { Id = 2, Name = "Express Shipping", Cost = 100, FreeShippingThreshold = 1000, AvailableRegions = "PE" },
                new ShippingOption { Id = 3, Name = "Free Pickup", Cost = 0, FreeShippingThreshold = 1000, AvailableRegions = "PE" }
            );

            // Seed data for DiscountCodes (example)
            modelBuilder.Entity<DiscountCode>().HasData(
                new DiscountCode { Id = 1, Code = "WELCOME10", DiscountAmount = 10, IsPercentage = false, IsActive = true },
                new DiscountCode { Id = 2, Code = "FREESHIP", DiscountAmount = 0, IsPercentage = true, IsActive = true }
            );
            // Seed fake bank details
            modelBuilder.Entity<BankDetails>().HasData(new BankDetails
            {
                Id = 1,
                BankName = "FakeBank SA",
                AccountName = "John Doe",
                AccountType = "Savings",
                AccountNumber = "123456789",
                BranchCode = "250655",
                ReferenceInstructions = "Use your order ID as the payment reference."
            });
        }
    }
}
