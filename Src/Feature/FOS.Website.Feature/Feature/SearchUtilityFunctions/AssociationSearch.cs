using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Concrete.Feature.Content.Data;
using FOS.Website.Concrete.Feature.Content.ListWidgets;
using FOS.Website.Feature.Content.Data;
using FOS.Website.Feature.Content.ListWidgets;
using Sitecore.Buckets.Extensions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using Sitecore.Mvc.Extensions;
using Synthesis;
using Sitecore.ContentSearch.Linq.Utilities;

namespace FOS.Website.Feature.SearchUtilityFunctions
{
    public class AssociationRegionSearchResultItem : SearchResultItem
    {
        [IndexField("region")]
        public string Region { get; set; }
    }

    public static class AssociationSearch
    {
        public static IEnumerable<IAssociationFlagTemplateItem> GetAllAssociations(string dbName)
        {
            var startItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.ContentStartPath);
            string index = string.Format("sitecore_{0}_index", dbName);
            using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
            {
                string templateID = AssociationFlagTemplate.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();
                var query = context.GetQueryable<SearchResultItem>()
                    .Where(i => i["_latestversion"].Equals("1"))
                    .Where(i => i.Language.Equals(startItem.Language.Name))
                    .Where(i => i.Paths.Contains(startItem.ID))
                    .Where(i => i["_templates"].Contains(templateID));

                var result = query.GetResults();

                return result.Hits.Select(i => i.Document.GetItem().As<IAssociationFlagTemplateItem>()).Where(n => n != null);
            }
        }

        public static IEnumerable<IAssociationFlagTemplateItem> GetAllAssociationsStartingWith(string namePartialString, Item startItem)
        {
            string index = string.Format("sitecore_{0}_index", startItem.Database.Name);
            using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
            {
                var nameStartsWith = PredicateCollection.DisplayNameStartsWith(namePartialString);
                string templateID = AssociationFlagTemplate.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();
                var query = context.GetQueryable<SearchResultItem>()
                    .Where(i => i["_latestversion"].Equals("1"))
                    .Where(i => i.Language.Equals(startItem.Language.Name))
                    .Where(i => i.Paths.Contains(startItem.ID))
                    .Where(i => i["_templates"].Contains(templateID))
                    .Where(nameStartsWith);

                var result = query.GetResults();

                return result.Hits.Select(i => i.Document.GetItem().As<IAssociationFlagTemplateItem>()).Where(n => n != null);
            }
        }

        public static IEnumerable<IRegionsItem> GetAllAssociationsWithRegionName(string regionQuery, Item startItem)
        {
            string index = string.Format("sitecore_{0}_index", startItem.Database.Name);
            using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
            {
                string regionFieldId = Regions.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();
                var query = context.GetQueryable<AssociationRegionSearchResultItem>()
                    .Where(i => i["_latestversion"].Equals("1"))
                    .Where(i => i.Language.Equals(startItem.Language.Name))
                    .Where(i => i.Paths.Contains(startItem.ID))
                    .Where(i => i["_templates"].Contains(regionFieldId))
                    .Where(i => i.Region.Equals(regionQuery));


                var result = query.GetResults();

                return result.Hits
                    .Select(i => i.Document.GetItem().As<IRegionsItem>());
            }
        }
    }
}