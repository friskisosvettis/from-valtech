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
using Sitecore.Pipelines.Save;
using Stimulsoft.Base.Context;
using Telerik.Web.Data.Extensions;

namespace FOS.Website.Feature.Content.Controllers
{
    public class ProximityController : Controller
    {
        private readonly int NR_OFF_ASSOCIATIONS_IN_ANSWER = 3;
        private readonly double VALTECH_LAT = 59.3277143;
        private readonly double VALTECH_LONG = 18.050467;

        private static IPAddress GetIpAddressFromTracker()
        {
            return Tracker.Current?.Interaction?.Ip != null
                ? new IPAddress(Tracker.Current.Interaction.Ip) : IPAddress.Parse("89.107.211.196");
        }

        private bool GotUserLocation(out double latitude, out double longitude)
        {
            latitude = 0.0;
            longitude = 0.0;
            var userIp = GetIpAddressFromTracker();
            if (userIp != null)
            {
                double? tempLat, tempLong;
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

        private double OptimizedDistance(double oX, double oY, double pX, double pY)
        {
            var dX = oX - pX;
            var dY = oY - pY;
            return dX*dX + dY*dY;
        }

        private Item GetAssociationItem(IMapNodeItem gymItem)
        {
            return gymItem.InnerItem.ClosestAscendantItemOfType<IAssociationFlagTemplateItem>()?.InnerItem;
        }

        private IEnumerable<Item> GetAllAssociations(Item item, double latitude, double longitude)
        {
            using (var context = ContentSearchManager.CreateSearchContext(new SitecoreIndexableItem(item)))
            {
                var result = context.GetSynthesisQueryable<IMapNodeItem>()
                    .ToList()
                    .Where(n => n.Longitude.HasTextValue && n.Latitude.HasTextValue)
                    .OrderBy(
                        n => OptimizedDistance( Convert.ToDouble(n.Latitude.RawValue.Replace('.',',')) 
                                              , Convert.ToDouble(n.Longitude.RawValue.Replace('.', ','))
                                              , latitude, longitude))
                    .Select(GetAssociationItem)
                    .DistinctBy(a => a.DisplayName)
                    .Take(NR_OFF_ASSOCIATIONS_IN_ANSWER).ToList();

                return result;
            }
        }

        public ActionResult GetProximityView()
        {
            double userLat, userLong;
            ProximityModel model = null;
            if (GotUserLocation(out userLat, out userLong))
            {
                var listOfAssociations = GetAllAssociations(Sitecore.Context.Item, userLat, userLong);

                model = new ProximityModel()
                {
                    AssociationsItems = listOfAssociations
                };
            }

            return View(Constants.Views.Paths.ProximityView, model);
        }
    }
}