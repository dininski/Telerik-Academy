using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Telelinkedin.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Institution { get; set; }

        [StringLength(100)]
        public string Specialty { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", NullDisplayText = "Present")]
        public DateTime? EndDate { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public UserProfile UserProfile{ get; set; }
    }
}