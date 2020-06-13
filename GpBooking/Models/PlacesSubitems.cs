using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("PlacesSubitems")]
    public class PlacesSubitems
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string About { get; set; }
        [ForeignKey("Place")]
        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
    }
}
