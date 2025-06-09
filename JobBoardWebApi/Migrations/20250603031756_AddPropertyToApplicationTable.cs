using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyToApplicationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66771e52-2306-4aef-b47d-b66bf9d8f10d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "681d0ca1-0e28-47ec-b9bd-aa42ca405a47");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "38436e3a-3c96-45c1-b5ce-bb8c7c998b93", "c930410f-cde8-4ff2-b283-7fc9eec96daf" });

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("0b665bdd-f95d-43d1-a8ae-9d43cc8e1829"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("2b0dd4c9-bd9c-4f04-b0c5-0659127506f6"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("3a212b83-3b2c-4acd-b7c8-b5708f1e68f4"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("a56a8a16-c280-4cdc-af27-b2841f2e8eff"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("d25023ca-7ca1-4c98-a678-9ba6c3ad8a2c"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("d79cca6d-6038-4ebd-976c-4488af047e35"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("276ac93c-4ec6-40cd-8af6-4915ff3e794e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("49885973-302d-42f8-94b9-a58e64439ccb"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("688baf0c-755e-4ada-88e9-59ce50b7ba9d"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("87149141-8499-46a9-9a5d-8625fdd590be"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("966b5854-6065-4ec1-8bda-11f4772d0391"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a84a0987-8ce4-494d-b6f2-34ffe24a6008"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a8f0df14-4420-446c-9fb0-fb156a57b1da"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("accad461-3aa5-4348-a2db-1223042a5baa"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c25db4f3-72bb-4c7e-ab56-e418cdb92da8"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("fe6c9a77-1df1-4171-8924-c58d4a368e22"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38436e3a-3c96-45c1-b5ce-bb8c7c998b93");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c930410f-cde8-4ff2-b283-7fc9eec96daf");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Applications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "085d0bd4-eaa5-4e92-887a-67b299c7542a", null, "Admin", "ADMIN" },
                    { "6c2806ed-74a0-4208-9796-97fb30fdc39a", null, "Recruiter", "RECRUITER" },
                    { "e89b993e-abea-4e78-821a-acd7a4e0b904", null, "Candidate", "CANDIDATE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_At", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicUrl", "SecurityStamp", "TwoFactorEnabled", "Updated_At", "UserName" },
                values: new object[] { "102592f6-e53a-4065-a361-cde5d9f3702b", 0, "a6712f74-7bf7-4914-94ea-8761f4ce4bc2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", true, "admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEH01w8Lh7LGDmssa2WqAzyH8ORSN1+ipovx4j4cmBAn98sUbfcj75z/bIBABgbsskQ==", null, false, "user.png", "", false, null, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("039062d3-fc22-47f2-a7b5-eacfdd3cfabc"), "Fresher" },
                    { new Guid("1be73c60-f680-472c-9207-83961deac57a"), "Intern" },
                    { new Guid("3fe31d54-d4a6-4449-9518-bb66b830fe92"), "Senior" },
                    { new Guid("72d37903-1614-47e9-b838-81d44596c06d"), "Leader" },
                    { new Guid("81306599-659c-4be3-9a00-12a3cbe853bd"), "Junior" },
                    { new Guid("eddf71d5-8488-4c9c-ab8d-4723c649281a"), "Middle" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1901c160-dd1d-4c88-8752-b1ee1fc88346"), "Python" },
                    { new Guid("4557d052-f8b5-4d8f-b8b6-89611a065c5f"), "SQL" },
                    { new Guid("479c5e1d-bf4e-451b-b4a3-36ee17e8b233"), "JavaScript" },
                    { new Guid("524157b6-7e94-4aac-9ccc-4a68e3292a19"), "ASP.NET Core" },
                    { new Guid("535bbbe3-595a-4cf6-94cc-17df5f039768"), "Java" },
                    { new Guid("77631c1f-7316-47ce-9fb0-ea41eb88818a"), "HTML/CSS" },
                    { new Guid("7b6186ff-34c2-40b4-995f-03852933d668"), "C#" },
                    { new Guid("844c5b98-6c66-4992-801c-95884909d8bc"), "React" },
                    { new Guid("9a7e2423-4ccf-42ad-88cf-59374ff26bed"), "Kubernetes" },
                    { new Guid("e2f7d43d-fac5-4f1b-a0ce-c8ad5b0254a1"), "Azure" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "085d0bd4-eaa5-4e92-887a-67b299c7542a", "102592f6-e53a-4065-a361-cde5d9f3702b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c2806ed-74a0-4208-9796-97fb30fdc39a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e89b993e-abea-4e78-821a-acd7a4e0b904");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "085d0bd4-eaa5-4e92-887a-67b299c7542a", "102592f6-e53a-4065-a361-cde5d9f3702b" });

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("039062d3-fc22-47f2-a7b5-eacfdd3cfabc"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("1be73c60-f680-472c-9207-83961deac57a"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("3fe31d54-d4a6-4449-9518-bb66b830fe92"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("72d37903-1614-47e9-b838-81d44596c06d"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("81306599-659c-4be3-9a00-12a3cbe853bd"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("eddf71d5-8488-4c9c-ab8d-4723c649281a"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("1901c160-dd1d-4c88-8752-b1ee1fc88346"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("4557d052-f8b5-4d8f-b8b6-89611a065c5f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("479c5e1d-bf4e-451b-b4a3-36ee17e8b233"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("524157b6-7e94-4aac-9ccc-4a68e3292a19"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("535bbbe3-595a-4cf6-94cc-17df5f039768"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("77631c1f-7316-47ce-9fb0-ea41eb88818a"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("7b6186ff-34c2-40b4-995f-03852933d668"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("844c5b98-6c66-4992-801c-95884909d8bc"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9a7e2423-4ccf-42ad-88cf-59374ff26bed"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e2f7d43d-fac5-4f1b-a0ce-c8ad5b0254a1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "085d0bd4-eaa5-4e92-887a-67b299c7542a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "102592f6-e53a-4065-a361-cde5d9f3702b");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Applications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38436e3a-3c96-45c1-b5ce-bb8c7c998b93", null, "Admin", "ADMIN" },
                    { "66771e52-2306-4aef-b47d-b66bf9d8f10d", null, "Recruiter", "RECRUITER" },
                    { "681d0ca1-0e28-47ec-b9bd-aa42ca405a47", null, "Candidate", "CANDIDATE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_At", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicUrl", "SecurityStamp", "TwoFactorEnabled", "Updated_At", "UserName" },
                values: new object[] { "c930410f-cde8-4ff2-b283-7fc9eec96daf", 0, "ee3a9e9c-5f1b-4040-837b-89b289001175", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", true, "admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAENwlw2ZeMfJUlZq6oHtHLp1JDYlQifY6AYebeZFBNbrZD6Ea7bO3K6t8K3e1EyOLwA==", null, false, "user.png", "", false, null, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0b665bdd-f95d-43d1-a8ae-9d43cc8e1829"), "Intern" },
                    { new Guid("2b0dd4c9-bd9c-4f04-b0c5-0659127506f6"), "Junior" },
                    { new Guid("3a212b83-3b2c-4acd-b7c8-b5708f1e68f4"), "Fresher" },
                    { new Guid("a56a8a16-c280-4cdc-af27-b2841f2e8eff"), "Leader" },
                    { new Guid("d25023ca-7ca1-4c98-a678-9ba6c3ad8a2c"), "Senior" },
                    { new Guid("d79cca6d-6038-4ebd-976c-4488af047e35"), "Middle" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("276ac93c-4ec6-40cd-8af6-4915ff3e794e"), "Kubernetes" },
                    { new Guid("49885973-302d-42f8-94b9-a58e64439ccb"), "HTML/CSS" },
                    { new Guid("688baf0c-755e-4ada-88e9-59ce50b7ba9d"), "SQL" },
                    { new Guid("87149141-8499-46a9-9a5d-8625fdd590be"), "Python" },
                    { new Guid("966b5854-6065-4ec1-8bda-11f4772d0391"), "Azure" },
                    { new Guid("a84a0987-8ce4-494d-b6f2-34ffe24a6008"), "ASP.NET Core" },
                    { new Guid("a8f0df14-4420-446c-9fb0-fb156a57b1da"), "JavaScript" },
                    { new Guid("accad461-3aa5-4348-a2db-1223042a5baa"), "React" },
                    { new Guid("c25db4f3-72bb-4c7e-ab56-e418cdb92da8"), "Java" },
                    { new Guid("fe6c9a77-1df1-4171-8924-c58d4a368e22"), "C#" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "38436e3a-3c96-45c1-b5ce-bb8c7c998b93", "c930410f-cde8-4ff2-b283-7fc9eec96daf" });
        }
    }
}
