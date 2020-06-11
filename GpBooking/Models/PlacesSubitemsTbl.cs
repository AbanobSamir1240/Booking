namespace Booking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlacesSubitemsTbl")]
    public partial class PlacesSubitemsTbl
    {
        public int id { get; set; }

        public int parent_place_id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        public string about_html { get; set; }

        public virtual PlacesTbl PlacesTbl { get; set; }
    }
}