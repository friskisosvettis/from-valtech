using System.Collections.Generic;
using System.Linq;
using FOS.Website.Feature.Navigation.Data;
using FOS.Website.Foundation.Settings;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Synthesis;

namespace FOS.Website.Feature.Taxonomy.Controllers
{
    public class Taxonomy
    {
        public static List<SearchHit<TaxonomyItem>> GetItems(TaxonomySearchOptions taxonomySearchOptions)
        {
            return GetItems(taxonomySearchOptions.TaxonomyIds, taxonomySearchOptions.TemplateIds, taxonomySearchOptions.ExcludedIds, taxonomySearchOptions.SearchRootIds, taxonomySearchOptions.Skip, taxonomySearchOptions.Take);
        }

        public static List<SearchHit<TaxonomyItem>> GetItems(List<ID> taxonomyIds, List<ID> templateIds, List<ID> excludeIds, List<ID> searchRootIds ,int skip, int take)
        {
            if (searchRootIds == null || searchRootIds.All(ID.IsNullOrEmpty))
            {
                searchRootIds = new List<ID>();
            }
            if (searchRootIds.Count < 1)
            {
                Item frontpageItem = Sitecore.Context.Item.Axes.GetAncestors().FirstOrDefault(a => a.As<INavigationRootPageFlagItem>() != null);
                {
                    if (frontpageItem != null)
                    {
                        searchRootIds.Add(frontpageItem.ID);
                    }
                }
            }
            


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // IN SHORT: To make ranking work, Query fields as STRING (not ID or IEnumerable<ID>) AND USE .CONTAINS() (not equal ==), more details below //
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            #region Fetch Index

            Language language = Sitecore.Context.Language;
            string languageName = string.Empty;
            if (language != null)
            {
                languageName = language.Name;
            }
            
            string webIndexName = "sitecore_web_index";
            string masterIndexName = "sitecore_master_index";
            string indexName = webIndexName;
            
            if (Sitecore.Context.Database.Name != "web")
            {
                indexName = masterIndexName;
            }
            
            var index = ContentSearchManager.GetIndex(indexName);
            #endregion

            #region Hardcoded Strings and IDs
            //string taxonomyKeyword1_1IdString = "{4812E57A-3473-4FAA-934F-9AEFCB9C1C3D}";
            //string taxonomyKeyword1_1IdStringNoBrackets = "4812E57A-3473-4FAA-934F-9AEFCB9C1C3D";
            //string taxonomyKeyword1_1IdStringNoBracketsLowerCase = "4812e57a-3473-4faa-934f-9aefcb9c1c3d";
            //string taxonomyKeyword1_1IdStringNoBracketsLowerCaseNoMinus = "4812e57a34734faa934f9aefcb9c1c3d";
            //string taxonomyKeyword1_2IdString = "{B57A84FE-425A-4DEC-B2AA-F881852CFF31}";
            //string taxonomyKeyword1_2IdStringNoBrackets = "B57A84FE-425A-4DEC-B2AA-F881852CFF31";
            //string taxonomyKeyword1_2IdStringNoBracketsLowerCase = "b57a84fe-425a-4dec-b2aa-f881852cff31";
            //string taxonomyKeyword1_2IdStringNoBracketsLowerCaseNoMinus = "b57a84fe425a4decb2aaf881852cff31";
            //string testPageTemplateIdString = "{553C2361-EAC2-445B-AEFB-CC785E650165}";
            //string basicContentPageTemplateIdString = "{09545571-38F4-48CF-B148-BAFF7FD993D1}";
            //ID taxonomyKeyword1_1Id = new ID(taxonomyKeyword1_1IdString);
            //ID taxonomyKeyword1_2Id = new ID(taxonomyKeyword1_2IdString);
            //ID testPageTemplateId = new ID(testPageTemplateIdString);
            //ID basicContentPageTemplateId = new ID(basicContentPageTemplateIdString);
            #endregion

            var context = index.CreateSearchContext();

            #region Predicate building
                //OR Taxonomy Id predicate builder
                var taxonomyPredicate = PredicateBuilder.True<TaxonomyItem>();
                foreach (ID taxonomyId in taxonomyIds)
                {
                    //string taxonomyIdString = Clean(taxonomyId.ToString());
                    string taxonomyIdString = taxonomyId.ToString().Replace("{","").Replace("}","").ToUpper();
                    taxonomyPredicate = taxonomyPredicate.Or(t => t.Taxonomy.Contains(taxonomyIdString));
                }

                // OR Template Id predicate builder
                var templatePredicate = PredicateBuilder.True<TaxonomyItem>();
                foreach (ID templateId in templateIds)
                {
                    string templateIdString = Clean(templateId.ToString());
                    templatePredicate = templatePredicate.Or(t => t.TemplateIdAsString.Contains(templateIdString));
                }

                // AND Exclude Id predicate builder
                var excludePredicate = PredicateBuilder.True<TaxonomyItem>();
                foreach (ID excludeId in excludeIds)
                {
                    string excludeIdString = Clean(excludeId.ToString());
                    excludePredicate = excludePredicate.And(t => !t.IdAsString.Contains(excludeIdString));
                }

                // OR searchRoot predicate builder
                var searchRootPredicate = PredicateBuilder.True<TaxonomyItem>();
                foreach (ID searchRootId in searchRootIds)
                {
                    if (ID.IsNullOrEmpty(searchRootId))
                    {
                        continue;
                    }
                    Item searchRootItem = Sitecore.Context.Database.GetItem(searchRootId);
                    if (searchRootItem != null)
                    {
                        string searchRootPathString = searchRootItem.Paths.Path;
                        searchRootPredicate = searchRootPredicate.Or(t => t.Path.StartsWith(searchRootPathString));
                        //searchRootPredicate = searchRootPredicate.Or(t => t.Path.Contains(searchRootPathString));
                    }
                    
                }

            #endregion

            //var query = context.GetQueryable<TaxonomyItem>()
            SearchResults<TaxonomyItem> query = context.GetQueryable<TaxonomyItem>()
                //SearchResults<SearchResultItem> query = context.GetQueryable<SearchResultItem>()
            
            #region Use built predicates
            .Where(taxonomyPredicate)
            //.Where(t => t["taxonomy"].Contains(Clean("5591eb94-4daf-4256-9c79-b2d60a04cb6c").ToUpper()))
            //.Where(t => t.Taxonomy.Contains("5591eb94-4daf-4256-9c79-b2d60a04cb6c".ToUpper()))
            .Where(templatePredicate)
			.Where(excludePredicate)
            .Where(searchRootPredicate)
            #endregion

            #region Boosting
                // -- Boosting --
                // Boosting is not working, no form of query time boosting have been producing results
                //.Where(t => t.TemplateIdAsString == Clean(basicContentPageTemplateIdString).Boost(2) || t.TemplateIdAsString == Clean(testPageTemplateIdString).Boost(3)).Boost(1)
            #endregion

            #region Other example queries
                // -- Other example queries --
                //.Where(t => t.Path.Contains("Sitecore"))
                //.Where(t => t.Path.StartsWith("/Sitecore/Content"))
            #endregion

            #region Template ID
                // -- Template ID --
                // When querying Built-in property TemplateId that is of type ID and found on class SearchResultItem the ranking produces score = 0 on all results.
                //.Where(t => t.TemplateId == basicContentPageTemplateId || t.TemplateId == testPageTemplateId)
                    
                // When querying Template as string but using equal (==) instead of .Contains, the ranking fails - scores from this part of the query on all hits are 0
                //.Where(t => t.TemplateIdAsString == (Clean(basicContentPageTemplateIdString)) || t.TemplateIdAsString == (Clean(testPageTemplateIdString)))

                // When querying "_template" field as a string via POCO class (TaxonomyItem) ranking works.
                //.Where(t => t.TemplateIdAsString.Contains(Clean(basicContentPageTemplateIdString)) || t.TemplateIdAsString.Contains(Clean(testPageTemplateIdString)))
                //.Where(t => t.TemplateIdAsString.Contains(Clean(basicContentPageTemplateIdString)))
                //.Where(t => t.TemplateIdAsString.Contains(Clean(testPageTemplateIdString)))
            #endregion

            #region Taxonomy
                // -- Taxonomy --
                // When querying field Taxonomy by property TaxonomyAsIEnum as type IEnumerable<ID> found on POCO class (TaxonomyItem), scores from this part of the query on all hits are 0.
                //.Where(t => t.TaxonomyAsIEnum.Contains(taxonomyKeyword1_1Id) || t.TaxonomyAsIEnum.Contains(taxonomyKeyword1_2Id))
                    
                // When querying property Taxonomy as type string found on POCO class (TaxonomyItem) the ranking works. 
                //.Where(t => t.Taxonomy.Contains(Clean(taxonomyKeyword1_1IdString)) || t.Taxonomy.Contains(Clean(taxonomyKeyword1_2IdString)))
                
            #endregion

            .Where(t => t.Language =="en")
            .Where(t => t.Language == languageName)
            //.Where(t=> t.Taxonomy.Length > 0)
            .GetResults();
            //    List < SearchHit < SearchResultItem >>  testlist = new List<SearchHit<SearchResultItem>>();
            //testlist = query.Hits.ToList();
            //maybe return query (SearchResults<TaxonomyItem>) instead
			return query.Hits.Take(take).ToList();
            //return new List<SearchHit<TaxonomyItem>>();
        }

