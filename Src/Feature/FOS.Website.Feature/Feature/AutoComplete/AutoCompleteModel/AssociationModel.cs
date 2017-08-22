using System.Collections.Generic;
using Newtonsoft.Json;

namespace FOS.Website.Feature.AutoComplete.AutoCompleteModel
{
    public class AssociationModel
    {
        [JsonIgnore]
        public string Name { get; set; }
        public string Url { get; set; }
        public string ShowAll { get; set; }

        public List<AssociationTrainingCenterModel> Centers { get; set; }

        public AssociationModel(string name, string url, string showAllCentersCustomUrl)
        {
            Centers = new List<AssociationTrainingCenterModel>();
            Name = name;
            Url = url;
            ShowAll = showAllCentersCustomUrl;
        }

        public void AddCenter(AssociationTrainingCenterModel center)
        {
            Centers.Add(center);
        }
    }
}