using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telelinkedin.Models;
using WebMatrix.WebData;

namespace Telelinkedin.Controllers
{
    [Authorize]
    public class EndorsementController : Controller
    {
        private TelelinkedinDb db = new TelelinkedinDb();

        // TODO: update for ajax use
        public ActionResult Endorse(int skillId)
        {
            // check if user has already endorsed this skill
            if (db.Endorsements.Where(e =>
                    e.SkillId == skillId &&
                    e.Endorser.UserId == WebSecurity.CurrentUserId).Any())
            {
                return HttpNotFound();
            }

            var endorsement = new Endorsement()
            {
                Skill = db.Skills.Find(skillId),
                Endorser = db.UserProfiles.Find(WebSecurity.CurrentUserId),
            };

            db.Endorsements.Add(endorsement);
            db.SaveChanges();

            return Redirect(Request.UrlReferrer.AbsolutePath);
        }

        public ActionResult Unendorse(int skillId)
        {
            var skill = db.Skills.Find(skillId);

            if (skill != null)
            {
                var endorsement = skill
                    .Endorsements
                    .Where(e => e.Endorser.UserId == WebSecurity.CurrentUserId)
                    .FirstOrDefault();

                db.Endorsements.Remove(endorsement);
                db.SaveChanges();
            }

            return Redirect(Request.UrlReferrer.AbsolutePath);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}