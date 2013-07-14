using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Telelinkedin.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Display(Name = "Skill")]
        public string Name { get; set; }

        [ForeignKey("UserProfile")]
        public int UserId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<Endorsement> Endorsements { get; set; }
    }
}