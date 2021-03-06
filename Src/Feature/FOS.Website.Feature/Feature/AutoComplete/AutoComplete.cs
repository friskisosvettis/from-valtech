﻿using System;
using System.Collections.Generic;
using System.Linq;
using FOS.Website.Feature.AutoComplete.AutoCompleteModel;
using FOS.Website.Feature.Content.Data;
using FOS.Website.Feature.Content.ListWidgets;
using FOS.Website.Feature.SearchUtilityFunctions;
using Newtonsoft.Json;
using Sitecore.Data.Items;
using Sitecore.Links;
using Synthesis;
using Valtech.Foundation.Synthesis;


namespace FOS.Website.Feature.AutoComplete
{
    public class AutoComplete
    {
        public string StartsWith(string searchQuery, Item homePage)
        {
            var autoCompleteList = new List<AutoCompleteSearchModel>();
            autoCompleteList.AddRange(GetAssocitionsStartingWith(searchQuery, homePage));
            autoCompleteList.AddRange(GetRegionsStartingWith(searchQuery, homePage));
            autoCompleteList.AddRange(GetTrainingCenterStartingWith(searchQuery, homePage));
            return "{ \"suggestions\":" + JsonConvert.SerializeObject(autoCompleteList) + "}";
        }

        private IEnumerable<AutoCompleteSearchModel> GetAssocitionsStartingWith(string searchQuery, Item homePage)
        {
            var associationModels = new List<AssociationModel>();
            var associations = AssociationSearch.GetAllAssociationsStartingWith(searchQuery, homePage);
            foreach (var assocition in associations)
            {
                var associationFlagTemplateItem = assocition.InnerItem.As<IAssociationFlagTemplateItem>();
                var url = LinkManager.GetItemUrl(assocition.InnerItem);
                var showAllCentersCustomUrl = associationFlagTemplateItem.ShowAllCentersCustomUrl.HasValue
                    ? associationFlagTemplateItem.ShowAllCentersCustomUrl.Href
                    : LinkManager.GetItemUrl(assocition.InnerItem);
                var associotionModel = new AssociationModel(associationFlagTemplateItem.DisplayName, url, showAllCentersCustomUrl);

                var trainingCenterList = TrainingCenterSearch.GetAllTrainingCenterOnAssociation(assocition.InnerItem).AsSitecoreOrdered();
                foreach (var trainingCenter in trainingCenterList)
                {
                    var trainingCenterItem = trainingCenter.InnerItem;
                    var mapNode = trainingCenterItem.As<IMapNodeItem>();
                    var address = (mapNode != null)
                        ? $"{mapNode.Street.RawValue}{(mapNode.StreetNr.HasTextValue ? " " + mapNode.StreetNr.RawValue : "")}"
                        : "";
                    var tcUrl = LinkManager.GetItemUrl(trainingCenterItem);
                    var tcCity = mapNode?.City.RawValue;

                    associotionModel.AddCenter(new AssociationTrainingCenterModel(trainingCenter.DisplayName
                        , tcUrl, address, tcCity));
                }

                associationModels.Add(associotionModel);
            }

            return associationModels.Select(a => new AutoCompleteSearchModel(a));
        }

        private IEnumerable<AutoCompleteSearchModel> GetRegionsStartingWith(string searchQuery, Item homePage)
        {
            var regions = new List<RegionModel>();
            var regionTest = RegionSearch.GetAllRegionsStartingWith(searchQuery, homePage);
            foreach (var regionObj in regionTest)
            {
                var associations = AssociationSearch.GetAllAssociationsWithRegionName(regionObj.Name, homePage).AsSitecoreOrdered();
                foreach (var assocition in associations)
                {
                    var associationItem = assocition.InnerItem;
                    AddRegionsToAutocomplete(regions, associationItem, regionObj.DisplayName);
                }
            }
            return regions.Select(r => new AutoCompleteSearchModel(r));
        }

        private IEnumerable<AutoCompleteSearchModel> GetTrainingCenterStartingWith(string searchQuery, Item homePage)
        {
            var trainingCenters = new List<TrainingCenterModel>();
            var foundTrainingCenters = TrainingCenterSearch.GetAllTrainingCenterStartingWith(searchQuery, homePage).AsSitecoreOrdered();
            foreach (var trainingCenter in foundTrainingCenters)
            {
                var trainingCenterItem = trainingCenter.InnerItem;
                var mapNode = trainingCenterItem.As<IMapNodeItem>();
                var address = (mapNode != null)
                    ? String.Format("{0}{1}", mapNode.Street.RawValue,
                        (mapNode.StreetNr.HasTextValue ? " " + mapNode.StreetNr.RawValue : ""))
                    : "";
                var tcUrl = LinkManager.GetItemUrl(trainingCenterItem);
                var tcCity = mapNode?.City.RawValue;
                var association = trainingCenterItem.ClosestAscendantItemOfType<IAssociationFlagTemplateItem>();


                trainingCenters.Add(new TrainingCenterModel(trainingCenter.DisplayName
                    , (association == null) ? "Tror fel Template" : association.DisplayName, tcUrl, address, mapNode?.ZipCode.RawValue, tcCity));
            }
            return trainingCenters.Select(t => new AutoCompleteSearchModel(t));
        }

        private void AddRegionsToAutocomplete(List<RegionModel> regions, Item assocition, string regionName)
        {
            var region = assocition.As<IRegionsItem>();
            if (region != null && region.Region != null && region.Region.HasTextValue)
            {
                var regionAssocition = new RegionAssociationModel(assocition.DisplayName,
                    LinkManager.GetItemUrl(assocition));
                var newRegion = regions.Where(r => r.Name.Equals(regionName)).FirstOrDefault();
                if (newRegion != null)
                {
                    newRegion.Associations.Add(regionAssocition);
                }
                else
                {
                    newRegion = new RegionModel(regionName);
                    newRegion.Associations.Add(regionAssocition);
                    regions.Add(newRegion);
                }
            }
        }
    }
}