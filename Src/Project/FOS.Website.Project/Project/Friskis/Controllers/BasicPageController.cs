using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOS.Website.Project.Friskis.Controllers
{
    public class BasicPageController : Controller
    {
        public ActionResult GetArticlePageView()
        {
            return View(Constants.Views.Paths.ArticlePage);
        }

        public ActionResult GetHeroPageView()
        {
            return View(Constants.Views.Paths.HeroPage);
        }
    }
}