using System.Collections.Generic;
using System.Linq;
//using Core.CustomItems.Components.Event;
//using Core.CustomItems.Components.Filter;
//using Core.CustomItems.Pagetypes;
//using Core.Site;
using Sitecore.Data.Items;
using System;
using FOS.Website.Feature.Event;
using FOS.Website.Feature.News;
using FOS.Website.Feature.Summary.Controllers;
using FOS.Website.Feature.TrainingForm;
using Synthesis;

//using Web.Models.Base;
//using Core.CustomItems.Components.News;

namespace FOS.Website.Feature.Summary.Models
{
    public class SummarySpotModel
    {
        public ISummaryItem SummaryItem { get; set; }

        public string SummaryHeadingString { get; set; }

        public DateTime NewsPublishDate { get; set; }

        public DateTime EventStartDate { get; set; }

        public DateTime EventEndDate { get; set; }

        public INewsItem NewsItem { get; set; }

        public IEventItem EventItem { get; set; }

        public ITrainingFormItem TrainingFormItem { get; set; }

        public Item Item { get; set; }
        
        public bool HideNewsDate { get; set; }

        public SummarySpotModel()
        {
            SummaryItem = null;
            SummaryHeadingString = String.Empty;
            NewsPublishDate = DateTime.MinValue;
            EventStartDate = DateTime.MaxValue;
            EventEndDate = DateTime.MinValue;
            Item = null;
            HideNewsDate = false;
        }

        public SummarySpotModel(Item item) : this()
        {
            SummaryItem = item.As<ISummaryItem>();
            if (SummaryItem != null && string.IsNullOrEmpty(SummaryHeadingString))
            {
                SummaryHeadingString = SummaryItem.SummaryHeading.RawValue;
            }

            NewsItem = item.As<INewsItem>();

            if (NewsItem != null)
            {
                NewsPublishDate = NewsItem.NewsDate.Value;
            }

            EventItem = item.As<IEventItem>();
            if (EventItem != null)
            {
                EventStartDate = EventItem.EventStartDate.Value;
                EventEndDate = EventItem.EventEndDate.HasValue ? EventItem.EventEndDate.Value : DateTime.MinValue;
            }

            TrainingFormItem = item.As<ITrainingFormItem>();
        }

        // Used for generic items
        public SummarySpotModel(Item item, string invalidModelText = "") : this()
        {

            SummaryHeadingString = SummaryItem.SummaryHeading.RawValue;

            if (String.IsNullOrWhiteSpace(SummaryHeadingString))
            {
                SummaryHeadingString = SummaryItem.Name;
            }
            

            if (item != null)
            {
                Item = item;
                INewsItem newsItem = item.As<INewsItem>();
                if (newsItem != null)
                {
                    NewsPublishDate = newsItem.NewsDate.Value;
                    HideNewsDate = newsItem.DisableDate.Value;
                }
            }
           
        }
    }
}