using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Buckets.Extensions;
using Sitecore.Data.Items;
using Synthesis;
using Valtech.Foundation.Dictionary;
using Valtech.Foundation.Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class AssociationNotMigratedModel
    {
        public IAssociationNotMigratedInfoItem GeneralData { get; set; }
        public IAssociationNotMigratedWidgetItem AssociationCheckWidget{ get; set; }
        public string label_Button
        {
            get
            {
                var label = DictionaryRepository.Default.GetRawValueText("/Content/AssociationNotMigrated",
                    "LabelGoToButton", "Go to Friskis");

                if (AssociationCheckWidget != null && label.Contains("{name}"))
                {
                    label = label.Replace("{name}", AssociationCheckWidget.InnerItem.DisplayName);
                }

                return label;
            }
        }
    }
}