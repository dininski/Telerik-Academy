using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Telelinkedin.Models;

namespace Telelinkedin.ViewModels
{
    public class EducationViewModel
    {
        public static EducationViewModel CreateViewModel(Education edu)
        {
            var model = new EducationViewModel();
            model.Institution = edu.Institution;
            model.Specialty = edu.Specialty;
            model.StartDate = edu.StartDate;
            model.EndDate = edu.EndDate;
            model.Description = edu.Description;

            return model;
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Institution { get; set; }

        public string Specialty { get; set; }

        public string Description { get; set; }

        [UIHint("Date")]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime StartDate { get; set; }

        [UIHint("Date")]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", NullDisplayText = "Present")]
        public DateTime? EndDate { get; set; }
    }
}