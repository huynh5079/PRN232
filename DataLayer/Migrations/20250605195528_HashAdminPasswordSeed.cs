using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class HashAdminPasswordSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "084a451f-5467-454e-a37a-933451063632");

            migrationBuilder.InsertData(
                table: "SystemAccounts",
                columns: new[] { "Id", "AccountEmail", "AccountName", "AccountPassword", "AccountRole", "CreatedAt", "UpdatedAt" },
                values: new object[] { "8908368e-4567-460c-bba9-38b60d8f225f", "admin@FUNewsManagementSystem.org", "Admin", "$2b$10$S2fR3gA0B1C29gRX2aFRZ.jaVc2u5fWaY9D9zCLk3CmcdiLJ0rKpe", 0, new DateTime(2025, 6, 5, 19, 55, 26, 888, DateTimeKind.Utc).AddTicks(2089), new DateTime(2025, 6, 5, 19, 55, 26, 888, DateTimeKind.Utc).AddTicks(2093) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "8908368e-4567-460c-bba9-38b60d8f225f");

            migrationBuilder.InsertData(
                table: "SystemAccounts",
                columns: new[] { "Id", "AccountEmail", "AccountName", "AccountPassword", "AccountRole", "CreatedAt", "UpdatedAt" },
                values: new object[] { "084a451f-5467-454e-a37a-933451063632", "admin@FUNewsManagementSystem.org", "Admin", "@@abc123@@", 0, new DateTime(2025, 6, 3, 6, 45, 4, 35, DateTimeKind.Utc).AddTicks(7352), new DateTime(2025, 6, 3, 6, 45, 4, 35, DateTimeKind.Utc).AddTicks(7352) });
        }
    }
}
