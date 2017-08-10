using FOS.Website.Feature.Content.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Synthesis;
using FOS.Website.Feature.Content.Models;
using Valtech.Foundation.Synthesis;
using FOS.Website.Concrete.Feature.Content.Data;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using Sitecore.ContentSearch.Linq;

namespace FOS.Website.Feature.Content.Controllers
{
    public class TrainingCenterCollectionMapController : Controller
    {
        private IEnumerable<IMapNodeItem> GetAllDecendentMapNodes(Item item)
        {
            string index = string.Format("sitecore_{0}_index", Sitecore.Context.Database.Name);
            using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
            {
                string templateID = MapNode.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();
                var query = context.GetQueryable<SearchResultItem>()
                    .Where(i => i["_latestversion"].Equals("1"))
                    .Where(i => i.Language.Equals(item.Language.Name))
                    .Where(i => i.Paths.Contains(item.ID))
                    .Where(i => i["_templates"].Contains(templateID));

                var result = query.GetResults();

                var resultItems = result.Hits.Select(i => i.Document.GetItem());
                                
                return resultItems.OrderBy(x => !string.IsNullOrEmpty(x["__Sortorder"])? int.Parse(x["__Sortorder"]) : 0)
                                .Select(y => y.As<IMapNodeItem>())
                                .Where(z => z != null);
            }
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