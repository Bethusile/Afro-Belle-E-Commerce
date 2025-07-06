using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AB.Data.Migrations
{
    /// <inheritdoc />
    public partial class prodQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Products",
                newName: "prodQuantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "prodQuantity",
                table: "Products",
                newName: "Quantity");
        }
    }
}
