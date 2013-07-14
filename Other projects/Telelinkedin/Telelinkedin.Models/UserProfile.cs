using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telelinkedin.Models
{

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "First name")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [DisplayFormat(NullDisplayText = "Not set")]
        public string Email { get; set; }

        [Display(Name = "Profile visibility")]
        public VisibilityState Visibility { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        [Display(Name = "Jobs visibility")]
        public VisibilityState JobsVisibility { get; set; }

        public virtual ICollection<Education> Education { get; set; }

        [Display(Name = "Education visibility")]
        public VisibilityState EducationVisibility { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        [Display(Name = "Skills visibility")]
        public VisibilityState SkillVisibility { get; set; }

        public virtual ICollection<Request> Requests { get; set; }

        public virtual ICollection<UserProfile> Followers { get; set; }

        public virtual ICollection<UserProfile> Following { get; set; }

        public string APIKey { get; set; }
    }
}
