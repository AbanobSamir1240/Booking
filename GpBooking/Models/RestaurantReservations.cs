using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("RestaurantReservations")]
    public class RestaurantReservations
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")] public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Restaurant")] public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        [DataType(DataType.Date)] public DateTime ReservationDate { get; set; }

        [DataType(DataType.Date)] public DateTime Date { get; set; }
        public int NumberOfTable { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool IsCheckIn { get; set; } = false;
    }
}
