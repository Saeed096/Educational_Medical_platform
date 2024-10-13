using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class TestDifficulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "StandardTests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Difficulty",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Difficulty",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "Difficulty",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "StandardTests");

        }
    }
}
