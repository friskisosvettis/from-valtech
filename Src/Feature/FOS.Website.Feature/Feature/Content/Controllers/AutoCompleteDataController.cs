using FOS.Website.Feature.Content.Data;
using FOS.Website.Feature.Content.PresentationData;
using FOS.Website.Feature.AutoComplete;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Synthesis;
using FOS.Website.Feature.Content.Models;
using Newtonsoft.Json;
using Sitecore.Buckets.Extensions;
using Valtech.Foundation.SitecoreExtensions;
using Valtech.Foundation.Synthesis;
using Sitecore.Data.Items;
using Sitecore.Services.Infrastructure.Web.Http;


namespace FOS.Website.Feature.Content.Controllers
{
    public class AutoCompleteDataController : ServicesApiController
    {
        AutoComplete.AutoComplete autoComplete = new AutoComplete.AutoComplete();
            
        [HttpGet]
        public HttpResponseMessage GetAutoCompleteData(string query)
        {
            var startItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.ContentStartPath);
            string dataSet = autoComplete.StartsWith(query, startItem);
            Debug.WriteLine(dataSet);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(dataSet, Encoding.UTF8, "application/json");
            return response;
        }

    }
}