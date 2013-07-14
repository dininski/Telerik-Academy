using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Telelinkedin.Models;

namespace Telelinkedin.ViewModels
{
    public class ProfileApiViewModel
    {
        public static ProfileApiViewModel CreateViewModel(UserProfile user, bool isIndex = false)
        {
            var apiViewModel = new ProfileApiViewModel();

            var jsonSerializer = new JavaScriptSerializer();
            apiViewModel.Name = string.Format("{0} {1}", user.FirstName, user.LastName);
            apiViewModel.Email = user.Email;
            apiViewModel.Skills = jsonSerializer.Serialize(
                user.Skills
                .Select(s => new
                {
                    Name = s.Name
                }));

            apiViewModel.Jobs = jsonSerializer.Serialize(user.Jobs
                .Select(j => new
                {
                    Employer = j.Employer,
                    Position = j.Position,
                    Description = j.Description,
                    StartDate = j.StartDate.ToString(),
                    EndDate = j.EndDate.ToString()
                }));

            apiViewModel.Educations = jsonSerializer.Serialize(user.Education
                .Select(e => new
                {
                    Institution = e.Institution,
                    Specialty = e.Specialty,
                    Description = e.Description,
                    StartDate = e.StartDate.ToString(),
                    EndDate = e.EndDate.ToString()
                }));

            apiViewModel.Connections = jsonSerializer.Serialize(user.Followers
                .Where(e => e.Visibility == VisibilityState.Public)
                .Select(e => new
                {
                    Name = String.Format("{0} {1}", e.FirstName, e.LastName),
                }));

            return apiViewModel;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Skills { get; set; }

        public string Jobs { get; set; }

        public string Educations { get; set; }

        public string Connections { get; set; }
    }
}