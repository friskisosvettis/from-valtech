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
using Sitecore.Buckets.Extensions;
using Valtech.Foundation.SitecoreExtensions;
using Valtech.Foundation.Synthesis;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using FOS.Website.Concrete.Feature.Content.Data;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Items;

using System.Net.Http;
using System.Net.Http.Headers;
using Sitecore.Analytics.Rules.Conditions;

namespace FOS.Website.Feature.Content.Controllers
{
    public class TrainingCenterCollectionMapController : Controller
    {
        private IEnumerable<TTemplate> GetAllDescendentsOfType<TTemplate>(Item item)
            where TTemplate : class, IStandardTemplateItem
        {
            using (var context = ContentSearchManager.CreateSearchContext(new SitecoreIndexableItem(item)))
            {
                var result = context.GetSynthesisQueryable<TTemplate>()
                    .Where(i => i.Path.StartsWith(item.Paths.Path))
                    .ToList();

                return result;
            }
        }

        private IEnumerable<TTemplate> GetAllOfType<TTemplate>(Item item)
            where TTemplate : class, IStandardTemplateItem
        {
            using (var context = ContentSearchManager.CreateSearchContext(new SitecoreIndexableItem(item)))
            {
                var result = context.GetSynthesisQueryable<TTemplate>()
                    .ToList();

                return result;
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
                    listOfGyms = GetAllDescendentsOfType<IMapNodeItem>(assosiationItem.InnerItem).ToList();
                }
                else
                {
                    listOfGyms = GetAllOfType<IMapNodeItem>(Sitecore.Context.Item).ToList();
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