using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIExamplePRN232.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "StudentAddress", "StudentID1", "StudentName" },
                values: new object[,]
                {
                    { 1, "123 Main St", null, "John Doe" },
                    { 2, "456 Oak Ave", null, "Jane Smith" },
                    { 3, "789 Elm Dr", null, "Michael Brown" },
                    { 4, "321 Birch Ln", null, "Emily Johnson" },
                    { 5, "654 Pine Rd", null, "David Lee" },
                    { 6, "987 Maple St", null, "Sarah Wilson" },
                    { 7, "741 Cedar Blvd", null, "Robert Martinez" },
                    { 8, "852 Ash St", null, "Laura White" },
                    { 9, "159 Spruce Ave", null, "Kevin Harris" },
                    { 10, "753 Redwood Blvd", null, "Sophia Clark" },
                    { 11, "264 Chestnut Ct", null, "Daniel King" },
                    { 12, "978 Acacia Rd", null, "Olivia Lewis" },
                    { 13, "183 Magnolia Ln", null, "James Hall" },
                    { 14, "365 Willow St", null, "Mia Allen" },
                    { 15, "572 Poplar Rd", null, "William Young" },
                    { 16, "492 Cypress Blvd", null, "Emma Turner" },
                    { 17, "611 Cherry St", null, "Henry Scott" },
                    { 18, "284 Fir Ave", null, "Alice Adams" },
                    { 19, "705 Juniper Ct", null, "Benjamin Carter" },
                    { 20, "840 Dogwood Blvd", null, "Ella Baker" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentID",
                keyValue: 20);
        }
    }
}
