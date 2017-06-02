using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Navigation.Data;
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
    }
}