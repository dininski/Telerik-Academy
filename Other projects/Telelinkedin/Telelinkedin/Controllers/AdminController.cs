using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telelinkedin.Models;
using Telelinkedin.ViewModels;
using WebMatrix.WebData;
using Kendo.Mvc.Extensions;

namespace Telelinkedin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        TelelinkedinDb db = new TelelinkedinDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageUsers()
        {
            ViewBag.Title = "Manage users";

            return View();
        }

        #region Profiles
        public ActionResult GetProfiles([DataSourceRequest] DataSourceRequest dsRequest)
        {
            IQueryable<ProfileAdminViewModel> result = db.UserProfiles
                .Select(u => new ProfileAdminViewModel()
                {
                    Id = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Visibility = u.Visibility,
                    SkillVisibility = u.SkillVisibility,
                    JobVisibility = u.JobsVisibility,
                    EducationVisibility = u.EducationVisibility
                });

            var model = result.ToDataSourceResult(dsRequest);

            return Json(model);
        }

        public ActionResult UpdateProfile([DataSourceRequest] DataSourceRequest dsRequest,
            ProfileAdminViewModel profileAdminViewModel)
        {
            var userProfile = db.UserProfiles.Find(profileAdminViewModel.Id);

            if (userProfile != null && ModelState.IsValid)
            {
                userProfile.FirstName = profileAdminViewModel.FirstName;
                userProfile.LastName = profileAdminViewModel.LastName;
                userProfile.Visibility = profileAdminViewModel.Visibility;
                userProfile.EducationVisibility = profileAdminViewModel.EducationVisibility;
                userProfile.JobsVisibility = profileAdminViewModel.JobVisibility;
                userProfile.SkillVisibility = profileAdminViewModel.SkillVisibility;
                userProfile.Email = profileAdminViewModel.Email;
                db.Entry<UserProfile>(userProfile).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult DeleteProfile([DataSourceRequest] DataSourceRequest dsRequest,
            ProfileAdminViewModel ProfileAdminViewModel)
        {
            var userProfile = db.UserProfiles.Find(ProfileAdminViewModel.Id);

            if (userProfile != null &&
                ModelState.IsValid &&
                userProfile.UserId != WebSecurity.CurrentUserId)
            {
                // possible performance issue

                var endorsements = db.Endorsements
                    .Where(x => x.Endorser.UserId == userProfile.UserId);

                foreach (var endorsement in endorsements)
                {
                    db.Endorsements.Remove(endorsement);
                }

                userProfile.Following.Clear();
                userProfile.Followers.Clear();

                db.Entry(userProfile).State = EntityState.Modified;
                db.UserProfiles.Remove(userProfile);
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }
        #endregion

        #region Jobs
        public ActionResult GetJobs([DataSourceRequest] DataSourceRequest dsRequest, int userId)
        {
            var model = db.UserProfiles.Find(userId);
            IQueryable<JobViewModel> jobs = model.Jobs.Select(e =>
            {
                var jobViewModel = JobViewModel.CreateViewModel(e);
                jobViewModel.Id = e.Id;
                return jobViewModel;
            }).AsQueryable();

            var viewModel = jobs.ToDataSourceResult(dsRequest);
            return Json(viewModel);
        }

        public ActionResult UpdateJob([DataSourceRequest] DataSourceRequest dsRequest, JobViewModel jobViewModel)
        {
            var jobModel = db.Jobs.SingleOrDefault(job => job.Id == jobViewModel.Id);
            if (jobModel != null && ModelState.IsValid)
            {
                jobModel.Employer = jobViewModel.Employer;
                jobModel.Position = jobViewModel.Position;
                jobModel.Description = jobViewModel.Description;
                jobModel.StartDate = jobViewModel.StartDate;
                jobModel.EndDate = jobViewModel.EndDate;

                db.Entry<Job>(jobModel).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult DeleteJob([DataSourceRequest] DataSourceRequest dsRequest, JobViewModel jobViewModel)
        {
            var jobModel = db.Jobs.SingleOrDefault(job => job.Id == jobViewModel.Id);

            if (jobModel != null && ModelState.IsValid)
            {
                db.Jobs.Remove(jobModel);
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult CreateJob([DataSourceRequest] DataSourceRequest dsRequest, JobViewModel jobViewModel, int userId)
        {
            if (ModelState.IsValid)
            {
                var job = new Job();
                var user = db.UserProfiles.Find(userId);

                job.UserId = user.UserId;
                job.UserProfile = user;
                job.Employer = jobViewModel.Employer;
                job.Position = jobViewModel.Position;
                job.Description = jobViewModel.Description;
                job.StartDate = jobViewModel.StartDate;
                job.EndDate = jobViewModel.EndDate;

                db.Jobs.Add(job);
                db.SaveChanges();

                jobViewModel.Id = job.Id;
            }

            return Json(new[] { jobViewModel }.ToDataSourceResult(dsRequest, ModelState));
        }

        #endregion

        #region Skills
        public ActionResult GetSkills([DataSourceRequest] DataSourceRequest dsRequest, int userId)
        {
            var model = db.UserProfiles.Find(userId);
            var skills = model.Skills.Select(e => SkillViewModel.CreateViewModel(e)).AsQueryable();

            var viewModel = skills.ToDataSourceResult(dsRequest);
            return Json(viewModel);
        }

        public ActionResult UpdateSkill([DataSourceRequest] DataSourceRequest dsRequest, SkillViewModel skillViewModel)
        {
            var skillModel = db.Skills.SingleOrDefault(edu => edu.Id == skillViewModel.Id);
            if (skillModel != null && ModelState.IsValid)
            {
                skillModel.Name = skillViewModel.Name;

                db.Entry<Skill>(skillModel).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult DeleteSkill([DataSourceRequest] DataSourceRequest dsRequest, SkillViewModel skillViewModel)
        {
            var skillModel = db.Skills.SingleOrDefault(skill => skill.Id == skillViewModel.Id);

            //TODO: Remove endorsers
            if (skillModel != null && ModelState.IsValid)
            {
                db.Skills.Remove(skillModel);
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult CreateSkill([DataSourceRequest] DataSourceRequest dsRequest, SkillViewModel skillViewModel, int userId)
        {
            if (ModelState.IsValid)
            {
                var skill = new Skill();
                var user = db.UserProfiles.Find(userId);

                skill.UserId = user.UserId;
                skill.UserProfile = user;
                skill.Name = skillViewModel.Name;

                db.Skills.Add(skill);
                db.SaveChanges();

                skillViewModel.Id = skill.Id;
            }

            return Json(new[] { skillViewModel }.ToDataSourceResult(dsRequest, ModelState));
        }

        #endregion

        #region Connections
        public ActionResult GetConnections([DataSourceRequest] DataSourceRequest dsRequest, int userId)
        {
            var model = db.UserProfiles.Find(userId);
            var connections = model.Followers.Select(e => ProfileConnectionViewModel.CreateViewModel(e))
                .AsQueryable();

            var viewModel = connections.ToDataSourceResult(dsRequest);
            return Json(viewModel);
        }

        public ActionResult DeleteConnection([DataSourceRequest] DataSourceRequest dsRequest, ProfileConnectionViewModel connViewModel, int userId)
        {
            var user = db.UserProfiles.Find(userId);
            var connModel = user.Followers.SingleOrDefault(conn => conn.UserId == connViewModel.Id);

            if (connModel != null && ModelState.IsValid)
            {
                user.Followers.Remove(connModel);
                user.Following.Remove(connModel);

                var request = db.Requests.Single(r => r.FromUserId == userId || r.UserId == userId);

                db.Requests.Remove(request);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        // TODO: maybe delete or implement
        public ActionResult CreateConnection([DataSourceRequest] DataSourceRequest dsRequest, ProfileConnectionViewModel eduViewModel, int userId)
        {
            if (ModelState.IsValid)
            {
                var edu = new Education();
                var user = db.UserProfiles.Find(userId);

                edu.UserId = user.UserId;
                edu.UserProfile = user;

                db.Education.Add(edu);
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        #endregion

        #region Education

        public ActionResult GetEducations([DataSourceRequest] DataSourceRequest dsRequest, int userId)
        {
            var model = db.UserProfiles.Find(userId);
            var educations = model.Education.Select(e =>
            {
                var educationViewModel = EducationViewModel.CreateViewModel(e);
                educationViewModel.Id = e.Id;
                return educationViewModel;
            });

            var viewModel = educations.ToDataSourceResult(dsRequest);
            return Json(viewModel);
        }

        public ActionResult UpdateEducation([DataSourceRequest] DataSourceRequest dsRequest, EducationViewModel eduViewModel)
        {
            var eduModel = db.Education.SingleOrDefault(edu => edu.Id == eduViewModel.Id);
            if (eduModel != null && ModelState.IsValid)
            {
                eduModel.Institution = eduViewModel.Institution;
                eduModel.Specialty = eduViewModel.Specialty;
                eduModel.Description = eduViewModel.Description;
                eduModel.StartDate = eduViewModel.StartDate;
                eduModel.EndDate = eduViewModel.EndDate;

                db.Entry<Education>(eduModel).State = EntityState.Modified;
                db.SaveChanges();

                eduViewModel.Id = eduModel.Id;
            }

            return Json(new[] { eduViewModel }.ToDataSourceResult(dsRequest, ModelState));
        }

        public ActionResult DeleteEducation([DataSourceRequest] DataSourceRequest dsRequest, EducationViewModel eduViewModel)
        {
            var eduModel = db.Education.SingleOrDefault(edu => edu.Id == eduViewModel.Id);

            if (eduModel != null && ModelState.IsValid)
            {
                db.Education.Remove(eduModel);
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult CreateEducation([DataSourceRequest] DataSourceRequest dsRequest, EducationViewModel eduViewModel, int userId)
        {
            if (ModelState.IsValid)
            {
                var edu = new Education();
                var user = db.UserProfiles.Find(userId);

                edu.UserId = user.UserId;
                edu.UserProfile = user;
                edu.Institution = eduViewModel.Institution;
                edu.Specialty = eduViewModel.Specialty;
                edu.Description = eduViewModel.Description;
                edu.StartDate = eduViewModel.StartDate;
                edu.EndDate = eduViewModel.EndDate;

                db.Education.Add(edu);
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        #endregion
    }
}