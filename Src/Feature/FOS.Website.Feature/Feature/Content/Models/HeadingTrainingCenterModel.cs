using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class HeadingTrainingCenterModel
    {
        public IHeadingTrainingCenterItem HeadingTrainingCenterItem = null;
        public string TrainingCenterName { get; set; }
        public string TrainingCenterAddress { get; set; }


        public HeadingTrainingCenterModel(Item trainingCenterItem)
        {
            var gymItem = trainingCenterItem.As<IMapWidgetGymsItem>();
            TrainingCenterName = (gymItem!=null)?gymItem.Name:trainingCenterItem.DisplayName;

            HeadingTrainingCenterItem = trainingCenterItem.As<IHeadingTrainingCenterItem>();

            var mapNode = trainingCenterItem.As<IMapNodeItem>();
            TrainingCenterAddress = (mapNode != null) ? String.Format("{0}{1}, {2}", mapNode.Street.RawValue,
                (mapNode.StreetNr.HasTextValue ? " " + mapNode.StreetNr.RawValue : ""), mapNode.City):"";
        }
    }
}