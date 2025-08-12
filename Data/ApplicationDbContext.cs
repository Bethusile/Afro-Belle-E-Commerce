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
                AccountName = "Sazi",
                AccountType = "Savings",
                AccountNumber = "123456789",
                BranchCode = "250655",
                ReferenceInstructions = "Use your order ID as the payment reference."
            });

            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                // Satin Bonnets
                new Product { Id = 2, Name = "Bonnet", Description = "elastic", ImageUrl = "elastic-champ.jpeg", Price = 150.00m, Sizes = "S,M,L", Colors = "Pink, Blue, Grey, Black, White, Pink", Category = "Bonnets", prodQuantity = 35 },

                // Scrunchies
                new Product { Id = 4, Name = "Scrunchie", Description = "oversized", ImageUrl = "scrunchie-pink.jpeg", Price = 50.00m, Sizes = "M,L,XL", Colors = "Gold,Rose,Silver, White, Blue,Pink,Purple", Category = "Scrunchies", prodQuantity = 6 },
                new Product { Id = 6, Name = "Scrunchie", Description = "fun size", ImageUrl = "scrunchie-red.jpeg", Price = 50.00m, Sizes = "M,L,XL", Colors = "Gold,Rose,Silver, White, Blue,Pink,Purple", Category = "Scrunchies", prodQuantity = 90 },

                // Pillowcases
                new Product { Id = 7, Name = "Pillowcase Set", Description = "standard", ImageUrl = "pillowcase.jpeg", Price = 150.00m, Sizes = "Standard,Queen,King", Colors = "White,Champagne,Black", Category = "Pillowcases", prodQuantity = 40 },
                new Product { Id = 8, Name = "Pillowcase Set", Description = "queen", ImageUrl = "pillowcase.jpeg", Price = 150.00m, Sizes = "Standard,Queen,King", Colors = "White,Champagne,Black", Category = "Pillowcases", prodQuantity = 0 },
                new Product { Id = 9, Name = "Pillowcase Set", Description = "king", ImageUrl = "pillowcase.jpeg", Price = 150.00m, Sizes = "Standard,Queen,King", Colors = "White,Champagne,Black", Category = "Pillowcases", prodQuantity = 15 },

                //New Arrivals
                new Product { Id = 10, Name = "Bonnet", Description = "non-elastic", ImageUrl = "bonnet-pink.jpeg", Price = 200.00m, Sizes = "S,M,L", Colors = "Black, White, Pink, Teal, Navy", Category = "Bonnets", prodQuantity = 50 },
                new Product { Id = 11, Name = "Scrunchie", Description = "one-size", ImageUrl = "scrunchie-white.jpeg", Price = 50.00m, Sizes = "S,M,L", Colors = "Gold,Rose,Silver, White, Blue,Pink,Purple", Category = "Scrunchies", prodQuantity = 75 },
                new Product { Id = 3, Name = "Bonnet", Description = "non-elastic", ImageUrl = "bonnet-red.jpeg", Price = 200.00m, Sizes = "S,M,L", Colors = "Teal, Navy", Category = "Bonnets", prodQuantity = 3 }

            );
        }
    }
}
