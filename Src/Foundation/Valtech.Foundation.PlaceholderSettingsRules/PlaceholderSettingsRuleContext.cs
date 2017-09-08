namespace Valtech.Foundation.PlaceholderSettingsRules
{
  using System.Collections.Generic;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Rules;

  /// <summary>
    /// Custom rule context used by the placeholder settings conditions and actions.
    /// </summary>
    public class PlaceholderSettingsRuleContext : RuleContext
    {
        public List<Item> AllowedRenderingItems { get; set; }
        public ID DeviceId { get; set; }
        public string PlaceholderKey { get; set; }
        public Database ContentDatabase { get; set; }
        public string LayoutDefinition { get; set; }
        public bool? DisplaySelectionTree { get; set; }
    }
}
