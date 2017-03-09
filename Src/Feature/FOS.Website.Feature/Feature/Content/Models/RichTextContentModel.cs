using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Synthesis;
using Synthesis.FieldTypes;
using Synthesis.FieldTypes.Interfaces;

namespace FOS.Website.Feature.Content.Models
{
    public class RichTextContentModel
    {
        public IRichTextContentItem RichTextContentItem { get; set; }
        public RichTextContentModel()
        {
            var test = RenderingContext.Current.Rendering.Item.As<IRichTextContentItem>();
            RichTextContentItem = Sitecore.Context.Item.As<IRichTextContentItem>();
            if (RichTextContentItem == null)
            {
                RichTextContentItem = RenderingContext.Current.Rendering.Item.As<IRichTextContentItem>();
            }
        }
    }
}