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
    public class HeroAreaController : Controller
    {
        private readonly string HERO_AREA_PLACEHOLDER_NAME = "heroarea";

        public ActionResult GetHeroAreaView()
        {
            var renderingReferences = Sitecore.Context.Item.Visualization.GetRenderings(Sitecore.Context.Device, true);
            HeroAreaModel model = new HeroAreaModel()
            {
                PlaceholderName = HERO_AREA_PLACEHOLDER_NAME,
                NrOfHeroObjects =
                    renderingReferences.Where(r => r.Placeholder.EndsWith("/" + HERO_AREA_PLACEHOLDER_NAME)).Count()
            };

            return View(Constants.Views.Paths.HeroArea, model);
        }

        public ActionResult GetHeroObjectImageView()
        {
            HeroObjectImageModel model = new HeroObjectImageModel(Sitecore.Context.Item);
            return View(Constants.Views.Paths.HeroObjectImage, model);
        }
    }
}