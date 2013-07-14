using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telelinkedin.Models;
using Telelinkedin.ViewModels;
using WebMatrix.WebData;
using Kendo.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Telelinkedin.Controllers
{
    public class JobController : Controller
    {
        private TelelinkedinDb db = new TelelinkedinDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetJobs([DataSourceRequest] DataSourceRequest dsRequest)
        {
            IQueryable<JobViewModel> result = db.Jobs
                .Where(x => x.UserId == WebSecurity.CurrentUserId)
                .Select(job => new JobViewModel()
                {
                    Id = job.Id,
                    Position = job.Position,
                    Description = job.Description,
                    Employer = job.Employer,
                    StartDate = job.StartDate,
                    EndDate = job.EndDate
                });

            var model = result.ToDataSourceResult(dsRequest);
            return Json(model);
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

        public ActionResult CreateJob([DataSourceRequest] DataSourceRequest dsRequest, JobViewModel jobViewModel)
        {

            if (ModelState.IsValid)
            {
                var job = new Job();
                var user = db.UserProfiles.Find(WebSecurity.CurrentUserId);

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

            return Json(new[] {jobViewModel}.ToDataSourceResult(dsRequest, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}