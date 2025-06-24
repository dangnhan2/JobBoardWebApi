using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateSkillMapping");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Skills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_at",
                table: "Skills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Levels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_at",
                table: "Levels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_At",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_at",
                table: "Companies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CandidateSkills",
                columns: table => new
                {
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkills", x => new { x.CandidateId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CandidateSkills_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanySkill",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySkill", x => new { x.SkillId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_CompanySkill_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanySkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Jti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    Added_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expired_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_CandidateSkills_SkillId",
                table: "CandidateSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanySkill_CompanyId",
                table: "CompanySkill",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateSkills");

            migrationBuilder.DropTable(
                name: "CompanySkill");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

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

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Updated_at",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "Updated_at",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Updated_at",
                table: "Companies");

            migrationBuilder.CreateTable(
                name: "CandidateSkillMapping",
                columns: table => new
                {
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateSkillMapping", x => new { x.CandidateId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CandidateSkillMapping_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateSkillMapping_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkillMapping_SkillId",
                table: "CandidateSkillMapping",
                column: "SkillId");
        }
    }
}
