using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Pipelines.Response.GetRenderer;
using Sitecore.Mvc.Presentation;

namespace Valtech.Foundation.TrueItemRendering
{
    public class GetTrueItemRenderer : GetItemRenderer //GetItemRenderer
    {
        public override void Process(GetRendererArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (args.Result != null)
                return;
            args.Result = GetRenderer(args.Rendering, args);
        }

        protected override Renderer GetRenderer(Rendering rendering, GetRendererArgs args)
        {
            var itemToRender = GetItemToRender(rendering, args);
            if (itemToRender == null)
                return null;
            return new TrueItemRenderer
            {
                Item = itemToRender
            };
        }
    }
}