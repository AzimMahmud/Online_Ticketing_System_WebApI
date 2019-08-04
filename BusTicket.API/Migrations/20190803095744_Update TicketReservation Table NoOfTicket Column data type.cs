using Microsoft.EntityFrameworkCore.Migrations;

namespace BusTicket.API.Migrations
{
    public partial class UpdateTicketReservationTableNoOfTicketColumndatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NoOfTicket",
                table: "TicketReservations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "TicketReservations",
                keyColumn: "TicketResrvID",
                keyValue: 1,
                column: "NoOfTicket",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TicketReservations",
                keyColumn: "TicketResrvID",
                keyValue: 2,
                column: "NoOfTicket",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NoOfTicket",
                table: "TicketReservations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "TicketReservations",
                keyColumn: "TicketResrvID",
                keyValue: 1,
                column: "NoOfTicket",
                value: "1");

            migrationBuilder.UpdateData(
                table: "TicketReservations",
                keyColumn: "TicketResrvID",
                keyValue: 2,
                column: "NoOfTicket",
                value: "1");
        }
    }
}
