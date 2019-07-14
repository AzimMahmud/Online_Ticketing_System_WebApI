namespace BusTicket.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.BusDetails",
                c => new
                    {
                        BusDetailID = c.Int(nullable: false, identity: true),
                        BrandID = c.Int(nullable: false),
                        BusCategoryID = c.Int(nullable: false),
                        VendorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BusDetailID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.BusCategories", t => t.BusCategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorID, cascadeDelete: true)
                .Index(t => t.BrandID)
                .Index(t => t.BusCategoryID)
                .Index(t => t.VendorID);
            
            CreateTable(
                "dbo.BusCategories",
                c => new
                    {
                        BusCategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BusCategoryID);
            
            CreateTable(
                "dbo.RouteDetails",
                c => new
                    {
                        RouteDetailsID = c.Int(nullable: false, identity: true),
                        BoardPoint = c.String(),
                        BoardTime = c.DateTime(nullable: false),
                        DropPoint = c.String(),
                        DropTime = c.DateTime(nullable: false),
                        BusDetailsID = c.Int(nullable: false),
                        Fare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BusDetails_BusDetailID = c.Int(),
                    })
                .PrimaryKey(t => t.RouteDetailsID)
                .ForeignKey("dbo.BusDetails", t => t.BusDetails_BusDetailID)
                .Index(t => t.BusDetails_BusDetailID);
            
            CreateTable(
                "dbo.TicketReservations",
                c => new
                    {
                        TicketResrvID = c.Int(nullable: false, identity: true),
                        PassengerName = c.String(),
                        PassengerPhoneNo = c.String(),
                        PassengerEmail = c.String(),
                        Gender = c.String(),
                        NoOfTicket = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SeatNo = c.String(),
                        RouteDetailsID = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TicketResrvID)
                .ForeignKey("dbo.RouteDetails", t => t.RouteDetailsID, cascadeDelete: true)
                .Index(t => t.RouteDetailsID);
            
            CreateTable(
                "dbo.SeatLayouts",
                c => new
                    {
                        SeatLayoutID = c.Int(nullable: false, identity: true),
                        BusDetailsID = c.Int(nullable: false),
                        TotalSeat = c.Int(nullable: false),
                        LastSeat = c.Int(nullable: false),
                        Layout = c.String(),
                        LayoutType = c.String(),
                        BusDetail_BusDetailID = c.Int(),
                    })
                .PrimaryKey(t => t.SeatLayoutID)
                .ForeignKey("dbo.BusDetails", t => t.BusDetail_BusDetailID)
                .Index(t => t.BusDetail_BusDetailID);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        VendorID = c.Int(nullable: false, identity: true),
                        VendorName = c.String(),
                        VendorPhone = c.String(),
                        VendorEmail = c.String(),
                        VendorAddress = c.String(),
                    })
                .PrimaryKey(t => t.VendorID);
            
            CreateTable(
                "dbo.VendorPayments",
                c => new
                    {
                        VendorPaymentID = c.Int(nullable: false, identity: true),
                        VendorID = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDescription = c.String(),
                        PaymentMethod = c.String(),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VendorPaymentID)
                .ForeignKey("dbo.Vendors", t => t.VendorID, cascadeDelete: true)
                .Index(t => t.VendorID);
            
            CreateTable(
                "dbo.BusReservationCancels",
                c => new
                    {
                        BusRsrvCnclID = c.Int(nullable: false, identity: true),
                        InvoiceID = c.Int(nullable: false),
                        Comment = c.String(),
                        NoOfBus = c.String(),
                        ReturnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BusRsrvCnclID);
            
            CreateTable(
                "dbo.BusReservations",
                c => new
                    {
                        BusReservationID = c.Int(nullable: false, identity: true),
                        PassengerName = c.String(nullable: false),
                        PassengerPhoneNo = c.String(nullable: false),
                        PassengerEmail = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        NoOfBus = c.String(),
                        ReservationDate = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BusReservationID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        BoardPoint = c.String(),
                        BoardTime = c.DateTime(nullable: false),
                        DropPoint = c.String(),
                        DropTime = c.DateTime(nullable: false),
                        BusDetails = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReservationDate = c.DateTime(nullable: false),
                        NoOfTicket = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentMethod = c.String(),
                        TransactionType = c.String(),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        MessageBody = c.String(),
                        RecipientID = c.Int(nullable: false),
                        MessageDeliveryTime = c.DateTime(nullable: false),
                        MessageDeliveryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        PasswordHash = c.Binary(),
                        PasswordSalt = c.Binary(),
                        Gender = c.String(),
                        Designation = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(),
                        JoiningDate = c.DateTime(nullable: false),
                        LeavingDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PayTypID = c.Int(nullable: false, identity: true),
                        PaymentMethod = c.String(),
                    })
                .PrimaryKey(t => t.PayTypID);
            
            CreateTable(
                "dbo.PromoOffers",
                c => new
                    {
                        PromoID = c.Int(nullable: false, identity: true),
                        PromoCode = c.String(),
                        PromoDetails = c.String(),
                    })
                .PrimaryKey(t => t.PromoID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TicketReturns",
                c => new
                    {
                        TicktReturnID = c.Int(nullable: false, identity: true),
                        InvoiceID = c.Int(nullable: false),
                        Comment = c.String(),
                        NoOfTicket = c.String(),
                        ReturnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TicktReturnID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Messages", "UserID", "dbo.Users");
            DropForeignKey("dbo.VendorPayments", "VendorID", "dbo.Vendors");
            DropForeignKey("dbo.BusDetails", "VendorID", "dbo.Vendors");
            DropForeignKey("dbo.SeatLayouts", "BusDetail_BusDetailID", "dbo.BusDetails");
            DropForeignKey("dbo.TicketReservations", "RouteDetailsID", "dbo.RouteDetails");
            DropForeignKey("dbo.RouteDetails", "BusDetails_BusDetailID", "dbo.BusDetails");
            DropForeignKey("dbo.BusDetails", "BusCategoryID", "dbo.BusCategories");
            DropForeignKey("dbo.BusDetails", "BrandID", "dbo.Brands");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Messages", new[] { "UserID" });
            DropIndex("dbo.VendorPayments", new[] { "VendorID" });
            DropIndex("dbo.SeatLayouts", new[] { "BusDetail_BusDetailID" });
            DropIndex("dbo.TicketReservations", new[] { "RouteDetailsID" });
            DropIndex("dbo.RouteDetails", new[] { "BusDetails_BusDetailID" });
            DropIndex("dbo.BusDetails", new[] { "VendorID" });
            DropIndex("dbo.BusDetails", new[] { "BusCategoryID" });
            DropIndex("dbo.BusDetails", new[] { "BrandID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TicketReturns");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PromoOffers");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.Invoices");
            DropTable("dbo.BusReservations");
            DropTable("dbo.BusReservationCancels");
            DropTable("dbo.VendorPayments");
            DropTable("dbo.Vendors");
            DropTable("dbo.SeatLayouts");
            DropTable("dbo.TicketReservations");
            DropTable("dbo.RouteDetails");
            DropTable("dbo.BusCategories");
            DropTable("dbo.BusDetails");
            DropTable("dbo.Brands");
        }
    }
}
