using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class FTestPageModel
    {
        public string TestPageString = String.Empty;

        public IFTestPageItem TestPageItem = null;


        public FTestPageModel(Item item)
        {
            TestPageItem = item.As<IFTestPageItem>();
            TestPageString = "TestPageString";
        }
    }
}