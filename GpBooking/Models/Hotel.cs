using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        public Hotel()
        {
            HotelRooms = new HashSet<HotelRooms>();
            HotelServices = new HashSet<HotelServices>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ShortName { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(15)]
        public string Tel1 { get; set; }

        [StringLength(15)]
        public string Tel2 { get; set; }

        public int Rating { get; set; }

        public string About { get; set; }

        public virtual ICollection<HotelRooms> HotelRooms { get; set; }

        public virtual ICollection<HotelServices> HotelServices { get; set; }
    }
}
