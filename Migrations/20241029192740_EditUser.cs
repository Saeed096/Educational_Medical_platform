using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class EditUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a111a11-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5563ac9c-8792-472e-a715-a7b306becee3", "AQAAAAIAAYagAAAAEI0koI2pzsniUaZ+/ZRGASmolwd/O5qUBeT7y1CGH1pCWxYyBaPZFYTCyQmQpp3l+w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b222b22-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "b6ce7068-031e-4ee4-9212-ca17073e6eb8", "Abdallah_Saudie@business.example.com", "Abdallah", "Saudie", "ABDALLAH_SAUDIE@BUSINESS.EXAMPLE.COM", "ABDALLAH_SAUDIE", "AQAAAAIAAYagAAAAECYJUzFtLFewzXeYctbjHzmt1iLxCDkEJVMY863Dryb9ut2bdlOeyTaF8vgsVR/NQA==", "Abdallah_Saudie" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c333c33-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c1870591-f5fe-4ef8-b676-4d5f8552bfde", "AQAAAAIAAYagAAAAENDmD7rMPjBXZCLYZ3zuimffMwgxlo+um+dF3wGSd0F/VfYHBHruByB0/yLTJdISiQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a111a11-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6913b07-a432-4730-a15f-d7e164d6c69f", "AQAAAAIAAYagAAAAELS92WnQFZUOod5SpdfiqT07Gk+JkVGdiOhJcZkaMXHPblOA7LRDkwuT39xdnaxsgw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2b222b22-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "38049d35-732e-4dcd-be41-e5f062c0b845", "Mohamed_Galal@example.com", "Mohamed", "Galal", "MOHAMED_GALAL@EXAMPLE.COM", "MOHAMED_GALAL", "AQAAAAIAAYagAAAAEE22QGkHlpoCXu4fv7VBbXg2P4Tsj0ec5SNk3FvxSxOb5Y7DH+Q61UPhANc4JOoFNg==", "Mohamed_Galal" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c333c33-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ecbc276-f4e0-444e-9f14-faac297d4f6d", "AQAAAAIAAYagAAAAEPll/ikRAJjPSEVCFXV7q2Qmy8ZEEB7OiedgP2x7tNXbM1XmgME5ctJ2N9yoRa2udA==" });
        }
    }
}
