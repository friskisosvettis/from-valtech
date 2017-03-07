using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class AdvancedHeadingModel
    {
        public IAdvancedHeadingItem AdvancedHeadingItem = null;


        public AdvancedHeadingModel(Item item)
        {
            AdvancedHeadingItem = item.As<IAdvancedHeadingItem>();
        }
    }
}