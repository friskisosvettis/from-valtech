using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOS.Website.Project.Friskis.Controllers
{
    public class RowPlaceholderController : Controller
    {
        public ActionResult GetLayoutFullWidthView()
        {
            return View(Constants.Views.Paths.Layout_full_width);
        }

        public ActionResult GetLayoutHalfView()
        {
            return View(Constants.Views.Paths.Layout_half);
        }

        public ActionResult GetLayoutOneView()
        {
            return View(Constants.Views.Paths.Layout_one);
        }

        public ActionResult GetLayoutOneTwoView()
        {
            return View(Constants.Views.Paths.Layout_one_two);
        }

        public ActionResult GetLayoutThirdsView()
        {
            return View(Constants.Views.Paths.Layout_thirds);
        }

        public ActionResult GetLayoutTwoOneView()
        {
            return View(Constants.Views.Paths.Layout_two_one);
        }
    }
}