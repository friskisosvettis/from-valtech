using FOS.Website.Feature.ContentBlocks.Data;
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
        public I_RichTextItem RichTextItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<I_RichTextItem>();

        public I_ImageItem ImageItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<I_ImageItem>();

        public I_VideoItem VideoItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<I_VideoItem>();

        public I_InvertContentItem ImageAndTextItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<I_InvertContentItem>();

        public I_StyleItem ContentBlockStyleSetting { get; set; } = RenderingHelper.GetRenderingContextOrDefault<I_StyleItem>();

        public bool InvertPositions => ImageAndTextItem.InvertPositions.Value;

        public string Style
        {
            get
            {
                var styleSettingReferenceItem = ContentBlockStyleSetting?.Style?.Target as ITextSettingItem;

                return styleSettingReferenceItem != null ? styleSettingReferenceItem.Value.RawValue : string.Empty;
            }
        }
    }
}