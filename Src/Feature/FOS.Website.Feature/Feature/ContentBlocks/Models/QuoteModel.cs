using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Helpers;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class QuoteModel : ContentBlockModelBase
    {
        public I_QuoteItem QuoteItem { get; set; }
    }
}