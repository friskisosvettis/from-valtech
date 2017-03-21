using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOS.Website.Project.Friskis.Controllers
{
    public class StaticRowPlaceholderController : Controller
    {
        public ActionResult GetStaticFullWidthView()
        {
            return View(Constants.Views.Paths.Static_full_width);
        }

        public ActionResult GetStaticOneView()
        {
            return View(Constants.Views.Paths.Static_one);
        }
    }
}