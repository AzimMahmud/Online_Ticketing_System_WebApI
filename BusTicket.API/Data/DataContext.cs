using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


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
        


    }
}