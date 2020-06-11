using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("ClubsTbl")]
    public class ClubsTbl
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        [Required]
        public string about_html { get; set; }
    }
}
