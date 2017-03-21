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
    public class BasicImageModel
    {
        public IBasicImageItem BasicImageItem { get; set; }


        public BasicImageModel()
        {
            var contextItem = RenderingContext.Current.Rendering.Item.As<IBasicImageItem>();
            BasicImageItem = (contextItem == null)
                ? Sitecore.Context.Item.As<IBasicImageItem>()
                : contextItem;
        }
    }
}