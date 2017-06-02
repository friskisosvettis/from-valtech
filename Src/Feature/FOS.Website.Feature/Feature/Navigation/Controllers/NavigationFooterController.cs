using FOS.Website.Feature.Navigation;
using FOS.Website.Feature.Navigation.Data;
using FOS.Website.Feature.Navigation.Models;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Synthesis;
using Sitecore.Buckets.Extensions;
using Valtech.Foundation.SitecoreExtensions;
using Valtech.Foundation.Synthesis;
using Sitecore.Data.Items;

namespace FOS.Website.Feature.Navigation.Controllers
{
    public class NavigationFooterController : Controller
    {
        public ActionResult GetNavigationFooterView()
        {
            var activeItem = Sitecore.Context.Item;
            NavigationBarModel model = null;
            var navigationRoot = activeItem.ClosestAscendantItemOfType<INavigationRootPageFlagItem>();
            if (navigationRoot != null)
            {
                List<INavigationDataItem> mainMenuItems = new List<INavigationDataItem>();
                List<INavigationDataItem> moreMenuItems = new List<INavigationDataItem>();
                NavigationDataCollector.GetNavigationChildren(navigationRoot.InnerItem, ref mainMenuItems, ref moreMenuItems);

                var associtionNavRoot = navigationRoot.InnerItem.As<INavigationFooterLinksAssociationItem>();
                if (associtionNavRoot != null)
                {
                    return GetNavigationFooterAssociationView(associtionNavRoot, mainMenuItems, moreMenuItems);
                }
                else
                {
                    return GetNavigationFooterFrontPageView(mainMenuItems);
                }
            }

            return new EmptyResult();
        }

        private ActionResult GetNavigationFooterAssociationView(INavigationFooterLinksAssociationItem extraLinks, List<INavigationDataItem> mainMenuItems, List<INavigationDataItem> moreMenuItems)
        {
            var model = new NavigationFooterAssociation()
            {
                PrimaryMenuItems = mainMenuItems,
                MoreMenuItems = moreMenuItems,
                AssociationFooterLinks = extraLinks
            };

            return View(Constants.Views.Paths.NavigationFooterAssociation, model);
        }

        private ActionResult GetNavigationFooterFrontPageView(List<INavigationDataItem> mainMenuItems)
        {
            var model = new NavigationFooterFrontPage()
            {
                PrimaryMenuItems = mainMenuItems
            };

            return View(Constants.Views.Paths.NavigationFooterFrontPage, model);
        }

    }
}