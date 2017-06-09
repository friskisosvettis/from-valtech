using System.Collections.Generic;
using System.Linq;
//using Core.CustomItems.Components.Event;
//using Core.CustomItems.Components.Filter;
//using Core.CustomItems.Pagetypes;
//using Core.Site;
using Sitecore.Data.Items;
using System;
using FOS.Website.Concrete.Feature.ComponentBlock;
using FOS.Website.Feature.News;
using FOS.Website.Feature.Summary.Controllers;
using Synthesis;

//using Web.Models.Base;
//using Core.CustomItems.Components.News;

namespace FOS.Website.Feature.ComponentBlock.Models
{
    public class ComponentBlockModel
    {
        public Item Item { get; set; }

        public ComponentBlockModel()
        {
            Item = null;
        }

        public ComponentBlockModel(Item item) : this()
        {
            // If the item inherits from OriginalItem template check if it has reference to the original item and if it has use that item instead.
            IOriginalItemItem originalItemItem = item.As<IOriginalItemItem>();
            if (originalItemItem != null && originalItemItem.OriginalItemLink.HasValue)
            {
                if (originalItemItem.OriginalItemLink.TargetId != item.ID)
                {
                    Item originalItemTarget = Sitecore.Context.Database.GetItem(originalItemItem.OriginalItemLink.TargetId);
                    originalItemItem = originalItemTarget.As<IOriginalItemItem>();
                }
            }

            if (originalItemItem != null && originalItemItem.Id == originalItemItem.OriginalItemLink.TargetId)
            {
                IComponentBlockItem componentBlockItem = originalItemItem.InnerItem.As<IComponentBlockItem>();
                IComponentBlockContentItem componentBlockContentItem = componentBlockItem?.ComponentBlockItem?.Target?.InnerItem?.As<IComponentBlockContentItem>();
                if (componentBlockContentItem != null)
                {
                    Item = componentBlockContentItem.InnerItem;
                }
            }

            //Item = item; 
        }
    }
}