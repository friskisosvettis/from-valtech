using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Helpers;
using Sitecore.Analytics.Commons;
using Synthesis.FieldTypes.Interfaces;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class ImageModel : ContentBlockModelBase
    {
        public I_ImageItem ImageItem { get; set; }
    }
}