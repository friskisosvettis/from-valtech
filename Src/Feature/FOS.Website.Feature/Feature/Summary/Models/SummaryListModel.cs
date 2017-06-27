using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Items;
using Synthesis;
using Valtech.Foundation.Index;
using FOS.Website.Feature.Taxonomy.Controllers;


namespace FOS.Website.Feature.Summary.Models
{
    public class SummaryListModel
    {

        public List<SummarySpotModel> SummaryList { get; set; }
        public string ListStyle { get; set; }

        public ISummaryListItem SummaryListItem {get; set; }
        
        public int ResultCount { get { return SummaryList.Count(); } }
        public int NumberOfProductsPerPage = 3;

        public SummaryListModel()
        {
            SummaryList = new List<SummarySpotModel>();
            ListStyle = string.Empty;
        }

        public SummaryListModel(Item item) : this()
        {
            SummaryListItem = item.As<ISummaryListItem>();
            
            if (SummaryListItem != null)
            {
                List<Item> summaryItemList = new List<Item>();
                SummaryList = new List<SummarySpotModel>();
               
                if (SummaryListItem.UseManualList.Value)
                {
                    summaryItemList = SummaryListItem.ChosenListItems.TargetItems.Select(i => i.InnerItem).ToList();
                }
                else
                {
                    summaryItemList = GetSummaryList(SummaryListItem);
                }

                // Add items to the list of SummarySpotModels to show
                SummaryList.AddRange(summaryItemList.Select(x => new SummarySpotModel(x)));

                Item sortByItem = SummaryListItem?.SortBy?.Target?.InnerItem;

                int maxResults = SummaryListItem.MaxResults.Value;
                if (maxResults < 1)
                {
                    maxResults = 10;
                }

                // Sort by SummaryHeading
                ISortBySummaryHeadingItem sortBySummaryHeadingItem = sortByItem.As<ISortBySummaryHeadingItem>();
                if (sortBySummaryHeadingItem != null)
                {
                    SummaryList = SummaryList.OrderBy(t => t.SummaryHeadingString).ToList();
                }

                // Sort by newsdate
                ISortByNewsDateItem sortByNewsDateItem = sortByItem.As<ISortByNewsDateItem>();
                if (sortByNewsDateItem != null)
                { 
                    SummaryList = SummaryList.OrderBy(t => t.NewsPublishDate).ToList();
                }

                SummaryList = SummaryList.Take(maxResults).ToList();   
            }
        }

        ///// <summary>
        ///// Uses a shared settings item to create a list based on supplied items.
        ///// </summary>
        //public SummaryListModel(SummaryListBasicItem listItem, IList<Item> items) : this()
        //{
        //    var summaryItemList = new List<Item>();
        //    SummaryList = new List<SummarySpotModel>();

        //    if (listItem != null)
        //    {
        //        ReadMoreLink.Item = listItem;
        //        ReadMoreLink.FieldName = listItem.MoreStoriesLinkFieldName;
        //        ReadMoreLink = new ItemAndFieldName(listItem.InnerItem, listItem.MoreStoriesLinkFieldName);

        //        Header = new ItemAndFieldName(listItem.InnerItem, listItem.Header);

        //        ListStyle = string.Empty;
        //        if (listItem.ListStyle != null && listItem.ListStyle.Item != null)
        //        {
        //            var cssClassItem = new CssClassItem(listItem.ListStyle.Item);
        //            if (CssClassItem.IsValid(cssClassItem))
        //            {
        //                if (!string.IsNullOrWhiteSpace(cssClassItem.CssClass.Raw))
        //                {
        //                    ListStyle = cssClassItem.CssClass.Raw;
        //                }
        //            }
        //        }

        //        foreach (Item item in items)
        //        {
        //            SummaryList.Add(new SummarySpotModel(item));
        //        }
        //    }
        //}

        public class SummarySearchResultItem : SearchResultItem
        {
            [IndexField("months")]
            public string Months { get; set; }

            [IndexField("taxonomy")]
            public string Taxonomy { get; set; }

            [IndexField("newsdate")]
            public string NewsDate { get; set; }

            [IndexField("summaryheading")]
            public string SummaryHeading { get; set; }

            [IndexField("_template")]
            public string TemplateIdAsString { get; set; }

