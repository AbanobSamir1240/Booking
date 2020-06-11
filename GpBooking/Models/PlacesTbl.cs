namespace Booking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlacesTbl")]
    public partial class PlacesTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlacesTbl()
        {
            PlacesSubitemsTbls = new HashSet<PlacesSubitemsTbl>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string short_name { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [Required]
        public string about_html { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlacesSubitemsTbl> PlacesSubitemsTbls { get; set; }
    }
}
