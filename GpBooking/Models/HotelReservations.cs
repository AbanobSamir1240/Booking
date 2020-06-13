using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("HotelReservations")]
    public class HotelReservations
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")] public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("HotelRooms")] public int HotelRoomsId { get; set; }
        public virtual HotelRooms HotelRooms { get; set; }

        [DataType(DataType.Date)] public DateTime ReservationDate { get; set; }

        [DataType(DataType.Date)] public DateTime StartDate { get; set; }

        [DataType(DataType.Date)] public DateTime EndDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool IsCheckIn { get; set; } = false;
    }
}
