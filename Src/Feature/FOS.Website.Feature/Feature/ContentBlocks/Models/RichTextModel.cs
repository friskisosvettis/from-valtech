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
        public I_RichTextItem RichTextItem { get; set; }
    }
}