using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Tags",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryDescription", "CategoryName", "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[,]
                {
                    { "007e6d98-387b-4048-ad2f-9bd8f0bc4d74", "Description for category 7 of university news.", "Category 7", new DateTime(2024, 10, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1841), true, new DateTime(2024, 8, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1842) },
                    { "0e3788f2-8b0a-47a5-a130-1452972025bd", "Description for category 10 of university news.", "Category 10", new DateTime(2024, 9, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1856), true, new DateTime(2024, 11, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1857) },
                    { "1d344006-5b28-441b-ac6e-ca159bd49ac0", "Description for category 4 of university news.", "Category 4", new DateTime(2025, 1, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1826), true, new DateTime(2024, 10, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1827) },
                    { "1f482ec7-11f2-4551-90b1-d67dc1f44559", "Description for category 19 of university news.", "Category 19", new DateTime(2025, 2, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1900), true, new DateTime(2025, 3, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1900) },
                    { "266b486f-5389-4ecb-9d49-e45bd79c1ff9", "Description for category 13 of university news.", "Category 13", new DateTime(2025, 5, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1870), true, new DateTime(2025, 1, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1871) },
                    { "27dffebf-9ac6-43c3-9f4f-5855394af11e", "Description for category 1 of university news.", "Category 1", new DateTime(2025, 4, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1754), true, new DateTime(2025, 2, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1758) },
                    { "291c53ff-a0bc-41b8-bd3e-4b278632fe35", "Description for category 20 of university news.", "Category 20", new DateTime(2025, 4, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1904), true, new DateTime(2024, 7, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1904) },
                    { "2dc87923-74b9-4403-81ea-97ea4c57ca02", "Description for category 3 of university news.", "Category 3", new DateTime(2024, 9, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1822), true, new DateTime(2024, 11, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1822) },
                    { "32b014f3-ca61-4687-bc62-d305dc29ff5b", "Description for category 6 of university news.", "Category 6", new DateTime(2025, 5, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1835), true, new DateTime(2024, 7, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1836) },
                    { "6f5435bd-7e8b-4b54-b151-e91adeb8fdfb", "Description for category 14 of university news.", "Category 14", new DateTime(2024, 10, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1874), true, new DateTime(2025, 4, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1875) },
                    { "7f9b03b3-ee86-41bc-8f54-5a1afc6d5342", "Description for category 5 of university news.", "Category 5", new DateTime(2024, 9, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1830), true, new DateTime(2025, 5, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1831) },
                    { "84a628bb-a886-492e-9766-9fc25f17ac9d", "Description for category 11 of university news.", "Category 11", new DateTime(2025, 3, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1862), true, new DateTime(2024, 9, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1862) },
                    { "8efda896-9075-4198-8c2d-e6f42b5fb79a", "Description for category 15 of university news.", "Category 15", new DateTime(2025, 2, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1881), true, new DateTime(2025, 5, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1881) },
                    { "90d5d4ad-2a67-4499-8e8a-65dd9b05789c", "Description for category 16 of university news.", "Category 16", new DateTime(2024, 7, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1885), true, new DateTime(2024, 12, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1885) },
                    { "c24b3184-083a-4831-9828-2f93f5ae3f21", "Description for category 2 of university news.", "Category 2", new DateTime(2024, 12, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1763), true, new DateTime(2024, 8, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1764) },
                    { "ca078160-6bc0-49ad-869f-2a6588f35573", "Description for category 9 of university news.", "Category 9", new DateTime(2024, 12, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1850), true, new DateTime(2025, 3, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1850) },
                    { "eaf19e11-72c6-4baf-b4e5-58c5f2f1d2af", "Description for category 18 of university news.", "Category 18", new DateTime(2024, 12, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1894), true, new DateTime(2025, 3, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1894) },
                    { "eba490d7-74e5-4d5b-b6dd-771a02e1bb82", "Description for category 8 of university news.", "Category 8", new DateTime(2024, 10, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1846), true, new DateTime(2024, 11, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1846) },
                    { "ec8265b7-d899-4a89-bf12-1d8b566633ff", "Description for category 17 of university news.", "Category 17", new DateTime(2024, 11, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1889), true, new DateTime(2025, 4, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1889) },
                    { "f99f7276-bbfc-4ab1-9d2a-9cad7bf26ba7", "Description for category 12 of university news.", "Category 12", new DateTime(2024, 10, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1866), true, new DateTime(2024, 10, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(1867) }
                });

            migrationBuilder.UpdateData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "8908368e-4567-460c-bba9-38b60d8f225f",
                columns: new[] { "AccountPassword", "CreatedAt", "UpdatedAt" },
                values: new object[] { "$2b$10$D0wZ1oId1o2W.2StbaUt8.XLUilJJTzMG9WVbPdQTSVoA1VjIbTs6", new DateTime(2024, 6, 5, 21, 37, 21, 194, DateTimeKind.Utc).AddTicks(7627), new DateTime(2024, 6, 5, 21, 37, 21, 194, DateTimeKind.Utc).AddTicks(7636) });

            migrationBuilder.InsertData(
                table: "SystemAccounts",
                columns: new[] { "Id", "AccountEmail", "AccountName", "AccountPassword", "AccountRole", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { "00c8e53e-9825-4a0f-a689-b07ec9b4f4d6", "staff1@fuedu.vn", "Staff Member 1", "$2b$10$vTu2XTC5p0gEKRLl8mKLIuxsSH/Kg3qyg7eoZtld9wKKjOrAqpc/a", 1, new DateTime(2025, 5, 5, 21, 37, 21, 265, DateTimeKind.Utc).AddTicks(2998), new DateTime(2024, 7, 5, 21, 37, 21, 265, DateTimeKind.Utc).AddTicks(3016) },
                    { "00d3f0c6-e9c0-4c0c-8e76-339b2cc60e9b", "staff5@fuedu.vn", "Staff Member 5", "$2b$10$abLUMqxw1RvyNnA/x/tqV.cjarc3RDeFqFoPJuSS3RC90ywhDw7rm", 1, new DateTime(2025, 1, 5, 21, 37, 21, 545, DateTimeKind.Utc).AddTicks(7750), new DateTime(2024, 7, 5, 21, 37, 21, 545, DateTimeKind.Utc).AddTicks(7764) },
                    { "08a71291-df33-4468-b825-ac42cd682ce0", "staff7@fuedu.vn", "Staff Member 7", "$2b$10$TrISOPUjYzUh5Qr4SSO7BOq/Ukuovurt2HnavCMUBDAGsegI/ctPa", 1, new DateTime(2024, 8, 5, 21, 37, 21, 692, DateTimeKind.Utc).AddTicks(8416), new DateTime(2024, 8, 5, 21, 37, 21, 692, DateTimeKind.Utc).AddTicks(8433) },
                    { "2a2b4691-7f48-437a-90dd-0cbea52590cc", "lecturer3@fuedu.vn", "Lecturer 3", "$2b$10$exKnuPX2uOyAWIaUKdroyeffT.rvlP6TS/23s9NZf3Vh/acHOy7ja", 2, new DateTime(2024, 9, 5, 21, 37, 22, 93, DateTimeKind.Utc).AddTicks(9856), new DateTime(2025, 3, 5, 21, 37, 22, 93, DateTimeKind.Utc).AddTicks(9871) },
                    { "30ec03a3-edb6-459f-9f85-9d6d56625600", "lecturer6@fuedu.vn", "Lecturer 6", "$2b$10$rirFF/fZ/Wa2fv1Q789UP.7r1NZpMl3Z68VbO.0LyykaFPfhK3iQ.", 2, new DateTime(2025, 5, 5, 21, 37, 22, 295, DateTimeKind.Utc).AddTicks(8025), new DateTime(2025, 1, 5, 21, 37, 22, 295, DateTimeKind.Utc).AddTicks(8039) },
                    { "4dcb0ede-bdc8-40f1-884e-ace4786a0145", "staff6@fuedu.vn", "Staff Member 6", "$2b$10$hnQpH9vVd8mYbYwN2f9fY.pbMf287Wl.N2D.JeqlkTXlf48kcNErW", 1, new DateTime(2024, 12, 5, 21, 37, 21, 619, DateTimeKind.Utc).AddTicks(7176), new DateTime(2025, 1, 5, 21, 37, 21, 619, DateTimeKind.Utc).AddTicks(7190) },
                    { "6283d1bf-bfc3-4b99-96cb-9825af009158", "staff3@fuedu.vn", "Staff Member 3", "$2b$10$PkCgbao7Gi6FnMOb1JnL3ONhLZahCTtpJI7K.PuBXCzwYGsTTOOI.", 1, new DateTime(2024, 7, 5, 21, 37, 21, 400, DateTimeKind.Utc).AddTicks(806), new DateTime(2025, 3, 5, 21, 37, 21, 400, DateTimeKind.Utc).AddTicks(817) },
                    { "6dfe714f-9886-40ea-a0dd-864fe1dc4ef3", "lecturer1@fuedu.vn", "Lecturer 1", "$2b$10$HXiptPpmz2ac2fFx5JLCyuX4uztmP428e7OSZ8vFkhQftdf9FcoMC", 2, new DateTime(2025, 5, 5, 21, 37, 21, 962, DateTimeKind.Utc).AddTicks(6712), new DateTime(2025, 2, 5, 21, 37, 21, 962, DateTimeKind.Utc).AddTicks(6725) },
                    { "6f4cfd29-b515-430d-954d-29f04491b136", "lecturer7@fuedu.vn", "Lecturer 7", "$2b$10$9Y.JxEqpNVhnVc1jIswG9.cChJjgU1IsP2fRZy7WFgPbDyGNFN.uS", 2, new DateTime(2024, 10, 5, 21, 37, 22, 365, DateTimeKind.Utc).AddTicks(9689), new DateTime(2024, 9, 5, 21, 37, 22, 365, DateTimeKind.Utc).AddTicks(9702) },
                    { "75dc7281-6259-4bde-bee0-3be7aabfc677", "staff4@fuedu.vn", "Staff Member 4", "$2b$10$Y7X4/pcnHRzl31u./vHAs.avcWX9N7dpbfvs1Kh24zTA5AMK5JkFq", 1, new DateTime(2024, 9, 5, 21, 37, 21, 472, DateTimeKind.Utc).AddTicks(4659), new DateTime(2024, 9, 5, 21, 37, 21, 472, DateTimeKind.Utc).AddTicks(4675) },
                    { "7be4d735-f5c3-4afd-bd97-950a672a42aa", "lecturer8@fuedu.vn", "Lecturer 8", "$2b$10$nVEof7/m6NUKqu9T2SdZh.1FXEsniwXpi8E5JIRQKwnXtHVO2kUN.", 2, new DateTime(2025, 4, 5, 21, 37, 22, 432, DateTimeKind.Utc).AddTicks(9846), new DateTime(2025, 1, 5, 21, 37, 22, 432, DateTimeKind.Utc).AddTicks(9858) },
                    { "831696b4-8803-404d-8990-1c178d208114", "lecturer5@fuedu.vn", "Lecturer 5", "$2b$10$ZYzh3jLq1LogVf.bBmFbYujhI9K.p5V7I3WgjV3kUB0YACgY8Fg6q", 2, new DateTime(2024, 9, 5, 21, 37, 22, 224, DateTimeKind.Utc).AddTicks(4316), new DateTime(2024, 9, 5, 21, 37, 22, 224, DateTimeKind.Utc).AddTicks(4328) },
                    { "b3359099-b7c3-438e-af3f-5a74f415210f", "staff9@fuedu.vn", "Staff Member 9", "$2b$10$yW4WPNKM7Ws/Sk08OCkVNOcnhERThQOZfKDSNSBmeJ3z6QXXsoQDO", 1, new DateTime(2024, 11, 5, 21, 37, 21, 830, DateTimeKind.Utc).AddTicks(7339), new DateTime(2024, 7, 5, 21, 37, 21, 830, DateTimeKind.Utc).AddTicks(7353) },
                    { "c45be152-66e2-4635-a6e5-687f9d18e1bb", "lecturer10@fuedu.vn", "Lecturer 10", "$2b$10$c0muECb8uy32SiQO0kaUzuRNrNi4L9QT7Q1oPGrs4.jv/iwxF9UB.", 2, new DateTime(2024, 9, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(443), new DateTime(2024, 12, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(456) },
                    { "c6a02908-bdf5-49c8-8655-e6b281990077", "staff8@fuedu.vn", "Staff Member 8", "$2b$10$muVZN0Jd3VcdSfYsb..oquQr0R16yVAkeZmXDCD7Xklg3Fn10IFoi", 1, new DateTime(2025, 5, 5, 21, 37, 21, 764, DateTimeKind.Utc).AddTicks(4736), new DateTime(2024, 11, 5, 21, 37, 21, 764, DateTimeKind.Utc).AddTicks(4748) },
                    { "cfa8daa3-2872-47b1-89c0-e4a14fa752c4", "lecturer2@fuedu.vn", "Lecturer 2", "$2b$10$pMFpOs5SKexTzDWaRAlNxum9r8Gf74Cq3yvRdz5gdbwphEabgz4Fm", 2, new DateTime(2024, 10, 5, 21, 37, 22, 26, DateTimeKind.Utc).AddTicks(8461), new DateTime(2025, 4, 5, 21, 37, 22, 26, DateTimeKind.Utc).AddTicks(8471) },
                    { "dca12f71-473a-4166-8da4-1cdde805371c", "lecturer4@fuedu.vn", "Lecturer 4", "$2b$10$imXxgFVULlqQ5o9EXI6VCeMdM0FdcnYrEgFVMeZPwzvRH4NmhFai6", 2, new DateTime(2025, 1, 5, 21, 37, 22, 160, DateTimeKind.Utc).AddTicks(1714), new DateTime(2024, 10, 5, 21, 37, 22, 160, DateTimeKind.Utc).AddTicks(1727) },
                    { "e609065a-8a36-4d5d-b1b9-2af55a123367", "staff10@fuedu.vn", "Staff Member 10", "$2b$10$wYcB/1chQN93QxWZqaz0wuPs2AIPltROflKbF/9DzdCPgP0RoPjp.", 1, new DateTime(2025, 5, 5, 21, 37, 21, 896, DateTimeKind.Utc).AddTicks(7772), new DateTime(2024, 7, 5, 21, 37, 21, 896, DateTimeKind.Utc).AddTicks(7784) },
                    { "f14e2936-77ec-4496-a92b-cd7f0a915045", "staff2@fuedu.vn", "Staff Member 2", "$2b$10$Mkkpe1.R8WoLmY.pwLSg7uEbHYdNxTCJ9NbZelRLwn7GsDFphJVMW", 1, new DateTime(2024, 9, 5, 21, 37, 21, 333, DateTimeKind.Utc).AddTicks(9865), new DateTime(2025, 4, 5, 21, 37, 21, 333, DateTimeKind.Utc).AddTicks(9878) },
                    { "fd8d8d31-0c3b-40a1-8cc4-ee26bdb7633d", "lecturer9@fuedu.vn", "Lecturer 9", "$2b$10$MYIcH4BdPmV/2Qr9e.YW5u8PxmvkUXZY6YpdCHKi2xfGFJ6ktnlZ.", 2, new DateTime(2025, 3, 5, 21, 37, 22, 496, DateTimeKind.Utc).AddTicks(9279), new DateTime(2025, 4, 5, 21, 37, 22, 496, DateTimeKind.Utc).AddTicks(9291) }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Note", "TagName", "UpdatedAt" },
                values: new object[,]
                {
                    { "075084b9-c21d-463c-bd59-b0e388baecb4", new DateTime(2025, 5, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2356), "Note for generic tag 1.", "Generic Tag 1", new DateTime(2025, 1, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2357) },
                    { "08ee4872-65ed-4b3f-966b-f7568556275f", new DateTime(2025, 5, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2376), "Note for generic tag 5.", "Generic Tag 5", new DateTime(2024, 7, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2377) },
                    { "1a85842d-241c-4773-be2f-54f047dc3307", new DateTime(2025, 3, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2264), "General note for Sports tag.", "Sports", new DateTime(2024, 10, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2265) },
                    { "1c38e6ed-9100-4a51-9a0f-fc42a3b726d3", new DateTime(2025, 3, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2284), "General note for Scholarships tag.", "Scholarships", new DateTime(2025, 5, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2285) },
                    { "243fec52-92d7-426c-ac71-fb8ee94a7788", new DateTime(2024, 11, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2294), "General note for Sustainability tag.", "Sustainability", new DateTime(2024, 12, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2294) },
                    { "2982951d-5a91-4c0c-b58e-18a32a7d381b", new DateTime(2024, 8, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2372), "Note for generic tag 4.", "Generic Tag 4", new DateTime(2024, 9, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2373) },
                    { "320743f5-a2df-4b92-bade-a92011fb5f19", new DateTime(2024, 8, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2339), "General note for Business tag.", "Business", new DateTime(2024, 11, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2339) },
                    { "34a548e5-ee5a-4e6b-b7f2-a95dfb020804", new DateTime(2025, 1, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2361), "Note for generic tag 2.", "Generic Tag 2", new DateTime(2024, 11, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2362) },
                    { "39f45f39-01c6-4e1a-96d9-c0a180deda1f", new DateTime(2024, 9, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2248), "General note for Research tag.", "Research", new DateTime(2025, 4, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2249) },
                    { "3adbda9d-1e72-4ed1-bb21-84a4fa515dab", new DateTime(2025, 1, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2347), "General note for Community tag.", "Community", new DateTime(2024, 12, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2348) },
                    { "3aeb1f76-2f18-45f9-9ea2-c1b488984edb", new DateTime(2024, 10, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2273), "General note for Alumni tag.", "Alumni", new DateTime(2025, 2, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2273) },
                    { "4a84e146-1c1f-4fba-98d9-0659460dbc3f", new DateTime(2025, 2, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2291), "General note for Health tag.", "Health", new DateTime(2025, 5, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2291) },
                    { "4c805900-0439-4e12-a8a8-9b41c41243ab", new DateTime(2025, 4, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2258), "General note for CampusNews tag.", "CampusNews", new DateTime(2025, 4, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2259) },
                    { "4d8beb4c-4d56-4517-b509-cb4bc21c0559", new DateTime(2024, 8, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2270), "General note for Academics tag.", "Academics", new DateTime(2025, 3, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2270) },
                    { "521461b0-2a80-4d5c-8567-b9d5ed6aae66", new DateTime(2025, 5, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2299), "General note for Arts tag.", "Arts", new DateTime(2024, 7, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2299) },
                    { "5c4aaa6a-3fde-4474-9616-e94d9f31db70", new DateTime(2025, 1, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2261), "General note for Events tag.", "Events", new DateTime(2025, 1, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2261) },
                    { "8456c06b-4d67-4db6-9e0f-9f2dcc4cef2b", new DateTime(2024, 8, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2276), "General note for International tag.", "International", new DateTime(2024, 7, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2276) },
                    { "86b39a89-3588-432c-a294-d47b05c0f12c", new DateTime(2025, 2, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2305), "General note for Engineering tag.", "Engineering", new DateTime(2025, 5, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2305) },
                    { "9720f493-2987-4856-9197-bc58add21994", new DateTime(2025, 2, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2302), "General note for Science tag.", "Science", new DateTime(2024, 11, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2302) },
                    { "a98d3bda-464b-4cee-9f13-0e3e7b057c97", new DateTime(2024, 10, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2279), "General note for Admissions tag.", "Admissions", new DateTime(2025, 4, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2280) },
                    { "abca5a96-a113-4b62-986d-bdde9ad74ac6", new DateTime(2024, 7, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2344), "General note for Humanities tag.", "Humanities", new DateTime(2024, 9, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2344) },
                    { "ac611768-3b81-4cae-a473-1c251d2333fc", new DateTime(2024, 7, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2255), "General note for StudentLife tag.", "StudentLife", new DateTime(2025, 3, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2256) },
                    { "b918e898-7044-4d4f-a25d-dd1ec892477b", new DateTime(2025, 4, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2287), "General note for Career tag.", "Career", new DateTime(2025, 1, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2288) },
                    { "ea9eadd7-07d4-4840-88af-d86998f0b716", new DateTime(2025, 3, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2368), "Note for generic tag 3.", "Generic Tag 3", new DateTime(2024, 8, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2368) },
                    { "fdd9e980-a653-4ef9-9353-a6e11d0b7e8c", new DateTime(2024, 12, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2242), "General note for Technology tag.", "Technology", new DateTime(2024, 9, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2244) }
                });

            migrationBuilder.InsertData(
                table: "NewsArticles",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "CreatedById", "CreatedDate", "NewsContent", "NewsStatus", "NewsTitle", "UpdatedAt" },
                values: new object[,]
                {
                    { "009c3ae2-bbcd-448f-b574-c16a12872c67", "7f9b03b3-ee86-41bc-8f54-5a1afc6d5342", new DateTime(2025, 1, 29, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2707), "30ec03a3-edb6-459f-9f85-9d6d56625600", new DateTime(2025, 1, 29, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2707), "This is the detailed content for news article 17. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 17 - 4fbd6531", new DateTime(2025, 1, 29, 22, 29, 22, 560, DateTimeKind.Utc).AddTicks(2707) },
                    { "0a305430-69aa-4ce6-b100-7e2e3856325e", "eaf19e11-72c6-4baf-b4e5-58c5f2f1d2af", new DateTime(2025, 2, 28, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2483), "8908368e-4567-460c-bba9-38b60d8f225f", new DateTime(2025, 2, 28, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2483), "This is the detailed content for news article 1. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 1 - d037b2aa", new DateTime(2025, 2, 28, 22, 1, 22, 560, DateTimeKind.Utc).AddTicks(2483) },
                    { "258ec250-a032-4cd5-b32e-a90869a68562", "27dffebf-9ac6-43c3-9f4f-5855394af11e", new DateTime(2025, 3, 30, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2775), "831696b4-8803-404d-8990-1c178d208114", new DateTime(2025, 3, 30, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2775), "This is the detailed content for news article 24. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", false, "University Update: Article 24 - ec424677", new DateTime(2025, 3, 30, 22, 8, 22, 560, DateTimeKind.Utc).AddTicks(2775) },
                    { "26c85523-9687-4960-87ec-6573454ecc58", "c24b3184-083a-4831-9828-2f93f5ae3f21", new DateTime(2025, 1, 30, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2586), "dca12f71-473a-4166-8da4-1cdde805371c", new DateTime(2025, 1, 30, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2586), "This is the detailed content for news article 7. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 7 - dea19c13", new DateTime(2025, 1, 30, 21, 55, 22, 560, DateTimeKind.Utc).AddTicks(2586) },
                    { "33cf89da-6b18-489a-8bbe-66e747b8cb89", "eba490d7-74e5-4d5b-b6dd-771a02e1bb82", new DateTime(2024, 8, 17, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2576), "6283d1bf-bfc3-4b99-96cb-9825af009158", new DateTime(2024, 8, 17, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2576), "This is the detailed content for news article 5. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", false, "University Update: Article 5 - 1981e71b", new DateTime(2024, 8, 17, 22, 23, 22, 560, DateTimeKind.Utc).AddTicks(2576) },
                    { "379cc9b0-d3b1-4b5f-8508-175e349e0410", "ca078160-6bc0-49ad-869f-2a6588f35573", new DateTime(2025, 4, 13, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2668), "fd8d8d31-0c3b-40a1-8cc4-ee26bdb7633d", new DateTime(2025, 4, 13, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2668), "This is the detailed content for news article 11. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 11 - 17d3d721", new DateTime(2025, 4, 13, 22, 20, 22, 560, DateTimeKind.Utc).AddTicks(2668) },
                    { "46f29f09-63df-4ab8-a40a-d5287b857eca", "007e6d98-387b-4048-ad2f-9bd8f0bc4d74", new DateTime(2024, 10, 15, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2597), "b3359099-b7c3-438e-af3f-5a74f415210f", new DateTime(2024, 10, 15, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2597), "This is the detailed content for news article 9. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", false, "University Update: Article 9 - 9deaa332", new DateTime(2024, 10, 15, 22, 29, 22, 560, DateTimeKind.Utc).AddTicks(2597) },
                    { "4a6c0e55-38c4-4912-bf37-4ea5e8eea92d", "c24b3184-083a-4831-9828-2f93f5ae3f21", new DateTime(2024, 9, 22, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2592), "f14e2936-77ec-4496-a92b-cd7f0a915045", new DateTime(2024, 9, 22, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2592), "This is the detailed content for news article 8. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 8 - 013e38c1", new DateTime(2024, 9, 22, 22, 34, 22, 560, DateTimeKind.Utc).AddTicks(2592) },
                    { "5a39b647-5bb5-43dd-a8ea-625a04da0fa8", "ca078160-6bc0-49ad-869f-2a6588f35573", new DateTime(2025, 1, 7, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2746), "00d3f0c6-e9c0-4c0c-8e76-339b2cc60e9b", new DateTime(2025, 1, 7, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2746), "This is the detailed content for news article 18. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", false, "University Update: Article 18 - ab16d604", new DateTime(2025, 1, 7, 21, 46, 22, 560, DateTimeKind.Utc).AddTicks(2746) },
                    { "5a3b046a-05fd-45b0-8a8f-5128fc7e7939", "0e3788f2-8b0a-47a5-a130-1452972025bd", new DateTime(2024, 8, 19, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2582), "2a2b4691-7f48-437a-90dd-0cbea52590cc", new DateTime(2024, 8, 19, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2582), "This is the detailed content for news article 6. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", false, "University Update: Article 6 - c5e5c3be", new DateTime(2024, 8, 19, 22, 19, 22, 560, DateTimeKind.Utc).AddTicks(2582) },
                    { "5bdbc52c-6ff4-4bb4-9bff-a4eaa52d197d", "eba490d7-74e5-4d5b-b6dd-771a02e1bb82", new DateTime(2024, 12, 23, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2802), "f14e2936-77ec-4496-a92b-cd7f0a915045", new DateTime(2024, 12, 23, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2802), "This is the detailed content for news article 25. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", false, "University Update: Article 25 - b6c61b2c", new DateTime(2024, 12, 23, 21, 40, 22, 560, DateTimeKind.Utc).AddTicks(2802) },
                    { "5e8fc9d0-05ed-49f6-bbce-6bcc90803a74", "c24b3184-083a-4831-9828-2f93f5ae3f21", new DateTime(2025, 3, 2, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2751), "00c8e53e-9825-4a0f-a689-b07ec9b4f4d6", new DateTime(2025, 3, 2, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2751), "This is the detailed content for news article 19. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", false, "University Update: Article 19 - 03b602d2", new DateTime(2025, 3, 2, 22, 29, 22, 560, DateTimeKind.Utc).AddTicks(2751) },
                    { "724d4173-a964-4b01-877d-8939df35bc1d", "27dffebf-9ac6-43c3-9f4f-5855394af11e", new DateTime(2024, 6, 10, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2770), "7be4d735-f5c3-4afd-bd97-950a672a42aa", new DateTime(2024, 6, 10, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2770), "This is the detailed content for news article 23. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", false, "University Update: Article 23 - 1e3c5685", new DateTime(2024, 6, 10, 22, 34, 22, 560, DateTimeKind.Utc).AddTicks(2770) },
                    { "7b43a7bd-2db9-4f05-b335-c7d8fafe73ea", "eaf19e11-72c6-4baf-b4e5-58c5f2f1d2af", new DateTime(2024, 9, 5, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2515), "c6a02908-bdf5-49c8-8655-e6b281990077", new DateTime(2024, 9, 5, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2515), "This is the detailed content for news article 2. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 2 - 99500eed", new DateTime(2024, 9, 5, 22, 0, 22, 560, DateTimeKind.Utc).AddTicks(2515) },
                    { "7f80144e-2cc6-4201-aebe-ec7c7a09a1d4", "266b486f-5389-4ecb-9d49-e45bd79c1ff9", new DateTime(2024, 12, 31, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2603), "8908368e-4567-460c-bba9-38b60d8f225f", new DateTime(2024, 12, 31, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2603), "This is the detailed content for news article 10. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 10 - e7095fe8", new DateTime(2024, 12, 31, 21, 53, 22, 560, DateTimeKind.Utc).AddTicks(2603) },
                    { "802c5661-eda8-4b42-ad1a-166cb588dc05", "27dffebf-9ac6-43c3-9f4f-5855394af11e", new DateTime(2024, 10, 10, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2673), "6dfe714f-9886-40ea-a0dd-864fe1dc4ef3", new DateTime(2024, 10, 10, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2673), "This is the detailed content for news article 12. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 12 - e3e0cd3d", new DateTime(2024, 10, 10, 22, 13, 22, 560, DateTimeKind.Utc).AddTicks(2673) },
                    { "9267f91e-6648-4c52-98f4-35598cd01f0c", "8efda896-9075-4198-8c2d-e6f42b5fb79a", new DateTime(2025, 4, 20, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2755), "b3359099-b7c3-438e-af3f-5a74f415210f", new DateTime(2025, 4, 20, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2755), "This is the detailed content for news article 20. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 20 - 0c635b9b", new DateTime(2025, 4, 20, 22, 23, 22, 560, DateTimeKind.Utc).AddTicks(2755) },
                    { "a9e377c3-de4c-4d68-adad-382569227984", "2dc87923-74b9-4403-81ea-97ea4c57ca02", new DateTime(2024, 10, 18, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2683), "2a2b4691-7f48-437a-90dd-0cbea52590cc", new DateTime(2024, 10, 18, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2683), "This is the detailed content for news article 14. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", false, "University Update: Article 14 - 86c7af2d", new DateTime(2024, 10, 18, 22, 13, 22, 560, DateTimeKind.Utc).AddTicks(2683) },
                    { "aaf1dc0b-915c-4598-ac93-72d09f1cfba7", "266b486f-5389-4ecb-9d49-e45bd79c1ff9", new DateTime(2024, 9, 9, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2761), "cfa8daa3-2872-47b1-89c0-e4a14fa752c4", new DateTime(2024, 9, 9, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2761), "This is the detailed content for news article 21. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 21 - ad44a261", new DateTime(2024, 9, 9, 22, 16, 22, 560, DateTimeKind.Utc).AddTicks(2761) },
                    { "bc49a86e-459f-4b41-a031-e2942808ba59", "ec8265b7-d899-4a89-bf12-1d8b566633ff", new DateTime(2025, 5, 19, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2703), "8908368e-4567-460c-bba9-38b60d8f225f", new DateTime(2025, 5, 19, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2703), "This is the detailed content for news article 16. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", false, "University Update: Article 16 - f2abf112", new DateTime(2025, 5, 19, 22, 33, 22, 560, DateTimeKind.Utc).AddTicks(2703) },
                    { "c36a6a3a-8c6c-4ad4-b3d7-0e352b812a31", "0e3788f2-8b0a-47a5-a130-1452972025bd", new DateTime(2024, 12, 15, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2679), "4dcb0ede-bdc8-40f1-884e-ace4786a0145", new DateTime(2024, 12, 15, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2679), "This is the detailed content for news article 13. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 13 - f3b04bf8", new DateTime(2024, 12, 15, 21, 54, 22, 560, DateTimeKind.Utc).AddTicks(2679) },
                    { "c9834247-9438-4cbf-9a72-4b9a7fb29930", "8efda896-9075-4198-8c2d-e6f42b5fb79a", new DateTime(2024, 9, 25, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2521), "75dc7281-6259-4bde-bee0-3be7aabfc677", new DateTime(2024, 9, 25, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2521), "This is the detailed content for news article 3. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 3 - 7f043080", new DateTime(2024, 9, 25, 21, 53, 22, 560, DateTimeKind.Utc).AddTicks(2521) },
                    { "e81ba74d-2440-440e-bc91-93fd9d5c186b", "84a628bb-a886-492e-9766-9fc25f17ac9d", new DateTime(2024, 8, 3, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2765), "c6a02908-bdf5-49c8-8655-e6b281990077", new DateTime(2024, 8, 3, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2765), "This is the detailed content for news article 22. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", false, "University Update: Article 22 - 1e874bb8", new DateTime(2024, 8, 3, 22, 5, 22, 560, DateTimeKind.Utc).AddTicks(2765) },
                    { "e93b9e54-6f3a-4672-bf06-76682abf9b16", "f99f7276-bbfc-4ab1-9d2a-9cad7bf26ba7", new DateTime(2024, 8, 30, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2547), "c45be152-66e2-4635-a6e5-687f9d18e1bb", new DateTime(2024, 8, 30, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2547), "This is the detailed content for news article 4. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 4 - e16ce3cd", new DateTime(2024, 8, 30, 21, 57, 22, 560, DateTimeKind.Utc).AddTicks(2547) },
                    { "f122ad11-e823-406a-9bf4-ff5a1463462f", "f99f7276-bbfc-4ab1-9d2a-9cad7bf26ba7", new DateTime(2024, 12, 1, 20, 37, 22, 560, DateTimeKind.Utc).AddTicks(2697), "8908368e-4567-460c-bba9-38b60d8f225f", new DateTime(2024, 12, 1, 21, 37, 22, 560, DateTimeKind.Utc).AddTicks(2697), "This is the detailed content for news article 15. It covers important developments and announcements within the university community. Stay tuned for more updates! This article aims to inform students, faculty, and staff about recent achievements and upcoming events. We value our community's engagement.", true, "University Update: Article 15 - 07dafab2", new DateTime(2024, 12, 1, 22, 7, 22, 560, DateTimeKind.Utc).AddTicks(2697) }
                });

            migrationBuilder.InsertData(
                table: "NewsTags",
                columns: new[] { "NewsArticleId", "TagId" },
                values: new object[,]
                {
                    { "009c3ae2-bbcd-448f-b574-c16a12872c67", "1a85842d-241c-4773-be2f-54f047dc3307" },
                    { "009c3ae2-bbcd-448f-b574-c16a12872c67", "1c38e6ed-9100-4a51-9a0f-fc42a3b726d3" },
                    { "009c3ae2-bbcd-448f-b574-c16a12872c67", "4a84e146-1c1f-4fba-98d9-0659460dbc3f" },
                    { "009c3ae2-bbcd-448f-b574-c16a12872c67", "4d8beb4c-4d56-4517-b509-cb4bc21c0559" },
                    { "009c3ae2-bbcd-448f-b574-c16a12872c67", "86b39a89-3588-432c-a294-d47b05c0f12c" },
                    { "0a305430-69aa-4ce6-b100-7e2e3856325e", "1a85842d-241c-4773-be2f-54f047dc3307" },
                    { "0a305430-69aa-4ce6-b100-7e2e3856325e", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" },
                    { "0a305430-69aa-4ce6-b100-7e2e3856325e", "a98d3bda-464b-4cee-9f13-0e3e7b057c97" },
                    { "0a305430-69aa-4ce6-b100-7e2e3856325e", "ac611768-3b81-4cae-a473-1c251d2333fc" },
                    { "258ec250-a032-4cd5-b32e-a90869a68562", "08ee4872-65ed-4b3f-966b-f7568556275f" },
                    { "258ec250-a032-4cd5-b32e-a90869a68562", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" },
                    { "26c85523-9687-4960-87ec-6573454ecc58", "320743f5-a2df-4b92-bade-a92011fb5f19" },
                    { "26c85523-9687-4960-87ec-6573454ecc58", "9720f493-2987-4856-9197-bc58add21994" },
                    { "26c85523-9687-4960-87ec-6573454ecc58", "ac611768-3b81-4cae-a473-1c251d2333fc" },
                    { "33cf89da-6b18-489a-8bbe-66e747b8cb89", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" },
                    { "33cf89da-6b18-489a-8bbe-66e747b8cb89", "4c805900-0439-4e12-a8a8-9b41c41243ab" },
                    { "33cf89da-6b18-489a-8bbe-66e747b8cb89", "5c4aaa6a-3fde-4474-9616-e94d9f31db70" },
                    { "379cc9b0-d3b1-4b5f-8508-175e349e0410", "243fec52-92d7-426c-ac71-fb8ee94a7788" },
                    { "379cc9b0-d3b1-4b5f-8508-175e349e0410", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" },
                    { "379cc9b0-d3b1-4b5f-8508-175e349e0410", "5c4aaa6a-3fde-4474-9616-e94d9f31db70" },
                    { "379cc9b0-d3b1-4b5f-8508-175e349e0410", "ea9eadd7-07d4-4840-88af-d86998f0b716" },
                    { "46f29f09-63df-4ab8-a40a-d5287b857eca", "1c38e6ed-9100-4a51-9a0f-fc42a3b726d3" },
                    { "46f29f09-63df-4ab8-a40a-d5287b857eca", "4d8beb4c-4d56-4517-b509-cb4bc21c0559" },
                    { "4a6c0e55-38c4-4912-bf37-4ea5e8eea92d", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" },
                    { "4a6c0e55-38c4-4912-bf37-4ea5e8eea92d", "9720f493-2987-4856-9197-bc58add21994" },
                    { "4a6c0e55-38c4-4912-bf37-4ea5e8eea92d", "b918e898-7044-4d4f-a25d-dd1ec892477b" },
                    { "5a39b647-5bb5-43dd-a8ea-625a04da0fa8", "5c4aaa6a-3fde-4474-9616-e94d9f31db70" },
                    { "5a39b647-5bb5-43dd-a8ea-625a04da0fa8", "86b39a89-3588-432c-a294-d47b05c0f12c" },
                    { "5a39b647-5bb5-43dd-a8ea-625a04da0fa8", "abca5a96-a113-4b62-986d-bdde9ad74ac6" },
                    { "5a3b046a-05fd-45b0-8a8f-5128fc7e7939", "243fec52-92d7-426c-ac71-fb8ee94a7788" },
                    { "5a3b046a-05fd-45b0-8a8f-5128fc7e7939", "2982951d-5a91-4c0c-b58e-18a32a7d381b" },
                    { "5a3b046a-05fd-45b0-8a8f-5128fc7e7939", "86b39a89-3588-432c-a294-d47b05c0f12c" },
                    { "5a3b046a-05fd-45b0-8a8f-5128fc7e7939", "abca5a96-a113-4b62-986d-bdde9ad74ac6" },
                    { "5a3b046a-05fd-45b0-8a8f-5128fc7e7939", "ea9eadd7-07d4-4840-88af-d86998f0b716" },
                    { "5bdbc52c-6ff4-4bb4-9bff-a4eaa52d197d", "08ee4872-65ed-4b3f-966b-f7568556275f" },
                    { "5bdbc52c-6ff4-4bb4-9bff-a4eaa52d197d", "320743f5-a2df-4b92-bade-a92011fb5f19" },
                    { "5bdbc52c-6ff4-4bb4-9bff-a4eaa52d197d", "ea9eadd7-07d4-4840-88af-d86998f0b716" },
                    { "5e8fc9d0-05ed-49f6-bbce-6bcc90803a74", "243fec52-92d7-426c-ac71-fb8ee94a7788" },
                    { "5e8fc9d0-05ed-49f6-bbce-6bcc90803a74", "320743f5-a2df-4b92-bade-a92011fb5f19" },
                    { "5e8fc9d0-05ed-49f6-bbce-6bcc90803a74", "4c805900-0439-4e12-a8a8-9b41c41243ab" },
                    { "5e8fc9d0-05ed-49f6-bbce-6bcc90803a74", "86b39a89-3588-432c-a294-d47b05c0f12c" },
                    { "5e8fc9d0-05ed-49f6-bbce-6bcc90803a74", "b918e898-7044-4d4f-a25d-dd1ec892477b" },
                    { "724d4173-a964-4b01-877d-8939df35bc1d", "39f45f39-01c6-4e1a-96d9-c0a180deda1f" },
                    { "724d4173-a964-4b01-877d-8939df35bc1d", "9720f493-2987-4856-9197-bc58add21994" },
                    { "7b43a7bd-2db9-4f05-b335-c7d8fafe73ea", "075084b9-c21d-463c-bd59-b0e388baecb4" },
                    { "7b43a7bd-2db9-4f05-b335-c7d8fafe73ea", "1c38e6ed-9100-4a51-9a0f-fc42a3b726d3" },
                    { "7b43a7bd-2db9-4f05-b335-c7d8fafe73ea", "3adbda9d-1e72-4ed1-bb21-84a4fa515dab" },
                    { "7b43a7bd-2db9-4f05-b335-c7d8fafe73ea", "8456c06b-4d67-4db6-9e0f-9f2dcc4cef2b" },
                    { "7b43a7bd-2db9-4f05-b335-c7d8fafe73ea", "a98d3bda-464b-4cee-9f13-0e3e7b057c97" },
                    { "7f80144e-2cc6-4201-aebe-ec7c7a09a1d4", "1c38e6ed-9100-4a51-9a0f-fc42a3b726d3" },
                    { "7f80144e-2cc6-4201-aebe-ec7c7a09a1d4", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" },
                    { "7f80144e-2cc6-4201-aebe-ec7c7a09a1d4", "3aeb1f76-2f18-45f9-9ea2-c1b488984edb" },
                    { "7f80144e-2cc6-4201-aebe-ec7c7a09a1d4", "8456c06b-4d67-4db6-9e0f-9f2dcc4cef2b" },
                    { "802c5661-eda8-4b42-ad1a-166cb588dc05", "1a85842d-241c-4773-be2f-54f047dc3307" },
                    { "802c5661-eda8-4b42-ad1a-166cb588dc05", "1c38e6ed-9100-4a51-9a0f-fc42a3b726d3" },
                    { "802c5661-eda8-4b42-ad1a-166cb588dc05", "4a84e146-1c1f-4fba-98d9-0659460dbc3f" },
                    { "802c5661-eda8-4b42-ad1a-166cb588dc05", "b918e898-7044-4d4f-a25d-dd1ec892477b" },
                    { "802c5661-eda8-4b42-ad1a-166cb588dc05", "fdd9e980-a653-4ef9-9353-a6e11d0b7e8c" },
                    { "9267f91e-6648-4c52-98f4-35598cd01f0c", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" },
                    { "9267f91e-6648-4c52-98f4-35598cd01f0c", "ac611768-3b81-4cae-a473-1c251d2333fc" },
                    { "a9e377c3-de4c-4d68-adad-382569227984", "1a85842d-241c-4773-be2f-54f047dc3307" },
                    { "a9e377c3-de4c-4d68-adad-382569227984", "3adbda9d-1e72-4ed1-bb21-84a4fa515dab" },
                    { "a9e377c3-de4c-4d68-adad-382569227984", "5c4aaa6a-3fde-4474-9616-e94d9f31db70" },
                    { "a9e377c3-de4c-4d68-adad-382569227984", "a98d3bda-464b-4cee-9f13-0e3e7b057c97" },
                    { "a9e377c3-de4c-4d68-adad-382569227984", "ea9eadd7-07d4-4840-88af-d86998f0b716" },
                    { "aaf1dc0b-915c-4598-ac93-72d09f1cfba7", "08ee4872-65ed-4b3f-966b-f7568556275f" },
                    { "aaf1dc0b-915c-4598-ac93-72d09f1cfba7", "fdd9e980-a653-4ef9-9353-a6e11d0b7e8c" },
                    { "bc49a86e-459f-4b41-a031-e2942808ba59", "1a85842d-241c-4773-be2f-54f047dc3307" },
                    { "bc49a86e-459f-4b41-a031-e2942808ba59", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" },
                    { "c36a6a3a-8c6c-4ad4-b3d7-0e352b812a31", "1a85842d-241c-4773-be2f-54f047dc3307" },
                    { "c36a6a3a-8c6c-4ad4-b3d7-0e352b812a31", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" },
                    { "c9834247-9438-4cbf-9a72-4b9a7fb29930", "ea9eadd7-07d4-4840-88af-d86998f0b716" },
                    { "c9834247-9438-4cbf-9a72-4b9a7fb29930", "fdd9e980-a653-4ef9-9353-a6e11d0b7e8c" },
                    { "e81ba74d-2440-440e-bc91-93fd9d5c186b", "1a85842d-241c-4773-be2f-54f047dc3307" },
                    { "e81ba74d-2440-440e-bc91-93fd9d5c186b", "ea9eadd7-07d4-4840-88af-d86998f0b716" },
                    { "e93b9e54-6f3a-4672-bf06-76682abf9b16", "3adbda9d-1e72-4ed1-bb21-84a4fa515dab" },
                    { "e93b9e54-6f3a-4672-bf06-76682abf9b16", "a98d3bda-464b-4cee-9f13-0e3e7b057c97" },
                    { "f122ad11-e823-406a-9bf4-ff5a1463462f", "4c805900-0439-4e12-a8a8-9b41c41243ab" },
                    { "f122ad11-e823-406a-9bf4-ff5a1463462f", "5c4aaa6a-3fde-4474-9616-e94d9f31db70" },
                    { "f122ad11-e823-406a-9bf4-ff5a1463462f", "9720f493-2987-4856-9197-bc58add21994" },
                    { "f122ad11-e823-406a-9bf4-ff5a1463462f", "b918e898-7044-4d4f-a25d-dd1ec892477b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "1d344006-5b28-441b-ac6e-ca159bd49ac0");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "1f482ec7-11f2-4551-90b1-d67dc1f44559");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "291c53ff-a0bc-41b8-bd3e-4b278632fe35");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "32b014f3-ca61-4687-bc62-d305dc29ff5b");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6f5435bd-7e8b-4b54-b151-e91adeb8fdfb");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "90d5d4ad-2a67-4499-8e8a-65dd9b05789c");

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "009c3ae2-bbcd-448f-b574-c16a12872c67", "1a85842d-241c-4773-be2f-54f047dc3307" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "009c3ae2-bbcd-448f-b574-c16a12872c67", "1c38e6ed-9100-4a51-9a0f-fc42a3b726d3" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "009c3ae2-bbcd-448f-b574-c16a12872c67", "4a84e146-1c1f-4fba-98d9-0659460dbc3f" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "009c3ae2-bbcd-448f-b574-c16a12872c67", "4d8beb4c-4d56-4517-b509-cb4bc21c0559" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "009c3ae2-bbcd-448f-b574-c16a12872c67", "86b39a89-3588-432c-a294-d47b05c0f12c" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "0a305430-69aa-4ce6-b100-7e2e3856325e", "1a85842d-241c-4773-be2f-54f047dc3307" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "0a305430-69aa-4ce6-b100-7e2e3856325e", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "0a305430-69aa-4ce6-b100-7e2e3856325e", "a98d3bda-464b-4cee-9f13-0e3e7b057c97" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "0a305430-69aa-4ce6-b100-7e2e3856325e", "ac611768-3b81-4cae-a473-1c251d2333fc" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "258ec250-a032-4cd5-b32e-a90869a68562", "08ee4872-65ed-4b3f-966b-f7568556275f" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "258ec250-a032-4cd5-b32e-a90869a68562", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "26c85523-9687-4960-87ec-6573454ecc58", "320743f5-a2df-4b92-bade-a92011fb5f19" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "26c85523-9687-4960-87ec-6573454ecc58", "9720f493-2987-4856-9197-bc58add21994" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "26c85523-9687-4960-87ec-6573454ecc58", "ac611768-3b81-4cae-a473-1c251d2333fc" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "33cf89da-6b18-489a-8bbe-66e747b8cb89", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "33cf89da-6b18-489a-8bbe-66e747b8cb89", "4c805900-0439-4e12-a8a8-9b41c41243ab" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "33cf89da-6b18-489a-8bbe-66e747b8cb89", "5c4aaa6a-3fde-4474-9616-e94d9f31db70" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "379cc9b0-d3b1-4b5f-8508-175e349e0410", "243fec52-92d7-426c-ac71-fb8ee94a7788" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "379cc9b0-d3b1-4b5f-8508-175e349e0410", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "379cc9b0-d3b1-4b5f-8508-175e349e0410", "5c4aaa6a-3fde-4474-9616-e94d9f31db70" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "379cc9b0-d3b1-4b5f-8508-175e349e0410", "ea9eadd7-07d4-4840-88af-d86998f0b716" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "46f29f09-63df-4ab8-a40a-d5287b857eca", "1c38e6ed-9100-4a51-9a0f-fc42a3b726d3" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "46f29f09-63df-4ab8-a40a-d5287b857eca", "4d8beb4c-4d56-4517-b509-cb4bc21c0559" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "4a6c0e55-38c4-4912-bf37-4ea5e8eea92d", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "4a6c0e55-38c4-4912-bf37-4ea5e8eea92d", "9720f493-2987-4856-9197-bc58add21994" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "4a6c0e55-38c4-4912-bf37-4ea5e8eea92d", "b918e898-7044-4d4f-a25d-dd1ec892477b" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5a39b647-5bb5-43dd-a8ea-625a04da0fa8", "5c4aaa6a-3fde-4474-9616-e94d9f31db70" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5a39b647-5bb5-43dd-a8ea-625a04da0fa8", "86b39a89-3588-432c-a294-d47b05c0f12c" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5a39b647-5bb5-43dd-a8ea-625a04da0fa8", "abca5a96-a113-4b62-986d-bdde9ad74ac6" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5a3b046a-05fd-45b0-8a8f-5128fc7e7939", "243fec52-92d7-426c-ac71-fb8ee94a7788" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5a3b046a-05fd-45b0-8a8f-5128fc7e7939", "2982951d-5a91-4c0c-b58e-18a32a7d381b" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5a3b046a-05fd-45b0-8a8f-5128fc7e7939", "86b39a89-3588-432c-a294-d47b05c0f12c" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5a3b046a-05fd-45b0-8a8f-5128fc7e7939", "abca5a96-a113-4b62-986d-bdde9ad74ac6" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5a3b046a-05fd-45b0-8a8f-5128fc7e7939", "ea9eadd7-07d4-4840-88af-d86998f0b716" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5bdbc52c-6ff4-4bb4-9bff-a4eaa52d197d", "08ee4872-65ed-4b3f-966b-f7568556275f" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5bdbc52c-6ff4-4bb4-9bff-a4eaa52d197d", "320743f5-a2df-4b92-bade-a92011fb5f19" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5bdbc52c-6ff4-4bb4-9bff-a4eaa52d197d", "ea9eadd7-07d4-4840-88af-d86998f0b716" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5e8fc9d0-05ed-49f6-bbce-6bcc90803a74", "243fec52-92d7-426c-ac71-fb8ee94a7788" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5e8fc9d0-05ed-49f6-bbce-6bcc90803a74", "320743f5-a2df-4b92-bade-a92011fb5f19" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5e8fc9d0-05ed-49f6-bbce-6bcc90803a74", "4c805900-0439-4e12-a8a8-9b41c41243ab" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5e8fc9d0-05ed-49f6-bbce-6bcc90803a74", "86b39a89-3588-432c-a294-d47b05c0f12c" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "5e8fc9d0-05ed-49f6-bbce-6bcc90803a74", "b918e898-7044-4d4f-a25d-dd1ec892477b" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "724d4173-a964-4b01-877d-8939df35bc1d", "39f45f39-01c6-4e1a-96d9-c0a180deda1f" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "724d4173-a964-4b01-877d-8939df35bc1d", "9720f493-2987-4856-9197-bc58add21994" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "7b43a7bd-2db9-4f05-b335-c7d8fafe73ea", "075084b9-c21d-463c-bd59-b0e388baecb4" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "7b43a7bd-2db9-4f05-b335-c7d8fafe73ea", "1c38e6ed-9100-4a51-9a0f-fc42a3b726d3" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "7b43a7bd-2db9-4f05-b335-c7d8fafe73ea", "3adbda9d-1e72-4ed1-bb21-84a4fa515dab" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "7b43a7bd-2db9-4f05-b335-c7d8fafe73ea", "8456c06b-4d67-4db6-9e0f-9f2dcc4cef2b" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "7b43a7bd-2db9-4f05-b335-c7d8fafe73ea", "a98d3bda-464b-4cee-9f13-0e3e7b057c97" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "7f80144e-2cc6-4201-aebe-ec7c7a09a1d4", "1c38e6ed-9100-4a51-9a0f-fc42a3b726d3" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "7f80144e-2cc6-4201-aebe-ec7c7a09a1d4", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "7f80144e-2cc6-4201-aebe-ec7c7a09a1d4", "3aeb1f76-2f18-45f9-9ea2-c1b488984edb" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "7f80144e-2cc6-4201-aebe-ec7c7a09a1d4", "8456c06b-4d67-4db6-9e0f-9f2dcc4cef2b" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "802c5661-eda8-4b42-ad1a-166cb588dc05", "1a85842d-241c-4773-be2f-54f047dc3307" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "802c5661-eda8-4b42-ad1a-166cb588dc05", "1c38e6ed-9100-4a51-9a0f-fc42a3b726d3" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "802c5661-eda8-4b42-ad1a-166cb588dc05", "4a84e146-1c1f-4fba-98d9-0659460dbc3f" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "802c5661-eda8-4b42-ad1a-166cb588dc05", "b918e898-7044-4d4f-a25d-dd1ec892477b" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "802c5661-eda8-4b42-ad1a-166cb588dc05", "fdd9e980-a653-4ef9-9353-a6e11d0b7e8c" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "9267f91e-6648-4c52-98f4-35598cd01f0c", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "9267f91e-6648-4c52-98f4-35598cd01f0c", "ac611768-3b81-4cae-a473-1c251d2333fc" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "a9e377c3-de4c-4d68-adad-382569227984", "1a85842d-241c-4773-be2f-54f047dc3307" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "a9e377c3-de4c-4d68-adad-382569227984", "3adbda9d-1e72-4ed1-bb21-84a4fa515dab" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "a9e377c3-de4c-4d68-adad-382569227984", "5c4aaa6a-3fde-4474-9616-e94d9f31db70" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "a9e377c3-de4c-4d68-adad-382569227984", "a98d3bda-464b-4cee-9f13-0e3e7b057c97" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "a9e377c3-de4c-4d68-adad-382569227984", "ea9eadd7-07d4-4840-88af-d86998f0b716" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "aaf1dc0b-915c-4598-ac93-72d09f1cfba7", "08ee4872-65ed-4b3f-966b-f7568556275f" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "aaf1dc0b-915c-4598-ac93-72d09f1cfba7", "fdd9e980-a653-4ef9-9353-a6e11d0b7e8c" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "bc49a86e-459f-4b41-a031-e2942808ba59", "1a85842d-241c-4773-be2f-54f047dc3307" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "bc49a86e-459f-4b41-a031-e2942808ba59", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "c36a6a3a-8c6c-4ad4-b3d7-0e352b812a31", "1a85842d-241c-4773-be2f-54f047dc3307" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "c36a6a3a-8c6c-4ad4-b3d7-0e352b812a31", "34a548e5-ee5a-4e6b-b7f2-a95dfb020804" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "c9834247-9438-4cbf-9a72-4b9a7fb29930", "ea9eadd7-07d4-4840-88af-d86998f0b716" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "c9834247-9438-4cbf-9a72-4b9a7fb29930", "fdd9e980-a653-4ef9-9353-a6e11d0b7e8c" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "e81ba74d-2440-440e-bc91-93fd9d5c186b", "1a85842d-241c-4773-be2f-54f047dc3307" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "e81ba74d-2440-440e-bc91-93fd9d5c186b", "ea9eadd7-07d4-4840-88af-d86998f0b716" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "e93b9e54-6f3a-4672-bf06-76682abf9b16", "3adbda9d-1e72-4ed1-bb21-84a4fa515dab" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "e93b9e54-6f3a-4672-bf06-76682abf9b16", "a98d3bda-464b-4cee-9f13-0e3e7b057c97" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "f122ad11-e823-406a-9bf4-ff5a1463462f", "4c805900-0439-4e12-a8a8-9b41c41243ab" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "f122ad11-e823-406a-9bf4-ff5a1463462f", "5c4aaa6a-3fde-4474-9616-e94d9f31db70" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "f122ad11-e823-406a-9bf4-ff5a1463462f", "9720f493-2987-4856-9197-bc58add21994" });

            migrationBuilder.DeleteData(
                table: "NewsTags",
                keyColumns: new[] { "NewsArticleId", "TagId" },
                keyValues: new object[] { "f122ad11-e823-406a-9bf4-ff5a1463462f", "b918e898-7044-4d4f-a25d-dd1ec892477b" });

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "08a71291-df33-4468-b825-ac42cd682ce0");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "6f4cfd29-b515-430d-954d-29f04491b136");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "e609065a-8a36-4d5d-b1b9-2af55a123367");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "521461b0-2a80-4d5c-8567-b9d5ed6aae66");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "009c3ae2-bbcd-448f-b574-c16a12872c67");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "0a305430-69aa-4ce6-b100-7e2e3856325e");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "258ec250-a032-4cd5-b32e-a90869a68562");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "26c85523-9687-4960-87ec-6573454ecc58");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "33cf89da-6b18-489a-8bbe-66e747b8cb89");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "379cc9b0-d3b1-4b5f-8508-175e349e0410");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "46f29f09-63df-4ab8-a40a-d5287b857eca");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "4a6c0e55-38c4-4912-bf37-4ea5e8eea92d");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "5a39b647-5bb5-43dd-a8ea-625a04da0fa8");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "5a3b046a-05fd-45b0-8a8f-5128fc7e7939");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "5bdbc52c-6ff4-4bb4-9bff-a4eaa52d197d");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "5e8fc9d0-05ed-49f6-bbce-6bcc90803a74");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "724d4173-a964-4b01-877d-8939df35bc1d");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "7b43a7bd-2db9-4f05-b335-c7d8fafe73ea");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "7f80144e-2cc6-4201-aebe-ec7c7a09a1d4");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "802c5661-eda8-4b42-ad1a-166cb588dc05");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "9267f91e-6648-4c52-98f4-35598cd01f0c");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "a9e377c3-de4c-4d68-adad-382569227984");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "aaf1dc0b-915c-4598-ac93-72d09f1cfba7");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "bc49a86e-459f-4b41-a031-e2942808ba59");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "c36a6a3a-8c6c-4ad4-b3d7-0e352b812a31");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "c9834247-9438-4cbf-9a72-4b9a7fb29930");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "e81ba74d-2440-440e-bc91-93fd9d5c186b");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "e93b9e54-6f3a-4672-bf06-76682abf9b16");

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: "f122ad11-e823-406a-9bf4-ff5a1463462f");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "075084b9-c21d-463c-bd59-b0e388baecb4");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "08ee4872-65ed-4b3f-966b-f7568556275f");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "1a85842d-241c-4773-be2f-54f047dc3307");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "1c38e6ed-9100-4a51-9a0f-fc42a3b726d3");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "243fec52-92d7-426c-ac71-fb8ee94a7788");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "2982951d-5a91-4c0c-b58e-18a32a7d381b");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "320743f5-a2df-4b92-bade-a92011fb5f19");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "34a548e5-ee5a-4e6b-b7f2-a95dfb020804");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "39f45f39-01c6-4e1a-96d9-c0a180deda1f");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "3adbda9d-1e72-4ed1-bb21-84a4fa515dab");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "3aeb1f76-2f18-45f9-9ea2-c1b488984edb");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "4a84e146-1c1f-4fba-98d9-0659460dbc3f");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "4c805900-0439-4e12-a8a8-9b41c41243ab");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "4d8beb4c-4d56-4517-b509-cb4bc21c0559");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "5c4aaa6a-3fde-4474-9616-e94d9f31db70");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "8456c06b-4d67-4db6-9e0f-9f2dcc4cef2b");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "86b39a89-3588-432c-a294-d47b05c0f12c");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "9720f493-2987-4856-9197-bc58add21994");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "a98d3bda-464b-4cee-9f13-0e3e7b057c97");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "abca5a96-a113-4b62-986d-bdde9ad74ac6");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "ac611768-3b81-4cae-a473-1c251d2333fc");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "b918e898-7044-4d4f-a25d-dd1ec892477b");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "ea9eadd7-07d4-4840-88af-d86998f0b716");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "fdd9e980-a653-4ef9-9353-a6e11d0b7e8c");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "007e6d98-387b-4048-ad2f-9bd8f0bc4d74");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "0e3788f2-8b0a-47a5-a130-1452972025bd");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "266b486f-5389-4ecb-9d49-e45bd79c1ff9");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "27dffebf-9ac6-43c3-9f4f-5855394af11e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2dc87923-74b9-4403-81ea-97ea4c57ca02");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "7f9b03b3-ee86-41bc-8f54-5a1afc6d5342");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "84a628bb-a886-492e-9766-9fc25f17ac9d");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "8efda896-9075-4198-8c2d-e6f42b5fb79a");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "c24b3184-083a-4831-9828-2f93f5ae3f21");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ca078160-6bc0-49ad-869f-2a6588f35573");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "eaf19e11-72c6-4baf-b4e5-58c5f2f1d2af");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "eba490d7-74e5-4d5b-b6dd-771a02e1bb82");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "ec8265b7-d899-4a89-bf12-1d8b566633ff");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f99f7276-bbfc-4ab1-9d2a-9cad7bf26ba7");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "00c8e53e-9825-4a0f-a689-b07ec9b4f4d6");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "00d3f0c6-e9c0-4c0c-8e76-339b2cc60e9b");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "2a2b4691-7f48-437a-90dd-0cbea52590cc");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "30ec03a3-edb6-459f-9f85-9d6d56625600");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "4dcb0ede-bdc8-40f1-884e-ace4786a0145");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "6283d1bf-bfc3-4b99-96cb-9825af009158");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "6dfe714f-9886-40ea-a0dd-864fe1dc4ef3");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "75dc7281-6259-4bde-bee0-3be7aabfc677");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "7be4d735-f5c3-4afd-bd97-950a672a42aa");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "831696b4-8803-404d-8990-1c178d208114");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "b3359099-b7c3-438e-af3f-5a74f415210f");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "c45be152-66e2-4635-a6e5-687f9d18e1bb");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "c6a02908-bdf5-49c8-8655-e6b281990077");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "cfa8daa3-2872-47b1-89c0-e4a14fa752c4");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "dca12f71-473a-4166-8da4-1cdde805371c");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "f14e2936-77ec-4496-a92b-cd7f0a915045");

            migrationBuilder.DeleteData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "fd8d8d31-0c3b-40a1-8cc4-ee26bdb7633d");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Tags",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "SystemAccounts",
                keyColumn: "Id",
                keyValue: "8908368e-4567-460c-bba9-38b60d8f225f",
                columns: new[] { "AccountPassword", "CreatedAt", "UpdatedAt" },
                values: new object[] { "$2b$10$S2fR3gA0B1C29gRX2aFRZ.jaVc2u5fWaY9D9zCLk3CmcdiLJ0rKpe", new DateTime(2025, 6, 5, 19, 55, 26, 888, DateTimeKind.Utc).AddTicks(2089), new DateTime(2025, 6, 5, 19, 55, 26, 888, DateTimeKind.Utc).AddTicks(2093) });
        }
    }
}
