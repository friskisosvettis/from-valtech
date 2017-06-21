using FOS.Website.Feature.ContentBlocks.Blocks;
using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Helpers;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class ImageAndVideoModel : ContentBlockModelBase
    {
        public bool IsFullSize { get; set; } = false;
        public IImageAndVideoItem ImageAndVideoItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<IImageAndVideoItem>();
    }
}