namespace Valtech.Foundation.PlaceholderSettingsRules.Conditions
{
  using System.Text.RegularExpressions;
  using DynamicPlaceholders;
  using Sitecore.Data;
  using Sitecore.Layouts;
  using Sitecore.Rules.Conditions;

  /// <summary>
  /// Custom Sitecore rules engine condition that counts the total number of renderings in a placeholder and evaluates an integer comparison.
  /// </summary>
  public class RenderingCountCondition<T> : IntegerComparisonCondition<T> where T : PlaceholderSettingsRuleContext
  {
    protected override bool Execute(T ruleContext)
    {
      // Parse the layout definition.
      LayoutDefinition layoutDef = LayoutDefinition.Parse(ruleContext.LayoutDefinition);
      if (layoutDef == null) return false;

      // Find the device definition for the current device.
      DeviceDefinition deviceDef = null;
      foreach (DeviceDefinition dd in layoutDef.Devices)
      {
        if (new ID(dd.ID) == ruleContext.DeviceId)
        {
          deviceDef = dd;
          break;
        }
      }
      if (deviceDef == null) return false;




      // Loop through the rendering definitions for the device and count the number of renderings in the placeholder.
      int renderingCount = 0;
      foreach (RenderingDefinition rendering in deviceDef.Renderings)
      {

        if (rendering.Placeholder == ruleContext.PlaceholderKey)
          renderingCount++;
      }

      // Evaluate the condition.
      return base.Compare(renderingCount);
    }
  }
}
