using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.ContentBlocks.Helpers
{
    public static class RenderingHelper
    {
        public static T GetRenderingContextOrDefault<T>() where T : class, IStandardTemplateItem
        {
            var renderingContext = RenderingContext.Current.Rendering.Item.As<T>();
            return renderingContext ?? Sitecore.Context.Item.As<T>();
        }
    }
}