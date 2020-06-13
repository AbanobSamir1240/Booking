using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("ClubReservations")]
    public class ClubReservations
    {


        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")] public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Club")] public int ClubId { get; set; }
        public virtual Club Club { get; set; }

        [DataType(DataType.Date)] public DateTime ReservationDate { get; set; }

        [DataType(DataType.Date)] public DateTime StartDate { get; set; }

        [DataType(DataType.Date)] public DateTime EndDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool IsCheckIn { get; set; } = false;
    }
}
