using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOS.Website.Feature.AutoComplete.AutoCompleteModel
{
    public class RegionAssociationModel
    {
        public string name { get; set; }
        public string url { get; set; }

        public RegionAssociationModel(string rName, string path)
        {
            name = rName;
            url = path;
        }
    }
}