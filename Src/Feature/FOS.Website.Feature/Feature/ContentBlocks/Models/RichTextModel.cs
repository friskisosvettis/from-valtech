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
    public class RichTextModel : ContentBlockModelBase
    {
        public IRichTextItem RichTextItem { get; set; }
        public RichTextModel() : base()
        {
            var contextItem = RenderingContext.Current.Rendering.Item.As<IRichTextItem>();
            RichTextItem = (contextItem == null)
                ? Sitecore.Context.Item.As<IRichTextItem>()
                : contextItem;
        }
    }
}