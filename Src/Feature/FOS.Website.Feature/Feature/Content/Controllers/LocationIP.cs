using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using Sitecore.Analytics.Lookups;

public class coordParser
{
    public decimal latitude { get; set; }
    public decimal longitude { get; set; }
}

namespace FOS.Website.Feature.Content.Controllers
{
    public static class LocationIP
    {
        public static void GetCoords(IPAddress ip, out decimal? lat, out decimal? longi)
        {
            lat = null;
            longi = null;
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://freegeoip.net/json/");
            var response = client.GetAsync(ip.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content;

                if (null != content)
                {
                    var answer = content.ReadAsStringAsync().Result;
                    var coord = JsonConvert.DeserializeObject<coordParser>(answer);

                    if (!decimal.Equals(coord.latitude, 0) && !decimal.Equals(coord.longitude, 0))
                    {
                        lat = coord.latitude;
                        longi = coord.longitude;
                    }
                }
            }
        }

        // NOT used or Tested. If it should be used it need to be activated in App - center
        public static void GetCoordsSiteCore(IPAddress ip, out decimal? lat, out decimal? longi)
        {
            lat = null;
            longi = null;

            var geoIpOptions = new GeoIpOptions
            {
                Ip = ip,
                MillisecondsTimeout = 1000,
                Id = GeoIpManager.IpHashProvider.ComputeGuid(ip)
            };

            var geoIpResult = GeoIpManager.GetGeoIpData(geoIpOptions);

            if (geoIpResult?.GeoIpData != null && geoIpResult.GeoIpData.Latitude.HasValue && geoIpResult.GeoIpData.Longitude.HasValue)
            {
                lat = (decimal)geoIpResult.GeoIpData.Latitude.Value;
                longi = (decimal)geoIpResult.GeoIpData.Longitude.Value;
            }
        }
    }
}