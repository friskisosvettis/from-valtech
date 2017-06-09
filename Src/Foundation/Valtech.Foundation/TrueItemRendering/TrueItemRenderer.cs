using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Mvc.Presentation;

namespace Valtech.Foundation.TrueItemRendering
{
    public class TrueItemRenderer : ItemRenderer
    {
        protected override List<Rendering> GetRenderings()
        {
            var renderings = new List<Rendering>();
            // renderings.AddRange(base.GetRenderings()); // Uncomment to add renderings from the Renderers field (default functionality)

            var refs = Item.Visualization.GetRenderings(Context.Device, false);
            if (!refs.Any())
                return null;

            var renderingReferences = refs.Where(r => !(Context.Database.GetItem(r.RenderingID).TemplateID.ToString() == "{86776923-ECA5-4310-8DC0-AE65FE88D078}" && string.IsNullOrWhiteSpace(r.Settings.DataSource))).ToList();

            if (!renderingReferences.Any())
                return null;

            renderings.AddRange(renderingReferences.Select(r => new Rendering
            {
                RenderingItemPath = r.RenderingID.ToString(),
                Parameters = new RenderingParameters(r.Settings.Parameters),
                DataSource = r.Settings.DataSource
            }));

            return renderings;
        }
    }
}