using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Buckets.Extensions;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Synthesis;
using Valtech.Foundation.Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class ProximityModel
    {
        public IProximityItem ProximityItem { get; set; }
        public IEnumerable<Item> AssociationsItems { get; set; }

        public ProximityModel()
        {
            var contextItem = RenderingContext.Current.Rendering.Item.As<IProximityItem>();
            ProximityItem = (contextItem == null)
                ? Sitecore.Context.Item.As<IProximityItem>()
                : contextItem;
        }
    }
}