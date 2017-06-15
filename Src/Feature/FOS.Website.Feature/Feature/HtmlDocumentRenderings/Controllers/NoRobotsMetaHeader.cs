using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Synthesis;
using FOS.Website.Feature.HtmlDocumentRenderings;
using Sitecore.Buckets.Extensions;
using Valtech.Foundation.SitecoreExtensions;
using Valtech.Foundation.Synthesis;
using Sitecore.Data.Items;
using System.Diagnostics;
using FOS.Website.Feature.Content.Data;

namespace FOS.Website.Feature.HtmlDocumentRenderings.Controllers
{
    public class NoRobotsMetaHeaderController : Controller
    {
        public ActionResult HandleMetaDataRobots()
        {
            var associationMigratedCheckItem = Sitecore.Context.Item.ClosestAscendantItemOfType<IAssociationNotMigratedWidgetItem>();
            if (associationMigratedCheckItem != null && !associationMigratedCheckItem.AssociationReady.Value)
            {
                return View(Constants.Views.Paths.NoRobotsMetaHeader, null);
            }

            return new EmptyResult();
        }
    }
}