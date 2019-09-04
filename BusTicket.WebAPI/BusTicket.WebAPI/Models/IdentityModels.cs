using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using BusTicket.WebAPI.Core.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace BusTicket.WebAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class BusTicketContext : IdentityDbContext<ApplicationUser>
    {
        public BusTicketContext()
            : base("DbCon", throwIfV1Schema: false)
        {
        }
        
        public static BusTicketContext Create()
        {
            return new BusTicketContext();
        }


        public virtual DbSet<BusCategory> BusCategories { get; set; }
        public virtual DbSet<BusDetail> BusDetails { get; set; }
        public virtual DbSet<BusReservation> BusReservations { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<PromoOffer> PromoOffers { get; set; }
        public virtual DbSet<VendorPayment> VendorPayments { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<TicketReservation> TicketReservations { get; set; }
        public virtual DbSet<RouteDetail> RouteDetails { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<TicketReturn> TicketReturns { get; set; }
      
        public virtual DbSet<BusReservationCancel> BusReservationCancels { get; set; }
        public virtual DbSet<Message> Messages { get; set; }


    }
}