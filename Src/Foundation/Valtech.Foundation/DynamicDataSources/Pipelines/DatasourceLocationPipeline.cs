using System;
using System.Linq;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetRenderingDatasource;
using Sitecore.Text;
using Valtech.Foundation.SitecoreExtensions;
using System.Configuration;
using Sitecore.Data;

namespace Valtech.Foundation.DynamicDataSources.Pipelines
{
    public class DatasourceLocationPipeline
    {
        private const string WebsiteToken = "[Website]";

        public void Process(GetRenderingDatasourceArgs args)
        {
            Assert.IsNotNull(args, "args");
            
            foreach (string path in new ListString(args.RenderingItem["Datasource Location"]))
            {
                if (string.IsNullOrEmpty(path))
                    continue;

                string tmpPath = path;

                if (path.StartsWith(WebsiteToken))
                {
                    string templateId = Sitecore.Configuration.Settings.GetSetting("DynamicDataSource.WebsiteRootTemplateId");
                    if (String.IsNullOrEmpty(templateId))
                    {
                        throw new ConfigurationErrorsException("Cannot find setting DynamicDataSource.WebsiteRootTemplateId");
                    }
                    ID id = new ID(templateId);
                    Item contextItem = args.ContentDatabase.GetItem(args.ContextItemPath);
                    Item websiteItem = contextItem.GetAncestorsAndSelf().FirstOrDefault(i => i.IsDerived(id));
                    tmpPath = path.Replace(WebsiteToken, websiteItem.Paths.Path);
                }
                else if (path.StartsWith("query:") && !string.IsNullOrEmpty(args.ContextItemPath))
                {
                    string query = path.Substring("query:".Length);
                    Item contextItem = args.ContentDatabase.GetItem(args.ContextItemPath);
                    if (contextItem != null)
                    {
                        Item queryItem = contextItem.Axes.SelectSingleItem(query);
                        if (queryItem != null)
                        {
                            args.DatasourceRoots.Add(queryItem);
                        }
                    }
                    continue;
                }
                else if (path.StartsWith("./", StringComparison.InvariantCulture) && !string.IsNullOrEmpty(args.ContextItemPath))
                {
                    var itemPath = args.ContextItemPath;
                    tmpPath = string.Concat(itemPath, path.Remove(0, 1));
                }

                Item item = args.ContentDatabase.GetItem(tmpPath);
                if (item == null)
                {
                    continue;
                }
                args.DatasourceRoots.Add(item);
            }
        }
    }
}