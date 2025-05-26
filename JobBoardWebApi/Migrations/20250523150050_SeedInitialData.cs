using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0fd1dd75-2b80-4a6d-952d-08e3cda36e5e"), "Orient Software" },
                    { new Guid("5f61f57d-5ba3-4eea-9be3-958e6c6f0e3e"), "VNG Corporation" },
                    { new Guid("65c08d5e-0793-42b1-a0eb-204801d2b71a"), "Axon Active" },
                    { new Guid("65e34caf-3ef1-46d2-a73e-5e47f48df565"), "FPT Software" },
                    { new Guid("78286ce9-5e78-47d7-ad5b-656048c8edd2"), "NashTech" },
                    { new Guid("9a194594-0a16-4135-a84b-39adad0f438f"), "KMS Technology" },
                    { new Guid("a37a3f46-812a-43fc-9243-1a758e0639ba"), "CMC Corporation" },
                    { new Guid("c16197f7-6298-4ccb-ae2a-328d7b7069b2"), "VNPT Technology" },
                    { new Guid("d1a26785-f84d-470c-a114-53ba16fb8f8c"), "TMA Solutions" },
                    { new Guid("e3e39a95-bc17-467c-96d9-56b8135e7136"), "Haravan" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("14300151-52fc-492f-a36a-f98853cae822"), "Senior" },
                    { new Guid("339d84b6-43ce-4f1d-8e91-14e04c1213d3"), "Middle" },
                    { new Guid("9fd640b0-7457-407f-9c0c-ba9bbb6015f7"), "Fresher" },
                    { new Guid("b51a7237-47ac-4bcf-8d7a-2e088bea0166"), "Junior" },
                    { new Guid("dff9cd6e-74a5-40aa-a27d-e9f16048ca5e"), "Leader" },
                    { new Guid("e02ce61f-85e0-4662-b87b-0930b9cbbf29"), "Intern" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0cdb6634-8f3a-4091-a838-fe6a42776766"), "JavaScript" },
                    { new Guid("1584de84-6a67-4454-8a6c-ad7fc44a1a76"), "C#" },
                    { new Guid("17ff414b-88a3-4e92-a8a7-3a107522f280"), "Azure" },
                    { new Guid("2681736f-4298-4605-9ca0-2ec4ee46c783"), "Kubernetes" },
                    { new Guid("46313e1c-a0ee-4696-a740-4d1d5d35994e"), "Python" },
                    { new Guid("8536948b-a699-4565-b283-a9b5895c524d"), "Java" },
                    { new Guid("b12f31d2-a71c-4589-8a31-d94e43968242"), "SQL" },
                    { new Guid("b3b936df-bb4e-43f3-ac93-5741cb9a142c"), "ASP.NET Core" },
                    { new Guid("ce17c151-eb47-4ff2-9fcb-7754575cad8d"), "HTML/CSS" },
                    { new Guid("e5cd282b-698b-4d06-9bb4-416c8ec6d4bf"), "React" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("0fd1dd75-2b80-4a6d-952d-08e3cda36e5e"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("5f61f57d-5ba3-4eea-9be3-958e6c6f0e3e"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("65c08d5e-0793-42b1-a0eb-204801d2b71a"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("65e34caf-3ef1-46d2-a73e-5e47f48df565"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("78286ce9-5e78-47d7-ad5b-656048c8edd2"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("9a194594-0a16-4135-a84b-39adad0f438f"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a37a3f46-812a-43fc-9243-1a758e0639ba"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("c16197f7-6298-4ccb-ae2a-328d7b7069b2"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("d1a26785-f84d-470c-a114-53ba16fb8f8c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("e3e39a95-bc17-467c-96d9-56b8135e7136"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("14300151-52fc-492f-a36a-f98853cae822"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("339d84b6-43ce-4f1d-8e91-14e04c1213d3"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("9fd640b0-7457-407f-9c0c-ba9bbb6015f7"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("b51a7237-47ac-4bcf-8d7a-2e088bea0166"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("dff9cd6e-74a5-40aa-a27d-e9f16048ca5e"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("e02ce61f-85e0-4662-b87b-0930b9cbbf29"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("0cdb6634-8f3a-4091-a838-fe6a42776766"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("1584de84-6a67-4454-8a6c-ad7fc44a1a76"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("17ff414b-88a3-4e92-a8a7-3a107522f280"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2681736f-4298-4605-9ca0-2ec4ee46c783"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("46313e1c-a0ee-4696-a740-4d1d5d35994e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("8536948b-a699-4565-b283-a9b5895c524d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b12f31d2-a71c-4589-8a31-d94e43968242"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b3b936df-bb4e-43f3-ac93-5741cb9a142c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("ce17c151-eb47-4ff2-9fcb-7754575cad8d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e5cd282b-698b-4d06-9bb4-416c8ec6d4bf"));
        }
    }
}
