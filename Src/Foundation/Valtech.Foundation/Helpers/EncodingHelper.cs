using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Valtech.Foundation.Helpers
{
    public static class EncodingHelper
    {
        public static IHtmlString GetRazorViewText(string text)
        {
            return new MvcHtmlString(text
                .Replace("ä", @"&auml;")
                .Replace("ö", @"&ouml;")
                .Replace("å", @"&aring;")
                .Replace("Ä", @"&Auml;")
                .Replace("Ö", @"&Ouml;")
                .Replace("Å", @"&Aring;"));
        }
    }
}