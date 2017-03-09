using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOS.Website.Project.Friskis.Controllers
{
    public class RowPlaceholderController : Controller
    {
        public ActionResult GetColumn_1_1_View()
        {
            return View(Constants.Views.Paths.Column_1_1);
        }
    }
}