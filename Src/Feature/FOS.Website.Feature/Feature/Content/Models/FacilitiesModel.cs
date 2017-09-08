using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using FOS.Website.Feature.Content.ListWidgets;
using Sitecore.Data.Items;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class FacilitiesModel
    {
        public IEnumerable<IFacilityItem> Facilities { get; set; }
    }
}