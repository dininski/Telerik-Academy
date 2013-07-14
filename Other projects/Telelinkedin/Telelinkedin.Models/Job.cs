using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Telelinkedin.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Employer { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", NullDisplayText = "Present")]
        public DateTime? EndDate { get; set; }

        [ForeignKey("UserProfile")]
        public int UserId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}