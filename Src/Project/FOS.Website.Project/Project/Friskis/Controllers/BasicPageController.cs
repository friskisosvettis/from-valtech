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

        public ActionResult GetAssociationPageView()
        {
            return View(Constants.Views.Paths.AssociationPage);
        }

        public ActionResult GetHeroPageView()
        {
            return View(Constants.Views.Paths.HeroPage);
        }

        public ActionResult GetFrontPageView()
        {
            return View(Constants.Views.Paths.FrontPage);
        }

        public ActionResult GetTrainingCenterPageView()
        {
            return View(Constants.Views.Paths.TrainingCenterPage);
        }
    }
}