using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Telelinkedin.Models
{
    public enum VisibilityState
    {
        [Display(Name="Private")]
        Private = 0,
        [Display(Name = "Public")]
        Public = 1
    }
}