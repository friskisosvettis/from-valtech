using System.Web.Mvc;
using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Helpers;
using FOS.Website.Feature.ContentBlocks.Models;

namespace FOS.Website.Feature.ContentBlocks.Controllers
{
    public class ContentBlockController : Controller
    {
        public ActionResult GetRichTextView()
        {
            var model = new RichTextModel();
            
            return View(Constants.Views.Paths.RichText, model);
        }

        public ActionResult GetImageAndRichTextView()
        {
            var model = new ImageAndRichTextModel();

            return View(Constants.Views.Paths.ImageRichText, model);
        }

        public ActionResult GetLinkBlockView()
        {
            var model = new LinkBlockModel()
            {
                LinkBlock  = RenderingHelper.GetRenderingContextOrDefault<ILinkItem>(),
                ImageItem = RenderingHelper.GetRenderingContextOrDefault<IImageItem>()
            };

            return View(Constants.Views.Paths.LinkBlock, model);
        }

        public ActionResult GetVideoView()
        {
            var model = new VideoModel();

            return View(Constants.Views.Paths.Video, model);
        }
    }
}