using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GpBooking.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DbConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<ApplicationLog> ApplicationLogs { get; set; }
        public virtual DbSet<ClubsTbl> ClubsTbls { get; set; }
        public virtual DbSet<HotelReservationsTbl> HotelReservationsTbls { get; set; }
        public virtual DbSet<HotelRoomsTbl> HotelRoomsTbls { get; set; }
        public virtual DbSet<HotelRoomTypesTbl> HotelRoomTypesTbls { get; set; }
        public virtual DbSet<HotelServicesTbl> HotelServicesTbls { get; set; }
        public virtual DbSet<HotelsTbl> HotelsTbls { get; set; }
        public virtual DbSet<PlacesSubitemsTbl> PlacesSubitemsTbls { get; set; }
        public virtual DbSet<PlacesTbl> PlacesTbls { get; set; }
        public virtual DbSet<RestaurantDishsTbl> RestaurantDishsTbls { get; set; }
        public virtual DbSet<RestaurantImagesTbl> RestaurantImagesTbls { get; set; }
        public virtual DbSet<RestaurantsTbl> RestaurantsTbls { get; set; }
        public virtual DbSet<UsersTbl> UsersTbls { get; set; }
    }
}
