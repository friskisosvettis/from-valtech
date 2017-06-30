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

        public ActionResult GetImageAndTextView()
        {
            var model = new MediaAndTextModel();

            return View(Constants.Views.Paths.ImageAndText, model);
        }

        public ActionResult GetVideoAndTextView()
        {
            var model = new MediaAndTextModel();

            return View(Constants.Views.Paths.VideoAndText, model);
        }
        public ActionResult GetImageAndVideoView()
        {
            var model = new ImageAndVideoModel();

            return View(Constants.Views.Paths.ImageAndVideo, model);
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

        public ActionResult GetWideImageSeparatorView()
        {
            var model = new WideImageSeparatorModel()
            {
                SimpleTextBox = RenderingHelper.GetRenderingContextOrDefault<ISimpleTextBoxItem>(),
                ImageItem = RenderingHelper.GetRenderingContextOrDefault<IImageItem>()
            };

            return View(Constants.Views.Paths.WideImageSeparator, model);
        }

        public ActionResult GetFiftyFiftyMediaView()
        {
            var model = new FiftyFiftyMediaModel();
            if (model.LeftMediaBlock == null || model.RightMediaBlock == null)
            {
                return new EmptyResult();
            }

            return View(Constants.Views.Paths.FiftyFiftyMedia, model);
        }
    }
}