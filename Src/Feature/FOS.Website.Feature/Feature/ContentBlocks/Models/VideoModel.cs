using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Helpers;
using Sitecore.Analytics.Commons;
using Synthesis.FieldTypes.Interfaces;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class VideoModel : ContentBlockModelBase
    {
        public bool IsFullSize { get; set; } = true;
        public I_VideoItem VideoItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<I_VideoItem>();

        public ITextField VideoIdField { get; set; }

        public IImageField ImageThumbnailField { get; set; }

        public VideoModel()
        {
            VideoIdField = VideoItem.YoutubeID;
            ImageThumbnailField = VideoItem.StartImage;
        }

        public VideoModel(ITextField videoIdField, IImageField imageField)
        {
            VideoIdField = videoIdField;
            ImageThumbnailField = imageField;
        }
    }
}