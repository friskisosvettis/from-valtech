using System.Collections.Generic;
using System.Linq;
using FOS.Website.Feature.CustomScripts.Data;
using Synthesis;
using Synthesis.FieldTypes.Interfaces;
using Valtech.Foundation.Settings;

namespace FOS.Website.Feature.CustomScripts.Services
{
    public static class CustomScriptsService
    {
        public static IEnumerable<ISiteSpecificScriptItem> GetSiteSpecificCustomScripts()
        {
            var repo = new SettingsRepository().GetSetting<ISiteCustomScriptsSettingsFolderItem>(Sitecore.Context.Item);

            if (repo == null)
            {
                return new ISiteSpecificScriptItem[0];
            }

            return repo.Children.Cast<ISiteSpecificScriptItem>().Where(x => x != null && x.CustomScripts.HasTextValue);
        }

        public static IEnumerable<ITextField> GetInheritedScripts()
        {
            var currentItemScript = Sitecore.Context.Item.As<IPageSpecificCustomScriptsItem>();

            //return the current item script
            if (currentItemScript != null && currentItemScript.CustomScripts.HasTextValue)
            {
                yield return currentItemScript.CustomScripts;
            }

            //return the context items script that will also be inherited on subpages
            if (currentItemScript != null && currentItemScript.ScriptsInheritedOnSubpages.HasTextValue)
            {
                yield return currentItemScript.ScriptsInheritedOnSubpages;
            }

            //return the inherited scripts
            foreach (var item in Sitecore.Context.Item.Axes.GetAncestors())
            {
                var pageSpecificItem = item.As<IPageSpecificCustomScriptsItem>();
                if (pageSpecificItem != null && pageSpecificItem.ScriptsInheritedOnSubpages.HasTextValue)
                {
                    yield return pageSpecificItem.ScriptsInheritedOnSubpages;
                }
            }
        }

        public static IGlobalCustomScriptItem GetGlobalCustomScripts()
        {
            return null;
        }
    }
}