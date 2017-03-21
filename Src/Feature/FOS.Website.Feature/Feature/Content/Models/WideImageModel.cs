using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class WideImageModel
    {
        public IWideImageItem WideImageItem { get; set; }


        public WideImageModel()
        {
            var contextItem = RenderingContext.Current.Rendering.Item.As<IWideImageItem>();
            WideImageItem = (contextItem == null)
                ? Sitecore.Context.Item.As<IWideImageItem>()
                : contextItem;
        }
    }
}