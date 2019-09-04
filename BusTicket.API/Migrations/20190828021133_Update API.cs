using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusTicket.API.Migrations
{
    public partial class UpdateAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    VendorName = table.Column<string>(nullable: true),
                    TicketResrvID = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    VendorID = table.Column<int>(nullable: true)
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
                    { 5, "For Tour", 5, "2", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "For Campaign", 4, "2", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "For Weading", 3, "2", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "For Picnic", 2, "2", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "For Wedding", 1, "3", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "BusReservations",
                columns: new[] { "BusReservationID", "Gender", "NoOfBus", "PassengerEmail", "PassengerName", "PassengerPhoneNo", "ReservationDate", "TotalAmount" },
                values: new object[,]
                {
                    { 8, "Female", "3", "nasima@gmail.com", "Naima", "01613567800", new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 380m },
                    { 3, "Male", "1", "mahamud@gmail.com", "Mahanud", "01916783647", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m },
                    { 6, "Female", "2", "rasgeda@gmail.com", "Rasheda", "01613567866", new DateTime(2019, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 600m },
                    { 5, "Male", "4", "orrvin@gmail.com", "Orvin", "01613567893", new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 900m },
                    { 4, "Male", "3", "faiaz@gmail.com", "Faiaz", "01716263748", new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 400m },
                    { 2, "Male", "3", "faisal@gmail.com", "Faisal", "01752676253", new DateTime(2019, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m },
                    { 1, "Male", "2", "abir@gmail.com", "Abir", "01999998888", new DateTime(2019, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m },
                    { 7, "Female", "1", "rohima@gmail.com", "Rohima", "01613567852", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceID", "BoardPoint", "BoardTime", "BusDetails", "DropPoint", "DropTime", "Email", "Gender", "Name", "NoOfTicket", "PaymentMethod", "PhoneNo", "ReservationDate", "TotalAmount", "TransactionType", "UnitPrice" },
                values: new object[,]
                {
                    { 6, "Dhaka", new DateTime(2019, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Borishal", new DateTime(2019, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "mahima@gmail.com", "Female", "Mahima", "1", "bKash", "01715589874", new DateTime(2019, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 600m, "bKash", 800m },
                    { 8, "Dhaka", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Borishal", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "costa@gmail.com", "Female", "Costa", "1", "bKash", "01848784532", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 800m, "bKash", 800m },
                    { 5, "Dhaka", new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Borishal", new DateTime(2019, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "lopez@gmail.com", "Female", "Lopez", "2", "Card", "01712563479", new DateTime(2019, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 900m, "Card", 800m },
                    { 7, "Dhaka", new DateTime(2019, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Borishal", new DateTime(2019, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "sadia@gmail.com", "Female", "Sadia", "3", "bKash", "01548789548", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, "bKash", 800m },
                    { 3, "Dhaka", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rongpur", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mahamud@gmail.com", "Male", "Mahamud", "4", "bKash", "01614562789", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 800m, "bKash", 600m },
                    { 1, "Chittagong", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Dhaka", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "faisaal@gmail.com", "Male", "Faisal", "4", "bKash", "01725635613", new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, "bKash", 500m },
                    { 4, "Chittagong", new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rongpur", new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "faiaz@gmail.com", "Male", "Faiaz", "3", "bKash", "01763526790", new DateTime(2019, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 700m, "bKash", 700m },
                    { 2, "Dhaka", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Comilla", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "abir@gmail.com", "Male", "Abir", "1", "Card", "01746357890", new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 600m, "Card", 400m }
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
                    { 1, false, "pc-eid-1", "For STAR passenger eid-ul-fitar promo offer" },
                    { 3, false, "pc-eid-3", "For SILVER passenger eid-ul-fitar promo offer" },
                    { 4, false, "pc-eid-4", "For DIAMOND passenger eid-ul-fitar promo offer" },
                    { 5, false, "pc-eid-5", "For NEW passenger eid-ul-fitar promo offer" },
                    { 2, false, "pc-eid-2", "For GOLD passenger eid-ul-fitar promo offer" }
                });

            migrationBuilder.InsertData(
                table: "SeatLayout",
                columns: new[] { "SeatLayoutID", "BusDetailID", "BusDetailsID", "LastSeat", "Layout", "LayoutType", "TotalSeat" },
                values: new object[,]
                {
                    { 7, null, 7, 0, null, null, 0 },
                    { 10, null, 10, 0, null, null, 0 },
                    { 9, null, 9, 0, null, null, 0 },
                    { 8, null, 8, 0, null, null, 0 },
                    { 11, null, 11, 0, null, null, 0 },
                    { 5, null, 5, 0, null, null, 0 },
                    { 4, null, 4, 0, null, null, 0 },
                    { 3, null, 3, 0, null, null, 0 },
                    { 2, null, 2, 0, null, null, 0 },
                    { 1, null, 1, 0, null, null, 0 },
                    { 6, null, 6, 0, null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "TicketReturns",
                columns: new[] { "TicktReturnID", "Comment", "InvoiceID", "NoOfTicket", "ReturnDate" },
                values: new object[,]
                {
                    { 1, "Rearenge Program Schedule", 1, "2", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "For Sickness", 2, "2", new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Not Interested", 3, "2", new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Rearenge Program Schedule", 4, "2", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Not Interested", 5, "2", new DateTime(2019, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "IsActive", "VendorAddress", "VendorEmail", "VendorName", "VendorPhone" },
                values: new object[,]
                {
                    { 4, false, "10 A, Chittagong, Bangladesh", "silkline@gmail.com", "Silk Line", "01861587955" },
                    { 1, false, "120 A, Dhaka, Bangladesh", "greenline@gmail.com", "Green Line", "01731569155" },
                    { 2, false, "130 B, Rongpur, Bangladesh", "shohag@gmail.com", "Shohag", "01731569165" },
                    { 3, false, "140 A, Comilla, Bangladesh", "skyline@gmail.com", "Sky Line", "01861569155" },
                    { 5, false, "40 B, Khulna, Bangladesh", "salom@gmail.com", "S. Alom", "01861231155" }
                });

            migrationBuilder.InsertData(
                table: "BusDetails",
                columns: new[] { "BusDetailID", "BrandID", "BusCategoryID", "IsActive", "VendorID" },
                values: new object[,]
                {
                    { 1, 1, 1, false, 1 },
                    { 17, 5, 5, false, 4 },
                    { 15, 4, 4, false, 4 },
                    { 14, 4, 5, false, 4 },
                    { 16, 5, 5, false, 3 },
                    { 9, 1, 3, false, 3 },
                    { 6, 1, 2, false, 3 },
                    { 3, 2, 1, false, 3 },
                    { 8, 3, 3, false, 2 },
                    { 11, 2, 2, false, 2 },
                    { 2, 1, 1, false, 2 },
                    { 13, 3, 2, false, 1 },
                    { 12, 3, 1, false, 1 },
                    { 10, 2, 1, false, 1 },
                    { 7, 1, 3, false, 1 },
                    { 4, 1, 2, false, 1 },
                    { 5, 1, 2, false, 2 }
                });

            migrationBuilder.InsertData(
                table: "VendorPayments",
                columns: new[] { "VendorPaymentID", "PaymentDate", "PaymentDescription", "PaymentMethod", "TotalAmount", "VendorID" },
                values: new object[,]
                {
                    { 4, new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "By bKash", "bKash", 900m, 4 },
                    { 3, new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "By bKash", "bKash", 900m, 2 },
                    { 1, new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "By bKash", "bKash", 55m, 1 },
                    { 2, new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "By bKash", "bKash", 5775m, 3 },
                    { 5, new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "By Card", "Card", 800m, 5 }
                });

            migrationBuilder.InsertData(
                table: "RouteDetails",
                columns: new[] { "RouteDetailID", "BoardPoint", "BoardTime", "BusDetailID", "DropPoint", "DropTime", "Fare", "IsActive" },
                values: new object[,]
                {
                    { 1, "Chittagong", "10.30", 1, "Dhaka", "12.30", 800m, true },
                    { 23, "Rongpur", "7.30", 3, "Dhaka", "18.30", 200m, true },
                    { 12, "Comilla", "9.30", 3, "Shylet", "23.30", 700m, true },
                    { 8, "Dhaka", "11.30", 3, "Comilla", "21.30", 500m, true },
                    { 3, "Chittagong", "10.30", 3, "Dhaka", "12.30", 800m, true },
                    { 16, "Chittagong", "8.30", 11, "Comilla", "20.30", 800m, true },
                    { 19, "Rongpur", "7.30", 8, "Dhaka", "18.30", 200m, true },
                    { 20, "Rongpur", "7.30", 5, "Dhaka", "18.30", 200m, true },
                    { 22, "Rongpur", "7.30", 2, "Dhaka", "18.30", 200m, true },
                    { 11, "Comilla", "9.30", 2, "Shylet", "23.30", 700m, true },
                    { 7, "Dhaka", "11.30", 2, "Comilla", "21.30", 500m, true },
                    { 2, "Chittagong", "10.30", 2, "Dhaka", "12.30", 800m, true },
                    { 14, "Chittagong", "8.30", 13, "Comilla", "20.30", 800m, true },
                    { 15, "Chittagong", "8.30", 12, "Comilla", "20.30", 800m, true },
                    { 17, "Rongpur", "7.30", 10, "Dhaka", "18.30", 200m, true },
                    { 5, "Chittagong", "10.30", 7, "Dhaka", "12.30", 800m, true },
                    { 13, "Comilla", "9.30", 4, "Shylet", "23.30", 700m, true },
                    { 9, "Dhaka", "11.30", 4, "Comilla", "21.30", 500m, true },
                    { 4, "Chittagong", "10.30", 4, "Dhaka", "12.30", 800m, true },
                    { 21, "Rongpur", "7.30", 1, "Dhaka", "18.30", 200m, true },
                    { 10, "Comilla", "9.30", 1, "Shylet", "23.30", 700m, true },
                    { 6, "Dhaka", "11.30", 1, "Comilla", "21.30", 500m, true },
                    { 24, "Rongpur", "7.30", 6, "Dhaka", "18.30", 200m, true },
                    { 18, "Rongpur", "7.30", 9, "Dhaka", "18.30", 200m, true }
                });

            migrationBuilder.InsertData(
                table: "TicketReservations",
                columns: new[] { "TicketResrvID", "Gender", "NoOfTicket", "PassengerEmail", "PassengerName", "PassengerPhoneNo", "ReservationDate", "RouteDetailID", "SeatNo", "TicketNo", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Male", 2, "faoasal@gmail.com", "Faiasl", "01999998888", new DateTime(2019, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "A2, E2", null, 300m },
                    { 6, "Female", 1, "nasima@gmail.com", "Nasima", "01715546859", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "F2", null, 300m },
                    { 10, "Male", 1, "ses@gmail.com", "Noman", "01571584567", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "F2", null, 300m },
                    { 4, "Male", 1, "orvin@gmail.com", "Orvin", "01245789587", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "F2", null, 300m },
                    { 9, "Female", 1, "ksudi@gmail.com", "KUshi", "01745598754", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "F2", null, 300m },
                    { 5, "Male", 1, "mede@gmail.com", "Mehedi", "01478549365", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "F2", null, 300m },
                    { 2, "Male", 2, "abir@gmail.com", "Abir", "01514258965", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "D1, D2", null, 600m },
                    { 7, "Male", 1, "asoe@gmail.com", "Azim", "01758458968", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "F2", null, 300m },
                    { 11, "Female", 1, "sdfs@gmail.com", "Maimuna", "01589965587", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "F2", null, 300m },
                    { 3, "Male", 1, "mahamud@gmail.com", "Mahamud", "01248965478", new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "E4", null, 500m },
                    { 8, "Male", 1, "gasks@gmail.com", "Fahad", "01458879548", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "F2", null, 300m },
                    { 12, "Male", 1, "sdwe@gmail.com", "Belal", "01819878584", new DateTime(2019, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "F2", null, 300m }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "PaymentAmount", "PaymentDate", "Status", "TicketResrvID", "TransactionID", "VendorID", "VendorName" },
                values: new object[,]
                {
                    { 1, 1600.00m, new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, "TX20190101001", null, "Green Line" },
                    { 4, 1600.00m, new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, "TX20190101004", null, "S.Alom" },
                    { 2, 1600.00m, new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, "TX20190101002", null, "Green Line" },
                    { 3, 1600.00m, new DateTime(2019, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, "TX20190101003", null, "Silk Line" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
