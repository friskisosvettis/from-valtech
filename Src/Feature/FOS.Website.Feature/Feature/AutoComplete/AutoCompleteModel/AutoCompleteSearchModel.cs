﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FOS.Website.Feature.AutoComplete.AutoCompleteModel
{
    class AutoCompleteSearchModel
    {
        public string value { get; set; }
        public dynamic data { get; set; }

        public AutoCompleteSearchModel(AssociationModel associationModel)
        {
            value = associationModel.Name;
            data = new {
                sortBy = associationModel.Name + "__a",
                category = "Association",
                url = associationModel.Url,
                showAll = associationModel.ShowAll,
                centers = associationModel.Centers };
        }

        public AutoCompleteSearchModel(RegionModel regionModel)
        {
            value = regionModel.Name;
            data = new {
                sortBy = regionModel.Name + "__r",
                category = "Area",
                associations = regionModel.Associations
            };
        }

        public AutoCompleteSearchModel(TrainingCenterModel trainingCenterModel)
        {
            value = trainingCenterModel.Name;
            data = new {
                sortBy = trainingCenterModel.Name + "__tc",
                category = "Trainingcenter",
                url = trainingCenterModel.Url,
                address = trainingCenterModel.Address,
                association = trainingCenterModel.Association};
        }
    }
}
