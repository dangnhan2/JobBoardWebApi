using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSaveJobTableNFireUrlToApplicationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationJobMappings");

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("3ed807bd-2a5d-4d0e-b2ae-d8d7daac712c"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("611e8048-8b04-45ee-9dd6-899640cc8672"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("6c46e3c6-8a2f-4b65-8dc3-98e81a8066c3"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("7adccfbe-0936-4a34-8aa2-0a1aff02cf9f"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("a20f36a6-6aaf-442b-be1c-332159ea84ea"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("e63eef83-89bd-40f5-bcc9-c9be22304db6"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5e6e5c93-edeb-445c-ac70-3b7889ee7225"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5faa1522-f10b-484e-beb6-4c6c3e282a45"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("885f95cf-0591-47cb-8d3c-142efb176ebe"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9c7840dc-dc3b-4da4-b8c3-0d722688c52b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b5345f6a-96cb-4904-8001-c04b154a2846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("badc25e9-a2fd-4309-a559-4903516dbd1f"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("bcc11365-865b-4d15-a2e3-b4567c085bb3"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e8b0a132-170e-44da-b5e6-b849b299e18b"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("f07348f8-0ba7-49eb-9afb-f310639588b5"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("fac67745-a1b2-4c57-8cd5-9a5c110a7854"));

            migrationBuilder.AddColumn<string>(
                name: "FileUrl",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AppliedJobs",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppliedJobs", x => new { x.JobId, x.ApplicationId });
                    table.ForeignKey(
                        name: "FK_AppliedJobs_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppliedJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavedJobs",
                columns: table => new
                {
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SavedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedJobs", x => new { x.JobId, x.CandidateId });
                    table.ForeignKey(
                        name: "FK_SavedJobs_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SavedJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AppliedJobs_ApplicationId",
                table: "AppliedJobs",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedJobs_CandidateId",
                table: "SavedJobs",
                column: "CandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppliedJobs");

            migrationBuilder.DropTable(
                name: "SavedJobs");

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
                name: "FileUrl",
                table: "Applications");

            migrationBuilder.CreateTable(
                name: "ApplicationJobMappings",
                columns: table => new
                {
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationJobMappings", x => new { x.JobId, x.ApplicationId });
                    table.ForeignKey(
                        name: "FK_ApplicationJobMappings_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationJobMappings_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3ed807bd-2a5d-4d0e-b2ae-d8d7daac712c"), "Junior" },
                    { new Guid("611e8048-8b04-45ee-9dd6-899640cc8672"), "Leader" },
                    { new Guid("6c46e3c6-8a2f-4b65-8dc3-98e81a8066c3"), "Fresher" },
                    { new Guid("7adccfbe-0936-4a34-8aa2-0a1aff02cf9f"), "Senior" },
                    { new Guid("a20f36a6-6aaf-442b-be1c-332159ea84ea"), "Intern" },
                    { new Guid("e63eef83-89bd-40f5-bcc9-c9be22304db6"), "Middle" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5e6e5c93-edeb-445c-ac70-3b7889ee7225"), "C#" },
                    { new Guid("5faa1522-f10b-484e-beb6-4c6c3e282a45"), "Kubernetes" },
                    { new Guid("885f95cf-0591-47cb-8d3c-142efb176ebe"), "React" },
                    { new Guid("9c7840dc-dc3b-4da4-b8c3-0d722688c52b"), "Python" },
                    { new Guid("b5345f6a-96cb-4904-8001-c04b154a2846"), "JavaScript" },
                    { new Guid("badc25e9-a2fd-4309-a559-4903516dbd1f"), "SQL" },
                    { new Guid("bcc11365-865b-4d15-a2e3-b4567c085bb3"), "HTML/CSS" },
                    { new Guid("e8b0a132-170e-44da-b5e6-b849b299e18b"), "Azure" },
                    { new Guid("f07348f8-0ba7-49eb-9afb-f310639588b5"), "Java" },
                    { new Guid("fac67745-a1b2-4c57-8cd5-9a5c110a7854"), "ASP.NET Core" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationJobMappings_ApplicationId",
                table: "ApplicationJobMappings",
                column: "ApplicationId");
        }
    }
}
