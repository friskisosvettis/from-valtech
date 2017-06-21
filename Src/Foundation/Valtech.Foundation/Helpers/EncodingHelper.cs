using System.Text;

namespace Valtech.Foundation.Helpers
{
    public static class EncodingHelper
    {
        public static string GetRazorViewText(string text)
        {
            return Encoding.UTF8.GetString(Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("ISO-8859-1"), Encoding.UTF8.GetBytes(text)));
        }
    }
}