using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Helpers;
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
        public IHeadingItem HeadingItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<IHeadingItem>();

        protected ContentBlockModelBase()
        {
        }
    }
}