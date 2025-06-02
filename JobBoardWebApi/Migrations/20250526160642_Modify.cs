using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Modify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("150a9cd7-b425-4c08-8111-8c65c8fe65e4"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("2479a6fa-8f27-4f3c-9347-370b670462fc"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("33ac2d39-5f8a-4cdd-9a70-48d84566bfd0"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("34ab60dc-3960-4683-8f52-02e09e7f85b5"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("38f6e635-a668-438e-bcaf-1496437567ac"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("40827481-aec8-4aec-8365-01266ce2e71d"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("45730681-a492-4dca-b0f2-328b217c148d"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("45799118-bd2d-4bea-8548-525da4c5a8cb"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("918c9268-83a7-48c4-ac99-0666bf7ec306"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("d4dbba25-69e4-4dde-9ec6-b8957369558f"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("277f7c38-5dcd-43bc-82a9-8b6d1582641a"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("2c87ee47-8df2-4901-b2b5-7b3365154f0f"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("4c538d10-7fbb-4c6d-ab13-015a1b0d674c"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("505dfd95-8791-4299-a4ec-fea374383f24"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("b46ed5b4-b6be-4c8f-90a4-2c8a1e9d1070"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("d1c3b82f-e64d-48e6-a086-1a31874ea4c1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2f72ee02-16cf-461a-b786-f1bdff01c861"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("51b42eca-b8c5-4851-ba8f-371fd3ae5a3b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("750c3e08-c59a-42b3-8b8f-018d8f323a2e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("8455dc33-5c0c-4876-b51a-035a4c44abbd"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9a6eb404-080d-49c6-969a-7300681fa568"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9ae62d2c-e96f-47b1-ba50-a7ce3d5890e6"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c211171a-2c9d-4406-8c87-87d4a2775665"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e53cd856-87a0-4d27-a9c4-7686b6028de5"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("f1c71f60-6650-443c-b22a-befb1f80683d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("f964ac54-8cb5-42a4-8948-c9188bbb47e0"));

            migrationBuilder.DropColumn(
                name: "FileUrl",
                table: "Applications");

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0186cef8-f6a4-4ae1-bfeb-163fa9bcc572"), "Intern" },
                    { new Guid("22441847-bd3d-4586-89ad-5cd11af6016b"), "Fresher" },
                    { new Guid("67873b2b-7536-4ec8-8ecf-5dfb0627c71b"), "Junior" },
                    { new Guid("78784ac1-61a2-45f6-90b9-65f37407840e"), "Leader" },
                    { new Guid("88c9d23e-a378-4561-9786-d0769743bdd2"), "Middle" },
                    { new Guid("96847469-1a7a-4b29-bd7f-273700fff90c"), "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ace6866-999f-4d6a-974c-0db9a3d9de59"), "HTML/CSS" },
                    { new Guid("0deefa0c-07f1-421e-8b55-81631fa9b55e"), "Python" },
                    { new Guid("2a47e95b-1298-49ec-af21-89b49db3b907"), "ASP.NET Core" },
                    { new Guid("347b35e2-73e0-4a05-a44c-2857cb40907e"), "C#" },
                    { new Guid("3de872c5-cf64-4fba-ad20-9eb562b40908"), "Kubernetes" },
                    { new Guid("4f4ecbfd-5a0d-4cdb-9a9c-5fe141bf5744"), "SQL" },
                    { new Guid("80b8da0b-77a3-482c-a908-037b34acb083"), "Azure" },
                    { new Guid("c85ae328-bc80-413d-a841-663e45d5ae37"), "JavaScript" },
                    { new Guid("d8885370-6f0a-4bd1-b5eb-766cd7a3eafb"), "React" },
                    { new Guid("fd3f0b0f-2baa-4067-8c08-9ff62f997be2"), "Java" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("0186cef8-f6a4-4ae1-bfeb-163fa9bcc572"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("22441847-bd3d-4586-89ad-5cd11af6016b"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("67873b2b-7536-4ec8-8ecf-5dfb0627c71b"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("78784ac1-61a2-45f6-90b9-65f37407840e"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("88c9d23e-a378-4561-9786-d0769743bdd2"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("96847469-1a7a-4b29-bd7f-273700fff90c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("0ace6866-999f-4d6a-974c-0db9a3d9de59"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("0deefa0c-07f1-421e-8b55-81631fa9b55e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2a47e95b-1298-49ec-af21-89b49db3b907"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("347b35e2-73e0-4a05-a44c-2857cb40907e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("3de872c5-cf64-4fba-ad20-9eb562b40908"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("4f4ecbfd-5a0d-4cdb-9a9c-5fe141bf5744"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("80b8da0b-77a3-482c-a908-037b34acb083"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c85ae328-bc80-413d-a841-663e45d5ae37"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("d8885370-6f0a-4bd1-b5eb-766cd7a3eafb"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("fd3f0b0f-2baa-4067-8c08-9ff62f997be2"));

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("150a9cd7-b425-4c08-8111-8c65c8fe65e4"), "/images/logo/cmc.png", "CMC Corporation" },
                    { new Guid("2479a6fa-8f27-4f3c-9347-370b670462fc"), "/images/logo/vng.png", "VNG Corporation" },
                    { new Guid("33ac2d39-5f8a-4cdd-9a70-48d84566bfd0"), "/images/logo/VNPT-logo.png", "VNPT Technology" },
                    { new Guid("34ab60dc-3960-4683-8f52-02e09e7f85b5"), "/images/logo/VNPT-logo.png", "Orient Software" },
                    { new Guid("38f6e635-a668-438e-bcaf-1496437567ac"), "/images/logo/axon.png", "Axon Active" },
                    { new Guid("40827481-aec8-4aec-8365-01266ce2e71d"), "/images/logo/nash-tech.png", "NashTech" },
                    { new Guid("45730681-a492-4dca-b0f2-328b217c148d"), "/images/logo/haranvan.png", "Haravan" },
                    { new Guid("45799118-bd2d-4bea-8548-525da4c5a8cb"), "/images/logo/kms-logo.png", "KMS Technology" },
                    { new Guid("918c9268-83a7-48c4-ac99-0666bf7ec306"), "/images/logo/fpt-software.png", "FPT Software" },
                    { new Guid("d4dbba25-69e4-4dde-9ec6-b8957369558f"), "/images/logo/TMA-Solutions-Logo.png", "TMA Solutions" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("277f7c38-5dcd-43bc-82a9-8b6d1582641a"), "Middle" },
                    { new Guid("2c87ee47-8df2-4901-b2b5-7b3365154f0f"), "Junior" },
                    { new Guid("4c538d10-7fbb-4c6d-ab13-015a1b0d674c"), "Leader" },
                    { new Guid("505dfd95-8791-4299-a4ec-fea374383f24"), "Senior" },
                    { new Guid("b46ed5b4-b6be-4c8f-90a4-2c8a1e9d1070"), "Intern" },
                    { new Guid("d1c3b82f-e64d-48e6-a086-1a31874ea4c1"), "Fresher" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2f72ee02-16cf-461a-b786-f1bdff01c861"), "Kubernetes" },
                    { new Guid("51b42eca-b8c5-4851-ba8f-371fd3ae5a3b"), "HTML/CSS" },
                    { new Guid("750c3e08-c59a-42b3-8b8f-018d8f323a2e"), "JavaScript" },
                    { new Guid("8455dc33-5c0c-4876-b51a-035a4c44abbd"), "Azure" },
                    { new Guid("9a6eb404-080d-49c6-969a-7300681fa568"), "ASP.NET Core" },
                    { new Guid("9ae62d2c-e96f-47b1-ba50-a7ce3d5890e6"), "C#" },
                    { new Guid("c211171a-2c9d-4406-8c87-87d4a2775665"), "Python" },
                    { new Guid("e53cd856-87a0-4d27-a9c4-7686b6028de5"), "Java" },
                    { new Guid("f1c71f60-6650-443c-b22a-befb1f80683d"), "SQL" },
                    { new Guid("f964ac54-8cb5-42a4-8948-c9188bbb47e0"), "React" }
                });
        }
    }
}
