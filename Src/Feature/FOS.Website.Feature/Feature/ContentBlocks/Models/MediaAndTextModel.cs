using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Blocks;
using FOS.Website.Feature.ContentBlocks.Data.Settings;
using FOS.Website.Feature.ContentBlocks.Helpers;
using FOS.Website.Foundation.Settings;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    /// <summary>
    /// Model used for image/text video/text type modules
    /// </summary>
    public class MediaAndTextModel : ContentBlockModelBase
    {
        public IRichTextItem RichTextItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<IRichTextItem>();

        public IImageItem ImageItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<IImageItem>();

        public IVideoItem VideoItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<IVideoItem>();

        public IInvertContentItem ImageAndTextItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<IInvertContentItem>();

        public IStyleItem ContentBlockStyleSetting { get; set; } = RenderingHelper.GetRenderingContextOrDefault<IStyleItem>();

        public bool InvertPositions => ImageAndTextItem.InvertPositions.Value;

        public string Style
        {
            get
            {
                var styleSettingReferenceItem = ContentBlockStyleSetting?.Style1?.Target as ITextSettingItem;

                return styleSettingReferenceItem != null ? styleSettingReferenceItem.Value.RawValue : string.Empty;
            }
        }
    }
}