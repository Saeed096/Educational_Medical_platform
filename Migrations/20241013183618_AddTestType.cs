using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class AddTestType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "StandardTests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "StandardTests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "StandardTests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "SubCategoryId", "Type" },
                values: new object[] { 13, 25, 0 });

            migrationBuilder.UpdateData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "SubCategoryId", "Type" },
                values: new object[] { 14, 27, 0 });

            migrationBuilder.UpdateData(
                table: "StandardTests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "SubCategoryId", "Type" },
                values: new object[] { 15, 29, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_StandardTests_CategoryId",
                table: "StandardTests",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardTests_SubCategoryId",
                table: "StandardTests",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StandardTests_Categories_CategoryId",
                table: "StandardTests",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StandardTests_SubCategories_SubCategoryId",
                table: "StandardTests",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandardTests_Categories_CategoryId",
                table: "StandardTests");

            migrationBuilder.DropForeignKey(
                name: "FK_StandardTests_SubCategories_SubCategoryId",
                table: "StandardTests");

            migrationBuilder.DropIndex(
                name: "IX_StandardTests_CategoryId",
                table: "StandardTests");

            migrationBuilder.DropIndex(
                name: "IX_StandardTests_SubCategoryId",
                table: "StandardTests");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "StandardTests");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "StandardTests");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "StandardTests");

        }
    }
}
