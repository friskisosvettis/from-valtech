using System.Collections.Generic;
using FOS.Website.Concrete.Feature.Content.Data;
using FOS.Website.Feature.Content.Data;
using Sitecore.Data.Items;

namespace FOS.Website.Feature.SearchUtilityFunctions
{
    public class TrainingCenterSearch
    {
        public static string TrainingCenterTemplateId => TrainingCenterFlagTemplate.ItemTemplateId.ToShortID().ToString().ToLowerInvariant();

        public static IEnumerable<ITrainingCenterFlagTemplateItem> GetAllTrainingCenterOnAssociation(Item associationItem)
        {
            return SearchUtility.SearchFor<ITrainingCenterFlagTemplateItem>(associationItem, TrainingCenterTemplateId);
        }

        public static IEnumerable<ITrainingCenterFlagTemplateItem> GetAllTrainingCenterStartingWith(string namePartialString, Item startItem)
        {
            var nameStartsWith = PredicateCollection.DisplayNameStartsWith(namePartialString);
            return SearchUtility.SearchFor<ITrainingCenterFlagTemplateItem>(startItem, TrainingCenterTemplateId, nameStartsWith);
        }
    }
}