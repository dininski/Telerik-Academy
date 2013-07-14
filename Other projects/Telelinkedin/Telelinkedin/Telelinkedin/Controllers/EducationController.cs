using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telelinkedin.Models;
using Telelinkedin.ViewModels;
using WebMatrix.WebData;

namespace Telelinkedin.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        private TelelinkedinDb db = new TelelinkedinDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEducations([DataSourceRequest] DataSourceRequest dsRequest)
        {
            IQueryable<EducationViewModel> result = db.Education
                .Where(x => x.UserId == WebSecurity.CurrentUserId)
                .Select(edu => new EducationViewModel()
                {
                    Id = edu.Id,
                    Institution = edu.Institution,
                    Specialty = edu.Specialty,
                    Description = edu.Description,
                    StartDate = edu.StartDate,
                    EndDate = edu.EndDate
                });

            var model = result.ToDataSourceResult(dsRequest);
            return Json(model);
        }

        public ActionResult UpdateEducation([DataSourceRequest] DataSourceRequest dsRequest, EducationViewModel eduViewModel)
        {
            var eduModel = db.Education.SingleOrDefault(job => job.Id == eduViewModel.Id);
            if (eduModel != null && ModelState.IsValid)
            {
                eduModel.Id = eduViewModel.Id;
                eduModel.Institution = eduViewModel.Institution;
                eduModel.Specialty = eduViewModel.Specialty;
                eduModel.Description = eduViewModel.Description;
                eduModel.StartDate = eduViewModel.StartDate;
                eduModel.EndDate = eduViewModel.EndDate;

                db.Entry<Education>(eduModel).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult DeleteEducation([DataSourceRequest] DataSourceRequest dsRequest, EducationViewModel eduViewModel)
        {
            var eduModel = db.Education.SingleOrDefault(job => job.Id == eduViewModel.Id);
            if (eduModel != null && ModelState.IsValid)
            {
                db.Education.Remove(eduModel);
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult CreateEducation([DataSourceRequest] DataSourceRequest dsRequest, EducationViewModel eduViewModel)
        {
            if (ModelState.IsValid)
            {
                var edu = new Education();
                var user = db.UserProfiles.Find(WebSecurity.CurrentUserId);

                edu.UserId = user.UserId;
                edu.UserProfile = user;
                edu.Institution = eduViewModel.Institution;
                edu.Specialty = eduViewModel.Specialty;
                edu.Description = eduViewModel.Description;
                edu.StartDate = eduViewModel.StartDate;
                edu.EndDate = eduViewModel.EndDate;

                db.Education.Add(edu);
                db.SaveChanges();

                eduViewModel.Id = edu.Id;
            }

            return Json(new[] { eduViewModel }.ToDataSourceResult(dsRequest, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}