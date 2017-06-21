using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.ContentBlocks.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class VideoModel : ContentBlockModelBase
    {
        public bool IsFullSize { get; set; }
        public IVideoItem VideoItem { get; set; }

        public VideoModel() : base()
        {
            var contextItem = RenderingContext.Current.Rendering.Item.As<IVideoItem>();
            VideoItem = (contextItem == null)
                ? Sitecore.Context.Item.As<IVideoItem>()
                : contextItem;
            IsFullSize = true;
        }
    }
}