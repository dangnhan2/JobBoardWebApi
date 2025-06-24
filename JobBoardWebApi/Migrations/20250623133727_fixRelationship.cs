using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class fixRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recruiters_CompanyId",
                table: "Recruiters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63e4997b-47aa-4b34-9477-85abe85631d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "865a9978-eb6b-4090-b385-41c96fc4911c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a3caa20c-d657-4a76-a6bd-0608454f160a", "cd7429a7-6312-445a-9424-b1d44be7286d" });

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("02f4d5e0-757f-41d6-a55d-84e220373a3d"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("4ea38c62-6064-496c-afda-5abbf87589b0"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("a97a6c5e-4abc-45ac-a16d-e1314d37aa22"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("c0c1bc1b-0f5b-4be1-b32e-6db1d85ff01a"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("4134c7da-72ad-415a-8295-b0cc10b156d4"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("53345452-2c7c-4c77-b7c3-8acc0e12c1d8"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("a06166aa-8aca-4d67-b347-74b247f4e955"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("a13bd4d7-450c-4b8f-a006-ae61f0c56def"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("c95a7dc2-2149-42fd-aac7-3274ee039076"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("eb7573ba-dbfd-4dc1-92cd-f0de3c559730"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("02e702f5-4f18-41c5-8954-989b2e2aa561"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("529fb769-fea1-4fc0-abff-5747d9ce1c08"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("73fab2c8-7f00-44cc-9e18-4efdf9fb3c5f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("74dd3d14-b08c-411c-b32d-a5e059b02c75"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b1e1f84a-65e2-4f12-adf9-9f3e1218b069"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b4fd346f-2cff-4eec-80e5-30bf11379120"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b8478816-557f-4ebd-9208-c283b0d302f1"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("cb7204fb-2d89-4e2f-8510-ee8c38b952e3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("d05dbe4d-03d4-4598-8de1-eea016203cd9"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("f2164e73-7359-4d0a-bbe1-78ea4a7cdcd6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3caa20c-d657-4a76-a6bd-0608454f160a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd7429a7-6312-445a-9424-b1d44be7286d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7c6399a6-a2ab-4c02-afb9-b7a4ff29aeae", null, "Admin", "ADMIN" },
                    { "8409056b-d1b8-4090-8faa-501d616158c8", null, "Candidate", "CANDIDATE" },
                    { "cbcbd7e8-7109-4021-9780-4e13bc9c0e8d", null, "Recruiter", "RECRUITER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_At", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicUrl", "SecurityStamp", "TwoFactorEnabled", "Updated_At", "UserName" },
                values: new object[] { "33ff7280-40c3-439a-9f08-0a9fcec6a744", 0, "2fa7b7d8-d7ac-4452-88ef-4c628f2b4a37", new DateTime(2025, 6, 23, 13, 37, 26, 552, DateTimeKind.Utc).AddTicks(5776), "admin@example.com", true, "admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHyOLtjRGaooQOdqM/Y+rnbSvE+VjpnXZM3aeHdRz56pvhh0OAFqFHedP71DrPE+Yg==", null, false, "https://res.cloudinary.com/dtihvekmn/image/upload/v1749112264/user_vga2r2.png", "", false, null, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Created_At", "LogoUrl", "Name", "Updated_at" },
                values: new object[,]
                {
                    { new Guid("55805609-b925-4c9f-94ea-8703e3a07dfb"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5655), "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136149/haranvan_l9df1x.png", "Haravan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5e606485-ed68-4b55-915e-2e2beaffd99d"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5641), "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136395/fpt-software_uorpkb.png", "FPT Software", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6da8d8a3-e511-480f-98e8-96ce370fffe9"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5650), "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136683/VNPT-logo_ngjek0.jpg", "VNPT Technology", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("94a48e01-47ab-41ea-ad04-a6bdedeb3932"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5653), "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136592/kms-logo_mnuae3.png", "KMS Technology", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Created_At", "Name", "Updated_at" },
                values: new object[,]
                {
                    { new Guid("042a31d6-68ab-45b5-9529-b4f109f02ea9"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5227), "Fresher", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("466db784-2a8f-4723-880f-4827534384fa"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5230), "Junior", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f39b3c1-eafb-44a2-8e6e-e4f4d5a517a7"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5235), "Leader", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6b2f309f-0b61-4d62-8f3a-8dfcedb6c3fd"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5232), "Middle", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d16a06f7-251b-41ef-8ef3-14974e9e2b94"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5123), "Intern", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eefc0922-80c7-4299-908a-70dc87e0c5b6"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5233), "Senior", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Created_At", "Name", "Updated_at" },
                values: new object[,]
                {
                    { new Guid("096c3ced-254c-455b-aebd-a8708e3993ce"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5575), "Python", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5954b07f-6983-429d-949c-ce5c3747b96c"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5589), "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6ace33f0-733d-4615-a9ed-b6811a6336f3"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5580), "SQL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("73ebf19f-0ccc-475e-8bbf-f58059f12fc2"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5594), "Azure", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1b53195-66de-4f99-8833-b6588b2d5866"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5587), "ASP.NET Core", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a348829f-6535-41d0-9b72-ad6a0b262eb9"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5582), "HTML/CSS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bbe3a548-4a8e-4079-8654-8df3b190fe8c"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5585), "React", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c07c0add-8546-4a9d-a40c-2746f1fdda27"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5572), "JavaScript", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd48e461-a480-435c-a516-86f4521a2904"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5591), "Kubernetes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f03d9fdc-fde0-4c1c-9a3b-22080fdeed19"), new DateTime(2025, 6, 23, 20, 37, 26, 552, DateTimeKind.Local).AddTicks(5558), "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7c6399a6-a2ab-4c02-afb9-b7a4ff29aeae", "33ff7280-40c3-439a-9f08-0a9fcec6a744" });

            migrationBuilder.CreateIndex(
                name: "IX_Recruiters_CompanyId",
                table: "Recruiters",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recruiters_CompanyId",
                table: "Recruiters");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8409056b-d1b8-4090-8faa-501d616158c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbcbd7e8-7109-4021-9780-4e13bc9c0e8d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7c6399a6-a2ab-4c02-afb9-b7a4ff29aeae", "33ff7280-40c3-439a-9f08-0a9fcec6a744" });

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("55805609-b925-4c9f-94ea-8703e3a07dfb"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("5e606485-ed68-4b55-915e-2e2beaffd99d"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6da8d8a3-e511-480f-98e8-96ce370fffe9"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("94a48e01-47ab-41ea-ad04-a6bdedeb3932"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("042a31d6-68ab-45b5-9529-b4f109f02ea9"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("466db784-2a8f-4723-880f-4827534384fa"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("5f39b3c1-eafb-44a2-8e6e-e4f4d5a517a7"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("6b2f309f-0b61-4d62-8f3a-8dfcedb6c3fd"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("d16a06f7-251b-41ef-8ef3-14974e9e2b94"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("eefc0922-80c7-4299-908a-70dc87e0c5b6"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("096c3ced-254c-455b-aebd-a8708e3993ce"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5954b07f-6983-429d-949c-ce5c3747b96c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("6ace33f0-733d-4615-a9ed-b6811a6336f3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("73ebf19f-0ccc-475e-8bbf-f58059f12fc2"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a1b53195-66de-4f99-8833-b6588b2d5866"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a348829f-6535-41d0-9b72-ad6a0b262eb9"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("bbe3a548-4a8e-4079-8654-8df3b190fe8c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c07c0add-8546-4a9d-a40c-2746f1fdda27"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("cd48e461-a480-435c-a516-86f4521a2904"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("f03d9fdc-fde0-4c1c-9a3b-22080fdeed19"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c6399a6-a2ab-4c02-afb9-b7a4ff29aeae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33ff7280-40c3-439a-9f08-0a9fcec6a744");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63e4997b-47aa-4b34-9477-85abe85631d4", null, "Candidate", "CANDIDATE" },
                    { "865a9978-eb6b-4090-b385-41c96fc4911c", null, "Recruiter", "RECRUITER" },
                    { "a3caa20c-d657-4a76-a6bd-0608454f160a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Created_At", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicUrl", "SecurityStamp", "TwoFactorEnabled", "Updated_At", "UserName" },
                values: new object[] { "cd7429a7-6312-445a-9424-b1d44be7286d", 0, "a20dae90-88ec-4a3f-a597-621a910ad651", new DateTime(2025, 6, 16, 9, 15, 34, 248, DateTimeKind.Utc).AddTicks(6619), "admin@example.com", true, "admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPNfPSJEP0OepjfJnl/QPO9mUz2+7ySZE4ai8oM7aDi5EvWW+RmKeVQ4HrCFT+hG7Q==", null, false, "https://res.cloudinary.com/dtihvekmn/image/upload/v1749112264/user_vga2r2.png", "", false, null, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Created_At", "LogoUrl", "Name", "Updated_at" },
                values: new object[,]
                {
                    { new Guid("02f4d5e0-757f-41d6-a55d-84e220373a3d"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6530), "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136592/kms-logo_mnuae3.png", "KMS Technology", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4ea38c62-6064-496c-afda-5abbf87589b0"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6531), "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136149/haranvan_l9df1x.png", "Haravan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a97a6c5e-4abc-45ac-a16d-e1314d37aa22"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6528), "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136683/VNPT-logo_ngjek0.jpg", "VNPT Technology", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c0c1bc1b-0f5b-4be1-b32e-6db1d85ff01a"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6523), "https://res.cloudinary.com/dtihvekmn/image/upload/v1749136395/fpt-software_uorpkb.png", "FPT Software", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Created_At", "Name", "Updated_at" },
                values: new object[,]
                {
                    { new Guid("4134c7da-72ad-415a-8295-b0cc10b156d4"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6285), "Leader", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("53345452-2c7c-4c77-b7c3-8acc0e12c1d8"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6283), "Senior", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a06166aa-8aca-4d67-b347-74b247f4e955"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6282), "Middle", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a13bd4d7-450c-4b8f-a006-ae61f0c56def"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6201), "Intern", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c95a7dc2-2149-42fd-aac7-3274ee039076"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6281), "Junior", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eb7573ba-dbfd-4dc1-92cd-f0de3c559730"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6279), "Fresher", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Created_At", "Name", "Updated_at" },
                values: new object[,]
                {
                    { new Guid("02e702f5-4f18-41c5-8954-989b2e2aa561"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6484), "HTML/CSS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("529fb769-fea1-4fc0-abff-5747d9ce1c08"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6487), "ASP.NET Core", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("73fab2c8-7f00-44cc-9e18-4efdf9fb3c5f"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6491), "Kubernetes", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74dd3d14-b08c-411c-b32d-a5e059b02c75"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6475), "C#", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1e1f84a-65e2-4f12-adf9-9f3e1218b069"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6481), "Python", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b4fd346f-2cff-4eec-80e5-30bf11379120"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6483), "SQL", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b8478816-557f-4ebd-9208-c283b0d302f1"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6488), "Java", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb7204fb-2d89-4e2f-8510-ee8c38b952e3"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6480), "JavaScript", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d05dbe4d-03d4-4598-8de1-eea016203cd9"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6485), "React", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f2164e73-7359-4d0a-bbe1-78ea4a7cdcd6"), new DateTime(2025, 6, 16, 16, 15, 34, 248, DateTimeKind.Local).AddTicks(6492), "Azure", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a3caa20c-d657-4a76-a6bd-0608454f160a", "cd7429a7-6312-445a-9424-b1d44be7286d" });

            migrationBuilder.CreateIndex(
                name: "IX_Recruiters_CompanyId",
                table: "Recruiters",
                column: "CompanyId",
                unique: true);
        }
    }
}
