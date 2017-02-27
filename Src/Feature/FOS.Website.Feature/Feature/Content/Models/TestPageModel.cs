using FOS.Website.Feature.Content.Data;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Concrete.Feature.Content.Data;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class TestPageModel
    {
        public string TestPageString = String.Empty;

        public ITestPageItem TestPageItem = null;


        public TestPageModel(Item item)
        {
            TestPageItem = item.As<ITestPageItem>();
            TestPageString = "TestPageString";
        }

    }
}