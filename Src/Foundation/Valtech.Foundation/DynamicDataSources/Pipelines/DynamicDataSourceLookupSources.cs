using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetLookupSourceItems;
using Sitecore.Shell.Applications.ContentEditor;
using Sitecore.Text;
using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valtech.Foundation.DynamicDataSources.Pipelines
{
    public class DynamicDataSourceLookupSources 
    {
        public void Process(GetLookupSourceItemsArgs args)
        {

            Assert.ArgumentNotNull(args, "args");

            if (!args.Source.StartsWith("query:"))
                return;

            var url = WebUtil.GetQueryString();

            if (string.IsNullOrWhiteSpace(url) || !url.Contains("hdl")) return;

            var parameters = FieldEditorOptions.Parse(new UrlString(url)).Parameters;

            var currentItemId = parameters["contentitem"];

            if (string.IsNullOrEmpty(currentItemId)) return;

            var contentItemUri = new Sitecore.Data.ItemUri(currentItemId);

            args.Item = Sitecore.Data.Database.GetItem(contentItemUri);

        }
    }
}