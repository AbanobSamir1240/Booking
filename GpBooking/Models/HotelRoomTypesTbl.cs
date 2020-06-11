namespace Booking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotelRoomTypesTbl")]
    public partial class HotelRoomTypesTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelRoomTypesTbl()
        {
            HotelRoomsTbls = new HashSet<HotelRoomsTbl>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string type_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelRoomsTbl> HotelRoomsTbls { get; set; }
    }
}
