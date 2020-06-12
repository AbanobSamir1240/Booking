using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GpBooking.Services;

namespace GpBooking.Models
{
    [Table("ApplicationLog")]
    public class ApplicationLog
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Create Date")] public DateTime CreateDate { get; private set; } = DateTime.Now;

        [Display(Name = "Updated Date")]
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DateTime? UpdatedDate { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        [ForeignKey("CreatedBy")] public string CreatedByUser { get; set; } = ApplicationUserService.GetUser()?.Id;

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public ApplicationUser CreatedBy { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        [ForeignKey("UpdatedBy")] public string UpdatedByUser { get; set; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public ApplicationUser UpdatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Data { get; set; }
        [Required]
        public string Ip { get; set; }
        [Required]
        public string Url { get; set; }
    }
}