        public static string Clean(string stringToClean)
        {
            string cleanString = stringToClean.ToLower();
            cleanString = cleanString.Replace("{", "");
            cleanString = cleanString.Replace("}", "");
            cleanString = cleanString.Replace("-", "");
            return cleanString;
        }

        public class TaxonomyItem : SearchResultItem
        {
            // Ranking does not work when accesing Taxonomy as an IEnumerable<ID> in queries
            //public IEnumerable<ID> Taxonomy { get; set; }
            // In order for ranking to work Taxonomy have to be accessed as a string in queryies
            public string Taxonomy { get; set; }
            
            // If a real IEnumerable<ID> type is needed for later processing of the result hits it is possible to create a duplicate property
            // This property works on the same field but with different name and type
            // This duplicate property is then used only for later processing while the string version is used when querying
            //[IndexField("taxonomy")]
            //public IEnumerable<ID> TaxonomyAsIEnum { get; set; }
            
            [IndexField("_template")]
            public string TemplateIdAsString { get; set; }

            [IndexField("_id")]
            public string IdAsString { get; set; }
        }

        public class TaxonomySearchOptions
        {
            public TaxonomySearchOptions()
            {
                TaxonomyIds = new List<ID>();
                TemplateIds = new List<ID>();
                ExcludedIds = new List<ID>();
                SearchRootIds = new List<ID>();
                FallbackItemId = null;
                Skip = 0;
                Take = 100;
                Variation = 0;
                UseSeasonal = false;
            }

