using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class SeedingBlg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "33b3d70e-aa1f-44ac-bb60-36ae05c0f473");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "c833fba6-0331-4308-83a2-6ea45bb831b6");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "f1bda0d3-dec7-47ee-84bc-6bb7ec270f5c");

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "23978a1d-7823-4030-bd5d-ef7a0e6412a2", "df2d8409-ce61-4dac-ae75-b26fbbab27f2", "Student", "STUDENT" },
            //        { "952625cb-623b-4f8e-a426-c9e14ffe41bc", "9e9ef764-d672-42d8-99ee-93c2410d8ae0", "Admin", "ADMIN" },
            //        { "ea3203f7-8571-4e45-b109-e593235f3420", "df2d8409-ce61-4dac-ae75-b26fbbab27f2", "Instructor", "INSTRUCTOR" }
            //    });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "CategoryId", "Content", "ImageURL", "LikesNumber", "SubCategoryId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "This blog covers the basics of human anatomy...", "/Images/Blogs/blog1.jpg", 10, null, "Introduction to Human Anatomy" },
                    { 2, 1, "This blog explores comparative anatomy across species...", "/Images/Blogs/blog1.jpg", 15, null, "Advanced Comparative Anatomy" },
                    { 3, 2, "Understanding the basics of cell physiology...", "/Images/Blogs/blog1.jpg", 20, null, "Fundamentals of Cell Physiology" },
                    { 4, 1, "This blog provides an overview of human anatomy...", "/Images/Blogs/blog1.jpg", 5, 1, "Human Anatomy Overview" },
                    { 5, 2, "An introductory blog on systemic physiology...", "/Images/Blogs/blog1.jpg", 8, 4, "Systemic Physiology Basics" },
                    { 6, 3, "Exploring clinical applications in pharmacology...", "/Images/Blogs/blog1.jpg", 12, 5, "Clinical Applications of Pharmacology" },
                    { 7, 4, "A comprehensive overview of pathology...", "/Images/Blogs/blog1.jpg", 7, 7, "Pathology: An Overview" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23978a1d-7823-4030-bd5d-ef7a0e6412a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "952625cb-623b-4f8e-a426-c9e14ffe41bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea3203f7-8571-4e45-b109-e593235f3420");

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33b3d70e-aa1f-44ac-bb60-36ae05c0f473", "c4479e14-e82f-42ba-9be5-48b7b6e860b3", "Admin", "ADMIN" },
                    { "c833fba6-0331-4308-83a2-6ea45bb831b6", "c9e78e69-8cdd-4e62-bfe3-72c1bad905ef", "Instructor", "INSTRUCTOR" },
                    { "f1bda0d3-dec7-47ee-84bc-6bb7ec270f5c", "6712401c-7646-46f9-baeb-f82c12808f53", "Student", "STUDENT" }
                });
        }
    }
}
