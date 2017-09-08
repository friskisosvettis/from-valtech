using FOS.Website.Feature.Content.Data;
using FOS.Website.Feature.Content.PresentationData;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOS.Website.Feature.ComponentBlock;
using FOS.Website.Feature.Content.ListWidgets;
using Synthesis;
using FOS.Website.Feature.Content.Models;
using Sitecore.Buckets.Extensions;
using Valtech.Foundation.SitecoreExtensions;
using Valtech.Foundation.Synthesis;
using Sitecore.Data.Items;
using Valtech.Foundation.Settings;

namespace FOS.Website.Feature.Content.Controllers
{
    public class ContentController : Controller
    {
        public ActionResult GeAssociationIntroductionModuleView()
        {
            var model = new AssociationIntroductionModuleModel()
            {
                AssociationIntroductionModuleItem = Sitecore.Context.Item.As<IAssociationIntroductionModuleItem>(),
                AssociationName = Sitecore.Context.Item.DisplayName
            };
            return View(Constants.Views.Paths.AssociationIntroductionModule, model);
        }

        public ActionResult GetAssociationNotMigratedView()
        {
            var associationMigratedCheckItem = Sitecore.Context.Item.ClosestAscendantItemOfType<IAssociationNotMigratedWidgetItem>();
            if (associationMigratedCheckItem != null && !associationMigratedCheckItem.AssociationReady.Value)
            {
                var model = new AssociationNotMigratedModel()
                {
                    AssociationCheckWidget = associationMigratedCheckItem,
                    GeneralData = associationMigratedCheckItem.InnerItem.ClosestAscendantItemOfType<IAssociationNotMigratedInfoItem>()
                };

                return View(Constants.Views.Paths.AssociationNotMigrated, model);
            }

            return new EmptyResult();
        }

        public ActionResult GetBasicHeadingView()
        {
            var originalBasicHeadingItem = Sitecore.Context.Item.GetOriginalItem<IBasicHeadingItem>();
            BasicHeadingModel basicHeadingModel = new BasicHeadingModel(originalBasicHeadingItem);
            return View(Constants.Views.Paths.BasicHeading, basicHeadingModel);
        }

        public ActionResult GetHeadingTrainingCenterView()
        {
            HeadingTrainingCenterModel model = new HeadingTrainingCenterModel(Sitecore.Context.Item);
            return View(Constants.Views.Paths.HeadingTrainingCenterView, model);
        }

        public ActionResult GetExpandableSectionView()
        {
            IExpandableSectionItem expandableItem = RenderingContext.Current.Rendering.Item.As<IExpandableSectionItem>();
            ExpandableSectionModel model = new ExpandableSectionModel(expandableItem);
            return View(Constants.Views.Paths.ExpandableSection, model);
        }

        public ActionResult GetFacilitiesView()
        {
            FacilitiesModel model = new FacilitiesModel()
            {
                Facilities =
                    Sitecore.Context.Item.As<IFacilitiesItem>()?
                        .Facilities1.TargetItems.Select(i => i.InnerItem.As<IFacilityItem>())
                        .Where(i => i != null)
            };

            return View(Constants.Views.Paths.Facilities, model);
        }

        public ActionResult GetCookieConsentView()
        {
            var model = new SettingsRepository().GetSetting<ICookieConsentItem>(Sitecore.Context.Item);

            return View(Constants.Views.Paths.CookieConsent, model);
        }
    }
}