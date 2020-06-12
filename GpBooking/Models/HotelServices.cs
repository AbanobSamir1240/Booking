using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("HotelServices")]
    public class HotelServices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] [StringLength(100)] public string Service { get; set; }
        [ForeignKey("Hotel")] public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}