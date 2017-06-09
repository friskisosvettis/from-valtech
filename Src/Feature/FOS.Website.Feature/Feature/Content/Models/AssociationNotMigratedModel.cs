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
    public class AssociationNotMigratedModel
    {
        public IAssociationNotMigratedInfoItem GeneralData { get; set; }
        public IAssociationNotMigratedWidgetItem AssociationCheckWidget{ get; set; }
    }
}