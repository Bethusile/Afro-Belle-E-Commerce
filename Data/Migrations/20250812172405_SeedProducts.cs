using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AB.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Colors", "Description", "ImageUrl", "Name", "Price", "Sizes", "prodQuantity" },
                values: new object[,]
                {
                    { 1, "Satin Bonnets", "Black, White, Pink, Teal, Navy", "non-elastic", "/images/bonnet-pink.jpeg", "Satin Bonnet", 200.00m, "Medium,Large", 50 },
                    { 2, "Satin Bonnets", "Pink, Blue, Grey, Black, White, Pink", "elastic", "/images/elastic-champ.jpeg", "Satin Bonnet", 150.00m, "Small,Medium", 35 },
                    { 3, "Satin Bonnets", "Teal, Navy", "non-elastic", "/images/bonnet-red.jpeg", "Satin Bonnet", 200.00m, "Large", 3 },
                    { 4, "Scrunchies", "Gold,Rose,Silver, White, Blue,Pink,Purple", "oversized", "/images/scrunchie-pink.jpeg", "Satin Scrunchie", 50.00m, "One Size", 6 },
                    { 5, "Scrunchies", "Gold,Rose,Silver, White, Blue,Pink,Purple", "one-size", "/images/scrunchie-white.jpeg", "Satin Scrunchie", 50.00m, "One Size", 75 },
                    { 6, "Scrunchies", "Gold,Rose,Silver, White, Blue,Pink,Purple", "fun size", "/images/scrunchie-red.jpeg", "Satin Scrunchie", 50.00m, "One Size", 90 },
                    { 7, "Pillowcases", "White", "standard", "/images/pillowcase.jpeg", "Satin Pillowcase", 150.00m, "Standard,King", 40 },
                    { 8, "Pillowcases", "Champagne", "queen", "/images/pillowcase.jpeg", "Satin Pillowcase", 150.00m, "Standard", 30 },
                    { 9, "Pillowcases", "Black", "king", "/images/pillowcase.jpeg", "Satin Pillowcase", 150.00m, "Standard,Queen", 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
