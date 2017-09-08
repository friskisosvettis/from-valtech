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
using Valtech.Foundation.Dictionary;
using Valtech.Foundation.Synthesis;

namespace FOS.Website.Feature.Navigation.Models
{
    public class NavigationBarModel
    {
        public IEnumerable<INavigationDataItem> PrimaryMenuItems { get; set; }
        public IEnumerable<INavigationDataItem> MoreMenuItems { get; set; }
        public Item HomeItem { get; set; }
        public ID ActiveItemID { get; set; }
        public INavigationMenuLinksAssociationItem AssociationLinks { get; set; }
        public AssociationTopBarModel AssociationTopBlackBarModel { get; set; }
        public string label_BookClass { get; } = DictionaryRepository.Default.GetRawValueText("/Content/NavigationBar", "BookClass", "Book a class");
        public IHtmlString label_TrainHere { get; } = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/NavigationBar", "TrainHere", "Train here"));
        public IHtmlString label_More { get; } = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/NavigationBar", "More", "More"));
    }
}