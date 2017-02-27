using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valtech.Foundation.Dictionary
{
    internal static class DictionaryCache
    {
        internal static string GetDictionaryPath(Item contextItem)
        {
            if (contextItem == null)
                return null;

            string cacheKey = GetCacheKey(contextItem);
            object dictionaryPathObject = HttpContext.Current != null ? HttpContext.Current.Cache.Get(cacheKey) : null;
            if (dictionaryPathObject != null)
                return (string)dictionaryPathObject;

            return null;
        }

        private static string GetCacheKey(Item contextItem)
        {
            return "DictionaryPath" + contextItem.Uri.ToString();
        }

        internal static void AddDictionaryPath(Item item, string dictionaryPath)
        {
            if (item == null)
                return;

            if (String.IsNullOrEmpty(dictionaryPath))
                return;

            string cacheKey = GetCacheKey(item);

            if(HttpContext.Current != null)
                HttpContext.Current.Cache.Add(cacheKey, dictionaryPath, null, DateTime.Now.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
        }
    }
}