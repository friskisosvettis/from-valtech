using System.Web.Mvc;
using FOS.Website.Feature.Document;
using FOS.Website.Feature.Document.Data;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.Document.Controllers
{
    public class DocumentController : Controller
    {
        public ActionResult GetDocumentTitle()
        {
            IDocumentTitleItem documentTitleItem = RenderingContext.Current.Rendering.Item.As<IDocumentTitleItem>();
            return View(Constants.Views.Paths.DocumentTitle, documentTitleItem);
        }
    }
}