            public List<ID> TaxonomyIds { get; set; }
            public List<ID> TemplateIds { get; set; }
            public List<ID> ExcludedIds { get; set; }
            public List<ID> SearchRootIds { get; set; }
            public ID FallbackItemId { get; set; }
            public int Skip { get; set; }
            public int Take { get; set; }
            public int Variation { get; set; }
            public bool UseSeasonal { get; set; }
        }

        public static Item GetMonthItem(string month)
        {
            Item taxonomyRootItem = GetTaxonomyRootItem();
            Item taxonomyMonthGroupItem = taxonomyRootItem?.Children.FirstOrDefault(c => c.As<ITaxonomyMonthsGroupItem>() != null);

            //Item taxonomyMonthItem = taxonomyMonthGroupItem?.Children.FirstOrDefault(c => c.Fields[CustomItems.Components.Taxonomy.TaxonomyKeywordItem.KeywordConstFieldName].Value.ToLower() == month.ToLower());
            Item taxonomyMonthItem = taxonomyMonthGroupItem?.Children.FirstOrDefault(c => c.As<ITaxonomyKeywordItem>() != null && c.As<ITaxonomyKeywordItem>().Keyword.RawValue.ToLower() == month.ToLower());

            return taxonomyMonthItem;
        }

        public static Item GetTaxonomyRootItem()
        {
            Item sitecoreContentRoot = Sitecore.Context.Database.GetItem("/sitecore/content");

            //Item taxonomyRoot = sitecoreContentRoot.Children.First(c => c.TemplateID.ToString() == CustomItems.Components.Taxonomy.TaxonomyFolderItem.TemplateId);
            Item taxonomyRoot = sitecoreContentRoot?.Children.FirstOrDefault(c => c.As<ITaxonomyFolderItem>() != null);

            return taxonomyRoot;
        }
    }
}
