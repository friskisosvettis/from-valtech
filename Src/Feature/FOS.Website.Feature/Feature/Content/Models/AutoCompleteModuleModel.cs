using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Buckets.Extensions;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Synthesis;
using Valtech.Foundation.Dictionary;
using Valtech.Foundation.Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class AutoCompleteModuleModel
    {
        public IAutoCompleteModuleItem AutoCompleteModuleItem { get; set; }
        public IHtmlString label_InputFieldBackground { get; } = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/AutoCompleteModule", "InputFieldBackground", "Find an area, association or training center"));
        public IHtmlString label_NoMatch = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/AutoCompleteModule", "NoMatch", "Vi kan inte hitta det du letar efter tyvärr!"));
        public IHtmlString label_Area = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/AutoCompleteModule", "Area", "Område"));
        public IHtmlString label_TrainingcenterOne = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/AutoCompleteModule", "TrainingcenterOne", "träningsställe"));
        public IHtmlString label_TrainingcenterMore = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/AutoCompleteModule", "TrainingcenterMore", "träningsställen"));
        public IHtmlString label_ShowAll = new HtmlString(DictionaryRepository.Default.GetRawValueText("/Content/AutoCompleteModule", "ShowAll", "Visa alla"));

        public AutoCompleteModuleModel()
        {
            AutoCompleteModuleItem = Sitecore.Context.Item.As<IAutoCompleteModuleItem>();
        }
    }
}