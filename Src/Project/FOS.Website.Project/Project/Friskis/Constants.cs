using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOS.Website.Project.Friskis
{
    public class Constants
    {
        public struct Views
        {
            public struct Paths
            {
                public const string ArticlePage = "/Project/Friskis/Views/ArticlePage.cshtml";
                public const string AssociationPage = "/Project/Friskis/Views/AssociationPage.cshtml";
                public const string ContentRegion = "/Project/Friskis/Views/ContentRegion.cshtml";
                public const string HeroPage = "/Project/Friskis/Views/HeroPage.cshtml";
                public const string TrainingCenterPage = "/Project/Friskis/Views/TrainingCenterPage.cshtml";

                // Column Placeholder layouts
                public const string Layout_full_width = "/Project/Friskis/Views/ContentRow/Layout_full_width.cshtml";
                public const string Layout_half = "/Project/Friskis/Views/ContentRow/Layout_half.cshtml";
                public const string Layout_one = "/Project/Friskis/Views/ContentRow/Layout_one.cshtml";
                public const string Layout_one_two = "/Project/Friskis/Views/ContentRow/Layout_one_two.cshtml";
                public const string Layout_thirds = "/Project/Friskis/Views/ContentRow/Layout_thirds.cshtml";
                public const string Layout_two_one = "/Project/Friskis/Views/ContentRow/Layout_two_one.cshtml";

                // Static content row. Will not have placeholde settings and will not me editable from Sitecore
                public const string Static_full_width = "/Project/Friskis/Views/StaticContentRow/Static_full_width.cshtml";
                public const string Static_one = "/Project/Friskis/Views/StaticContentRow/Static_one.cshtml";
            }
        }
    }
}