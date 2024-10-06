using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class AddedCategoryinCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a111a11-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a667f5bf-834a-4e5e-88a5-6e676d06d19d", "AQAAAAIAAYagAAAAELxs7u/R+tWfzp+Pl9luwe8eUyZMqff/QHsk7fkDwNYEKorger2zjkVOTHlJ24HQ6g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b222b22-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63ef3b13-4edf-45fb-8204-cf3423d64fe5", "AQAAAAIAAYagAAAAEHRE97bvpcJyIt9cem/NdbveKkrqpj9Ud+rWKEqAhb4t5ns+YBwdoTl9By2N7AL2BA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c333c33-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "97ee27ea-51d8-4cca-b4b0-05e6e5f8492d", "AQAAAAIAAYagAAAAEJXCjmJnWv0T3LvjlucYFLtQ/+gxEFT38QVMV9WEK3ec+G6OY3Ag1ym0IcxyVS9I5A==" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a111a11-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e7aec21-b4b1-42c8-ba50-e417fe08d92b", "AQAAAAIAAYagAAAAEOOs50pOP4tSRP5Ccpdg5iJ3b/8soYsDkFkQimQm+ZgtKMUqrFUxuourwd0BJCWfag==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b222b22-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "21c399e0-f462-4320-b9eb-edf3e345a916", "AQAAAAIAAYagAAAAEOjg5/g0QErpBZ9e44zjiJwiZJhW/nqqwO1BNYEDCLPHaZGVIwJVPpmZau068lnR+w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c333c33-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "68487010-1ca9-4b87-984d-b1c20fa20a05", "AQAAAAIAAYagAAAAEAHHDOgNv9qiWMRq5X8PcP1FPga1KuXIuyNoGUzERIyO92FudxldfQFdAmbnpChWQw==" });
        }
    }
}
