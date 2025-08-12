using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "ImageUrl", "Sizes" },
                values: new object[] { "Bonnets", "~/images/bonnet-pink.jpeg", "S,M,L" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "ImageUrl", "Sizes" },
                values: new object[] { "Bonnets", "~/images/elastic-champ.jpeg", "S,M,L" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "ImageUrl", "Sizes" },
                values: new object[] { "Bonnets", "~/images/bonnet-red.jpeg", "S,M,L" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Sizes" },
                values: new object[] { "~/images/scrunchie-pink.jpeg", "M,L,XL" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Sizes" },
                values: new object[] { "~/images/scrunchie-white.jpeg", "S,M,L" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Sizes" },
                values: new object[] { "~/images/scrunchie-red.jpeg", "M,L,XL" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageUrl", "Sizes" },
                values: new object[] { "~/images/pillowcase.jpeg", "Standard,Queen,King" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageUrl", "Sizes" },
                values: new object[] { "~/images/pillowcase.jpeg", "Standard,Queen,King" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageUrl", "Sizes" },
                values: new object[] { "~/images/pillowcase.jpeg", "Standard,Queen,King" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "ImageUrl", "Sizes" },
                values: new object[] { "Satin Bonnets", "/images/bonnet-pink.jpeg", "Medium,Large" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "ImageUrl", "Sizes" },
                values: new object[] { "Satin Bonnets", "/images/elastic-champ.jpeg", "Small,Medium" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "ImageUrl", "Sizes" },
                values: new object[] { "Satin Bonnets", "/images/bonnet-red.jpeg", "Large" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Sizes" },
                values: new object[] { "/images/scrunchie-pink.jpeg", "One Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Sizes" },
                values: new object[] { "/images/scrunchie-white.jpeg", "One Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Sizes" },
                values: new object[] { "/images/scrunchie-red.jpeg", "One Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageUrl", "Sizes" },
                values: new object[] { "/images/pillowcase.jpeg", "Standard,King" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageUrl", "Sizes" },
                values: new object[] { "/images/pillowcase.jpeg", "Standard" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageUrl", "Sizes" },
                values: new object[] { "/images/pillowcase.jpeg", "Standard,Queen" });
        }
    }
}
