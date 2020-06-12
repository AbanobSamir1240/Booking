using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GpBooking.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DbConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<ApplicationLog> ApplicationLogs { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<HotelReservations> HotelReservations { get; set; }
        public virtual DbSet<HotelRooms> HotelRooms { get; set; }
        public virtual DbSet<HotelRoomType> HotelRoomTypes { get; set; }
        public virtual DbSet<HotelServices> HotelServices { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<PlacesSubitems> PlacesSubitems { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<RestaurantDishs> RestaurantDishs { get; set; }
        public virtual DbSet<RestaurantImages> RestaurantImages { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }

        public static ApplicationDbContext CreateDb()
        {
            return new ApplicationDbContext();
        }
    }
}
