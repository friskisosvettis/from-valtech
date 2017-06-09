using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Concrete.Feature.Content.Data;
using FOS.Website.Feature.Content.Data;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.SearchUtilityFunctions
{
    public class RegionSearch
    {
        public static IEnumerable<IRegionItem> GetAllRegionsStartingWith(string namePartialString, Item startItem)
        {
            string index = string.Format("sitecore_{0}_index", startItem.Database.Name);
            using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
            {
                var nameStartsWith = PredicateCollection.DisplayNameStartsWith(namePartialString);
                string templateID = Region.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();
                var query = context.GetQueryable<SearchResultItem>()
                    .Where(i => i["_latestversion"].Equals("1"))
                    .Where(i => i["_templates"].Contains(templateID))
                    .Where(nameStartsWith);

                var result = query.GetResults();

                return result.Hits.Select(i => i.Document.GetItem().As<IRegionItem>()).Where(n => n != null);
            }
        }
    }
}