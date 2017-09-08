using Sitecore.Data.Items;
using Synthesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valtech.Foundation.Settings
{
    internal static class SettingsCache
    {
        internal static Item GetSettingRoot(Item contextItem)
        {
            if (contextItem == null)
                return null;

            string cacheKey = GetCacheKey(contextItem);
            object cacheObject = HttpContext.Current != null ? HttpContext.Current.Cache.Get(cacheKey) : null;

            if (cacheObject == null)
                return null;

            Item itemFromCache = cacheObject as Item;
            return itemFromCache;
        }

        internal static void AddSettingsRoot(Item contextItem, Item rootItem)
        {
            if (contextItem == null || rootItem == null)
                return;

            string cacheKey = GetCacheKey(contextItem);

            if (HttpContext.Current != null)
                HttpContext.Current.Cache.Add(cacheKey, rootItem, null, DateTime.Now.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);

        }

        internal static T GetSettingsInstance<T>(Item contextItem)
        {
            if (contextItem == null)
                return default(T);

            string cacheKey = GetCacheKey<T>(contextItem);
            object cacheObject = HttpContext.Current != null ? HttpContext.Current.Cache.Get(cacheKey) : null;
            if (cacheObject == null)
                return default(T);

            T objectFromCache = (T)cacheObject;
            return objectFromCache;
        }

        internal static void AddSettingInstance<T>(T element, Item contextItem) where T : class, IStandardTemplateItem
        {
            if (element == null || contextItem == null)
                return;

            string cacheKey = GetCacheKey<T>(contextItem);

            if (HttpContext.Current != null)
                HttpContext.Current.Cache.Add(cacheKey, element, null, DateTime.Now.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);

        }

        private static string GetCacheKey<T>(Item contextItem)
        {
            string typeName = typeof(T).FullName;
            string uri = contextItem.Uri.ToString();
            return "SettingsCache" + uri + typeName;
        }

        private static string GetCacheKey(Item contextItem)
        {
            string uri = contextItem.Uri.ToString();
            return "SettingsRootCache" + uri;
        }
    }
}