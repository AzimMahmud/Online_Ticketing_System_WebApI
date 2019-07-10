using Microsoft.EntityFrameworkCore;
using BusTicket.API.Models;


namespace BusTicket.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public virtual DbSet<BusCategory> BusCategory { get; set; }
        public virtual DbSet<BusDetail> BusDetails { get; set; }
        public virtual DbSet<BusReservation>  BusReservations { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<PromoOffer> PromoOffers { get; set; }
        public virtual DbSet<VendorPayment> VendorPayments { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<TicketReservation> TicketReservations { get; set; }
        public virtual DbSet<RouteDetails> RouteDetailses { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<TicketReturn> TicketReturns{ get; set; }
        public virtual DbSet<BusCategory> BusCategories  { get; set; }
        public virtual DbSet<BusReservationCancel> BusReservationCancels { get; set; }
        public virtual DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusDetail>().HasData(   
                new BusDetail {BusDetailID = 1, BrandID = 1, BusCategoryID = 1, VendorID = 1},
                new BusDetail {BusDetailID = 2, BrandID = 2, BusCategoryID = 2, VendorID = 2},
                new BusDetail {BusDetailID = 3, BrandID = 1, BusCategoryID = 1, VendorID = 3},
                new BusDetail {BusDetailID = 4, BrandID = 2, BusCategoryID = 2, VendorID = 2}
            );

            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandID = 1, Name = "Hino"},
                new Brand { BrandID = 2, Name = "Mac"},
                new Brand { BrandID = 3, Name = "Scania"}
            );


            modelBuilder.Entity<BusCategory>().HasData(
                new BusCategory { BusCategoryID = 1, Name = "Non-AC"},
                new BusCategory { BusCategoryID = 2, Name = "AC"}
            );

            modelBuilder.Entity<Vendor>().HasData(
                new Vendor { VendorID = 1, VendorName = "Green Line", VendorEmail = "greenline@gmail.com", VendorPhone = "01731569155", VendorAddress = "120 A, Dhaka, Bangladesh" },
                new Vendor { VendorID = 2, VendorName = "Shohag", VendorEmail = "shohag@gmail.com", VendorPhone = "01731569165", VendorAddress = "130 B, Dhaka, Bangladesh" },
                new Vendor { VendorID = 3, VendorName = "Sky Line", VendorEmail = "skyline@gmail.com", VendorPhone = "01861569155", VendorAddress = "140 A, Dhaka, Bangladesh" }
                
            );

        }
    }
}