            [IndexField("_id")]
            public string IdAsString { get; set; }
        }

        
        public static List<Item> GetSummaryList(ISummaryListItem summaryListItem)
        {
            List<Item> summaryItemList = new List<Item>();
            var indexName = Indexes.GetIndexName(summaryListItem.InnerItem);
            if (string.IsNullOrWhiteSpace(indexName))
            {
                return summaryItemList;
            }

            if (Sitecore.Context.Language == null || String.IsNullOrWhiteSpace(Sitecore.Context.Language.Name))
            {
                return summaryItemList;
            }


            // Taxonomy Predicate
            var taxonomyPredicate = PredicateBuilder.True<SummarySearchResultItem>();
            List<Item> taxonomyList = summaryListItem.SelectedTaxonomy.TargetItems.Select(i => i.InnerItem).ToList();

            foreach (ID taxonomyId in taxonomyList.Select(i => i.ID))
            {
                string taxonomyIdString = Clean(taxonomyId.ToString(), "{-}");
                taxonomyPredicate = taxonomyPredicate.Or(s => s.Taxonomy.Contains(taxonomyIdString));
            }

            // Seasonal Predicate
            var seasonalPredicate = PredicateBuilder.True<SummarySearchResultItem>();

            if (summaryListItem.UseSeasonal.Value)
            {
                List<Item> seasons = summaryListItem.SelectedMonths.TargetItems.Select(i => i.InnerItem).ToList();
                if (!seasons.Any())
                {
                    // Get the current month
                    var cultureInfo = new CultureInfo("en-US");
                    string month = DateTime.Now.ToString("MMMM", cultureInfo);

                    Item monthTaxonomyItem = Taxonomy.Controllers.Taxonomy.GetMonthItem(month);
                    if (monthTaxonomyItem != default(Item))
                        seasons.Add(monthTaxonomyItem);
                }
                foreach (ID seasonId in seasons.Select(i => i.ID))
                {
                    string seasonIdString = Clean(seasonId.ToString(), "{-}");

                    seasonalPredicate = seasonalPredicate.Or(s => s.Months.Contains(seasonIdString));
                }
            }


            // Template Predicate
            var templatePredicate = PredicateBuilder.True<SummarySearchResultItem>();
            List<Item> resultTypes = summaryListItem.ResultTypes.TargetItems.Select(i=>i.InnerItem).ToList();
            foreach (ID typeId in resultTypes.Select(i => i.ID))
            {
                string templateIdString = Clean(typeId.ToString());
                templatePredicate = templatePredicate.Or(t => t.TemplateIdAsString.Contains(templateIdString));
            }

            // Search Root Predicate
            var searchRootPredicate = PredicateBuilder.True<SummarySearchResultItem>();
            Item searchRootItem = summaryListItem.SourceRootItem.Target.InnerItem;
            if (searchRootItem != null)
            {
                ID searchRootItemId = searchRootItem.ID;
                // Find decendants and remove the searchroot
                searchRootPredicate = searchRootPredicate.Or(r => r.Paths.Contains(searchRootItemId) && r.ItemId != searchRootItemId);
            }

            // Only Search For Children of Root Predicate
            var onlySearchRootChildrenPredicate = PredicateBuilder.True<SummarySearchResultItem>();
            if (summaryListItem.OnlyIncludeSearchRootChildren.Value)
            {
                onlySearchRootChildrenPredicate = onlySearchRootChildrenPredicate.Or(r => r.Parent == searchRootItem.ID);
            }


            string contextLanguage = Sitecore.Context.Language.Name;

            using (var context = ContentSearchManager.GetIndex(indexName).CreateSearchContext())
            {
                SearchResults<SummarySearchResultItem> result = context.GetQueryable<SummarySearchResultItem>()
                    .Where(s => s.Language == contextLanguage)
                    .Where(taxonomyPredicate)
                    .Where(seasonalPredicate)
                    .Where(searchRootPredicate)
                    .Where(onlySearchRootChildrenPredicate)
                    .Where(templatePredicate)
                    .GetResults();

                return result.Hits.Select(i => i.Document.GetItem()).ToList();
            }

        }

        public static string Clean(string stringToClean, string charsToRemove)
        {
            string cleanString = stringToClean.ToLower();
            foreach (char chararater in charsToRemove)
            {
                cleanString = cleanString.Replace(chararater.ToString(CultureInfo.InvariantCulture), "");
            }
            return cleanString;
        }

        public static string Clean(string stringToClean)
        {
            string cleanString = stringToClean.ToLower();
            cleanString = cleanString.Replace("{", "");
            cleanString = cleanString.Replace("}", "");
            cleanString = cleanString.Replace("-", "");
            return cleanString;
        }

    }
}