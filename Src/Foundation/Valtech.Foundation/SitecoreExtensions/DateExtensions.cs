using System;
using Sitecore.Social.Infrastructure.Utils;
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

            var dateShow = Sitecore.DateUtil.IsoDateToDateTime(dateTimeField.Value.ToIso());
            var localDate = TimeZone.CurrentTimeZone.ToLocalTime(dateShow);

            return localDate.ToString(dateTimeFormat, Sitecore.Context.Site.ContentLanguage.CultureInfo);
        }
    }
}
