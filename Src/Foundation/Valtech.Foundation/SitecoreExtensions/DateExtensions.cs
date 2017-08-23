using Synthesis.FieldTypes.Interfaces;

namespace Valtech.Foundation.SitecoreExtensions
{
    public static class DateExtensions
    {
        public static string ToLocalizedString(this IDateTimeField dateTimeField, string dateTimeFormat)
        {
            if (!dateTimeField.HasValue)
            {
                return string.Empty;
            }

            return dateTimeField.Value.ToString(dateTimeFormat, Sitecore.Context.Site.ContentLanguage.CultureInfo);
        }
    }
}