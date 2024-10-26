using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class RequestEnrollStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UserEnrolledCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TransactionImageURL",
                table: "UserEnrolledCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserEnrolledCourses");

            migrationBuilder.DropColumn(
                name: "TransactionImageURL",
                table: "UserEnrolledCourses");

        }
    }
}
