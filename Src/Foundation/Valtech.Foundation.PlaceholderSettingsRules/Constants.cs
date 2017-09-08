namespace Valtech.Foundation.PlaceholderSettingsRules
{
  using System;
  using Sitecore.Configuration;

  /// <summary>
    /// Constant values used throughout the code.
    /// </summary>
    public static class Constants
    {
        public static string RulesFieldId
        { 
            get
            {
                string id = Settings.GetSetting("Valtech.Foundation.PlaceholderSettingsRules.RulesFieldId", null);
                if (id == null) throw new Exception("Could not read the 'Valtech.Foundation.PlaceholderSettingsRules.RulesFieldId' setting from Sitecore config");
                else return id;
            }
        }

        public static string AllowOptionId
        {
            get
            {
                string id = Settings.GetSetting("Valtech.Foundation.PlaceholderSettingsRules.AllowOptionId", null);
                if (id == null) throw new Exception("Could not read the 'Valtech.Foundation.PlaceholderSettingsRules.AllowOptionId' setting from Sitecore config");
                else return id;
            }
        }

        public static string DoNotAllowOptionId
        {
            get
            {
                string id = Settings.GetSetting("Valtech.Foundation.PlaceholderSettingsRules.DoNotAllowOptionId", null);
                if (id == null) throw new Exception("Could not read the 'Valtech.Foundation.PlaceholderSettingsRules.DoNotAllowOptionId' setting from Sitecore config");
                else return id;
            }
        }
    }
}
