using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Buckets.Extensions;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Synthesis;
using Valtech.Foundation.Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class AutoCompleteModuleModel
    {
        public IAutoCompleteModuleItem AutoCompleteModuleItem { get; set; }

        public AutoCompleteModuleModel()
        {
            AutoCompleteModuleItem = Sitecore.Context.Item.As<IAutoCompleteModuleItem>();
        }
    }
}