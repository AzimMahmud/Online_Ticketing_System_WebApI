using Microsoft.EntityFrameworkCore.Migrations;

namespace BusTicket.API.Migrations
{
    public partial class UpdateRouteTableColumnDataTypeDateTimeToTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketReservations_RouteDetails_RouteDetailID",
                table: "TicketReservations");

            migrationBuilder.RenameColumn(
                name: "RouteDetailID",
                table: "TicketReservations",
                newName: "RouteID");

            migrationBuilder.RenameIndex(
                name: "IX_TicketReservations_RouteDetailID",
                table: "TicketReservations",
                newName: "IX_TicketReservations_RouteID");

            migrationBuilder.RenameColumn(
                name: "RouteDetailID",
                table: "RouteDetails",
                newName: "RouteID");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "BusReservations",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PaymentTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "PassengerPhoneNo",
                table: "BusReservations",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PassengerName",
                table: "BusReservations",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PassengerEmail",
                table: "BusReservations",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "BusReservations",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReservations_RouteDetails_RouteID",
                table: "TicketReservations",
                column: "RouteID",
                principalTable: "RouteDetails",
                principalColumn: "RouteID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketReservations_RouteDetails_RouteID",
                table: "TicketReservations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PaymentTypes");

            migrationBuilder.RenameColumn(
                name: "RouteID",
                table: "TicketReservations",
                newName: "RouteDetailID");

            migrationBuilder.RenameIndex(
                name: "IX_TicketReservations_RouteID",
                table: "TicketReservations",
                newName: "IX_TicketReservations_RouteDetailID");

            migrationBuilder.RenameColumn(
                name: "RouteID",
                table: "RouteDetails",
                newName: "RouteDetailID");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "BusReservations",
                newName: "Total");

            migrationBuilder.AlterColumn<string>(
                name: "PassengerPhoneNo",
                table: "BusReservations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PassengerName",
                table: "BusReservations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PassengerEmail",
                table: "BusReservations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "BusReservations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReservations_RouteDetails_RouteDetailID",
                table: "TicketReservations",
                column: "RouteDetailID",
                principalTable: "RouteDetails",
                principalColumn: "RouteDetailID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
