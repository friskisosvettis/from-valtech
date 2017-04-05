using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Buckets.Extensions;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class TrainingCenterCollectionMapModel
    {
        public IMapWidgetGymsItem MapWidgetItem { get; set; }
        public IEnumerable<IMapNodeItem> MapNodes { get; set; }

        public TrainingCenterCollectionMapModel()
        {
            var contextItem = RenderingContext.Current.Rendering.Item.As<IMapWidgetGymsItem>();
            MapWidgetItem = (contextItem == null)
                ? Sitecore.Context.Item.As<IMapWidgetGymsItem>()
                : contextItem;
        }
    }
}