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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
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
                    Id = table.Column<string>(nullable: false),
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
                    Discriminator = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    JoiningDate = table.Column<DateTime>(nullable: true),
                    LeavingDate = table.Column<DateTime>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    LastActive = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
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
                    UserId = table.Column<string>(nullable: false),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
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
                    BoardTime = table.Column<DateTime>(nullable: false),
                    DropPoint = table.Column<string>(nullable: true),
                    DropTime = table.Column<DateTime>(nullable: false),
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
