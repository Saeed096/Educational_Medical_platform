using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class AddIsSubscribedInApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribedToPlatform",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribedToPlatform",
                table: "AspNetUsers");

        }
    }
}
