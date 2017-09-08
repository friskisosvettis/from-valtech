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
                public const string FrontPage = "/Project/Friskis/Views/FrontPage.cshtml";
                public const string TrainingCenterPage = "/Project/Friskis/Views/TrainingCenterPage.cshtml";

                // Static content row. Will not have placeholde settings and will not me editable from Sitecore
                public const string Static_one = "/Project/Friskis/Views/StaticContentRow/Static_one.cshtml";
            }
        }
    }
}