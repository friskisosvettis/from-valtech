using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.ContentEditor;
using Sitecore.Text;
using Sitecore.Web;

namespace Valtech.Foundation.CustomFields
{
    public class QueryableTree : Sitecore.Shell.Applications.ContentEditor.Tree
    {
        // override the Source property from the base class
        public new string Source
        {
            get
            {
                return StringUtil.GetString(new string[]
                {
                    base.Source // slightly altered from the original
                });
            }
            set
            {
                Assert.ArgumentNotNull(value, "value");
                if (!value.StartsWith("query:", StringComparison.InvariantCulture))
                {
                    base.Source = value; // slightly altered from the original
                    return;
                }
                Item item = Client.ContentDatabase.GetItem(this.ItemID);

                // Added code that figures out if we're looking at rendering parameters, 
                // and if so, figures out what the context item actually is.
                string url = WebUtil.GetQueryString();
                if (!string.IsNullOrWhiteSpace(url) && url.Contains("hdl"))
                {
                    FieldEditorParameters parameters = FieldEditorOptions.Parse(new UrlString(url)).Parameters;
                    var currentItemId = parameters["contentitem"];
                    if (!string.IsNullOrEmpty(currentItemId))
                    {
                        Sitecore.Data.ItemUri contentItemUri = new Sitecore.Data.ItemUri(currentItemId);
                        item = Sitecore.Data.Database.GetItem(contentItemUri);
                    }
                }

                if (item == null)
                {
                    return;
                }
                Item item2 = item.Axes.SelectSingleItem(value.Substring("query:".Length));
                if (item2 == null)
                {
                    return;
                }
                base.Source = item2.ID.ToString(); // slightly altered from the original
            }
        }
    }
}