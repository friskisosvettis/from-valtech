using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using FOS.Website.Concrete.Feature.Content.Data;
using FOS.Website.Feature.Content.Data;
using Google.Apis.Util;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.SearchUtilityFunctions
{
    public class TrainingCenterSearch
    {
        public static IEnumerable<ITrainingCenterFlagTemplateItem> GetAllTrainingCenterOnAssociation(Item associationItem)
        {
            string index = string.Format("sitecore_{0}_index", associationItem.Database);
            using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
            {
                string templateID = TrainingCenterFlagTemplate.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();
                var query = context.GetQueryable<SearchResultItem>()
                    .Where(i => i["_latestversion"].Equals("1"))
                    .Where(i => i.Language.Equals(associationItem.Language.Name))
                    .Where(i => i.Paths.Contains(associationItem.ID))
                    .Where(i => i["_templates"].Contains(templateID));

                var result = query.GetResults();

                return result.Hits.Select(i => i.Document.GetItem().As<ITrainingCenterFlagTemplateItem>()).Where(n => n != null);
            }
        }

        public static IEnumerable<ITrainingCenterFlagTemplateItem> GetAllTrainingCenter(string dbName)
        {
            string index = string.Format("sitecore_{0}_index", dbName);
            using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
            {
                string templateID = TrainingCenterFlagTemplate.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();
                var query = context.GetQueryable<SearchResultItem>()
                    .Where(i => i["_latestversion"].Equals("1"))
                    //.Where(i => i.Language.Equals(item.Language.Name))
                    //.Where(i => i.Paths.Contains(item.ID))
                    .Where(i => i["_templates"].Contains(templateID));

                var result = query.GetResults();

                return result.Hits.Select(i => i.Document.GetItem().As<ITrainingCenterFlagTemplateItem>()).Where(n => n != null);
            }
        }

        public static IEnumerable<ITrainingCenterFlagTemplateItem> GetAllTrainingCenterStartingWith(string namePartialString, Item startItem)
        {
            string index = string.Format("sitecore_{0}_index", startItem.Database.Name);
            using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
            {
                var nameStartsWith = PredicateCollection.DisplayNameStartsWith(namePartialString);
                string templateID = TrainingCenterFlagTemplate.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();
                var query = context.GetQueryable<SearchResultItem>()
                    .Where(i => i["_latestversion"].Equals("1"))
                    .Where(i => i.Language.Equals(startItem.Language.Name))
                    .Where(i => i.Paths.Contains(startItem.ID))
                    .Where(i => i["_templates"].Contains(templateID))
                    .Where(nameStartsWith);

                var result = query.GetResults();

                return result.Hits.Select(i => i.Document.GetItem().As<ITrainingCenterFlagTemplateItem>()).Where(n => n != null);
            }
        }
    }
}