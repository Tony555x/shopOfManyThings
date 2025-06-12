using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopOfManyThings.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Toasters", "Heavy-duty toaster for industrial kitchens", "Industrial Toaster", 250m },
                    { 2, "Construction", "A full pallet of red clay bricks", "Brick Pallet", 1500m },
                    { 3, "Construction", "Gas-powered chainsaw, 20-inch blade", "Chainsaw", 600m },
                    { 4, "Construction", "Load-bearing I-beams, 6m length", "Steel Beams", 3000m },
                    { 5, "Construction", "Portable concrete mixer, 150L capacity", "Concrete Mixer", 1200m },
                    { 6, "Countries", "Official flag, 90x150 cm", "Flag of Nauru", 35m },
                    { 7, "Countries", "Hypothetical offer. Buyer assumes all risks.", "Sovereignty of Liechtenstein", 750000000m },
                    { 8, "Construction", "Unauthorized black-market energy solution", "Portable Nuclear Generator", 1000000m },
                    { 9, "Construction", "25kg cement mix bag", "Bag of Cement", 10m },
                    { 10, "Toasters", "Half-melted chrome toaster, maybe works", "Toaster (Used)", 15m }
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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
