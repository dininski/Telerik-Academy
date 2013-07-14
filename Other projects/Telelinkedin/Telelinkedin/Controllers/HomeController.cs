using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telelinkedin.Models;
using Telelinkedin.ViewModels;

namespace Telelinkedin.Controllers
{
    public class HomeController : Controller
    {
        TelelinkedinDb db = new TelelinkedinDb();

        public ActionResult Index(int? page)
        {
            var model = db.UserProfiles
                .Where(x => x.Visibility == VisibilityState.Public)
                .ToList()
                .Select(u => ProfileListViewModel.CreateViewModel(u))
                .OrderByDescending(u => u.Id);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Telelinkedin - a linkedin clone project.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
