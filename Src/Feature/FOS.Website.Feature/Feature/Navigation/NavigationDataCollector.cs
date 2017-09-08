using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Navigation.Data;
using Sitecore.Buckets.Extensions;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.Navigation
{
    public static class NavigationDataCollector
    {
        public static void GetNavigationChildren(Item menuRoot, ref List<INavigationDataItem> mainMenuItems, ref List<INavigationDataItem> moreMenuItems)
        {
            foreach (Item childItem in menuRoot.Children)
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
        }

        public static IEnumerable<INavigationDataItem> GetNavigationChildren(this Item page)
        {
            var childNavigationDataItems = new List<INavigationDataItem>();
            foreach (Item childItem in page.Children)
            {
                var child = childItem.As<INavigationDataItem>();
                if (child != null && child.Navigation_ShowInMenu.Value)
                {
                    childNavigationDataItems.Add(child);
                }
            }

            return childNavigationDataItems;
        }

        public static IEnumerable<Item> GetAllParentsToNavRoot(this Item page)
        {
            var parentPages = new List<Item>();
            parentPages.Add(page);
            var parentPage = page.GetParentBucketItemOrParent();
            while (parentPage != null && parentPage.As<INavigationRootPageFlagItem>() == null)
            {
                parentPages.Add(parentPage);
                parentPage = parentPage.GetParentBucketItemOrParent();
            }
            
            return parentPages;
        }
    }
}