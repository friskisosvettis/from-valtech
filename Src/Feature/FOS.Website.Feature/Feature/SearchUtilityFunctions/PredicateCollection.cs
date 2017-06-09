using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;

namespace FOS.Website.Feature.SearchUtilityFunctions
{
    public static class PredicateCollection
    {
        public static Expression<Func<SearchResultItem, bool>>  DisplayNameStartsWith(string query)
        {
            var nameIfNotDisplayName = PredicateBuilder.True<SearchResultItem>();
            nameIfNotDisplayName = nameIfNotDisplayName.And(i => String.IsNullOrEmpty(i["_displayname"]));
            nameIfNotDisplayName = nameIfNotDisplayName.And(i => i.Name.StartsWith(query));

            var nameStartsWith = PredicateBuilder.False<SearchResultItem>();
            nameStartsWith = nameStartsWith.Or(nameIfNotDisplayName);
            nameStartsWith = nameStartsWith.Or(i => i["_displayname"].StartsWith(query));

            return nameStartsWith;
        }
    }
}