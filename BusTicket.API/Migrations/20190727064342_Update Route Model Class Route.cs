using Microsoft.EntityFrameworkCore.Migrations;

namespace BusTicket.API.Migrations
{
    public partial class UpdateRouteModelClassRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketReservations_Routes_RouteID",
                table: "TicketReservations");

            migrationBuilder.DropColumn(
                name: "RouteDetailsID",
                table: "TicketReservations");

            migrationBuilder.AlterColumn<int>(
                name: "RouteID",
                table: "TicketReservations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReservations_Routes_RouteID",
                table: "TicketReservations",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "RouteID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketReservations_Routes_RouteID",
                table: "TicketReservations");

            migrationBuilder.AlterColumn<int>(
                name: "RouteID",
                table: "TicketReservations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RouteDetailsID",
                table: "TicketReservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReservations_Routes_RouteID",
                table: "TicketReservations",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "RouteID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
