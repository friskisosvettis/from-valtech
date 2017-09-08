using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using FOS.Website.Feature.Event;
using FOS.Website.Feature.News;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class BasicHeadingModel
    {
        public IBasicHeadingItem BasicHeadingItem { get; set; }
        public IEventItem EventItem { get; set; }
        public INewsItem NewsItem { get; set; }

        public BasicHeadingModel()
        {
            BasicHeadingItem = null;
            EventItem = null;
            NewsItem = null;
        }

        public BasicHeadingModel(Item item) : this()
        {
            if (item != null)
            {
                BasicHeadingItem = item.As<IBasicHeadingItem>();
                EventItem = item.As<IEventItem>();
                NewsItem = item.As<INewsItem>();
            }
            
        }
    }
}