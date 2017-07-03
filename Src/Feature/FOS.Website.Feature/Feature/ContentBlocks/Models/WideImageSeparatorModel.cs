using FOS.Website.Feature.ContentBlocks.Data;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class WideImageSeparatorModel : ContentBlockModelBase
    {
        public I_SimpleTextBoxItem SimpleTextBox { get; set; }
        public I_ImageItem ImageItem { get; set; }
    }
}