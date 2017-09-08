using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FOS.Website.Concrete.Feature.Content.Data;
using FOS.Website.Concrete.Feature.Content.ListWidgets;
using FOS.Website.Feature.Content.Data;
using FOS.Website.Feature.Content.ListWidgets;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.SearchUtilityFunctions
{
    public class AssociationRegionSearchResultItem : SearchResultItem
    {
        [IndexField("region")]
        public string Region { get; set; }
    }

    public static class AssociationSearch
    {
        public static string AssociationFlagTemplateId => AssociationFlagTemplate.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();
        public static string RegionsTemplateId => Regions.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();

        public static IEnumerable<IAssociationFlagTemplateItem> GetAllAssociations(string dbName)
        {
            var startItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.ContentStartPath);
            return SearchUtility.SearchFor<IAssociationFlagTemplateItem>(startItem, AssociationFlagTemplateId);
        }

        public static IEnumerable<IAssociationFlagTemplateItem> GetAllAssociationsStartingWith(string namePartialString, Item startItem)
        {
            return SearchUtility.SearchFor<IAssociationFlagTemplateItem>(startItem, AssociationFlagTemplateId, PredicateCollection.DisplayNameStartsWith(namePartialString));
        }

        public static IEnumerable<IRegionsItem> GetAllAssociationsWithRegionName(string regionQuery, Item startItem)
        {
            return SearchUtility.SearchFor<IRegionsItem, AssociationRegionSearchResultItem>(startItem, RegionsTemplateId, item => item.Region.Equals(regionQuery));
        }
    }
}