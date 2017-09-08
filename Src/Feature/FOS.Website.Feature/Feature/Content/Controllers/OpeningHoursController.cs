using System.Web.Mvc;
using FOS.Website.Feature.Content.Models;

namespace FOS.Website.Feature.Content.Controllers
{
    public class OpeningHoursController : Controller
    {
        public ActionResult GetOpeningHoursView()
        {
            var model = new OpeningHoursModel();

            return View(Constants.Views.Paths.OpeningHours, model);
        }
    }
}