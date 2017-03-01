using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class VTestComponentModel
    {
        public IVTestComponentItem VTestComponentItem = null;

        public VTestComponentModel()
        {
            VTestComponentItem = RenderingContext.Current.Rendering.Item.As<IVTestComponentItem>();
            if (VTestComponentItem == null)
            {
                VTestComponentItem = Sitecore.Context.Item.As<IVTestComponentItem>();
            }
        }
    }
}