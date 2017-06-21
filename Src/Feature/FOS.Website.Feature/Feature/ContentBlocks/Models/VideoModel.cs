using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Helpers;
using Synthesis.FieldTypes.Interfaces;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class VideoModel : ContentBlockModelBase
    {
        public bool IsFullSize { get; set; } = true;
        public IVideoItem VideoItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<IVideoItem>();

        public ITextField VideoIdField { get; set; }

        public VideoModel()
        {
            VideoIdField = VideoItem.YoutubeID;
        }

        public VideoModel(ITextField videoIdField)
        {
            VideoIdField = videoIdField;
        }
    }
}