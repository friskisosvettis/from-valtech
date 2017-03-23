using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Buckets.Extensions;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class FTestPageModel
    {
        public string TestPageString = String.Empty;

        public IFTestPageItem TestPageItem = null;

        public IEnumerable<Item> TestLinks;


        public FTestPageModel(Item item)
        {
            TestPageItem = item.As<IFTestPageItem>();
            TestPageString = "TestPageString";

            var linkList = new List<Item>();
            var parent = item.GetParentBucketItemOrParent();
            foreach (Item page in parent.GetChildren())
            {
                linkList.Add(page);
            }

            TestLinks = linkList;
        }
    }
}