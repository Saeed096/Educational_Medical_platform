using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class CourseType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "1a111a11-1111-1111-1111-111111111111",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "31f2c8f5-0fe4-45a4-825c-2a96fb78c3ae", "AQAAAAIAAYagAAAAECcGwNmI4EMZueUReCzEZPKLezfPGi55cPApCL2vDyRHvwJnEGeUJRx8Cu2YmgeVjQ==", "3dd1b723-5465-4d8c-b671-123e98acf2ed" });

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "2b222b22-2222-2222-2222-222222222222",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "583d6f9f-4ab4-4f6f-8cd4-98be7fcdaba6", "AQAAAAIAAYagAAAAECcFmVj/5yMfSRbbAdzwgWuNzfhw42OC5QZZxeImtfEsARIZ/vrFqOPywDyxbmK/0g==", "9fc87029-3791-420a-9629-595516ff0c40" });

            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "3c333c33-3333-3333-3333-333333333333",
            //    columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
            //    values: new object[] { "712503fa-e298-4805-9dfc-7af88bc1f91a", "AQAAAAIAAYagAAAAEK/PGVSs/CbmCweOYqlsPtr1IYvaDZmGpHEZASS6w8dTJs5wFK1SbfpfrPOak+s33A==", "7448f7c5-ff5c-49e4-af6b-c4cffb42375a" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Courses");

        //    migrationBuilder.UpdateData(
        //        table: "AspNetUsers",
        //        keyColumn: "Id",
        //        keyValue: "1a111a11-1111-1111-1111-111111111111",
        //        columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
        //        values: new object[] { "c27ebef2-d3f6-44bc-a411-feedc0247924", "AQAAAAIAAYagAAAAEDDvpFCB+Jf1iH9aW8DLTfJRnGWV+bwD58DAbQVbf3iFNkJs4PDb+gfg2usuGZg5Xw==", "96578fe6-a780-4479-bec8-cfcd14a826ee" });

        //    migrationBuilder.UpdateData(
        //        table: "AspNetUsers",
        //        keyColumn: "Id",
        //        keyValue: "2b222b22-2222-2222-2222-222222222222",
        //        columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
        //        values: new object[] { "72891089-9cd3-42d0-8a84-cd145dd3f886", "AQAAAAIAAYagAAAAEBAkem3F4HxQKcpH/XAuKfAcSLwKrO6jv67+8H1xuOx6pHDaQJ+ryXJRWjeLEivCFw==", "b0d9cfe3-306b-43f6-991d-496e36c8adae" });

        //    migrationBuilder.UpdateData(
        //        table: "AspNetUsers",
        //        keyColumn: "Id",
        //        keyValue: "3c333c33-3333-3333-3333-333333333333",
        //        columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
        //        values: new object[] { "afdade58-9d79-43a3-aa76-0e11de086117", "AQAAAAIAAYagAAAAEJ3UkpzFeyRcIwLg+yqekfkIjZeAEVzs5E12rAVuJ9s4q7VN4y+FJKmy/bEN1KxQkA==", "6bf7325e-aba6-4b7d-a286-dc111c040daf" });
        //
        }
    }
}
