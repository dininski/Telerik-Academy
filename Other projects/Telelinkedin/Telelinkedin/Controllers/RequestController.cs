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
    public class RequestController : Controller
    {
        private TelelinkedinDb db = new TelelinkedinDb();

        public ActionResult Connect(int id)
        {
            var user = db.UserProfiles.Find(WebSecurity.CurrentUserId);

            if (db.Requests.Where(r => r.FromUserId == user.UserId && r.UserId == id && !r.Replied).Count() == 0)
            {
                var request = new Request()
                {
                    FromUserId = user.UserId,
                    UserProfile = db.UserProfiles.Single(u => u.UserId == id),
                    UserId = id,
                    FromUserName = user.FirstName + " " + user.LastName
                };

                db.Requests.Add(request);
                db.SaveChanges();

                return RedirectToAction("View", new { Controller = "Account", id = id });
            }

            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}