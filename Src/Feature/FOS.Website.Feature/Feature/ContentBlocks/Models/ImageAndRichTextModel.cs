using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Blocks;
using FOS.Website.Feature.ContentBlocks.Helpers;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class ImageAndRichTextModel : ContentBlockModelBase
    {
        public IRichTextItem RichTextItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<IRichTextItem>();
        public IImageItem ImageItem { get; set; } = RenderingContext.Current.Rendering.Item.As<IImageItem>();

        public bool InvertPositions => ImageAndTextItem.InvertPositions.Value;

        public IImageAndTextItem ImageAndTextItem { get; set; } = RenderingContext.Current.Rendering.Item.As<IImageAndTextItem>();
    }
}