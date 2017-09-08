using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOS.Website.Feature.Identity.Controllers
{
    public class FooterController : Controller
    {
        public ActionResult GetFooterView()
        {
            return View(Constants.Views.Paths.Footer);
        }
    }
}