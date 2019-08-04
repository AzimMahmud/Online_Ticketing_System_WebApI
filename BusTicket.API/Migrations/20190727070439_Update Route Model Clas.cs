using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusTicket.API.Migrations
{
    public partial class UpdateRouteModelClas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TicketReservations",
                columns: new[] { "TicketResrvID", "Gender", "NoOfTicket", "PassengerEmail", "PassengerName", "PassengerPhoneNo", "ReservationDate", "RouteID", "SeatNo", "UnitPrice" },
                values: new object[] { 1, "Male", "1", "faoasal@gmail.com", "Faiasl", "34242", new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "4", 900m });

            migrationBuilder.InsertData(
                table: "TicketReservations",
                columns: new[] { "TicketResrvID", "Gender", "NoOfTicket", "PassengerEmail", "PassengerName", "PassengerPhoneNo", "ReservationDate", "RouteID", "SeatNo", "UnitPrice" },
                values: new object[] { 2, "Male", "1", "faoaaal@gmail.com", "Abir", "3488242", new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "4", 900m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketReservations",
                keyColumn: "TicketResrvID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketReservations",
                keyColumn: "TicketResrvID",
                keyValue: 2);
        }
    }
}
