using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Valtech.Foundation.SitecoreExtensions;

namespace Valtech.Foundation.DataSource
{
    public class DataSource
    {
        /// <summary>
        /// 
        /// </summary>
        public static Item GetDataSourceItem(RenderingContext renderingContext)
        {
            if (renderingContext == null)
            {
                return null;
            }

            string dataSourceItemIdString = renderingContext.Rendering.DataSource;
            if (string.IsNullOrWhiteSpace(dataSourceItemIdString))
            {
                return null;
            }

            ID dataSourceItemId;
            if (!ID.TryParse(dataSourceItemIdString, out dataSourceItemId))
            {
                return null;
            }

            Database database = Sitecore.Context.Database;
            if (database == null)
            {
                return null;
            }

            Item dataSourceItem = database.GetItem(dataSourceItemId);
            return dataSourceItem;
        }

        /// <summary>
        /// If rendering datasource is empty and contextItem inherits from templateId, the contextItem will be returned as datasourceItem
        /// </summary>
        public static Item GetDataSourceItem(RenderingContext renderingContext, Item contextItem, string templateId)
        {
            Item dataSourceItem = null;
            Database database = Sitecore.Context.Database;
            if (database == null)
            {
                return null;
            }

            if (renderingContext != null && renderingContext.Rendering != null && renderingContext.Rendering.DataSource != null)
            {
                string dataSourceItemIdString = renderingContext.Rendering.DataSource;
                if (!string.IsNullOrWhiteSpace(dataSourceItemIdString))
                {
                    ID dataSourceItemId;
                    if (ID.TryParse(dataSourceItemIdString, out dataSourceItemId))
                    {
                        dataSourceItem = database.GetItem(dataSourceItemId);
                        if (dataSourceItem != null && !dataSourceItem.IsDerivedFrom(templateId))
                        {
                            dataSourceItem = null;
                        }
                    }
                }
            }

            if (dataSourceItem == null && contextItem != null && contextItem.IsDerivedFrom(templateId))
            {
                dataSourceItem = contextItem;
            }

            return dataSourceItem;
        }
    }
}