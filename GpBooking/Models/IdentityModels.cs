using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Booking.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GpBooking.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DbConnection", throwIfV1Schema: false)
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<HotelRoomTypesTbl>()
        //        .HasMany(e => e.HotelRoomsTbls)
        //        .WithRequired(e => e.HotelRoomTypesTbl)
        //        .HasForeignKey(e => e.room_type_id);

        //    modelBuilder.Entity<HotelsTbl>()
        //        .HasMany(e => e.HotelRoomsTbls)
        //        .WithRequired(e => e.HotelsTbl)
        //        .HasForeignKey(e => e.hotel_id);

        //    modelBuilder.Entity<HotelsTbl>()
        //        .HasMany(e => e.HotelServicesTbls)
        //        .WithRequired(e => e.HotelsTbl)
        //        .HasForeignKey(e => e.hotel_id);

        //    modelBuilder.Entity<PlacesTbl>()
        //        .HasMany(e => e.PlacesSubitemsTbls)
        //        .WithRequired(e => e.PlacesTbl)
        //        .HasForeignKey(e => e.parent_place_id);

        //    modelBuilder.Entity<RestaurantsTbl>()
        //        .HasMany(e => e.RestaurantDishsTbls)
        //        .WithRequired(e => e.RestaurantsTbl)
        //        .HasForeignKey(e => e.restaurant_id);

        //    modelBuilder.Entity<RestaurantsTbl>()
        //        .HasMany(e => e.RestaurantImagesTbls)
        //        .WithRequired(e => e.RestaurantsTbl)
        //        .HasForeignKey(e => e.restaurant_id);
        //}
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
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