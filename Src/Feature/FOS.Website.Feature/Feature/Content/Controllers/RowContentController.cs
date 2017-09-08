using FOS.Website.Feature.Content.Data;
using FOS.Website.Feature.Content.PresentationData;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOS.Website.Feature.ComponentBlock;
using Synthesis;
using FOS.Website.Feature.Content.Models;
using Valtech.Foundation.SitecoreExtensions;
using Valtech.Foundation.Synthesis;
using Sitecore.Data.Items;

namespace FOS.Website.Feature.Content.Controllers
{
    public class RowContentController : Controller
    {
        public ActionResult GetRichTextContentView()
        {
            var originalTextFieldItem = Sitecore.Context.Item.GetOriginalItem<IRichTextContentItem>();
            var richTextContent = originalTextFieldItem?.As<IRichTextContentItem>();
            if (richTextContent == null)
            {
                var contextItem = RenderingContext.Current.Rendering.Item.As<IRichTextContentItem>();
                richTextContent = (contextItem == null)
                    ? Sitecore.Context.Item.As<IRichTextContentItem>()
                    : contextItem;
            }

            var model = new RichTextContentModel()
            {
                RichTextContentItem = richTextContent
            };
            return View(Constants.Views.Paths.RichTextContent, model);
        }
    }
}