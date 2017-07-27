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
using Valtech.Foundation.Dictionary;

namespace FOS.Website.Feature.Content.Models
{
    public class TrainingCenterCollectionMapModel
    {
        public IMapWidgetGymsItem MapWidgetItem { get; set; }
        public IEnumerable<IMapNodeItem> MapNodes { get; set; }

        public IHtmlString label_ShowOnMap { get; } = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/TrainingCenterCollectionMap", "ShowOnMap", "Show on map"));
        public IHtmlString label_List { get; } = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/TrainingCenterCollectionMap", "tabList", "List"));
        public IHtmlString label_Map { get; } = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/TrainingCenterCollectionMap", "tabMap", "Map"));

        public TrainingCenterCollectionMapModel()
        {
            var contextItem = RenderingContext.Current.Rendering.Item.As<IMapWidgetGymsItem>();
            MapWidgetItem = (contextItem == null)
                ? Sitecore.Context.Item.As<IMapWidgetGymsItem>()
                : contextItem;
        }
    }
}