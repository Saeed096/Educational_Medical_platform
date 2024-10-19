using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class TestPriceAndEditedInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "StandardTests",
                type: "int",
                nullable: false,
                defaultValue: 0);
      
            migrationBuilder.UpdateData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "Type" },
                values: new object[] { 100, 1 });

            migrationBuilder.UpdateData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Price", "Type" },
                values: new object[] { 150, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "StandardTests");

            migrationBuilder.UpdateData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 0);
        }
    }
}
