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
    public class NavigationBarController : Controller
    {
        public ActionResult GetNavigationBarView()
        {
            var activeItem = Sitecore.Context.Item;
            NavigationBarModel model = null;
            var menuBarItem = activeItem.ClosestAscendantItemOfType<INavigationBarRootItem>();
            if (menuBarItem != null)
            {
                List<INavigationDataItem> mainMenuItems = new List<INavigationDataItem>();
                List<INavigationDataItem> moreMenuItems = new List<INavigationDataItem>();
                
                foreach (Item childItem in menuBarItem.InnerItem.Children)
                {
                    var child = childItem.As<INavigationDataItem>();
                    if (child != null && child.Navigation_ShowInMenu.Value)
                    {
                        if (child.Navigation_IsSecondary.Value)
                        {
                            moreMenuItems.Add(child);
                        }
                        else
                        {
                            mainMenuItems.Add(child);
                        }
                    }
                }

                model = new NavigationBarModel()
                {
                    PrimaryMenuItems = mainMenuItems,
                    MoreMenuItems = moreMenuItems,
                    HomeItem = menuBarItem.InnerItem,
                    ActiveItemID = activeItem.ID,
                    BookingLink = menuBarItem.BookingLink
                };
            }
                
            return View(Constants.Views.Paths.NavigationBar, model);
        }
    }
}