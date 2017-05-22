using FOS.Website.Feature.Content.Data;
using FOS.Website.Feature.Content.PresentationData;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Synthesis;
using FOS.Website.Feature.Content.Models;
using Valtech.Foundation.SitecoreExtensions;
using Valtech.Foundation.Synthesis;
using Sitecore.Data.Items;

namespace FOS.Website.Feature.Content.Controllers
{
    public class TestPageController : Controller
    {

        public ActionResult GetTestPageView()
        {
            TestPageModel testPageModel = new TestPageModel(Sitecore.Context.Item);
            return View(Constants.Views.Paths.TestPage, testPageModel);

        }
    }
}
