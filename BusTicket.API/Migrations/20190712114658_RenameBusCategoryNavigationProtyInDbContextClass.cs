using Microsoft.EntityFrameworkCore.Migrations;

namespace BusTicket.API.Migrations
{
    public partial class RenameBusCategoryNavigationProtyInDbContextClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusDetails_BusCategory_BusCategoryID",
                table: "BusDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_BusDetails_BusDetailID",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketReservations_RouteDetails_RouteID",
                table: "TicketReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RouteDetails",
                table: "RouteDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusCategory",
                table: "BusCategory");

            migrationBuilder.RenameTable(
                name: "RouteDetails",
                newName: "Routes");

            migrationBuilder.RenameTable(
                name: "BusCategory",
                newName: "BusCategories");

            migrationBuilder.RenameIndex(
                name: "IX_RouteDetails_BusDetailID",
                table: "Routes",
                newName: "IX_Routes_BusDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routes",
                table: "Routes",
                column: "RouteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusCategories",
                table: "BusCategories",
                column: "BusCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_BusDetails_BusCategories_BusCategoryID",
                table: "BusDetails",
                column: "BusCategoryID",
                principalTable: "BusCategories",
                principalColumn: "BusCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_BusDetails_BusDetailID",
                table: "Routes",
                column: "BusDetailID",
                principalTable: "BusDetails",
                principalColumn: "BusDetailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReservations_Routes_RouteID",
                table: "TicketReservations",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "RouteID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusDetails_BusCategories_BusCategoryID",
                table: "BusDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_BusDetails_BusDetailID",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketReservations_Routes_RouteID",
                table: "TicketReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routes",
                table: "Routes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusCategories",
                table: "BusCategories");

            migrationBuilder.RenameTable(
                name: "Routes",
                newName: "RouteDetails");

            migrationBuilder.RenameTable(
                name: "BusCategories",
                newName: "BusCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Routes_BusDetailID",
                table: "RouteDetails",
                newName: "IX_RouteDetails_BusDetailID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RouteDetails",
                table: "RouteDetails",
                column: "RouteID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusCategory",
                table: "BusCategory",
                column: "BusCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_BusDetails_BusCategory_BusCategoryID",
                table: "BusDetails",
                column: "BusCategoryID",
                principalTable: "BusCategory",
                principalColumn: "BusCategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteDetails_BusDetails_BusDetailID",
                table: "RouteDetails",
                column: "BusDetailID",
                principalTable: "BusDetails",
                principalColumn: "BusDetailID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReservations_RouteDetails_RouteID",
                table: "TicketReservations",
                column: "RouteID",
                principalTable: "RouteDetails",
                principalColumn: "RouteID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
