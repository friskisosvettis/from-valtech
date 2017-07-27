using FOS.Website.Foundation.Dictionary.Data;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Synthesis;

namespace Valtech.Foundation.Dictionary
{
    public class DictionaryRepository
    {
        private string _rootPath;

        public static DictionaryRepository Default
        {
            get
            {
                string dictionaryPath = String.Empty;
                if (Context.Item != null)
                {

                    string pathFromCache = DictionaryCache.GetDictionaryPath(Context.Item);
                    if (!String.IsNullOrEmpty(pathFromCache))
                    {
                        dictionaryPath = pathFromCache;
                    }
                    else
                    {
                        List<Item> items = new List<Item>(Context.Item.Axes.GetAncestors()) { Context.Item };
                        items.Reverse();
                        IDictionarySelectorItem selectorItem = items.FirstOrDefault(i => i.As<IDictionarySelectorItem>() != null).As<IDictionarySelectorItem>();
                        if (selectorItem != null && selectorItem.Dictionary_Dictionary.Target != null)
                        {
                            dictionaryPath = selectorItem.Dictionary_Dictionary.Target.Path;
                            if (!String.IsNullOrEmpty(dictionaryPath))
                            {
                                DictionaryCache.AddDictionaryPath(Context.Item, dictionaryPath);
                            }
                        }
                    }
                    
                }

                return new DictionaryRepository(dictionaryPath);
            }
        }

       public DictionaryRepository(string rootPath)
        {
            Assert.ArgumentNotNullOrEmpty(rootPath, "rootPath");

            _rootPath = rootPath;
        }

        public string GetRawValueText(string folderName, string dictionaryKey, string defaultText = "")
        {
            return GetText(folderName, dictionaryKey, string.IsNullOrWhiteSpace(defaultText) ? dictionaryKey : defaultText, true);
        }

        public string GetText(string folderName, string dictionaryKey, string defaultText = "CREATE: ", bool rawValue = false)
        {
            Item contextItem = Sitecore.Context.Item;
            if (contextItem == null)
            {
                return string.Empty;
            }
            return GetText(folderName, dictionaryKey, contextItem, contextItem.Language.Name, defaultText, rawValue);
        }

        public string GetText(string folderName, string dictionaryKey, Item contextItem, string defaultText = "CREATE: ", bool rawValue = false)
        {
            if (contextItem == null)
                return defaultText;

            return GetText(folderName, dictionaryKey, contextItem, contextItem.Language.Name, defaultText, rawValue);
        }

        public string GetText(string folderName, string dictionaryKey, Item contextItem, string language, string defaultText = "CREATE: ", bool rawValue = false)
        {
            try
            {
                IDictionaryTextItem dictionaryItem = GetDictionaryEntry(folderName, dictionaryKey, defaultText, language, contextItem);
                if (dictionaryItem == null)
                {
                    Sitecore.Diagnostics.Log.Info(string.Format("DictionaryItem lookup is null returning default text, folderName = {0}, fieldName = {1}, languageName = {2}, contextItem.Name = {3}, contextItem.Id = {4}", folderName, dictionaryKey, language, contextItem.Name, contextItem.ID), typeof(DictionaryRepository));
                    string defaultTextToOutput = string.IsNullOrWhiteSpace(defaultText) ? dictionaryKey : defaultText;
                    return defaultTextToOutput;
                }
                if (rawValue)
                {
                    var retString = HttpUtility.HtmlDecode(dictionaryItem.Dictionary_Text.RawValue);
                    return string.IsNullOrWhiteSpace(retString)
                        ? (string.IsNullOrWhiteSpace(defaultText) ? dictionaryKey : defaultText)
                        : retString;
                }
                return dictionaryItem.Dictionary_Text.RenderedValue;
            }
            catch (Exception e)
            {
                Sitecore.Diagnostics.Log.Warn(string.Format("Dictionary failed with error {0} in {1}", e.ToString(), (typeof(DictionaryRepository).Name)), e, typeof(DictionaryRepository));

                return string.IsNullOrWhiteSpace(defaultText) ? dictionaryKey : defaultText;
            }
        }

        private IDictionaryTextItem GetDictionaryEntry(string folderName, string dictionaryKey, string defaultText, string languageName, Item contextItem)
        {

            dictionaryKey = dictionaryKey.Replace("/", "");

            if (string.IsNullOrWhiteSpace(_rootPath))
            {
                Sitecore.Diagnostics.Log.Warn(string.Format("Failed getting dictionaryPath in GetOrCreateDictionaryEntry(), folderName = {0}, fieldName = {1}, languageName = {2}, contextItem.Name = {3}, contextItem.Id = {4}", folderName, dictionaryKey, languageName, contextItem.Name, contextItem.ID), typeof(DictionaryRepository));
                return null;
            }

            string dictionaryEntryPath = string.Format("{0}/{1}/{2}", _rootPath, folderName, dictionaryKey);
            //Clean up if double slashes have been entered.
            dictionaryEntryPath = dictionaryEntryPath.Replace("//", "/");
            Database contextDb = Sitecore.Context.Database;

            Language language = Sitecore.Globalization.Language.Parse(languageName);

            // Attempt to retrieve dictionaryEntry from the Sitecore.Context.Database database
            Item dictionaryEntry = contextDb.GetItem(dictionaryEntryPath, language);

            IDictionaryTextItem dicItem = dictionaryEntry.As<IDictionaryTextItem>();

            return dicItem;
            
        }
    }
    
}