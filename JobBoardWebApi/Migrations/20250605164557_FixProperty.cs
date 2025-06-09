using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class FixProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Jobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31a84316-960e-406a-8e4b-b539cf1bab93", null, "Candidate", "CANDIDATE" },
                    { "463f62ca-7de3-4cee-b2b3-58553553042f", null, "Recruiter", "RECRUITER" },
                    { "5c5e2ff0-1ca7-4158-ab12-3cbd7e7baf99", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_At", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicUrl", "SecurityStamp", "TwoFactorEnabled", "Updated_At", "UserName" },
                values: new object[] { "d371b9c6-6812-41c1-83c5-c3f2cf774fbb", 0, "3b5f783b-004a-4b15-976a-016e9dbd1189", new DateTime(2025, 6, 5, 16, 45, 56, 11, DateTimeKind.Utc).AddTicks(212), "admin@example.com", true, "admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEJ/tVRysfAFzIwIy2l54ubdmB7psBvgU1YZesz+YXmeENtt9sFKmbNPysuEoCX2DSQ==", null, false, "https://res.cloudinary.com/dtihvekmn/image/upload/v1749112264/user_vga2r2.png", "", false, null, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("54639c66-5357-4bec-a7c6-b18a96a07ec3"), "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136149/haranvan_l9df1x.png", "Haravan" },
                    { new Guid("6ead7f21-4759-43be-836f-a50034e57505"), "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136592/kms-logo_mnuae3.png", "KMS Technology" },
                    { new Guid("a2c2456d-fe71-49b5-8561-bfaf7a916a9a"), "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136395/fpt-software_uorpkb.png", "FPT Software" },
                    { new Guid("e65108fc-581f-4a23-a6dd-c27c778430ff"), "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136683/VNPT-logo_ngjek0.jpg", "VNPT Technology" }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("080f6f19-46fb-4883-b3b9-94fe3941aad3"), "Fresher" },
                    { new Guid("48ff09a5-bb0b-436b-82e2-f1abe4567816"), "Leader" },
                    { new Guid("64169e4d-7e62-40d6-930f-4d9efd9a3e7a"), "Junior" },
                    { new Guid("76584184-a379-4704-acb3-addb8b10900f"), "Senior" },
                    { new Guid("9f9d8e2b-5f37-42b3-9e89-408173d0be34"), "Intern" },
                    { new Guid("a676a27e-a23e-4aa9-9e76-26cc457fa835"), "Middle" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c3282f9-4595-4b0c-9e0d-b4c634abd092"), "ASP.NET Core" },
                    { new Guid("15754ef6-63d2-4dde-bffe-1153bf4af403"), "Java" },
                    { new Guid("15d90349-015c-4b55-ad39-0add58d87d78"), "JavaScript" },
                    { new Guid("3058a4db-1879-479b-934b-e94863006151"), "Python" },
                    { new Guid("5fa25bf3-5f56-4ca9-bf6a-f96c6dd5634b"), "React" },
                    { new Guid("656e085d-5a9e-4b30-b339-a8aae8b38e92"), "Azure" },
                    { new Guid("969bb38e-2d42-4c18-b76d-876bdda806be"), "SQL" },
                    { new Guid("cc68de50-eba7-4eec-8292-4909ae18b0d7"), "HTML/CSS" },
                    { new Guid("e6d60769-0b6c-4322-84c5-f752087da6d2"), "C#" },
                    { new Guid("ea583aa5-324a-47df-be0a-051cd5bf919b"), "Kubernetes" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5c5e2ff0-1ca7-4158-ab12-3cbd7e7baf99", "d371b9c6-6812-41c1-83c5-c3f2cf774fbb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31a84316-960e-406a-8e4b-b539cf1bab93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "463f62ca-7de3-4cee-b2b3-58553553042f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5c5e2ff0-1ca7-4158-ab12-3cbd7e7baf99", "d371b9c6-6812-41c1-83c5-c3f2cf774fbb" });

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("54639c66-5357-4bec-a7c6-b18a96a07ec3"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6ead7f21-4759-43be-836f-a50034e57505"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a2c2456d-fe71-49b5-8561-bfaf7a916a9a"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("e65108fc-581f-4a23-a6dd-c27c778430ff"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("080f6f19-46fb-4883-b3b9-94fe3941aad3"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("48ff09a5-bb0b-436b-82e2-f1abe4567816"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("64169e4d-7e62-40d6-930f-4d9efd9a3e7a"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("76584184-a379-4704-acb3-addb8b10900f"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("9f9d8e2b-5f37-42b3-9e89-408173d0be34"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("a676a27e-a23e-4aa9-9e76-26cc457fa835"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("0c3282f9-4595-4b0c-9e0d-b4c634abd092"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("15754ef6-63d2-4dde-bffe-1153bf4af403"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("15d90349-015c-4b55-ad39-0add58d87d78"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("3058a4db-1879-479b-934b-e94863006151"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5fa25bf3-5f56-4ca9-bf6a-f96c6dd5634b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("656e085d-5a9e-4b30-b339-a8aae8b38e92"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("969bb38e-2d42-4c18-b76d-876bdda806be"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("cc68de50-eba7-4eec-8292-4909ae18b0d7"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e6d60769-0b6c-4322-84c5-f752087da6d2"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("ea583aa5-324a-47df-be0a-051cd5bf919b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c5e2ff0-1ca7-4158-ab12-3cbd7e7baf99");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d371b9c6-6812-41c1-83c5-c3f2cf774fbb");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
