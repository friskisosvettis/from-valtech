using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Buckets.Extensions;
using Sitecore.ContentSearch.Linq.Extensions;
using Sitecore.Data.Items;
using Synthesis;

namespace Valtech.Foundation.Synthesis
{
    public static class StructureAssosiatedItemConverter
    {
        public static TTemplate ClosestAscendantItemOfType<TTemplate>(this Item item) where TTemplate : class, IStandardTemplateItem
        {
            var tempItem = item;
            var ascendentItemOfType = tempItem.As<TTemplate>();
            while (ascendentItemOfType == null)
            {
                tempItem = tempItem.GetParentBucketItemOrParent();
                if (tempItem == null)
                {
                    // No Ascendent page has template of correct type
                    return null;
                }

                ascendentItemOfType = tempItem.As<TTemplate>();
            }

            return ascendentItemOfType;
        }
    }
}