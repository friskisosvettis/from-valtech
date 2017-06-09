using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using Sitecore.Data.Items;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Helpers;
using Sitecore.Mvc.Pipelines;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using Sitecore.Mvc.Presentation;
using Sitecore;
using Valtech.Foundation.TrueItemRendering;


namespace Valtech.Foundation.SitecoreExtensions
{
    public static class SitecoreHelperExtension
    {

        /// <summary>
        /// Customs the item rendering.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="item">The item.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static HtmlString TrueItemRendering(this SitecoreHelper helper, Item item, object parameters)
        {
            var rendering = GetRendering("Item", parameters, "DataSource", item.ID.ToString());
            rendering.Renderer = new TrueItemRenderer
            {
                Item = item
            };

            var stringWriter = new StringWriter();
            PipelineService.Get().RunPipeline("mvc.renderRendering", new RenderRenderingArgs(rendering, stringWriter));
            return new HtmlString(stringWriter.ToString());
        }

        /// <summary>
        /// Gets the rendering.
        /// </summary>
        /// <param name="renderingType">Type of the rendering.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="defaultValues">The default values.</param>
        /// <returns></returns>
        private static Rendering GetRendering(string renderingType, object parameters, params string[] defaultValues)
        {
            var rendering = new Rendering { RenderingType = renderingType };
            int index = 0;
            while (index < defaultValues.Length - 1)
            {
                rendering[defaultValues[index]] = defaultValues[index + 1];
                index += 2;
            }
            if (parameters != null)
                TypeHelper.GetProperties(parameters).Each(pair => rendering.Properties[pair.Key] = pair.Value.ValueOrDefault(o => o.ToString()));
            return rendering;
        }
    }
}
