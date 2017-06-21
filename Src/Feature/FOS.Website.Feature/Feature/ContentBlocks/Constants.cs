using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOS.Website.Feature.ContentBlocks
{
    public class Constants
    {
        public struct Views
        {
            public struct Paths
            {
                public const string RichText = "/Feature/ContentBlocks/Views/RichText.cshtml";
                public const string ImageAndText = "/Feature/ContentBlocks/Views/ImageAndText.cshtml";
                public const string VideoAndText = "/Feature/ContentBlocks/Views/VideoAndText.cshtml";
                public const string LinkBlock = "/Feature/ContentBlocks/Views/LinkBlock.cshtml";
                public const string Video = "/Feature/ContentBlocks/Views/Video.cshtml"; 
                public const string WideImageSeparator = "/Feature/ContentBlocks/Views/WideImageSeparator.cshtml";
            }
        }
    }
}