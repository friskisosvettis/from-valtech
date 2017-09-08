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
        public MediaBlockModel MediaBlock { get; set; } = null;
        public I_RichTextItem RichTextItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<I_RichTextItem>();
        public I_InvertContentItem ImageAndTextItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<I_InvertContentItem>();

        public I_StyleItem StyleSetting { get; set; } = RenderingHelper.GetRenderingContextOrDefault<I_StyleItem>();

        public bool InvertPositions => ImageAndTextItem.InvertPositions.Value;

        public string Style
        {
            get
            {
                var styleSettingReferenceItem = StyleSetting?.Style?.Target as ITextSettingItem;

                return styleSettingReferenceItem != null ? styleSettingReferenceItem.Value.RawValue : string.Empty;
            }
        }

        public MediaAndTextModel()
        {
            var mediaBlock = RenderingHelper.GetRenderingContextOrDefault<I_MediaBlockItem>();
            if (mediaBlock != null)
            {
                MediaBlock = new MediaBlockModel(mediaBlock.MediaType, mediaBlock.BlockImage, mediaBlock.BlockYoutubeId, mediaBlock.BlockYoutubeStartImage);
            }
        }
    }
}