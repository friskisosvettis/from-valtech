using FOS.Website.Feature.Content.Data;
using FOS.Website.Feature.Content.PresentationData;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            RichTextContentModel model = new RichTextContentModel();
            return View(Constants.Views.Paths.RichTextContent, model);
        }

        public ActionResult GetBasicImageView()
        {
            BasicImageModel model = new BasicImageModel();
            return View(Constants.Views.Paths.BasicImage, model);
        }

        public ActionResult GetWideImageView()
        {
            WideImageModel model = new WideImageModel();
            return View(Constants.Views.Paths.WideImage, model);
        }
        public ActionResult GetVideoView()
        {
            VideoModel model = new VideoModel();
            return View(Constants.Views.Paths.Video, model);
        }
    }
}