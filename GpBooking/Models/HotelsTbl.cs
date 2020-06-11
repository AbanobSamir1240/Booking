using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("HotelsTbl")]
    public class HotelsTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelsTbl()
        {
            HotelRoomsTbls = new HashSet<HotelRoomsTbl>();
            HotelServicesTbls = new HashSet<HotelServicesTbl>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string short_name { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(150)]
        public string address { get; set; }

        [StringLength(15)]
        public string tel1 { get; set; }

        [StringLength(15)]
        public string tel2 { get; set; }

        public int rating { get; set; }

        public string about_html { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelRoomsTbl> HotelRoomsTbls { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelServicesTbl> HotelServicesTbls { get; set; }
    }
}
