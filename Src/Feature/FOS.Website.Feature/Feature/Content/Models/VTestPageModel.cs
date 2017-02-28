using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class VTestPageModel
    {
        public string TestPageString = String.Empty;

        public IVTestPageItem TestPageItem = null;


        public VTestPageModel(Item item)
        {
            TestPageItem = item.As<IVTestPageItem>();
            TestPageString = "TestPageString";
        }
    }
}