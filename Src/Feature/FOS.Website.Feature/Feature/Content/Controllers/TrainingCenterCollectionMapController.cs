using FOS.Website.Feature.Content.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Synthesis;
using FOS.Website.Feature.Content.Models;
using Valtech.Foundation.Synthesis;
using FOS.Website.Concrete.Feature.Content.Data;
using FOS.Website.Feature.SearchUtilityFunctions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using Sitecore.ContentSearch.Linq;

namespace FOS.Website.Feature.Content.Controllers
{
    public class TrainingCenterCollectionMapController : Controller
    {
        private string MapNodeTemplateId => MapNode.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();
        private IEnumerable<IMapNodeItem> GetAllDecendentMapNodes(Item item)
        {
            return SearchUtility.SearchFor<IMapNodeItem>(item, MapNodeTemplateId).AsSitecoreOrdered();
        }

        public ActionResult GetTrainingCenterCollectionMapView()
        {
            List<IMapNodeItem> listOfGyms = new List<IMapNodeItem>();
            if (Sitecore.Context.Item.As<IMapNodeItem>() != null)
            {
                listOfGyms.Add(Sitecore.Context.Item.As<IMapNodeItem>());
            }
            else
            {
                var assosiationItem = Sitecore.Context.Item.ClosestAscendantItemOfType<IAssociationFlagTemplateItem>();
                if (assosiationItem != null)
                {
                    listOfGyms = GetAllDecendentMapNodes(assosiationItem.InnerItem).ToList();
                }
                else
                {
                    // This is a map under .se
                    // We do not support this but will tell the the user in experience editor that this is not supported.
                    var editorMsgModel = new EditorInfoModel()
                    {
                        Heading = "Map placement",
                        Message = "This map component will only be visible when this page is under an Association page"
                    };
                    return View(Constants.Views.Paths.EditorInfo, editorMsgModel);
                }
            }

            var model = new TrainingCenterCollectionMapModel()
            {
                MapNodes = listOfGyms
            };

            return View(Constants.Views.Paths.TrainingCenterCollectionMap, model);
        }
    }
}