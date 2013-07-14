using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Telelinkedin.Models;

namespace Telelinkedin.ViewModels
{
    public class ProfileAdminViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [UIHint("VisibilityEnum")]
        public VisibilityState Visibility { get; set; }

        [UIHint("VisibilityEnum")]
        public VisibilityState JobVisibility { get; set; }

        [UIHint("VisibilityEnum")]
        public VisibilityState EducationVisibility { get; set; }

        [UIHint("VisibilityEnum")]
        public VisibilityState SkillVisibility { get; set; }
    }
}