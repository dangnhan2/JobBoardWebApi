using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class DeletePhotoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("1b9d9231-0f75-4b26-83e5-74684d966f01"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("44454340-b175-44a5-bdb1-9d442e570298"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("638aea10-8568-44c0-a7a1-d449a8924296"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("7258171b-6a45-4e7f-abfb-5c2d50afcb15"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("9359db04-313a-49d7-b833-91066a5881c2"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("9fbed620-b672-4549-a76b-abe468165e06"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("c69eee87-9652-4145-bfd0-ce4a52b4a782"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("e044bb03-c870-4d5b-b83d-88fb3684a800"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("fe2144cb-d08d-446b-b9df-523714c99e92"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("ffbf50b0-7305-4ac0-90c2-e49b7a08b984"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("00e1e3f4-daff-45db-b055-4e8283b1563d"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("518ff85c-661c-4b97-a343-854f8858dfe5"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("63f38ff1-6cb4-417d-b1b7-57d90e92bf05"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("b42ccaf7-a9dd-44e1-993e-7cbf2ca12d9d"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("d0a9fa35-223e-4284-b1fb-f07be08f8ee6"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("eae63649-3211-4b47-bc58-131254555c35"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("10cb0bd6-acc2-41e3-a061-1c7cf8a11ddd"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("13ed3b93-d012-41a1-89ae-c98b3c0b0442"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("26a3c7e6-f344-4bb0-9811-89ac178bedd3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5021f4c4-c732-4ace-960b-995247215fc7"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("52eff507-7d32-4178-bec0-7ecf7911c230"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5539df17-a840-4fff-8549-1019d5c9ce74"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("65cbc7ec-d3b9-4ab3-8573-fc0423dfe944"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("7259a9bc-e588-49b7-86a3-c96c8350285e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e2a19947-0929-4d22-a0ce-1909fe9df0a3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e6dec2bf-bcdf-4399-a788-d9eaa751c1a4"));

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
 
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicUrl",
                table: "AspNetUsers",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "LogoUrl",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ProfilePicUrl",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Photos_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1b9d9231-0f75-4b26-83e5-74684d966f01"), "Axon Active" },
                    { new Guid("44454340-b175-44a5-bdb1-9d442e570298"), "KMS Technology" },
                    { new Guid("638aea10-8568-44c0-a7a1-d449a8924296"), "TMA Solutions" },
                    { new Guid("7258171b-6a45-4e7f-abfb-5c2d50afcb15"), "VNG Corporation" },
                    { new Guid("9359db04-313a-49d7-b833-91066a5881c2"), "NashTech" },
                    { new Guid("9fbed620-b672-4549-a76b-abe468165e06"), "Orient Software" },
                    { new Guid("c69eee87-9652-4145-bfd0-ce4a52b4a782"), "Haravan" },
                    { new Guid("e044bb03-c870-4d5b-b83d-88fb3684a800"), "CMC Corporation" },
                    { new Guid("fe2144cb-d08d-446b-b9df-523714c99e92"), "FPT Software" },
                    { new Guid("ffbf50b0-7305-4ac0-90c2-e49b7a08b984"), "VNPT Technology" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00e1e3f4-daff-45db-b055-4e8283b1563d"), "Junior" },
                    { new Guid("518ff85c-661c-4b97-a343-854f8858dfe5"), "Intern" },
                    { new Guid("63f38ff1-6cb4-417d-b1b7-57d90e92bf05"), "Leader" },
                    { new Guid("b42ccaf7-a9dd-44e1-993e-7cbf2ca12d9d"), "Fresher" },
                    { new Guid("d0a9fa35-223e-4284-b1fb-f07be08f8ee6"), "Middle" },
                    { new Guid("eae63649-3211-4b47-bc58-131254555c35"), "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("10cb0bd6-acc2-41e3-a061-1c7cf8a11ddd"), "React" },
                    { new Guid("13ed3b93-d012-41a1-89ae-c98b3c0b0442"), "Java" },
                    { new Guid("26a3c7e6-f344-4bb0-9811-89ac178bedd3"), "C#" },
                    { new Guid("5021f4c4-c732-4ace-960b-995247215fc7"), "JavaScript" },
                    { new Guid("52eff507-7d32-4178-bec0-7ecf7911c230"), "Python" },
                    { new Guid("5539df17-a840-4fff-8549-1019d5c9ce74"), "Kubernetes" },
                    { new Guid("65cbc7ec-d3b9-4ab3-8573-fc0423dfe944"), "Azure" },
                    { new Guid("7259a9bc-e588-49b7-86a3-c96c8350285e"), "HTML/CSS" },
                    { new Guid("e2a19947-0929-4d22-a0ce-1909fe9df0a3"), "ASP.NET Core" },
                    { new Guid("e6dec2bf-bcdf-4399-a788-d9eaa751c1a4"), "SQL" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CompanyId",
                table: "Photos",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
