using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusTicket.API.Migrations
{
    public partial class UpdateAllModelClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
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
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
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
                    PromoDetails = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
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
                    VendorAddress = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
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
                    VendorID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
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
                name: "RouteDetails",
                columns: table => new
                {
                    RouteDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoardPoint = table.Column<string>(nullable: true),
                    BoardTime = table.Column<string>(nullable: true),
                    DropPoint = table.Column<string>(nullable: true),
                    DropTime = table.Column<string>(nullable: true),
                    BusDetailID = table.Column<int>(nullable: false),
                    Fare = table.Column<decimal>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
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
                    TicketNo = table.Column<string>(nullable: true),
                    PassengerName = table.Column<string>(nullable: true),
                    PassengerPhoneNo = table.Column<string>(nullable: true),
                    PassengerEmail = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    NoOfTicket = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    SeatNo = table.Column<string>(nullable: true),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    RouteDetailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketReservations", x => x.TicketResrvID);
                    table.ForeignKey(
                        name: "FK_TicketReservations_RouteDetails_RouteDetailID",
                        column: x => x.RouteDetailID,
                        principalTable: "RouteDetails",
                        principalColumn: "RouteDetailID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentAmount = table.Column<decimal>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    TransactionID = table.Column<string>(nullable: true),
                    VendorID = table.Column<int>(nullable: false),
                    TicketResrvID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_TicketReservations_TicketResrvID",
                        column: x => x.TicketResrvID,
                        principalTable: "TicketReservations",
                        principalColumn: "TicketResrvID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Vendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandID", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, false, "Hino" },
                    { 2, false, "Mac" },
                    { 3, false, "Scania" },
                    { 4, false, "Volvo" },
                    { 5, false, "Mistsubishi" }
                });

            migrationBuilder.InsertData(
                table: "BusCategories",
                columns: new[] { "BusCategoryID", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, false, "Non-AC" },
                    { 2, false, "AC" },
                    { 3, false, "Double-Decker" },
                    { 4, false, "Slipper" },
                    { 5, false, "Chair-Coach" }
                });

            migrationBuilder.InsertData(
                table: "BusReservationCancels",
                columns: new[] { "BusRsrvCnclID", "Comment", "InvoiceID", "NoOfBus", "ReturnDate" },
                values: new object[,]
                {
                    { 5, "For Tour", 5, "2", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "For Campaign", 4, "2", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "For Weading", 3, "2", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "For Picnic", 2, "2", new DateTime(2012, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "For Wedding", 1, "3", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "BusReservations",
                columns: new[] { "BusReservationID", "Gender", "NoOfBus", "PassengerEmail", "PassengerName", "PassengerPhoneNo", "ReservationDate", "TotalAmount" },
                values: new object[,]
                {
                    { 1, "Male", "2", "abir@gmail.com", "Abir", "01999998888", new DateTime(2000, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m },
                    { 4, "Male", "3", "faiaz@gmail.com", "Faiaz", "01716263748", new DateTime(2000, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m },
                    { 3, "Male", "1", "mahamud@gmail.com", "Mahanud", "01916783647", new DateTime(2000, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m },
                    { 2, "Male", "3", "faisal@gmail.com", "Faisal", "01752676253", new DateTime(2000, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m },
                    { 5, "Male", "5", "orrvin@gmail.com", "Orvin", "01613567893", new DateTime(2000, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceID", "BoardPoint", "BoardTime", "BusDetails", "DropPoint", "DropTime", "Email", "Gender", "Name", "NoOfTicket", "PaymentMethod", "PhoneNo", "ReservationDate", "TotalAmount", "TransactionType", "UnitPrice" },
                values: new object[,]
                {
                    { 5, "Dhaka", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ete", "Borishal", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lopez@gmail.com", "Female", "Lopez", "2", "Card", "01712563479", new DateTime(2010, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 900m, "Card", 800m },
                    { 3, "Dhaka", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ete", "Rongpur", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mahamud@gmail.com", "Male", "Mahamud", "4", "iPay", "01614562789", new DateTime(2010, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 800m, "iPay", 600m },
                    { 4, "Chittagong", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ete", "Rongpur", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "faiaz@gmail.com", "Male", "Faiaz", "3", "bKash", "01763526790", new DateTime(2010, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700m, "bKash", 700m },
                    { 1, "Chittagong", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ete", "Dhaka", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "faisaal@gmail.com", "Male", "Faisal", "4", "bKash", "01725635613", new DateTime(2010, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, "bKash", 500m },
                    { 2, "Dhaka", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ete", "Comilla", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abir@gmail.com", "Male", "Abir", "1", "Card", "01746357890", new DateTime(2010, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 600m, "Card", 400m }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "PayTypID", "IsActive", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, true, "bKash" },
                    { 2, false, "Credit/Debit Card" },
                    { 3, true, "iPay" }
                });

            migrationBuilder.InsertData(
                table: "PromoOffers",
                columns: new[] { "PromoID", "IsActive", "PromoCode", "PromoDetails" },
                values: new object[,]
                {
                    { 5, false, "pc-eid-5", "For NEW passenger eid-ul-fitar promo offer" },
                    { 1, false, "pc-eid-1", "For STAR passenger eid-ul-fitar promo offer" },
                    { 2, false, "pc-eid-2", "For GOLD passenger eid-ul-fitar promo offer" },
                    { 3, false, "pc-eid-3", "For SILVER passenger eid-ul-fitar promo offer" },
                    { 4, false, "pc-eid-4", "For DIAMOND passenger eid-ul-fitar promo offer" }
                });

            migrationBuilder.InsertData(
                table: "SeatLayout",
                columns: new[] { "SeatLayoutID", "BusDetailID", "BusDetailsID", "LastSeat", "Layout", "LayoutType", "TotalSeat" },
                values: new object[,]
                {
                    { 4, null, 4, 0, null, null, 0 },
                    { 3, null, 3, 0, null, null, 0 },
                    { 2, null, 2, 0, null, null, 0 },
                    { 1, null, 1, 0, null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "TicketReturns",
                columns: new[] { "TicktReturnID", "Comment", "InvoiceID", "NoOfTicket", "ReturnDate" },
                values: new object[,]
                {
                    { 5, "Not Interested", 5, "2", new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "Rearenge Program Schedule", 1, "2", new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "For Sickness", 2, "2", new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Not Interested", 3, "2", new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Rearenge Program Schedule", 4, "2", new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "IsActive", "VendorAddress", "VendorEmail", "VendorName", "VendorPhone" },
                values: new object[,]
                {
                    { 3, false, "140 A, Comilla, Bangladesh", "skyline@gmail.com", "Sky Line", "01861569155" },
                    { 4, false, "10 A, Chittagong, Bangladesh", "silkline@gmail.com", "Silk Line", "01861587955" },
                    { 1, false, "120 A, Dhaka, Bangladesh", "greenline@gmail.com", "Green Line", "01731569155" },
                    { 2, false, "130 B, Rongpur, Bangladesh", "shohag@gmail.com", "Shohag", "01731569165" },
                    { 5, false, "40 B, Khulna, Bangladesh", "salom@gmail.com", "S. Alom", "01861231155" }
                });

            migrationBuilder.InsertData(
                table: "BusDetails",
                columns: new[] { "BusDetailID", "BrandID", "BusCategoryID", "IsActive", "VendorID" },
                values: new object[,]
                {
                    { 1, 1, 1, false, 1 },
                    { 2, 2, 2, false, 2 },
                    { 4, 2, 2, false, 2 },
                    { 3, 1, 1, false, 3 }
                });

            migrationBuilder.InsertData(
                table: "VendorPayments",
                columns: new[] { "VendorPaymentID", "PaymentDate", "PaymentDescription", "PaymentMethod", "TotalAmount", "VendorID" },
                values: new object[,]
                {
                    { 1, new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "By bKash", "bKash", 55m, 1 },
                    { 3, new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "By Card", "Card", 5775m, 2 },
                    { 2, new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "By Card", "Card", 5775m, 3 },
                    { 4, new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "By BKash", "bKash", 5775m, 4 },
                    { 5, new DateTime(1910, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "By Card", "Card", 5775m, 5 }
                });

            migrationBuilder.InsertData(
                table: "RouteDetails",
                columns: new[] { "RouteDetailID", "BoardPoint", "BoardTime", "BusDetailID", "DropPoint", "DropTime", "Fare", "IsActive" },
                values: new object[,]
                {
                    { 1, "Chittagong", "10.30", 1, "Dhaka", "12.30", 800m, false },
                    { 2, "Dhaka", "11.30", 1, "Comilla", "21.30", 500m, false },
                    { 3, "Comilla", "9.30", 1, "Shylet", "23.30", 700m, false },
                    { 4, "Shylet", "8.30", 1, "Comilla", "20.30", 800m, false },
                    { 5, "Rongpur", "7.30", 1, "Dhaka", "18.30", 200m, false }
                });

            migrationBuilder.InsertData(
                table: "TicketReservations",
                columns: new[] { "TicketResrvID", "Gender", "NoOfTicket", "PassengerEmail", "PassengerName", "PassengerPhoneNo", "ReservationDate", "RouteDetailID", "SeatNo", "TicketNo", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Male", 2, "faoasal@gmail.com", "Faiasl", "34242", new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "A2, E2", null, 300m },
                    { 2, "Male", 2, "abir@gmail.com", "Abir", "3488242", new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "D1, D2", null, 600m },
                    { 3, "Male", 1, "mahamud@gmail.com", "Mahamud", "3242424", new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "E4", null, 500m },
                    { 5, "Male", 1, "orvin@gmail.com", "Orvin", "3488242", new DateTime(2013, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "F2", null, 300m }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "PaymentAmount", "PaymentDate", "TicketResrvID", "TransactionID", "VendorID" },
                values: new object[] { 1, 1600.00m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "TX20190101001", 1 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "PaymentAmount", "PaymentDate", "TicketResrvID", "TransactionID", "VendorID" },
                values: new object[] { 2, 1600.00m, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "TX20190101002", 1 });

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
                name: "IX_Payments_TicketResrvID",
                table: "Payments",
                column: "TicketResrvID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_VendorID",
                table: "Payments",
                column: "VendorID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_BusDetailID",
                table: "RouteDetails",
                column: "BusDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_SeatLayout_BusDetailID",
                table: "SeatLayout",
                column: "BusDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketReservations_RouteDetailID",
                table: "TicketReservations",
                column: "RouteDetailID");

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
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "PromoOffers");

            migrationBuilder.DropTable(
                name: "SeatLayout");

            migrationBuilder.DropTable(
                name: "TicketReturns");

            migrationBuilder.DropTable(
                name: "VendorPayments");

            migrationBuilder.DropTable(
                name: "TicketReservations");

            migrationBuilder.DropTable(
                name: "RouteDetails");

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
