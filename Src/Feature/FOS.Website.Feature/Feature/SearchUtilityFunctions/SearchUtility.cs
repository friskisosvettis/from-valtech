using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.SearchUtilityFunctions
{
    public class SearchUtility
    {
        public static IProviderSearchContext GetSearchContext()
        {
            string index = $"sitecore_{Sitecore.Context.Database.Name}_index";
            return ContentSearchManager.GetIndex(index).CreateSearchContext();
        }

        public static IEnumerable<T> SearchFor<T, TR>(Item item, string templateId, Expression<Func<TR, bool>> searchExpression = null) 
            where T : class, IStandardTemplateItem
            where TR: SearchResultItem
        {
            using (var context = GetSearchContext())
            {
                var query = context.GetQueryableItems<TR>(item, templateId);

                if (searchExpression != null)
                    query = query.Where(searchExpression);
                
                return query.GetResults().Hits.Select(i => i.Document.GetItem().As<T>()).Where(n => n != null);
            }
        }

        public static IEnumerable<T> SearchFor<T>(Item item, string templateId,
            Expression<Func<SearchResultItem, bool>> searchExpression = null) where T : class, IStandardTemplateItem
        {
            using (var context = GetSearchContext())
            {
                var query = context.GetQueryableItems<SearchResultItem>(item, templateId);

                if (searchExpression != null)
                    query = query.Where(searchExpression);

                return query.GetResults().Hits.Select(i => i.Document.GetItem().As<T>()).Where(n => n != null);
            }
        }
    }
}