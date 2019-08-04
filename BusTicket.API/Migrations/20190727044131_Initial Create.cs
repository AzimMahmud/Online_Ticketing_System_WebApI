using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusTicket.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandID);
                });

            migrationBuilder.CreateTable(
                name: "BusCategories",
                columns: table => new
                {
                    BusCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusCategories", x => x.BusCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "BusReservationCancels",
                columns: table => new
                {
                    BusRsrvCnclID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    NoOfBus = table.Column<string>(nullable: true),
                    ReturnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusReservationCancels", x => x.BusRsrvCnclID);
                });

            migrationBuilder.CreateTable(
                name: "BusReservations",
                columns: table => new
                {
                    BusReservationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PassengerName = table.Column<string>(nullable: true),
                    PassengerPhoneNo = table.Column<string>(nullable: true),
                    PassengerEmail = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    NoOfBus = table.Column<string>(nullable: true),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusReservations", x => x.BusReservationID);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    BoardPoint = table.Column<string>(nullable: true),
                    BoardTime = table.Column<DateTime>(nullable: false),
                    DropPoint = table.Column<string>(nullable: true),
                    DropTime = table.Column<DateTime>(nullable: false),
                    BusDetails = table.Column<string>(nullable: true),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    NoOfTicket = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    TransactionType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    MessageBody = table.Column<string>(nullable: true),
                    RecipientID = table.Column<int>(nullable: false),
                    MessageDeliveryTime = table.Column<DateTime>(nullable: false),
                    MessageDeliveryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    PayTypID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentMethod = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.PayTypID);
                });

            migrationBuilder.CreateTable(
                name: "PromoOffers",
                columns: table => new
                {
                    PromoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PromoCode = table.Column<string>(nullable: true),
                    PromoDetails = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoOffers", x => x.PromoID);
                });

            migrationBuilder.CreateTable(
                name: "TicketReturns",
                columns: table => new
                {
                    TicktReturnID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceID = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    NoOfTicket = table.Column<string>(nullable: true),
                    ReturnDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReturns", x => x.TicktReturnID);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VendorName = table.Column<string>(nullable: true),
                    VendorPhone = table.Column<string>(nullable: true),
                    VendorEmail = table.Column<string>(nullable: true),
                    VendorAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorID);
                });

            migrationBuilder.CreateTable(
                name: "BusDetails",
                columns: table => new
                {
                    BusDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandID = table.Column<int>(nullable: false),
                    BusCategoryID = table.Column<int>(nullable: false),
                    VendorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusDetails", x => x.BusDetailID);
                    table.ForeignKey(
                        name: "FK_BusDetails_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusDetails_BusCategories_BusCategoryID",
                        column: x => x.BusCategoryID,
                        principalTable: "BusCategories",
                        principalColumn: "BusCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusDetails_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorPayments",
                columns: table => new
                {
                    VendorPaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VendorID = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    PaymentDescription = table.Column<string>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    PaymentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorPayments", x => x.VendorPaymentID);
                    table.ForeignKey(
                        name: "FK_VendorPayments_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardPoint = table.Column<string>(nullable: true),
                    BoardTime = table.Column<TimeSpan>(nullable: false),
                    DropPoint = table.Column<string>(nullable: true),
                    DropTime = table.Column<TimeSpan>(nullable: false),
                    BusDetailID = table.Column<int>(nullable: false),
                    Fare = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteID);
                    table.ForeignKey(
                        name: "FK_Routes_BusDetails_BusDetailID",
                        column: x => x.BusDetailID,
                        principalTable: "BusDetails",
                        principalColumn: "BusDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatLayout",
                columns: table => new
                {
                    SeatLayoutID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusDetailsID = table.Column<int>(nullable: false),
                    TotalSeat = table.Column<int>(nullable: false),
                    LastSeat = table.Column<int>(nullable: false),
                    Layout = table.Column<string>(nullable: true),
                    LayoutType = table.Column<string>(nullable: true),
                    BusDetailID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatLayout", x => x.SeatLayoutID);
                    table.ForeignKey(
                        name: "FK_SeatLayout_BusDetails_BusDetailID",
                        column: x => x.BusDetailID,
                        principalTable: "BusDetails",
                        principalColumn: "BusDetailID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketReservations",
                columns: table => new
                {
                    TicketResrvID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PassengerName = table.Column<string>(nullable: true),
                    PassengerPhoneNo = table.Column<string>(nullable: true),
                    PassengerEmail = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    NoOfTicket = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    SeatNo = table.Column<string>(nullable: true),
                    RouteDetailsID = table.Column<int>(nullable: false),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    RouteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReservations", x => x.TicketResrvID);
                    table.ForeignKey(
                        name: "FK_TicketReservations_Routes_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Routes",
                        principalColumn: "RouteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandID", "Name" },
                values: new object[,]
                {
                    { 1, "Hino" },
                    { 2, "Mac" },
                    { 3, "Scania" }
                });

            migrationBuilder.InsertData(
                table: "BusCategories",
                columns: new[] { "BusCategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Non-AC" },
                    { 2, "AC" }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "VendorAddress", "VendorEmail", "VendorName", "VendorPhone" },
                values: new object[,]
                {
                    { 1, "120 A, Dhaka, Bangladesh", "greenline@gmail.com", "Green Line", "01731569155" },
                    { 2, "130 B, Dhaka, Bangladesh", "shohag@gmail.com", "Shohag", "01731569165" },
                    { 3, "140 A, Dhaka, Bangladesh", "skyline@gmail.com", "Sky Line", "01861569155" }
                });

            migrationBuilder.InsertData(
                table: "BusDetails",
                columns: new[] { "BusDetailID", "BrandID", "BusCategoryID", "VendorID" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 2 },
                    { 4, 2, 2, 2 },
                    { 3, 1, 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusDetails_BrandID",
                table: "BusDetails",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_BusDetails_BusCategoryID",
                table: "BusDetails",
                column: "BusCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_BusDetails_VendorID",
                table: "BusDetails",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_BusDetailID",
                table: "Routes",
                column: "BusDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_SeatLayout_BusDetailID",
                table: "SeatLayout",
                column: "BusDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketReservations_RouteID",
                table: "TicketReservations",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_VendorPayments_VendorID",
                table: "VendorPayments",
                column: "VendorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusReservationCancels");

            migrationBuilder.DropTable(
                name: "BusReservations");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "PromoOffers");

            migrationBuilder.DropTable(
                name: "SeatLayout");

            migrationBuilder.DropTable(
                name: "TicketReservations");

            migrationBuilder.DropTable(
                name: "TicketReturns");

            migrationBuilder.DropTable(
                name: "VendorPayments");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "BusDetails");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "BusCategories");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
