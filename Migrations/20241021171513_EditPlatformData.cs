using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Medical_platform.Migrations
{
    /// <inheritdoc />
    public partial class EditPlatformData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "platformData");

            migrationBuilder.DropColumn(
                name: "MonthlyFee",
                table: "platformData");

            migrationBuilder.RenameColumn(
                name: "Satatus",
                table: "UserSubscriptions",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "platformData",
                newName: "ProductDescribtion");

            migrationBuilder.AddColumn<string>(
                name: "PlanDescription",
                table: "platformData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PlanFixedPricePerMonth",
                table: "platformData",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PlanSetupFee",
                table: "platformData",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PlanTaxesPercentage",
                table: "platformData",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "platformData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PlanDescription", "PlanFixedPricePerMonth", "PlanSetupFee", "PlanTaxesPercentage" },
                values: new object[] { null, 20m, 2m, 10m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanDescription",
                table: "platformData");

            migrationBuilder.DropColumn(
                name: "PlanFixedPricePerMonth",
                table: "platformData");

            migrationBuilder.DropColumn(
                name: "PlanSetupFee",
                table: "platformData");

            migrationBuilder.DropColumn(
                name: "PlanTaxesPercentage",
                table: "platformData");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "UserSubscriptions",
                newName: "Satatus");

            migrationBuilder.RenameColumn(
                name: "ProductDescribtion",
                table: "platformData",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "platformData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyFee",
                table: "platformData",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
         
            migrationBuilder.UpdateData(
                table: "platformData",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MonthlyFee" },
                values: new object[] { new DateTime(2024, 10, 20, 21, 13, 15, 447, DateTimeKind.Local).AddTicks(8995), 20m });
        }
    }
}
