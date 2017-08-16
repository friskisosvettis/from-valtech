using System.Collections.Generic;
using System.Linq;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.SearchUtilityFunctions
{
    public static class SearchExtensions
    {
        public static IEnumerable<T> AsSitecoreOrdered<T>(this IEnumerable<T> items) where T: class, Synthesis.IStandardTemplateItem
        {
            return items.Select(x => x.InnerItem).OrderBy(x => !string.IsNullOrEmpty(x["__Sortorder"]) ? int.Parse(x["__Sortorder"]) : 0).Select(y => y.As<T>());
        }
        
        public static IQueryable<T> GetQueryableItems<T>(this IProviderSearchContext context, Item startItem, string templateId) where T : SearchResultItem
        {
            var query = context.GetQueryable<T>();

            return query.Where(i => i["_latestversion"].Equals("1"))
                        .Where(i => i.Language.Equals(startItem.Language.Name))
                        .Where(i => i.Paths.Contains(startItem.ID))
                        .Where(i => i["_templates"].Contains(templateId));
        }
    }
}