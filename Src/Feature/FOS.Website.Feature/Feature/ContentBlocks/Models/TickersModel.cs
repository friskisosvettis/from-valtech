using System;
using System.Collections.Generic;
using FOS.Website.Feature.ContentBlocks.Data;
using FOS.Website.Feature.ContentBlocks.Helpers;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.StringExtensions;
using Synthesis;
using Synthesis.FieldTypes.Interfaces;

namespace FOS.Website.Feature.ContentBlocks.Models
{
    public class TickersModel : ContentBlockModelBase
    {
        public int NrTickers { get; set; } = 0;
        public IEnumerable<ITextField> TickerList { get; set; }

        public TickersModel(I_TickersItem tickerItem)
        {
           var tickerList = new List<ITextField>();

            if (tickerItem != null)
            {
                AddTextField(ref tickerList, tickerItem.Statement1);
                AddTextField(ref tickerList, tickerItem.Statement2);
                AddTextField(ref tickerList, tickerItem.Statement3);
                AddTextField(ref tickerList, tickerItem.Statement4);
                AddTextField(ref tickerList, tickerItem.Statement5);
            }
            
            TickerList = tickerList;
        }

        private void AddTextField(ref List<ITextField> list, ITextField field)
        {
            if (field.HasTextValue)
                NrTickers++;

            list.Add(field);
        }
    }
}