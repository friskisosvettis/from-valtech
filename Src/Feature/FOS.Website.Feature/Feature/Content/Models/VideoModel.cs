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
    public class VideoModel
    {
        public IVideoItem VideoItem { get; set; }

        public VideoModel()
        {
            var contextItem = RenderingContext.Current.Rendering.Item.As<IVideoItem>();
            VideoItem = (contextItem == null)
                ? Sitecore.Context.Item.As<IVideoItem>()
                : contextItem;
        }

    }
}