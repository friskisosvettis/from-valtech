using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.ComponentBlock
{
    public static class OriginalItemHelper
    {
        public static Item GetOriginalItem<TTemplate>(this Item item) where TTemplate : class, IStandardTemplateItem
        {
            var retItem = item;
            IOriginalItemItem originalItemItem = item.As<IOriginalItemItem>();
            if (originalItemItem != null && originalItemItem.OriginalItemLink.HasValue)
            {
                if (originalItemItem.OriginalItemLink.TargetId != item.ID)
                {
                    Item originalItemTarget = Sitecore.Context.Database.GetItem(originalItemItem.OriginalItemLink.TargetId);
                    originalItemItem = originalItemTarget.As<IOriginalItemItem>();
                }

                if (originalItemItem != null && originalItemItem.Id == originalItemItem.OriginalItemLink.TargetId)
                {
                    var correctItem = originalItemItem.InnerItem.As<TTemplate>();
                    if (correctItem != null)
                    {
                        retItem = correctItem.InnerItem;
                    }
                }
            }

            return retItem;
        }
    }
}