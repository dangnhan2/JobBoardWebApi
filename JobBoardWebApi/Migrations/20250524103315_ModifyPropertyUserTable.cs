using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifyPropertyUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("07696292-fdc1-4071-abf1-54d6bf5ac159"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("08cefb8f-903b-4536-a1a2-724d4ade6683"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("141f026d-818e-4db2-9303-dd5086ca8eb4"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("2bf2ae74-b4c8-4b08-9c39-0ffe9b31f833"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("30c8e055-d99c-49d1-9dc5-25bf604f3f54"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("62ec5ec2-7bcc-4b7b-887b-38411829e300"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("737112fe-4cf2-438c-ad43-3b7f67934956"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a9d1336e-b791-496c-8ef3-5a6e17085071"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("d21b96f2-791f-4e9a-9b2d-d2281247521f"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("efa12fb9-f271-47b8-ae4f-d0730db93a3d"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("1ade31c0-e683-484c-aea6-2a20593fb06d"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("2aa51ec9-f40f-4ba4-ba91-5a9fcec43c81"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("79d411ad-b4f9-4341-85c4-a2dbc4edccdf"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("7fd0b9f4-5962-4ace-86d2-58cc63ddde40"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("807a693a-fa3c-4b9c-a35a-c76f86113bf0"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("8f694ed2-d368-40ef-b0a1-87af67c2ad14"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("24f12b25-a9d0-457e-bbe7-9d592acafc66"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2f02348e-dc1a-4ad2-95b1-2fadf7d52a2c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("3b39e73e-96e0-415a-99a7-61be4bf46aba"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("76140bec-0ac8-4492-a980-004e920f7c37"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("7d6e0e43-8523-48f2-a585-4f5715a3bf14"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("86ad2571-2385-43f5-8b30-cb55f98db917"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("908d351a-7502-4f79-91fc-15fbca65aa74"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a05f33b9-eb95-4177-a075-caa458d4c5e8"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a78d2ac9-7df4-4989-8db8-55b9809a2670"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b9370821-8382-45a7-aa25-b42324b47a36"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("07696292-fdc1-4071-abf1-54d6bf5ac159"), "VNG Corporation" },
                    { new Guid("08cefb8f-903b-4536-a1a2-724d4ade6683"), "CMC Corporation" },
                    { new Guid("141f026d-818e-4db2-9303-dd5086ca8eb4"), "VNPT Technology" },
                    { new Guid("2bf2ae74-b4c8-4b08-9c39-0ffe9b31f833"), "Orient Software" },
                    { new Guid("30c8e055-d99c-49d1-9dc5-25bf604f3f54"), "NashTech" },
                    { new Guid("62ec5ec2-7bcc-4b7b-887b-38411829e300"), "Axon Active" },
                    { new Guid("737112fe-4cf2-438c-ad43-3b7f67934956"), "KMS Technology" },
                    { new Guid("a9d1336e-b791-496c-8ef3-5a6e17085071"), "FPT Software" },
                    { new Guid("d21b96f2-791f-4e9a-9b2d-d2281247521f"), "Haravan" },
                    { new Guid("efa12fb9-f271-47b8-ae4f-d0730db93a3d"), "TMA Solutions" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1ade31c0-e683-484c-aea6-2a20593fb06d"), "Senior" },
                    { new Guid("2aa51ec9-f40f-4ba4-ba91-5a9fcec43c81"), "Intern" },
                    { new Guid("79d411ad-b4f9-4341-85c4-a2dbc4edccdf"), "Middle" },
                    { new Guid("7fd0b9f4-5962-4ace-86d2-58cc63ddde40"), "Junior" },
                    { new Guid("807a693a-fa3c-4b9c-a35a-c76f86113bf0"), "Fresher" },
                    { new Guid("8f694ed2-d368-40ef-b0a1-87af67c2ad14"), "Leader" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("24f12b25-a9d0-457e-bbe7-9d592acafc66"), "SQL" },
                    { new Guid("2f02348e-dc1a-4ad2-95b1-2fadf7d52a2c"), "HTML/CSS" },
                    { new Guid("3b39e73e-96e0-415a-99a7-61be4bf46aba"), "Kubernetes" },
                    { new Guid("76140bec-0ac8-4492-a980-004e920f7c37"), "React" },
                    { new Guid("7d6e0e43-8523-48f2-a585-4f5715a3bf14"), "Python" },
                    { new Guid("86ad2571-2385-43f5-8b30-cb55f98db917"), "Java" },
                    { new Guid("908d351a-7502-4f79-91fc-15fbca65aa74"), "C#" },
                    { new Guid("a05f33b9-eb95-4177-a075-caa458d4c5e8"), "ASP.NET Core" },
                    { new Guid("a78d2ac9-7df4-4989-8db8-55b9809a2670"), "Azure" },
                    { new Guid("b9370821-8382-45a7-aa25-b42324b47a36"), "JavaScript" }
                });
        }
    }
}
