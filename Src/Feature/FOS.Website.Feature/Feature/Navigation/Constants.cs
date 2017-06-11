using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOS.Website.Feature.Navigation
{
    public class Constants
    {
        public struct Views
        {
            public struct Paths
            {
                public const string NavigationBar = "/Feature/Navigation/Views/NavigationBar.cshtml";
                public const string NavigationFooterAssociation = "/Feature/Navigation/Views/NavigationFooterAssociation.cshtml";
                public const string NavigationFooterFrontPage = "/Feature/Navigation/Views/NavigationFooterFrontPage.cshtml";
                public const string SecondaryNavigation = "/Feature/Navigation/Views/SecondaryNavigation.cshtml";
            }
        }
    }
}