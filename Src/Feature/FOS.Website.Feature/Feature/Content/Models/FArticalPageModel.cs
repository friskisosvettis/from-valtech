using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class FArticalPageModel
    {
        public bool bFullPage { set; get; }
        public string sFormText { set; get; }

        public I_FTestBasicItem BasicItem = null;
        public I_FTestBlobItem BasicBlob = null;

        public FArticalPageModel(Item Article, bool bPuff)
        {
            this.BasicItem = Article.As<I_FTestBasicItem>();
            this.BasicBlob = bPuff ? null : Article.As<I_FTestBlobItem>();
            this.bFullPage = bPuff;
            this.sFormText = "";
        }
    }
}