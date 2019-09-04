using BusTicket.API.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace BusTicket.API.Persistence
{

    public class BusTicketContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public BusTicketContext(DbContextOptions<BusTicketContext> options) : base(options)
        {
        }


        public virtual DbSet<BusCategory> BusCategories { get; set; }
        public virtual DbSet<BusDetail> BusDetails { get; set; }
        public virtual DbSet<BusReservation> BusReservations { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<PromoOffer> PromoOffers { get; set; }
        public virtual DbSet<RouteDetail> RouteDetails { get; set; }
        public virtual DbSet<TicketReservation> TicketReservations { get; set; }
        public virtual DbSet<VendorPayment> VendorPayments { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<TicketReturn> TicketReturns { get; set; }
        public virtual DbSet<BusReservationCancel> BusReservationCancels { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<SeatLayout> SeatLayout { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });









            modelBuilder.Entity<Brand>().HasData(
            new Brand { BrandID = 1, Name = "Hino" },
            new Brand { BrandID = 2, Name = "Mac" },
            new Brand { BrandID = 3, Name = "Scania" },
            new Brand { BrandID = 4, Name = "Volvo" },
            new Brand { BrandID = 5, Name = "Mistsubishi" }
        );


            modelBuilder.Entity<BusCategory>().HasData(
                new BusCategory { BusCategoryID = 1, Name = "Non-AC" },
                new BusCategory { BusCategoryID = 2, Name = "AC" },
                new BusCategory { BusCategoryID = 3, Name = "Double-Decker" },
                new BusCategory { BusCategoryID = 4, Name = "Slipper" },
                new BusCategory { BusCategoryID = 5, Name = "Chair-Coach" }
            );

            modelBuilder.Entity<Vendor>().HasData(
                new Vendor { VendorID = 1, VendorName = "Green Line", VendorEmail = "greenline@gmail.com", VendorPhone = "01731569155", VendorAddress = "120 A, Dhaka, Bangladesh" },
                new Vendor { VendorID = 2, VendorName = "Shohag", VendorEmail = "shohag@gmail.com", VendorPhone = "01731569165", VendorAddress = "130 B, Rongpur, Bangladesh" },
                new Vendor { VendorID = 3, VendorName = "Sky Line", VendorEmail = "skyline@gmail.com", VendorPhone = "01861569155", VendorAddress = "140 A, Comilla, Bangladesh" },
                new Vendor { VendorID = 4, VendorName = "Silk Line", VendorEmail = "silkline@gmail.com", VendorPhone = "01861587955", VendorAddress = "10 A, Chittagong, Bangladesh" },
                new Vendor { VendorID = 5, VendorName = "S. Alom", VendorEmail = "salom@gmail.com", VendorPhone = "01861231155", VendorAddress = "40 B, Khulna, Bangladesh" }

            );
            modelBuilder.Entity<BusDetail>().HasData(
               new BusDetail { BusDetailID = 1, BrandID = 1, BusCategoryID = 1, VendorID = 1 },
               new BusDetail { BusDetailID = 2, BrandID = 1, BusCategoryID = 1, VendorID = 2 },
               new BusDetail { BusDetailID = 3, BrandID = 2, BusCategoryID = 1, VendorID = 3 },
               new BusDetail { BusDetailID = 4, BrandID = 1, BusCategoryID = 2, VendorID = 1 },
               new BusDetail { BusDetailID = 5, BrandID = 1, BusCategoryID = 2, VendorID = 2 },
               new BusDetail { BusDetailID = 6, BrandID = 1, BusCategoryID = 2, VendorID = 3 },
               new BusDetail { BusDetailID = 7, BrandID = 1, BusCategoryID = 3, VendorID = 1 },
               new BusDetail { BusDetailID = 8, BrandID = 3, BusCategoryID = 3, VendorID = 2 },
               new BusDetail { BusDetailID = 9, BrandID = 1, BusCategoryID = 3, VendorID = 3 },
               new BusDetail { BusDetailID = 10, BrandID = 2, BusCategoryID = 1, VendorID = 1 },
               new BusDetail { BusDetailID = 11, BrandID = 2, BusCategoryID = 2, VendorID = 2 },
               new BusDetail { BusDetailID = 12, BrandID = 3, BusCategoryID = 1, VendorID = 1 },
               new BusDetail { BusDetailID = 13, BrandID = 3, BusCategoryID = 2, VendorID = 1 },
               new BusDetail { BusDetailID = 14, BrandID = 4, BusCategoryID = 5, VendorID = 4 },
               new BusDetail { BusDetailID = 15, BrandID = 4, BusCategoryID = 4, VendorID = 4 },
               new BusDetail { BusDetailID = 16, BrandID = 5, BusCategoryID = 5, VendorID = 3 },
               new BusDetail { BusDetailID = 17, BrandID = 5, BusCategoryID = 5, VendorID = 4 }
           );

            modelBuilder.Entity<BusReservation>().HasData(
               new BusReservation { BusReservationID = 1, PassengerName = "Abir", PassengerPhoneNo = "01999998888", PassengerEmail = "abir@gmail.com", Gender = "Male", NoOfBus = "2", ReservationDate = Convert.ToDateTime("08/22/2019"), TotalAmount = 500 },
               new BusReservation { BusReservationID = 2, PassengerName = "Faisal", PassengerPhoneNo = "01752676253", PassengerEmail = "faisal@gmail.com", Gender = "Male", NoOfBus = "3", ReservationDate = Convert.ToDateTime("08/21/2019"), TotalAmount = 500 },
               new BusReservation { BusReservationID = 3, PassengerName = "Mahanud", PassengerPhoneNo = "01916783647", PassengerEmail = "mahamud@gmail.com", Gender = "Male", NoOfBus = "1", ReservationDate = Convert.ToDateTime("08/25/2019"), TotalAmount = 500 },
               new BusReservation { BusReservationID = 4, PassengerName = "Faiaz", PassengerPhoneNo = "01716263748", PassengerEmail = "faiaz@gmail.com", Gender = "Male", NoOfBus = "3", ReservationDate = Convert.ToDateTime("08/21/2019"), TotalAmount = 400 },
               new BusReservation { BusReservationID = 5, PassengerName = "Orvin", PassengerPhoneNo = "01613567893", PassengerEmail = "orrvin@gmail.com", Gender = "Male", NoOfBus = "4", ReservationDate = Convert.ToDateTime("08/24/2019"), TotalAmount = 900 },
               new BusReservation { BusReservationID = 6, PassengerName = "Rasheda", PassengerPhoneNo = "01613567866", PassengerEmail = "rasgeda@gmail.com", Gender = "Female", NoOfBus = "2", ReservationDate = Convert.ToDateTime("08/14/2019"), TotalAmount = 600 },
               new BusReservation { BusReservationID = 7, PassengerName = "Rohima", PassengerPhoneNo = "01613567852", PassengerEmail = "rohima@gmail.com", Gender = "Female", NoOfBus = "1", ReservationDate = Convert.ToDateTime("08/20/2019"), TotalAmount = 500 },
               new BusReservation { BusReservationID = 8, PassengerName = "Naima", PassengerPhoneNo = "01613567800", PassengerEmail = "nasima@gmail.com", Gender = "Female", NoOfBus = "3", ReservationDate = Convert.ToDateTime("08/24/2019"), TotalAmount = 380 }
           );

            modelBuilder.Entity<PaymentType>().HasData(
              new PaymentType { PayTypID = 1, PaymentMethod = "bKash", IsActive = true },
              new PaymentType { PayTypID = 2, PaymentMethod = "Credit/Debit Card", IsActive = false },
              new PaymentType { PayTypID = 3, PaymentMethod = "iPay", IsActive = true }
          );

            modelBuilder.Entity<PromoOffer>().HasData(
              new PromoOffer { PromoID = 1, PromoCode = "pc-eid-1", PromoDetails = "For STAR passenger eid-ul-fitar promo offer" },
              new PromoOffer { PromoID = 2, PromoCode = "pc-eid-2", PromoDetails = "For GOLD passenger eid-ul-fitar promo offer" },
              new PromoOffer { PromoID = 3, PromoCode = "pc-eid-3", PromoDetails = "For SILVER passenger eid-ul-fitar promo offer" },
              new PromoOffer { PromoID = 4, PromoCode = "pc-eid-4", PromoDetails = "For DIAMOND passenger eid-ul-fitar promo offer" },
              new PromoOffer { PromoID = 5, PromoCode = "pc-eid-5", PromoDetails = "For NEW passenger eid-ul-fitar promo offer" }

          );

            modelBuilder.Entity<RouteDetail>().HasData(
               new RouteDetail { RouteDetailID = 1, BoardPoint = "Chittagong", BoardTime = "10.30", DropPoint = "Dhaka", DropTime = "12.30", BusDetailID = 1, Fare = 800, IsActive = true },
               new RouteDetail { RouteDetailID = 2, BoardPoint = "Chittagong", BoardTime = "10.30", DropPoint = "Dhaka", DropTime = "12.30", BusDetailID = 2, Fare = 800, IsActive = true },
               new RouteDetail { RouteDetailID = 3, BoardPoint = "Chittagong", BoardTime = "10.30", DropPoint = "Dhaka", DropTime = "12.30", BusDetailID = 3, Fare = 800, IsActive = true },
               new RouteDetail { RouteDetailID = 4, BoardPoint = "Chittagong", BoardTime = "10.30", DropPoint = "Dhaka", DropTime = "12.30", BusDetailID = 4, Fare = 800, IsActive = true },
               new RouteDetail { RouteDetailID = 5, BoardPoint = "Chittagong", BoardTime = "10.30", DropPoint = "Dhaka", DropTime = "12.30", BusDetailID = 7, Fare = 800, IsActive = true },
               new RouteDetail { RouteDetailID = 6, BoardPoint = "Dhaka", BoardTime = "11.30", DropPoint = "Comilla", DropTime = "21.30", BusDetailID = 1, Fare = 500, IsActive = true },
               new RouteDetail { RouteDetailID = 7, BoardPoint = "Dhaka", BoardTime = "11.30", DropPoint = "Comilla", DropTime = "21.30", BusDetailID = 2, Fare = 500, IsActive = true },
               new RouteDetail { RouteDetailID = 8, BoardPoint = "Dhaka", BoardTime = "11.30", DropPoint = "Comilla", DropTime = "21.30", BusDetailID = 3, Fare = 500, IsActive = true },
               new RouteDetail { RouteDetailID = 9, BoardPoint = "Dhaka", BoardTime = "11.30", DropPoint = "Comilla", DropTime = "21.30", BusDetailID = 4, Fare = 500, IsActive = true },
               new RouteDetail { RouteDetailID = 10, BoardPoint = "Comilla", BoardTime = "9.30", DropPoint = "Shylet", DropTime = "23.30", BusDetailID = 1, Fare = 700, IsActive = true },
               new RouteDetail { RouteDetailID = 11, BoardPoint = "Comilla", BoardTime = "9.30", DropPoint = "Shylet", DropTime = "23.30", BusDetailID = 2, Fare = 700, IsActive = true },
               new RouteDetail { RouteDetailID = 12, BoardPoint = "Comilla", BoardTime = "9.30", DropPoint = "Shylet", DropTime = "23.30", BusDetailID = 3, Fare = 700, IsActive = true },
               new RouteDetail { RouteDetailID = 13, BoardPoint = "Comilla", BoardTime = "9.30", DropPoint = "Shylet", DropTime = "23.30", BusDetailID = 4, Fare = 700, IsActive = true },
               new RouteDetail { RouteDetailID = 14, BoardPoint = "Chittagong", BoardTime = "8.30", DropPoint = "Comilla", DropTime = "20.30", BusDetailID = 13, Fare = 800, IsActive = true },
               new RouteDetail { RouteDetailID = 15, BoardPoint = "Chittagong", BoardTime = "8.30", DropPoint = "Comilla", DropTime = "20.30", BusDetailID = 12, Fare = 800, IsActive = true },
               new RouteDetail { RouteDetailID = 16, BoardPoint = "Chittagong", BoardTime = "8.30", DropPoint = "Comilla", DropTime = "20.30", BusDetailID = 11, Fare = 800, IsActive = true },
               new RouteDetail { RouteDetailID = 17, BoardPoint = "Rongpur", BoardTime = "7.30", DropPoint = "Dhaka", DropTime = "18.30", BusDetailID = 10, Fare = 200, IsActive = true },
               new RouteDetail { RouteDetailID = 18, BoardPoint = "Rongpur", BoardTime = "7.30", DropPoint = "Dhaka", DropTime = "18.30", BusDetailID = 9, Fare = 200, IsActive = true },
               new RouteDetail { RouteDetailID = 19, BoardPoint = "Rongpur", BoardTime = "7.30", DropPoint = "Dhaka", DropTime = "18.30", BusDetailID = 8, Fare = 200, IsActive = true },
               new RouteDetail { RouteDetailID = 20, BoardPoint = "Rongpur", BoardTime = "7.30", DropPoint = "Dhaka", DropTime = "18.30", BusDetailID = 5, Fare = 200, IsActive = true },
               new RouteDetail { RouteDetailID = 21, BoardPoint = "Rongpur", BoardTime = "7.30", DropPoint = "Dhaka", DropTime = "18.30", BusDetailID = 1, Fare = 200, IsActive = true },
               new RouteDetail { RouteDetailID = 22, BoardPoint = "Rongpur", BoardTime = "7.30", DropPoint = "Dhaka", DropTime = "18.30", BusDetailID = 2, Fare = 200, IsActive = true },
               new RouteDetail { RouteDetailID = 23, BoardPoint = "Rongpur", BoardTime = "7.30", DropPoint = "Dhaka", DropTime = "18.30", BusDetailID = 3, Fare = 200, IsActive = true },
               new RouteDetail { RouteDetailID = 24, BoardPoint = "Rongpur", BoardTime = "7.30", DropPoint = "Dhaka", DropTime = "18.30", BusDetailID = 6, Fare = 200, IsActive = true }

           );


            modelBuilder.Entity<SeatLayout>().HasData(
               new SeatLayout { SeatLayoutID = 1, BusDetailsID = 1 },
               new SeatLayout { SeatLayoutID = 2, BusDetailsID = 2 },
               new SeatLayout { SeatLayoutID = 3, BusDetailsID = 3 },
               new SeatLayout { SeatLayoutID = 4, BusDetailsID = 4 },
               new SeatLayout { SeatLayoutID = 5, BusDetailsID = 5 },
               new SeatLayout { SeatLayoutID = 6, BusDetailsID = 6 },
               new SeatLayout { SeatLayoutID = 7, BusDetailsID = 7 },
               new SeatLayout { SeatLayoutID = 8, BusDetailsID = 8 },
               new SeatLayout { SeatLayoutID = 9, BusDetailsID = 9 },
               new SeatLayout { SeatLayoutID = 10, BusDetailsID = 10 },
               new SeatLayout { SeatLayoutID = 11, BusDetailsID = 11 }


           );


            modelBuilder.Entity<TicketReservation>().HasData(
               new TicketReservation { TicketResrvID = 1, PassengerName = "Faiasl", PassengerPhoneNo = "01999998888", PassengerEmail = "faoasal@gmail.com", Gender = "Male", NoOfTicket = 2, UnitPrice = 300, SeatNo = "A2, E2", RouteDetailID = 1, ReservationDate = DateTime.Parse("08/25/2019") },
               new TicketReservation { TicketResrvID = 2, PassengerName = "Abir", PassengerPhoneNo = "01514258965", PassengerEmail = "abir@gmail.com", Gender = "Male", NoOfTicket = 2, UnitPrice = 600, SeatNo = "D1, D2", RouteDetailID = 2, ReservationDate = DateTime.Parse("08/26/2019") },
               new TicketReservation { TicketResrvID = 3, PassengerName = "Mahamud", PassengerPhoneNo = "01248965478", PassengerEmail = "mahamud@gmail.com", Gender = "Male", NoOfTicket = 1, UnitPrice = 500, SeatNo = "E4", RouteDetailID = 3, ReservationDate = DateTime.Parse("08/24/2019") },
               new TicketReservation { TicketResrvID = 4, PassengerName = "Orvin", PassengerPhoneNo = "01245789587", PassengerEmail = "orvin@gmail.com", Gender = "Male", NoOfTicket = 1, UnitPrice = 300, SeatNo = "F2", RouteDetailID = 4, ReservationDate = DateTime.Parse("08/26/2019") },
               new TicketReservation { TicketResrvID = 5, PassengerName = "Mehedi", PassengerPhoneNo = "01478549365", PassengerEmail = "mede@gmail.com", Gender = "Male", NoOfTicket = 1, UnitPrice = 300, SeatNo = "F2", RouteDetailID = 5, ReservationDate = DateTime.Parse("08/26/2019") },
               new TicketReservation { TicketResrvID = 6, PassengerName = "Nasima", PassengerPhoneNo = "01715546859", PassengerEmail = "nasima@gmail.com", Gender = "Female", NoOfTicket = 1, UnitPrice = 300, SeatNo = "F2", RouteDetailID = 6, ReservationDate = DateTime.Parse("08/26/2019") },
               new TicketReservation { TicketResrvID = 7, PassengerName = "Azim", PassengerPhoneNo = "01758458968", PassengerEmail = "asoe@gmail.com", Gender = "Male", NoOfTicket = 1, UnitPrice = 300, SeatNo = "F2", RouteDetailID = 7, ReservationDate = DateTime.Parse("08/26/2019") },
               new TicketReservation { TicketResrvID = 8, PassengerName = "Fahad", PassengerPhoneNo = "01458879548", PassengerEmail = "gasks@gmail.com", Gender = "Male", NoOfTicket = 1, UnitPrice = 300, SeatNo = "F2", RouteDetailID = 8, ReservationDate = DateTime.Parse("08/26/2019") },
               new TicketReservation { TicketResrvID = 9, PassengerName = "KUshi", PassengerPhoneNo = "01745598754", PassengerEmail = "ksudi@gmail.com", Gender = "Female", NoOfTicket = 1, UnitPrice = 300, SeatNo = "F2", RouteDetailID = 9, ReservationDate = DateTime.Parse("08/26/2019") },
               new TicketReservation { TicketResrvID = 10, PassengerName = "Noman", PassengerPhoneNo = "01571584567", PassengerEmail = "ses@gmail.com", Gender = "Male", NoOfTicket = 1, UnitPrice = 300, SeatNo = "F2", RouteDetailID = 10, ReservationDate = DateTime.Parse("08/26/2019") },
               new TicketReservation { TicketResrvID = 11, PassengerName = "Maimuna", PassengerPhoneNo = "01589965587", PassengerEmail = "sdfs@gmail.com", Gender = "Female", NoOfTicket = 1, UnitPrice = 300, SeatNo = "F2", RouteDetailID = 11, ReservationDate = DateTime.Parse("08/26/2019") },
               new TicketReservation { TicketResrvID = 12, PassengerName = "Belal", PassengerPhoneNo = "01819878584", PassengerEmail = "sdwe@gmail.com", Gender = "Male", NoOfTicket = 1, UnitPrice = 300, SeatNo = "F2", RouteDetailID = 12, ReservationDate = DateTime.Parse("08/26/2019") }

           );

            modelBuilder.Entity<VendorPayment>().HasData(
               new VendorPayment { VendorPaymentID = 1, VendorID = 1, TotalAmount = 55, PaymentDescription = "By bKash", PaymentMethod = "bKash", PaymentDate = DateTime.Parse("08/20/2019") },
               new VendorPayment { VendorPaymentID = 2, VendorID = 3, TotalAmount = 5775, PaymentDescription = "By bKash", PaymentMethod = "bKash", PaymentDate = DateTime.Parse("08/25/2019") },
               new VendorPayment { VendorPaymentID = 3, VendorID = 2, TotalAmount = 900, PaymentDescription = "By bKash", PaymentMethod = "bKash", PaymentDate = DateTime.Parse("08/15/2019") },
               new VendorPayment { VendorPaymentID = 4, VendorID = 4, TotalAmount = 900, PaymentDescription = "By bKash", PaymentMethod = "bKash", PaymentDate = DateTime.Parse("08/20/2019") },
               new VendorPayment { VendorPaymentID = 5, VendorID = 5, TotalAmount = 800, PaymentDescription = "By Card", PaymentMethod = "Card", PaymentDate = DateTime.Parse("08/24/2019") }

           );

            modelBuilder.Entity<Invoice>().HasData(
               new Invoice { InvoiceID = 1, Name = "Faisal", PhoneNo = "01725635613", Email = "faisaal@gmail.com", Gender = "Male", BoardPoint = "Chittagong", DropPoint = "Dhaka", BoardTime = DateTime.Parse("08/20/2019"), DropTime = DateTime.Parse("08/20/2019"), TotalAmount = 500, ReservationDate = DateTime.Parse("08/15/2019"), NoOfTicket = "4", UnitPrice = 500, PaymentMethod = "bKash", TransactionType = "bKash" },
               new Invoice { InvoiceID = 2, Name = "Abir", PhoneNo = "01746357890", Email = "abir@gmail.com", Gender = "Male", BoardPoint = "Dhaka", DropPoint = "Comilla", BoardTime = DateTime.Parse("08/01/2019"), DropTime = DateTime.Parse("08/01/2019"), TotalAmount = 600, ReservationDate = DateTime.Parse("08/01/2019"), NoOfTicket = "1", UnitPrice = 400, PaymentMethod = "Card", TransactionType = "Card" },
               new Invoice { InvoiceID = 3, Name = "Mahamud", PhoneNo = "01614562789", Email = "mahamud@gmail.com", Gender = "Male", BoardPoint = "Dhaka", DropPoint = "Rongpur", BoardTime = DateTime.Parse("08/01/2019"), DropTime = DateTime.Parse("08/01/2019"), TotalAmount = 800, ReservationDate = DateTime.Parse("08/01/2019"), NoOfTicket = "4", UnitPrice = 600, PaymentMethod = "bKash", TransactionType = "bKash" },
               new Invoice { InvoiceID = 4, Name = "Faiaz", PhoneNo = "01763526790", Email = "faiaz@gmail.com", Gender = "Male", BoardPoint = "Chittagong", DropPoint = "Rongpur", BoardTime = DateTime.Parse("08/15/2019"), DropTime = DateTime.Parse("08/15/2019"), TotalAmount = 700, ReservationDate = DateTime.Parse("08/10/2019"), NoOfTicket = "3", UnitPrice = 700, PaymentMethod = "bKash", TransactionType = "bKash" },
               new Invoice { InvoiceID = 5, Name = "Lopez", PhoneNo = "01712563479", Email = "lopez@gmail.com", Gender = "Female", BoardPoint = "Dhaka", DropPoint = "Borishal", BoardTime = DateTime.Parse("08/06/2019"), DropTime = DateTime.Parse("08/06/2019"), TotalAmount = 900, ReservationDate = DateTime.Parse("08/05/2019"), NoOfTicket = "2", UnitPrice = 800, PaymentMethod = "Card", TransactionType = "Card" },
               new Invoice { InvoiceID = 6, Name = "Mahima", PhoneNo = "01715589874", Email = "mahima@gmail.com", Gender = "Female", BoardPoint = "Dhaka", DropPoint = "Borishal", BoardTime = DateTime.Parse("08/05/2019"), DropTime = DateTime.Parse("08/05/2019"), TotalAmount = 600, ReservationDate = DateTime.Parse("08/03/2019"), NoOfTicket = "1", UnitPrice = 800, PaymentMethod = "bKash", TransactionType = "bKash" },
               new Invoice { InvoiceID = 7, Name = "Sadia", PhoneNo = "01548789548", Email = "sadia@gmail.com", Gender = "Female", BoardPoint = "Dhaka", DropPoint = "Borishal", BoardTime = DateTime.Parse("08/02/2019"), DropTime = DateTime.Parse("08/02/2019"), TotalAmount = 500, ReservationDate = DateTime.Parse("08/01/2019"), NoOfTicket = "3", UnitPrice = 800, PaymentMethod = "bKash", TransactionType = "bKash" },
               new Invoice { InvoiceID = 8, Name = "Costa", PhoneNo = "01848784532", Email = "costa@gmail.com", Gender = "Female", BoardPoint = "Dhaka", DropPoint = "Borishal", BoardTime = DateTime.Parse("08/01/2019"), DropTime = DateTime.Parse("08/01/2019"), TotalAmount = 800, ReservationDate = DateTime.Parse("08/01/2019"), NoOfTicket = "1", UnitPrice = 800, PaymentMethod = "bKash", TransactionType = "bKash" }

           );


            modelBuilder.Entity<Payment>().HasData(
                        new Payment { PaymentID = 1, VendorName = "Green Line", TicketResrvID = 1, TransactionID = "TX20190101001", PaymentAmount = 1600.00M, PaymentDate = DateTime.Parse("08/01/2019") },
                         new Payment { PaymentID = 2, VendorName = "Green Line", TicketResrvID = 2, TransactionID = "TX20190101002", PaymentAmount = 1600.00M, PaymentDate = DateTime.Parse("08/01/2019") },
                         new Payment { PaymentID = 3, VendorName = "Silk Line", TicketResrvID = 3, TransactionID = "TX20190101003", PaymentAmount = 1600.00M, PaymentDate = DateTime.Parse("08/24/2019") },
                         new Payment { PaymentID = 4, VendorName = "S.Alom", TicketResrvID = 4, TransactionID = "TX20190101004", PaymentAmount = 1600.00M, PaymentDate = DateTime.Parse("08/20/2019") }
                    );

            modelBuilder.Entity<BusReservationCancel>().HasData(
               new BusReservationCancel { BusRsrvCnclID = 1, InvoiceID = 1, Comment = "For Wedding", NoOfBus = "3", ReturnDate = DateTime.Parse("08/25/2019") },
               new BusReservationCancel { BusRsrvCnclID = 2, InvoiceID = 2, Comment = "For Picnic", NoOfBus = "2", ReturnDate = DateTime.Parse("08/25/2019") },
               new BusReservationCancel { BusRsrvCnclID = 3, InvoiceID = 3, Comment = "For Weading", NoOfBus = "2", ReturnDate = DateTime.Parse("08/25/2019") },
               new BusReservationCancel { BusRsrvCnclID = 4, InvoiceID = 4, Comment = "For Campaign", NoOfBus = "2", ReturnDate = DateTime.Parse("08/25/2019") },
               new BusReservationCancel { BusRsrvCnclID = 5, InvoiceID = 5, Comment = "For Tour", NoOfBus = "2", ReturnDate = DateTime.Parse("08/25/2019") }

           );

            modelBuilder.Entity<TicketReturn>().HasData(
               new TicketReturn { TicktReturnID = 1, InvoiceID = 1, Comment = "Rearenge Program Schedule", NoOfTicket = "2", ReturnDate = DateTime.Parse("08/25/2019") },
               new TicketReturn { TicktReturnID = 2, InvoiceID = 2, Comment = "For Sickness", NoOfTicket = "2", ReturnDate = DateTime.Parse("08/20/2019") },
               new TicketReturn { TicktReturnID = 3, InvoiceID = 3, Comment = "Not Interested", NoOfTicket = "2", ReturnDate = DateTime.Parse("08/15/2019") },
               new TicketReturn { TicktReturnID = 4, InvoiceID = 4, Comment = "Rearenge Program Schedule", NoOfTicket = "2", ReturnDate = DateTime.Parse("08/25/2019") },
               new TicketReturn { TicktReturnID = 5, InvoiceID = 5, Comment = "Not Interested", NoOfTicket = "2", ReturnDate = DateTime.Parse("08/11/2019") }

           );
        }

    }


}
