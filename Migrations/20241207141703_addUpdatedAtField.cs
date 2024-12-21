using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class addUpdatedAtField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserSubscriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a111a11-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "be0648e8-b23d-46c2-a0d6-d89a566fe903", "AQAAAAIAAYagAAAAEM0XMxy42puR7brjuhXlGRso7hDkEmCNLIHwqPlfmWfM2u0/ncJTZN0Lvhc0LXwA4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b222b22-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c7a818a-3246-40b2-a357-94641f799229", "AQAAAAIAAYagAAAAEH+ebpdLQAMFCYKrpd4LS3u5quvJfuhEI2i6lF2sCi8/IqXBDLLbxas3948fExh3Tg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c333c33-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6678e2c-ee56-4f2e-95fe-454d6ee509c7", "AQAAAAIAAYagAAAAEKMXGFDkwxiG3GonAB+VEDvtKO2kpaIYkUQPTqllORyGPnMr+ahEvhFPlcP+OA62Xw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserSubscriptions");

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
