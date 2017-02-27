using FOS.Website.Feature.Content.Data;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOS.Website.Feature.Content.Models
{
    public class QuoteModel
    {
        public IQuoteItem QuoteItem { get; set; }
        private IContentAlignmentItem AlignmentItem { get; set; }
        private IContentSizeItem SizeItem { get; set; }
        public bool IsContained { get; set; }

        public QuoteModel(IQuoteItem quoteItem, IContentSizeItem sizeItem, IContentAlignmentItem contentAlignmentItem, bool isContained=false)
        {
            SizeItem = sizeItem;
            AlignmentItem = contentAlignmentItem;
            IsContained = isContained;
            QuoteItem = quoteItem;
        }

        public QuoteModel(IQuoteItem quoteItem, bool isContained=false)
        {
            IsContained = isContained;
            QuoteItem = quoteItem;
        }

        public string SizeClass => SizeItem == null ? String.Empty : SizeItem.Content_CssClass.RawValue;

        public string AlignmentClass => AlignmentItem == null ? String.Empty : AlignmentItem.Content_CssClass.RawValue;
    }
}