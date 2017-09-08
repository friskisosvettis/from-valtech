using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOS.Website.Project.Friskis.Controllers
{
    public class RegionController : Controller
    {
        public ActionResult GetContentRegionView()
        {
            return View(Constants.Views.Paths.ContentRegion);
        }
    }
}