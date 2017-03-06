using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class BasicContentModel
    {
        public IBasicContentItem BasicContentItem = null;


        public BasicContentModel(Item item)
        {
            BasicContentItem = item.As<IBasicContentItem>();
        }
    }
}