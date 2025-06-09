using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("2743a523-ebfa-4bc2-bdb8-30771dfa2aa9"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("39725961-75c7-40fa-a1cb-f24d64dfd95b"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("5c16940b-ac71-444d-8931-f33ed77dfb03"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("8f8c0b4a-78dd-4816-823c-fb81c445c856"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("ce466fa5-f874-452f-a99f-ab77b89d7282"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("ef4d8cad-651a-4d82-8fa8-f42e5388b6e0"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("1601702e-c063-4fe1-91ca-932f63e7676a"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("229a00af-d47c-42fa-96be-f00eac1120b3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2d7a497c-8ccd-40c1-a6d3-6b33cd93b955"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("3098974a-c130-4ec9-86a3-45a3fa76630f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("50e86ad5-4f13-4420-bfe7-7dd8ca38bcd3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5df7e074-2bb2-48a5-ab79-59f024595c8a"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("73cc5603-732d-450f-8010-8e51124430de"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("73dc8f76-ad4b-41ed-826d-334bffc72015"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("90e9ce97-4d57-4847-8a03-1d5c19037f1b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b8a81c69-3124-47b5-892a-d06b5408c21a"));

            migrationBuilder.DropColumn(
                name: "IsStudent",
                table: "Candidates");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsStudent",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2743a523-ebfa-4bc2-bdb8-30771dfa2aa9"), "Middle" },
                    { new Guid("39725961-75c7-40fa-a1cb-f24d64dfd95b"), "Junior" },
                    { new Guid("5c16940b-ac71-444d-8931-f33ed77dfb03"), "Intern" },
                    { new Guid("8f8c0b4a-78dd-4816-823c-fb81c445c856"), "Fresher" },
                    { new Guid("ce466fa5-f874-452f-a99f-ab77b89d7282"), "Leader" },
                    { new Guid("ef4d8cad-651a-4d82-8fa8-f42e5388b6e0"), "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1601702e-c063-4fe1-91ca-932f63e7676a"), "JavaScript" },
                    { new Guid("229a00af-d47c-42fa-96be-f00eac1120b3"), "React" },
                    { new Guid("2d7a497c-8ccd-40c1-a6d3-6b33cd93b955"), "Python" },
                    { new Guid("3098974a-c130-4ec9-86a3-45a3fa76630f"), "ASP.NET Core" },
                    { new Guid("50e86ad5-4f13-4420-bfe7-7dd8ca38bcd3"), "Azure" },
                    { new Guid("5df7e074-2bb2-48a5-ab79-59f024595c8a"), "Java" },
                    { new Guid("73cc5603-732d-450f-8010-8e51124430de"), "HTML/CSS" },
                    { new Guid("73dc8f76-ad4b-41ed-826d-334bffc72015"), "Kubernetes" },
                    { new Guid("90e9ce97-4d57-4847-8a03-1d5c19037f1b"), "C#" },
                    { new Guid("b8a81c69-3124-47b5-892a-d06b5408c21a"), "SQL" }
                });
        }
    }
}
