using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Data.Settings;
using FOS.Website.Feature.ContentBlocks.Helpers;
using FOS.Website.Foundation.Settings;
using Synthesis.FieldTypes.Interfaces;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class MediaBlockModel
    {
        public ITextField BlockMediaType { get; set; }
        public IImageField BlockImage { get; set; }
        public ITextField BlockYoutubeId { get; set; }
        public IImageField YoutubeStartImage { get; set; }

        public bool MediaIsImage => (!BlockMediaType.HasValue || BlockMediaType.RawValue.Equals("Image"));

        public bool MediaIsVideo => !MediaIsImage;

        public MediaBlockModel(ITextField mediaSelector, IImageField image, ITextField youtubeId,
            IImageField youtubeStartImage)
        {
            BlockMediaType = mediaSelector;
            BlockImage = image;
            BlockYoutubeId = youtubeId;
            YoutubeStartImage = youtubeStartImage;
        }
    }
}