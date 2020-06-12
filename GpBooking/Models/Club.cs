using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("Club")]
    public class Club
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        [Required] [StringLength(50)] public string ShortName { get; set; }

        [StringLength(100)] public string Name { get; set; }

        [Required] [StringLength(150)] public string Address { get; set; }

        [StringLength(15)] public string Tel1 { get; set; }

        [StringLength(15)] public string Tel2 { get; set; }

        [Required] public string About { get; set; }
    }
}
