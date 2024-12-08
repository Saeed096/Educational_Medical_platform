using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class publish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a111a11-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "38fa01ed-610f-4c55-ac53-3069e8281c8d", "AQAAAAIAAYagAAAAEAfx/X4E5M1hol1gTWLIuIk19MdG5eDbKRcqc8kI4OmJLjsdd/BDfv3NsNBV9vYWUA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b222b22-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "13735001-5a68-4bf2-9570-3e7d74402b64", "AQAAAAIAAYagAAAAEOopC71RhZx4M0hfITQC7PPEi1XS7k/6CQr+rbc2n1WNRN2uWI8N+Iy7MPOJL6tlLg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c333c33-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c8643f1-7910-49e5-ac5d-d159f66724c4", "AQAAAAIAAYagAAAAEEjiaPlH7woEgksl+EuxOaSY0lBN4703yeoY6jwzbYoxvjfSBmfysqXjZoC1Jy7GdA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a111a11-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cffb14a3-4614-48c2-b6a5-3f755019f233", "AQAAAAIAAYagAAAAEBsxX7ZE7gD1it/Cm/JzVVh4zG9e2jH/xWy8Gje2OqpO8Jtb5TPbLgCVrJoC8F7htA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b222b22-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8155b9e3-9ea4-4771-bee2-b868e8677373", "AQAAAAIAAYagAAAAEASqXeM56z9WBKczXoC3Nwux+7V6rYYellXGFO1vrasSz8bTh/2SuVNFOJ8x0VnVHQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c333c33-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "89e9ea2f-d88f-4fcf-b20d-ecb876028af5", "AQAAAAIAAYagAAAAEBh16Wrw5SjkLFEAUxlEFKO/MKIhLBX4PattvOipJ7MECv62suvuaIesmc5l+9ifcA==" });
        }
    }
}
