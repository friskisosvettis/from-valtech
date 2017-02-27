using Sitecore.Caching;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.GetRenderingDatasource;
using Sitecore.Sites;
using Sitecore.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valtech.Foundation.DynamicDataSources.Pipelines
{
    public class CreateDataSourcesFolder
    {
        public void Process(GetRenderingDatasourceArgs args)
        {
            Assert.IsNotNull(args, "args");
            if (args.RenderingItem == null)
                return;

            if (args.RenderingItem["Datasource Location"] == null)
                return;

            foreach (string str in new ListString(args.RenderingItem["Datasource Location"]))
            {
                if (str == "./DataSources")
                {
                    using (new Sitecore.SecurityModel.SecurityDisabler())
                    {
                        Item contextItem = args.ContentDatabase.GetItem(args.ContextItemPath);
                        if (contextItem != null)
                        {
                            Item dataSourcesFolder = contextItem.Children[FolderName];
                            if (dataSourcesFolder == null)
                            {
                                CreateFolder(contextItem);
                            }
                        }
                        else
                        {
                            Sitecore.Diagnostics.Log.Error("Could not get context item from path : " + args.ContextItemPath, this);
                        }
                    }
                }
            }
        }

        protected Item CreateFolder(Item contextItem)
        {
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                using (new SiteContextSwitcher(SiteContextFactory.GetSiteContext("system")))
                {
                    TemplateItem folderTemplate = contextItem.Database.GetTemplate(new ID(new Guid(FolderTemplateId)));
                    return contextItem.Add(FolderName, folderTemplate);
                }
            }
        }
        private const string FolderTemplateId = "{F7B78574-8135-4A79-B5C3-C313ABA1B06E}";
        private const string FolderName = "DataSources";
    }
}