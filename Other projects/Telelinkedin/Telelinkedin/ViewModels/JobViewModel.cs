using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Telelinkedin.Models;

namespace Telelinkedin.ViewModels
{
    public class JobViewModel
    {
        public static JobViewModel CreateViewModel(Job job)
        {
            var model = new JobViewModel();
            model.Position = job.Position;
            model.Description = job.Description;
            model.Employer = job.Employer;
            model.StartDate = job.StartDate;
            model.EndDate = job.EndDate;

            return model;
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Description { get; set; }

        public string Employer { get; set; }

        public string Position { get; set; }

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
