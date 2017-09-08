using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOS.Website.Feature.AutoComplete.AutoCompleteModel
{
    public class AssociationTrainingCenterModel
    {
        public string name { get; set; }
        public string url { get; set; }
        public string address { get; set; }
        public string city { get; set; }

        public AssociationTrainingCenterModel(string tName, string path, string tAddress, string tCity)
        {
            name = tName;
            url = path;
            address = tAddress;
            city = tCity;
        }
    }
}