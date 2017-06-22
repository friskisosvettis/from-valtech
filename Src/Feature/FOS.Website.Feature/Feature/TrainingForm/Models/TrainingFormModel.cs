using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Summary.Models;
using FOS.Website.Feature.TrainingForm;
//using Core.CustomItems.Components.Spot;
//using Core.CustomItems.Listtypes;
//using Core.Site;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.ExperienceContentManagement.Administration.Helpers.SupportPackage.Diagnostics.Base;
//using Web.Models.Spots;
using Synthesis;
using Valtech.Foundation.SitecoreExtensions;


namespace FOS.Website.Feature.TrainingForm.Models
{
    public class TrainingFormModel
    {

        public List<SummarySpotModel> TrainingFormList { get; set; }
        
        public int ResultCount { get { return TrainingFormList.Count(); } }
        
        public TrainingFormModel()
        {
            TrainingFormList = new List<SummarySpotModel>();
        }

        public TrainingFormModel(Item item) : this()
        {
            ITrainingFormItem trainingFormItem = item.As<ITrainingFormItem>();

            if (trainingFormItem != null && trainingFormItem.HideChildTrainingFormsFromList.Value == false)
            {
                List<Item> summaryItemList = new List<Item>();
                summaryItemList.AddRange(item.Children.Where(i => i.As<ITrainingFormItem>() != null && i.As<ITrainingFormItem>().HideThisTrainingFormFromList.Value != true));
                TrainingFormList = new List<SummarySpotModel>();

                // Add items to the list of SummarySpotModels to show
                TrainingFormList.AddRange(summaryItemList.Select(x => new SummarySpotModel(x)));
                int maxResults = 100;
                
                TrainingFormList = TrainingFormList.Take(maxResults).ToList();
            }
        }
    }
}