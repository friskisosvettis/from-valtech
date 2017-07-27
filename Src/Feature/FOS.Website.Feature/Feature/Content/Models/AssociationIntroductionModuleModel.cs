﻿using System;
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
    public class AssociationIntroductionModuleModel
    {
        public string AssociationName { get; set; }
        public IAssociationIntroductionModuleItem AssociationIntroductionModuleItem { get; set; }
        public IHtmlString label_Prize { get; } = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/AssociationIntroductionModule", "Prize", "Prize"));
        public IHtmlString label_Schedule { get; } = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/AssociationIntroductionModule", "Schedule", "Schedule"));
        public IHtmlString label_TrainingCenter { get; } = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/AssociationIntroductionModule", "TrainingCenter", "Training center"));
        public IHtmlString label_TrainingSelection { get; } = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/AssociationIntroductionModule", "TrainingSelection", "Training selection"));
    }
}