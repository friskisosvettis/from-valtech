using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Data.Settings;
using FOS.Website.Feature.ContentBlocks.Helpers;
using FOS.Website.Foundation.Settings;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    /// <summary>
    /// Model used for image/text video/text type modules
    /// </summary>
    public class FiftyFiftyMediaModel : ContentBlockModelBase
    {
        public MediaBlockModel LeftMediaBlock { get; set; } = null;
        public MediaBlockModel RightMediaBlock { get; set; } = null;

        public FiftyFiftyMediaModel()
        {
            var mediaBlock = RenderingHelper.GetRenderingContextOrDefault<I_MediaBlockItem>();
            if (mediaBlock != null)
            {
                LeftMediaBlock = new MediaBlockModel(mediaBlock.MediaType, mediaBlock.BlockImage, mediaBlock.BlockYoutubeId, mediaBlock.BlockYoutubeStartImage);
            }

            var mediaBlock2 = RenderingHelper.GetRenderingContextOrDefault<I_MediaBlockRightItem>();
            if (mediaBlock2 != null)
            {
                RightMediaBlock = new MediaBlockModel(mediaBlock2.RightMediaType, mediaBlock2.RightBlockImage, mediaBlock2.RightBlockYoutubeId, mediaBlock2.RightBlockYoutubeStartImage);
            }
        }
    }
}