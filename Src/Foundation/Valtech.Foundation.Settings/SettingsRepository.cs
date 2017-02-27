using FOS.Website.Foundation.Settings;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Synthesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valtech.Foundation.Settings
{
    public class SettingsRepository
    {
        
        public T GetSetting<T>(Item contextItem) where T : class, IStandardTemplateItem
        {
            if (contextItem == null)
                return null;

            T setting = SettingsCache.GetSettingsInstance<T>(contextItem);
            if (setting != null)
                return setting;

            setting = DoGetSetting<T>(contextItem);
            if (setting != null)
            {
                SettingsCache.AddSettingInstance<T>(setting, contextItem);
            }
            return setting;
        }

        private T DoGetSetting<T>(Item contextItem) where T : class, IStandardTemplateItem
        {
            Item settingsRoot = GetSettingsRoot(contextItem);
            if (settingsRoot == null)
                return default(T);

            T settingsItem = settingsRoot.Children.FirstOrDefault(i => i.As<T>() != null).As<T>();
            return settingsItem;

        }

        private Item GetSettingsRoot(Item contextItem)
        {
            if (contextItem == null)
                return null;

            Item settingsRoot = SettingsCache.GetSettingRoot(contextItem);
            if (settingsRoot != null)
                return settingsRoot;

            ISettingsSelectorItem settingsSelector = null;

            if (DefinesSettings(contextItem))
            {
                settingsSelector = contextItem.As<ISettingsSelectorItem>();
            }
            else
            {
                settingsSelector = contextItem.Axes.GetAncestors().FirstOrDefault(i => DefinesSettings(i)).As<ISettingsSelectorItem>();
            }

            if(settingsSelector != null)
            {
                settingsRoot = settingsSelector.Settings_SettingsRoot.Target.InnerItem;
                SettingsCache.AddSettingsRoot(contextItem, settingsRoot);
            }
            return settingsRoot;
        }

        private static bool DefinesSettings(Item contextItem)
        {
            ISettingsSelectorItem settingsSelector = contextItem.As<ISettingsSelectorItem>();
            return (settingsSelector != null && settingsSelector.Settings_SettingsRoot.Target != null);
        }
    }
}