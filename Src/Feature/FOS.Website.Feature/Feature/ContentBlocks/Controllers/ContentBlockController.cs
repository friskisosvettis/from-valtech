using System.Web.Mvc;
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

        public ActionResult GetVideoView()
        {
            var model = new VideoModel();

            return View(Constants.Views.Paths.Video, model);
        }
    }
}