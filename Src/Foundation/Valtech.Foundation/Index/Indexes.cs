using System;
using System.Linq;
using Sitecore.ContentSearch;
using Sitecore.Data.Items;

namespace Valtech.Foundation.Index
{
    public class Indexes
    {
        /// <summary>
        /// Returns the name of the index to be used for the ContextSearchManager.
        /// </summary>
        /// <param name="contextItem"></param>
        /// <returns></returns>
        public static String GetIndexName(Item contextItem)
        {
            // Start by asking the ContextSearchManager which index it thinks it should use.
            var indexName = ContentSearchManager.GetContextIndexName(contextItem as IIndexable);

            // Check if the index exists...
            if(!ContentSearchManager.Indexes.Any(x => x.Name.Equals(indexName)))
            {
                // If the item does not have a database associated...
                if(contextItem.Database == null)
                {
                    return String.Empty;
                }

                // Try to create the indexname based on the database name
                indexName = ("sitecore_" + contextItem.Database.Name + "_index").ToLower();

                // Check if the index exits...
                if(!ContentSearchManager.Indexes.Any(x => x.Name.Equals(indexName)))
                {
                    // Default to web index
                    indexName = "sitecore_web_index";

                    // If the web index does not exist, abort...
                    if(!ContentSearchManager.Indexes.Any(x => x.Name.Equals(indexName)))
                    {
                        return String.Empty;
                    }
                }
            }

            return indexName;
        }
    }
}
