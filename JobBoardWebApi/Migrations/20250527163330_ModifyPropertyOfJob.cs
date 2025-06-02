using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobBoardWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifyPropertyOfJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("0186cef8-f6a4-4ae1-bfeb-163fa9bcc572"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("22441847-bd3d-4586-89ad-5cd11af6016b"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("67873b2b-7536-4ec8-8ecf-5dfb0627c71b"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("78784ac1-61a2-45f6-90b9-65f37407840e"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("88c9d23e-a378-4561-9786-d0769743bdd2"));

            migrationBuilder.DeleteData(
                table: "Levels",
                keyColumn: "Id",
                keyValue: new Guid("96847469-1a7a-4b29-bd7f-273700fff90c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("0ace6866-999f-4d6a-974c-0db9a3d9de59"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("0deefa0c-07f1-421e-8b55-81631fa9b55e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2a47e95b-1298-49ec-af21-89b49db3b907"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("347b35e2-73e0-4a05-a44c-2857cb40907e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("3de872c5-cf64-4fba-ad20-9eb562b40908"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("4f4ecbfd-5a0d-4cdb-9a9c-5fe141bf5744"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("80b8da0b-77a3-482c-a908-037b34acb083"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c85ae328-bc80-413d-a841-663e45d5ae37"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("d8885370-6f0a-4bd1-b5eb-766cd7a3eafb"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("fd3f0b0f-2baa-4067-8c08-9ff62f997be2"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated_At",
                table: "Jobs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created_At",
                table: "Jobs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Updated_At",
                table: "Jobs",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Created_At",
                table: "Jobs",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0186cef8-f6a4-4ae1-bfeb-163fa9bcc572"), "Intern" },
                    { new Guid("22441847-bd3d-4586-89ad-5cd11af6016b"), "Fresher" },
                    { new Guid("67873b2b-7536-4ec8-8ecf-5dfb0627c71b"), "Junior" },
                    { new Guid("78784ac1-61a2-45f6-90b9-65f37407840e"), "Leader" },
                    { new Guid("88c9d23e-a378-4561-9786-d0769743bdd2"), "Middle" },
                    { new Guid("96847469-1a7a-4b29-bd7f-273700fff90c"), "Senior" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ace6866-999f-4d6a-974c-0db9a3d9de59"), "HTML/CSS" },
                    { new Guid("0deefa0c-07f1-421e-8b55-81631fa9b55e"), "Python" },
                    { new Guid("2a47e95b-1298-49ec-af21-89b49db3b907"), "ASP.NET Core" },
                    { new Guid("347b35e2-73e0-4a05-a44c-2857cb40907e"), "C#" },
                    { new Guid("3de872c5-cf64-4fba-ad20-9eb562b40908"), "Kubernetes" },
                    { new Guid("4f4ecbfd-5a0d-4cdb-9a9c-5fe141bf5744"), "SQL" },
                    { new Guid("80b8da0b-77a3-482c-a908-037b34acb083"), "Azure" },
                    { new Guid("c85ae328-bc80-413d-a841-663e45d5ae37"), "JavaScript" },
                    { new Guid("d8885370-6f0a-4bd1-b5eb-766cd7a3eafb"), "React" },
                    { new Guid("fd3f0b0f-2baa-4067-8c08-9ff62f997be2"), "Java" }
                });
        }
    }
}
