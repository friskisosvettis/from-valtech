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
using Sitecore.Buckets.Extensions;
using Valtech.Foundation.SitecoreExtensions;
using Valtech.Foundation.Synthesis;
using Sitecore.Data.Items;
using System.Diagnostics;

namespace FOS.Website.Feature.Content.Controllers
{
    public class FooterController : Controller
    {
        public ActionResult GetContactFooterView()
        {
            ContactFooterModel model = new ContactFooterModel()
            {
                ContactFooterItem = Sitecore.Context.Item.ClosestAscendantItemOfType<IFooterContactfooterItem>()
            };

            return View(Constants.Views.Paths.ContactFooter, model);
        }

        public ActionResult GetMoodFooterView()
        {
            MoodFooterModel model = new MoodFooterModel()
            {
                MoodFooterItem = Sitecore.Context.Item.ClosestAscendantItemOfType<IFooterMoodFooterItem>()
            };

            return View(Constants.Views.Paths.MoodFooter, model);
        }
    }
}