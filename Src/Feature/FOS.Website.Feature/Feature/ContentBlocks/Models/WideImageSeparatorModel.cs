using FOS.Website.Feature.ContentBlocks.Data;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class WideImageSeparatorModel : ContentBlockModelBase
    {
        public ISimpleTextBoxItem SimpleTextBox { get; set; }
        public IImageItem ImageItem { get; set; }
    }
}