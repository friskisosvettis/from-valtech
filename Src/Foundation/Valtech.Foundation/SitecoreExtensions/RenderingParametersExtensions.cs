using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valtech.Foundation.SitecoreExtensions
{
    public static class RenderingParametersExtensions
    {
        public static Item GetItemFromLookupField(this RenderingParameters parameters, string fieldName, Database database)
        {
            Assert.ArgumentNotNull(fieldName, "fieldName");
            Assert.ArgumentNotNull(database, "database");

            if (parameters == null)
                return null;

            string value = parameters[fieldName];

            Guid guid;
            if(Guid.TryParse(value, out guid))
            {
                Item item = database.GetItem(new ID(guid));
                return item;
            }

            return null;            
        }
    }
}