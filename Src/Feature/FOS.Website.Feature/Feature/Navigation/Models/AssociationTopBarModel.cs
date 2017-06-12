using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Navigation.Data;
using Sitecore.Data.Items;
using Synthesis;
using Valtech.Foundation.Synthesis;

namespace FOS.Website.Feature.Navigation.Models
{
    public class AssociationTopBarModel
    {
        public IAssociationTopBarDataItem TopBarData { get; set; }
        public Item AssociationItem { get; set; }
        public bool IsForMobile { get; set; }
    }
}