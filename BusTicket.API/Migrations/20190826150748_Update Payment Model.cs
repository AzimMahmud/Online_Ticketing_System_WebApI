using Microsoft.EntityFrameworkCore.Migrations;

namespace BusTicket.API.Migrations
{
    public partial class UpdatePaymentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VendorID",
                table: "Payments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "VendorName",
                table: "Payments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 1,
                columns: new[] { "VendorID", "VendorName" },
                values: new object[] { null, "Green Line" });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 2,
                columns: new[] { "VendorID", "VendorName" },
                values: new object[] { null, "Green Line" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VendorName",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "VendorID",
                table: "Payments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 1,
                column: "VendorID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "PaymentID",
                keyValue: 2,
                column: "VendorID",
                value: 1);
        }
    }
}
