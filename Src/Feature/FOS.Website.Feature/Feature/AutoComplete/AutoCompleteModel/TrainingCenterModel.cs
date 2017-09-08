using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOS.Website.Feature.AutoComplete.AutoCompleteModel
{
    public class TrainingCenterModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Association { get; set; }
        public string Url { get; set; }

        public TrainingCenterModel(string name, string associationName, string url, string address, string zip, string city)
        {
            Name = name;
            Url = url;
            Address = string.Format("{0}, {1} {2}", address, zip, city);
            Association = associationName;
        }
    }
}