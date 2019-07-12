using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusTicket.API.Migrations
{
    public partial class UpdateDomainClassNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketReservations_RouteDetailses_RouteDetailsID",
                table: "TicketReservations");

            migrationBuilder.DropTable(
                name: "RouteDetailses");

            migrationBuilder.DropIndex(
                name: "IX_TicketReservations_RouteDetailsID",
                table: "TicketReservations");

            migrationBuilder.AddColumn<int>(
                name: "RouteDetailID",
                table: "TicketReservations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RouteDetails",
                columns: table => new
                {
                    RouteDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardPoint = table.Column<string>(nullable: true),
                    BoardTime = table.Column<DateTime>(nullable: false),
                    DropPoint = table.Column<string>(nullable: true),
                    DropTime = table.Column<DateTime>(nullable: false),
                    BusDetailID = table.Column<int>(nullable: false),
                    Fare = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteDetails", x => x.RouteDetailID);
                    table.ForeignKey(
                        name: "FK_RouteDetails_BusDetails_BusDetailID",
                        column: x => x.BusDetailID,
                        principalTable: "BusDetails",
                        principalColumn: "BusDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketReservations_RouteDetailID",
                table: "TicketReservations",
                column: "RouteDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_BusDetailID",
                table: "RouteDetails",
                column: "BusDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReservations_RouteDetails_RouteDetailID",
                table: "TicketReservations",
                column: "RouteDetailID",
                principalTable: "RouteDetails",
                principalColumn: "RouteDetailID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketReservations_RouteDetails_RouteDetailID",
                table: "TicketReservations");

            migrationBuilder.DropTable(
                name: "RouteDetails");

            migrationBuilder.DropIndex(
                name: "IX_TicketReservations_RouteDetailID",
                table: "TicketReservations");

            migrationBuilder.DropColumn(
                name: "RouteDetailID",
                table: "TicketReservations");

            migrationBuilder.CreateTable(
                name: "RouteDetailses",
                columns: table => new
                {
                    RouteDetailsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardPoint = table.Column<string>(nullable: true),
                    BoardTime = table.Column<DateTime>(nullable: false),
                    BusDetailsID = table.Column<int>(nullable: false),
                    DropPoint = table.Column<string>(nullable: true),
                    DropTime = table.Column<DateTime>(nullable: false),
                    Fare = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteDetailses", x => x.RouteDetailsID);
                    table.ForeignKey(
                        name: "FK_RouteDetailses_BusDetails_BusDetailsID",
                        column: x => x.BusDetailsID,
                        principalTable: "BusDetails",
                        principalColumn: "BusDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketReservations_RouteDetailsID",
                table: "TicketReservations",
                column: "RouteDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetailses_BusDetailsID",
                table: "RouteDetailses",
                column: "BusDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketReservations_RouteDetailses_RouteDetailsID",
                table: "TicketReservations",
                column: "RouteDetailsID",
                principalTable: "RouteDetailses",
                principalColumn: "RouteDetailsID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
