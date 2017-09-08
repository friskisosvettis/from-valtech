using System;
using Sitecore.Data.Items;
using Sitecore.Shell.Applications.ContentEditor;

namespace Valtech.Foundation.CustomFields
{
    public class QueryableTreeList : TreeList
    {
        public new string Source
        {
            get
            {
                return base.Source;
            }

            set
            {
                if (!value.StartsWith("query:"))
                {
                    base.Source = value;
                }

                else
                {
                    string valueNoParameters = value;
                    string parameters = string.Empty;
                    if (valueNoParameters.Contains("&"))
                    {
                        valueNoParameters = value.Remove(value.IndexOf("&", System.StringComparison.Ordinal));
                        parameters = value.Substring(value.IndexOf("&", System.StringComparison.Ordinal));
                    }

                    Item item = Sitecore.Context.ContentDatabase.Items[this.ItemID];

                    if (item != null)
                    {

                        try
                        {
                            Item itemQueried = item.Axes.SelectSingleItem(valueNoParameters.Substring("query:".Length));
                            if (itemQueried != null)
                            {
                                base.Source = "datasource=" + itemQueried.Paths.FullPath + parameters;
                            }
                            else
                            {
                                base.Source = string.Empty;
                            }
                        }
                        catch (Exception e)
                        {
                            Sitecore.Diagnostics.Log.Error("QueryableTreeList.cs failed to run source query", e, this);
                            base.Source = string.Empty;
                        }

                    }
                }
            }
        }
    }
}


