using Sitecore;

namespace Valtech.Foundation.PlaceholderSettingsRules.Pipelines.GetPlaceholderRenderings
{
  using System.Collections.Generic;
  using System.Text.RegularExpressions;
  using DynamicPlaceholders;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Diagnostics;
  using Sitecore.Pipelines.GetPlaceholderRenderings;
  using Sitecore.Rules;

  public class ExecuteRulesProccessor
  {
    public void Process(GetPlaceholderRenderingsArgs args)
    {
     args.PlaceholderRenderings = this.EnvokeRules(args);
    }


    protected List<Sitecore.Data.Items.Item> EnvokeRules(GetPlaceholderRenderingsArgs args)
    {

      string placeholderKey = string.Empty;
      Match match = new Regex(PlaceholderKeyRegex.DynamicKeyRegex).Match(args.PlaceholderKey);
      if (match.Success && (match.Groups.Count > 0))
      {
        placeholderKey = match.Groups[1].Value;
      }
      else
      {
        placeholderKey = args.PlaceholderKey;
      }

      // Get the initial list of renderings from the base implementation.
      Item placeholderItem;
      if (ID.IsNullOrEmpty(args.DeviceId))
      {
        placeholderItem = Client.Page.GetPlaceholderItem(placeholderKey, args.ContentDatabase, args.LayoutDefinition);
      }
      else
      {
        using (new DeviceSwitcher(args.DeviceId, args.ContentDatabase))
        {
          placeholderItem = Client.Page.GetPlaceholderItem(placeholderKey, args.ContentDatabase, args.LayoutDefinition);
        }
      }

      // Get the rules from the placeholder item.
      string rulesXml = placeholderItem?[Constants.RulesFieldId];
      if (string.IsNullOrWhiteSpace(rulesXml)) return args.PlaceholderRenderings;

      // Parse the rules.
      var parsedRules = RuleFactory.ParseRules<PlaceholderSettingsRuleContext>(placeholderItem.Database, rulesXml);

      // Construct the context.
      PlaceholderSettingsRuleContext context = new PlaceholderSettingsRuleContext();
      context.Item = placeholderItem;
      context.AllowedRenderingItems = args.PlaceholderRenderings;
      context.DeviceId = args.DeviceId;
      context.PlaceholderKey = args.PlaceholderKey;
      context.ContentDatabase = args.ContentDatabase;
      context.LayoutDefinition = args.LayoutDefinition;


      // Execute the rules.
      RuleList<PlaceholderSettingsRuleContext> rules = new RuleList<PlaceholderSettingsRuleContext>();
      rules.Name = placeholderItem.Paths.Path;
      rules.AddRange(parsedRules.Rules);
      rules.Run(context);


      // Return the list.
      return context.AllowedRenderingItems;
    }
  }
}
