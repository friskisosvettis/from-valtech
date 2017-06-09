using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Buckets.Extensions;
using Sitecore.Data.Items;
using Synthesis;
using Valtech.Foundation.Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class AssociationTopBarModel
    {
        public IAssociationTopBarDataItem TopBarData { get; set; }
        public Item AssociationItem { get; set; }
    }
}