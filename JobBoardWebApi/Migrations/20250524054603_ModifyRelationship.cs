using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "IsStudent",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Applications",
                newName: "CoverLetter");

            migrationBuilder.AddColumn<bool>(
                name: "IsStudent",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsStudent",
                table: "Candidates");

            migrationBuilder.RenameColumn(
                name: "CoverLetter",
                table: "Applications",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Candidates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsStudent",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
    }
}
