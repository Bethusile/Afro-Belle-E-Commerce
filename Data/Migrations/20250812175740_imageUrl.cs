using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AB.Data.Migrations
{
    /// <inheritdoc />
    public partial class imageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BankDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountName",
                value: "Sazi");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/images/bonnet-pink.jpeg", "Bonnet" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/images/elastic-champ.jpeg", "Bonnet" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/images/bonnet-red.jpeg", "Bonnet" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/images/scrunchie-pink.jpeg", "Scrunchie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/images/scrunchie-white.jpeg", "Scrunchie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "/images/scrunchie-red.jpeg", "Scrunchie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Colors", "ImageUrl", "Name" },
                values: new object[] { "White,Champagne,Black", "/images/pillowcase.jpeg", "Pillowcase Set" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Colors", "ImageUrl", "Name" },
                values: new object[] { "White,Champagne,Black", "/images/pillowcase.jpeg", "Pillowcase Set" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Colors", "ImageUrl", "Name", "prodQuantity" },
                values: new object[] { "White,Champagne,Black", "/images/pillowcase.jpeg", "Pillowcase Set", 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Colors", "Description", "ImageUrl", "Name", "Price", "Sizes", "prodQuantity" },
                values: new object[,]
                {
                    { 10, "Bonnets", "Black, White, Pink, Teal, Navy", "non-elastic", "/images/bonnet-pink.jpeg", "Bonnet", 200.00m, "S,M,L", 50 },
                    { 11, "Scrunchies", "Gold,Rose,Silver, White, Blue,Pink,Purple", "one-size", "/images/scrunchie-white.jpeg", "Scrunchie", 50.00m, "S,M,L", 75 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "BankDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountName",
                value: "John Doe");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "~/images/bonnet-pink.jpeg", "Satin Bonnet" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "~/images/elastic-champ.jpeg", "Satin Bonnet" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "~/images/bonnet-red.jpeg", "Satin Bonnet" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "~/images/scrunchie-pink.jpeg", "Satin Scrunchie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "~/images/scrunchie-white.jpeg", "Satin Scrunchie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "~/images/scrunchie-red.jpeg", "Satin Scrunchie" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Colors", "ImageUrl", "Name" },
                values: new object[] { "White", "~/images/pillowcase.jpeg", "Satin Pillowcase" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Colors", "ImageUrl", "Name" },
                values: new object[] { "Champagne", "~/images/pillowcase.jpeg", "Satin Pillowcase" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Colors", "ImageUrl", "Name", "prodQuantity" },
                values: new object[] { "Black", "~/images/pillowcase.jpeg", "Satin Pillowcase", 25 });
        }
    }
}
