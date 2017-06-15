using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.ContentBlocks.Data;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Synthesis;
using Synthesis.FieldTypes;
using Synthesis.FieldTypes.Interfaces;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class ContentBlockModelBase
    {
        public IHeadingItem HeadingItem { get; set; }

        protected ContentBlockModelBase()
        {
            var contextItem = RenderingContext.Current.Rendering.Item.As<IHeadingItem>();
            HeadingItem = (contextItem == null)
                ? Sitecore.Context.Item.As<IHeadingItem>()
                : contextItem;
        }
    }
}