using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Navigation.Data;
using FOS.Website.Feature.Navigation.Models;
using Sitecore.Buckets.Extensions;
using Sitecore.Data;
using Sitecore.Data.Items;
using Synthesis;
using Synthesis.FieldTypes.Interfaces;
using Valtech.Foundation.Synthesis;

namespace FOS.Website.Feature.Navigation.Models
{
    public class NavigationBarModel
    {
        public IEnumerable<INavigationDataItem> PrimaryMenuItems { get; set; }
        public IEnumerable<INavigationDataItem> MoreMenuItems { get; set; }
        public Item HomeItem { get; set; }
        public ID ActiveItemID { get; set; }
        public IHyperlinkField BookingLink { get; set; }
    }
}