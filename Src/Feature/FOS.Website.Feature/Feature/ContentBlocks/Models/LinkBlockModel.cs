using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Helpers;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class LinkBlockModel : ContentBlockModelBase
    {
        public I_LinkItem LinkBlock { get; set; }
        public I_ImageItem ImageItem { get; set; }
    }
}