using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Templates;

namespace Valtech.Foundation.SitecoreExtensions
{
    public static class ItemExtensions
    {
        public static bool IsDerived(this Item item, ID templateId)
        {
            if (item == null)
            {
                return false;
            }

            return !templateId.IsNull && item.IsDerived(item.Database.Templates[templateId]);
        }

        private static bool IsDerived(this Item item, Item templateItem)
        {
            if (item == null)
            {
                return false;
            }

            if (templateItem == null)
            {
                return false;
            }

            var itemTemplate = TemplateManager.GetTemplate(item);
            return itemTemplate != null && (itemTemplate.ID == templateItem.ID || itemTemplate.DescendsFrom(templateItem.ID));
        }

        public static bool IsDerivedFrom(this Item item, string templateId)
        {
            if (string.IsNullOrEmpty(templateId))
                return false;

            Item templateItem = item.Database.Items[new ID(templateId)];
            if (templateItem == null)
                return false;

            //Template template = TemplateManager.GetTemplate(item);
            Template template = TemplateManager.GetTemplate(item.TemplateID, item.Database);
            if (template == null) return false;

            if (template.ID == templateItem.ID)
                return true;

            return template.DescendsFrom(templateItem.ID);
        }

        public static Item[] GetAncestorsAndSelf(this Item item)
        {
            List<Item> items = new List<Item>(item.Axes.GetAncestors()) { item };
            items.Reverse();
            return items.ToArray();
        }
    }
}