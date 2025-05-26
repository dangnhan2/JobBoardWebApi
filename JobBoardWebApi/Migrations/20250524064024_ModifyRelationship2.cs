using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRelationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("13c634ad-969d-4879-8f96-1a8ec11e48ba"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("24ce043b-ab70-479c-85dc-321069cb8cef"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("36726b0e-fe49-4abe-9afc-3716c97b9e1d"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("74e58484-0df8-488c-976d-d68391ed68de"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("75b13a09-e9ef-47f1-8673-a0671ff44605"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("ca61669a-c760-43f3-bf35-8869a1c4412e"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("d4d39007-93cb-477a-aa0b-1f80d56847c5"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("dfc4ce6c-2c82-4833-bd4f-af4ed437d03b"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("e041ccda-c2b2-46bf-80bb-71bf2e3dd30d"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("f4c64c4e-81cd-4055-b6ed-060ce85bdf64"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("0fdf1ddc-1338-43a2-a086-fd0514f84a5e"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("5040bd75-0eff-4b0d-a33b-3f1fd03d1b1b"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("96611516-6784-4015-81e7-d6e8c7fb5aeb"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("cab2a3f3-521e-4c35-af83-54481fafe4ad"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("d652052c-52ed-4821-951c-8d7815647ecf"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("f17c7965-aed2-4f1b-8ce9-c70071b9995a"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2761bee2-5547-4c30-8534-184edddbae90"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2c08383d-ddb8-49ca-8031-7f7d52d42d30"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2c5db1c5-a36e-4439-a0f4-2804d2c2ad6f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("32cddf5c-eaf9-4957-8691-9cb416587c44"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("91e0bf0f-a2c5-4110-b107-366ed740f8c1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9293412b-c01e-4595-a926-b2f03bdfc469"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a4ec4c5b-b3fb-4ff4-8f18-31093fbcbec8"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a62f9ce7-b62f-46f7-8108-bc3479d6c1c1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("d65fe7c6-d6ea-4c30-816b-ae54d56739fc"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e977c0fd-3a80-4a7a-9dd1-e99a469811e6"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("13c634ad-969d-4879-8f96-1a8ec11e48ba"), "VNG Corporation" },
                    { new Guid("24ce043b-ab70-479c-85dc-321069cb8cef"), "NashTech" },
                    { new Guid("36726b0e-fe49-4abe-9afc-3716c97b9e1d"), "FPT Software" },
                    { new Guid("74e58484-0df8-488c-976d-d68391ed68de"), "Orient Software" },
                    { new Guid("75b13a09-e9ef-47f1-8673-a0671ff44605"), "VNPT Technology" },
                    { new Guid("ca61669a-c760-43f3-bf35-8869a1c4412e"), "CMC Corporation" },
                    { new Guid("d4d39007-93cb-477a-aa0b-1f80d56847c5"), "Axon Active" },
                    { new Guid("dfc4ce6c-2c82-4833-bd4f-af4ed437d03b"), "Haravan" },
                    { new Guid("e041ccda-c2b2-46bf-80bb-71bf2e3dd30d"), "TMA Solutions" },
                    { new Guid("f4c64c4e-81cd-4055-b6ed-060ce85bdf64"), "KMS Technology" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0fdf1ddc-1338-43a2-a086-fd0514f84a5e"), "Intern" },
                    { new Guid("5040bd75-0eff-4b0d-a33b-3f1fd03d1b1b"), "Fresher" },
                    { new Guid("96611516-6784-4015-81e7-d6e8c7fb5aeb"), "Leader" },
                    { new Guid("cab2a3f3-521e-4c35-af83-54481fafe4ad"), "Junior" },
                    { new Guid("d652052c-52ed-4821-951c-8d7815647ecf"), "Middle" },
                    { new Guid("f17c7965-aed2-4f1b-8ce9-c70071b9995a"), "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2761bee2-5547-4c30-8534-184edddbae90"), "Kubernetes" },
                    { new Guid("2c08383d-ddb8-49ca-8031-7f7d52d42d30"), "ASP.NET Core" },
                    { new Guid("2c5db1c5-a36e-4439-a0f4-2804d2c2ad6f"), "Java" },
                    { new Guid("32cddf5c-eaf9-4957-8691-9cb416587c44"), "SQL" },
                    { new Guid("91e0bf0f-a2c5-4110-b107-366ed740f8c1"), "JavaScript" },
                    { new Guid("9293412b-c01e-4595-a926-b2f03bdfc469"), "Python" },
                    { new Guid("a4ec4c5b-b3fb-4ff4-8f18-31093fbcbec8"), "Azure" },
                    { new Guid("a62f9ce7-b62f-46f7-8108-bc3479d6c1c1"), "C#" },
                    { new Guid("d65fe7c6-d6ea-4c30-816b-ae54d56739fc"), "React" },
                    { new Guid("e977c0fd-3a80-4a7a-9dd1-e99a469811e6"), "HTML/CSS" }
                });
        }
    }
}
