using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lucene.Net.Support;
using Newtonsoft.Json;
using Sitecore.Syndication;

namespace FOS.Website.Feature.AutoComplete.AutoCompleteModel
{
    public class AssociationModel
    {
        [JsonIgnore]
        public string Name { get; set; }
        public string Url { get; set; }
        public List<AssociationTrainingCenterModel> Centers { get; set; }

        public AssociationModel(string name, string url )
        {
            Centers = new List<AssociationTrainingCenterModel>();
            Name = name;
            Url = url;
        }

        public void AddCenter(AssociationTrainingCenterModel center)
        {
            Centers.Add(center);
        }
    }
}