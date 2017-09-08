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
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using FOS.Website.Concrete.Feature.Content.Data;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Items;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Sitecore.Analytics;
using Sitecore.Analytics.Lookups;
using Sitecore.Analytics.Rules.Conditions;
using Sitecore.CES.GeoIp;
using Sitecore.ContentSearch.Linq;
using Sitecore.Pipelines.Save;
using Stimulsoft.Base.Context;
using Telerik.Web.Data.Extensions;

namespace FOS.Website.Feature.Content.Controllers
{
    public class ProximityController : Controller
    {
        private readonly int NR_OFF_ASSOCIATIONS_IN_ANSWER = 3;
        private readonly decimal VALTECH_LAT = 59.3277143m;
        private readonly decimal VALTECH_LONG = 18.050467m;

        private static IPAddress GetIpAddressFromTracker()
        {
            return Tracker.Current?.Interaction?.Ip != null
                ? new IPAddress(Tracker.Current.Interaction.Ip) : IPAddress.Parse("89.107.211.196");
        }

        private bool GotUserLocation(out decimal latitude, out decimal longitude)
        {
            latitude = 0.0m;
            longitude = 0.0m;
            var userIp = GetIpAddressFromTracker();
            if (userIp != null)
            {
                decimal? tempLat, tempLong;
                // 
                // LocationIP.GetCoordsSiteCore(userIp, out tempLat, out tempLong);
                //

                ///////////////////////////////////////// Temp ////////////////////////////////////////////////////

                LocationIP.GetCoords(userIp, out tempLat, out tempLong);
                //LocationIP.GetCoords("89.107.211.196", out tempLat, out tempLong);
                if (!tempLat.HasValue || !tempLong.HasValue) // For Demo
                {
                    latitude = VALTECH_LAT;
                    longitude = VALTECH_LONG;
                    return true;
                }

                //////////////////////////////////////////////////////////////////////////////////////////////////

                if (tempLat.HasValue && tempLong.HasValue)
                {
                    latitude = tempLat.Value;
                    longitude = tempLong.Value;
                    return true;
                }
            }

            return false;
        }

        private decimal OptimizedDistance(decimal oX, decimal oY, decimal pX, decimal pY )
        {
            var dX = oX - pX;
            var dY = oY - pY;
            return dX * dX + dY * dY;
        }

        private Item GetAssociationItem(IMapNodeItem gymItem)
        {
            return gymItem.InnerItem.ClosestAscendantItemOfType<IAssociationFlagTemplateItem>()?.InnerItem;
        }

        // Add some extra parameters so the list of Mapnodes to sort is reduced
        private IEnumerable<Item> GetAllAssociations(Item item, decimal latitude, decimal longitude)
        {
            string index = string.Format("sitecore_{0}_index", Sitecore.Context.Database.Name);
            using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
            {
                string templateID = MapNode.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();
                var query = context.GetQueryable<SearchResultItem>()
                    .Where(i => i["_latestversion"].Equals("1"))
                    .Where(i => i.Language.Equals(item.Language.Name))
                    .Where(i => i["_templates"].Contains(templateID));

                var result = query.GetResults();

                return result.Hits
                    .Select(i => i.Document.GetItem().As<IMapNodeItem>())
                    .Where(n => n != null )
                    .Where(n => !decimal.Equals(n.Latitude.Value, 0) && !decimal.Equals(n.Longitude.Value, 0))
                    .OrderBy(
                        n => OptimizedDistance(n.Latitude.Value, n.Longitude.Value, latitude, longitude))
                    .Select(GetAssociationItem)
                    .DistinctBy(a => a.DisplayName)
                    .Take(NR_OFF_ASSOCIATIONS_IN_ANSWER).ToList();
            }
        }

        public ActionResult GetProximityView()
        {
            decimal userLat, userLong;
            ProximityModel model = null;
            if (GotUserLocation(out userLat, out userLong))
            {
                model = new ProximityModel()
                {
                    AssociationsItems = GetAllAssociations(Sitecore.Context.Item, userLat, userLong)
            };
            }

            return View(Constants.Views.Paths.ProximityView, model);
        }
    }
}