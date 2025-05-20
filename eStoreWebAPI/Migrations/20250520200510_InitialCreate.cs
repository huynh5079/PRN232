using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace eStoreWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" },
                    { 3, "Clothing" },
                    { 4, "Groceries" },
                    { 5, "Toys" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductName", "UnitPrice", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, 2, "Sample Product 1", 11.99m, 101 },
                    { 2, 3, "Sample Product 2", 12.99m, 102 },
                    { 3, 4, "Sample Product 3", 13.99m, 103 },
                    { 4, 5, "Sample Product 4", 14.99m, 104 },
                    { 5, 1, "Sample Product 5", 15.99m, 105 },
                    { 6, 2, "Sample Product 6", 16.99m, 106 },
                    { 7, 3, "Sample Product 7", 17.99m, 107 },
                    { 8, 4, "Sample Product 8", 18.99m, 108 },
                    { 9, 5, "Sample Product 9", 19.99m, 109 },
                    { 10, 1, "Sample Product 10", 20.99m, 110 },
                    { 11, 2, "Sample Product 11", 21.99m, 111 },
                    { 12, 3, "Sample Product 12", 22.99m, 112 },
                    { 13, 4, "Sample Product 13", 23.99m, 113 },
                    { 14, 5, "Sample Product 14", 24.99m, 114 },
                    { 15, 1, "Sample Product 15", 25.99m, 115 },
                    { 16, 2, "Sample Product 16", 26.99m, 116 },
                    { 17, 3, "Sample Product 17", 27.99m, 117 },
                    { 18, 4, "Sample Product 18", 28.99m, 118 },
                    { 19, 5, "Sample Product 19", 29.99m, 119 },
                    { 20, 1, "Sample Product 20", 30.99m, 120 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
