using Synthesis.FieldTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Valtech.Foundation.Synthesis
{
    public static class FieldHelper
    {
        public static string GetFieldName<TModel, TProperty>(Expression<Func<TModel, TProperty>> property)
        {
            //TODO: We must be able to get the field name. This will return the index field name, which might not be accurate.
            PropertyInfo prop = GetPropertyInfo<TModel, TProperty>(property);
            object[] attrs = prop.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                Sitecore.ContentSearch.IndexFieldAttribute indexAttribute = attr as Sitecore.ContentSearch.IndexFieldAttribute;
                string indexFieldName = String.Empty;
                if (indexAttribute != null)
                {
                    string propName = prop.Name;
                    indexFieldName = indexAttribute.IndexFieldName;
                    return indexFieldName;
                }
            }
            return prop.Name;
        }

        private static PropertyInfo GetPropertyInfo<TModel, TProperty>(Expression<Func<TModel, TProperty>> property)
        {
            MemberExpression memberExpression = (MemberExpression)property.Body;
            if (memberExpression == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    property.ToString()));

            PropertyInfo propInfo = memberExpression.Member as PropertyInfo;

            return propInfo;
        }
        
    }
}