using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("HotelRoomType")]
    public class HotelRoomType
    {
        public HotelRoomType()
        {
            HotelRooms = new HashSet<HotelRooms>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeName { get; set; }

        public virtual ICollection<HotelRooms> HotelRooms { get; set; }
    }
}
