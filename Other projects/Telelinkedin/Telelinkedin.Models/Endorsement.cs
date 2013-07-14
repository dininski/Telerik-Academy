using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telelinkedin.Models
{
    public class Endorsement
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SkillId")]
        public virtual Skill Skill { get; set; }

        public int SkillId { get; set; }

        public virtual UserProfile Endorser { get; set; }
    }
}
