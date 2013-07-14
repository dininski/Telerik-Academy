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
using Kendo.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Telelinkedin.Controllers
{
    [Authorize]
    public class SkillsController : Controller
    {
        private TelelinkedinDb db = new TelelinkedinDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSkills([DataSourceRequest] DataSourceRequest dsRequest)
        {
            IQueryable<SkillViewModel> result = db.Skills
                .Where(x => x.UserId == WebSecurity.CurrentUserId)
                .Select(skill => new SkillViewModel()
                {
                    Id = skill.Id,
                    Name = skill.Name,
                });

            var model = result.ToDataSourceResult(dsRequest);
            return Json(model);
        }

        public ActionResult DeleteSkill([DataSourceRequest] DataSourceRequest dsRequest, SkillViewModel skillViewModel)
        {
            var skillModel = db.Skills.SingleOrDefault(skill => skill.Id == skillViewModel.Id);
            if (skillModel != null && ModelState.IsValid)
            {
                db.Skills.Remove(skillModel);
                db.SaveChanges();
            }

            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult CreateSkill([DataSourceRequest] DataSourceRequest dsRequest, SkillViewModel skillViewModel)
        {

            if (ModelState.IsValid)
            {
                var skill = new Skill();
                var user = db.UserProfiles.Find(WebSecurity.CurrentUserId);

                skill.UserId = user.UserId;
                skill.UserProfile = user;
                skill.Name = skillViewModel.Name;
                db.Skills.Add(skill);
                db.SaveChanges();
                skillViewModel.Id = skill.Id;
            }

            return Json(new[] { skillViewModel }.ToDataSourceResult(dsRequest, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}