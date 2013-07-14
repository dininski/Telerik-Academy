using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Telelinkedin.Models;

namespace Telelinkedin.ViewModels
{
    public class ProfileViewModel
    {
        public static ProfileViewModel CreateViewModel(UserProfile user, bool isIndex = false)
        {
            var model = new ProfileViewModel();

            model.Id = user.UserId;
            model.Name = string.Format("{0} {1}", user.FirstName, user.LastName);
            model.Email = user.Email;
            model.Skills = new List<SkillViewModel>();
            model.Jobs = new List<JobViewModel>();
            model.Educations = new List<EducationViewModel>();
            model.APIKey = user.APIKey;

            if (isIndex)
            {
                if (user.SkillVisibility == VisibilityState.Public)
                {
                    model.Skills = user.Skills.Select(s => SkillViewModel.CreateViewModel(s));
                }

                if (user.JobsVisibility == VisibilityState.Public)
                {
                    model.Jobs = user.Jobs.Select(j => JobViewModel.CreateViewModel(j));
                }

                if (user.EducationVisibility == VisibilityState.Public)
                {
                    model.Educations = user.Education.Select(e => EducationViewModel.CreateViewModel(e));
                }
            }
            else
            {
                model.APIKey = string.Empty;
            }

            model.Connections = user.Followers
                .Where(e => e.Visibility == VisibilityState.Public)
                .Select(e => ProfileConnectionViewModel.CreateViewModel(e));

            model.Requests = user.Requests.Select(r => new ProfileViewModel()
            {
                Name = r.FromUserName,
                Id = r.FromUserId
            });

            return model;
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public IEnumerable<SkillViewModel> Skills { get; set; }

        public IEnumerable<JobViewModel> Jobs { get; set; }

        public IEnumerable<EducationViewModel> Educations { get; set; }

        public IEnumerable<ProfileConnectionViewModel> Connections { get; set; }

        public IEnumerable<ProfileViewModel> Requests { get; set; }

        public bool CanConnect { get; set; }

        public string APIKey { get; set; }
    }
}