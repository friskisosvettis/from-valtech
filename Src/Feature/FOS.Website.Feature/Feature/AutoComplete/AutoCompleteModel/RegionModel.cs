using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FOS.Website.Feature.AutoComplete.AutoCompleteModel
{
    public class RegionModel
    {
        [JsonIgnore]
        public string Name { get; set; }
        public List<RegionAssociationModel> Associations { get; set; }

        public RegionModel(string rName)
        {
            Name = rName;
            Associations = new List<RegionAssociationModel>();
        }
    }
}