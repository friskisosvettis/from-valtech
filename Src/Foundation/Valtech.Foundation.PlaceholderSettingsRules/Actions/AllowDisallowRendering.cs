namespace Valtech.Foundation.PlaceholderSettingsRules.Actions
{
  using System.Collections.Generic;
  using System.Linq;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Rules.Actions;

  /// <summary>
    /// Custom Sitecore rules engine action that allows or disallows a specific rendering from being added to a placeholder.
    /// </summary>
    public class AllowDisallowRendering<T> : RuleAction<T> where T : PlaceholderSettingsRuleContext
    {
        private Option Option = Option.DoNotAllow;
        public string OptionId
        {
            get
            {
                switch (this.Option)
                {
                    case PlaceholderSettingsRules.Option.Allow: return Constants.AllowOptionId;
                    default:
                    case PlaceholderSettingsRules.Option.DoNotAllow: return Constants.DoNotAllowOptionId;
                }
            }
            set
            {
                if (new ID(value) == new ID(Constants.AllowOptionId))
                    this.Option = PlaceholderSettingsRules.Option.Allow;
                else
                    this.Option = PlaceholderSettingsRules.Option.DoNotAllow;
            }
        }

        public string RenderingId { get; set; }

        public override void Apply(T ruleContext)
        {
            // Convert the RenderingId string to a Sitecore ID.
            ID renderingId = new ID(this.RenderingId);

            // Create a new list if one hasn't been created yet.
            if (ruleContext.AllowedRenderingItems == null)
                ruleContext.AllowedRenderingItems = new List<Item>();

            // If the option is set to "allow"...
            if (this.Option == PlaceholderSettingsRules.Option.Allow)
            {
                // If the specified rendering is already allowed, do nothing.
                if (ruleContext.AllowedRenderingItems.Any(i => i.ID == renderingId)) return;

                // Otherwise, add the rendering to the context.
                ruleContext.AllowedRenderingItems.Add(ruleContext.Item.Database.GetItem(renderingId));
            }
            else
            {
                // If the specified rendering already isn't in the context, do nothing.
                Item item = ruleContext.AllowedRenderingItems.FirstOrDefault(i => i.ID == renderingId);
                if (item == null) return;

                // Otherwise, remove the rendering from the context.
                ruleContext.AllowedRenderingItems.Remove(item);
            }
        }
    }
}
