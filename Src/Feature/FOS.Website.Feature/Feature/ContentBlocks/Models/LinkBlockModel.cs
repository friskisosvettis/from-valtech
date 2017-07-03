﻿using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Helpers;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class LinkBlockModel : ContentBlockModelBase
    {
        public ILinkItem LinkBlock { get; set; }
        public IImageItem ImageItem { get; set; }
    }
}