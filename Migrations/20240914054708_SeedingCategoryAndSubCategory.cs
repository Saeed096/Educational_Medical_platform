using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class SeedingCategoryAndSubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "23978a1d-7823-4030-bd5d-ef7a0e6412a2");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "952625cb-623b-4f8e-a426-c9e14ffe41bc");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "ea3203f7-8571-4e45-b109-e593235f3420");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SubCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "33b3d70e-aa1f-44ac-bb60-36ae05c0f473", "c4479e14-e82f-42ba-9be5-48b7b6e860b3", "Admin", "ADMIN" },
            //        { "c833fba6-0331-4308-83a2-6ea45bb831b6", "c9e78e69-8cdd-4e62-bfe3-72c1bad905ef", "Instructor", "INSTRUCTOR" },
            //        { "f1bda0d3-dec7-47ee-84bc-6bb7ec270f5c", "6712401c-7646-46f9-baeb-f82c12808f53", "Student", "STUDENT" }
            //    });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Anatomy" },
                    { 2, "Physiology" },
                    { 3, "Pharmacology" },
                    { 4, "Pathology" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Human Anatomy" },
                    { 2, 1, "Comparative Anatomy" },
                    { 3, 2, "Cell Physiology" },
                    { 4, 2, "Systemic Physiology" },
                    { 5, 3, "Clinical Pharmacology" },
                    { 6, 3, "Pharmacokinetics" },
                    { 7, 4, "General Pathology" },
                    { 8, 4, "Systemic Pathology" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33b3d70e-aa1f-44ac-bb60-36ae05c0f473");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c833fba6-0331-4308-83a2-6ea45bb831b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1bda0d3-dec7-47ee-84bc-6bb7ec270f5c");

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SubCategories");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23978a1d-7823-4030-bd5d-ef7a0e6412a2", "a9d59149-3197-4a56-9b53-18eff28439ff", "Student", "STUDENT" },
                    { "952625cb-623b-4f8e-a426-c9e14ffe41bc", "1ad216ff-3853-4b5e-8f05-96f82ce3491f", "Admin", "ADMIN" },
                    { "ea3203f7-8571-4e45-b109-e593235f3420", "b15d17f3-86a5-498e-9210-6160919c67ec", "Instructor", "INSTRUCTOR" }
                });
        }
    }
}
