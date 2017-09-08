using System;
using System.Web;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Links;
using Sitecore.Pipelines.HttpRequest;

namespace Valtech.Foundation.Pipelines.HttpRequestBegin
{
    public class CustomUrlEnforcer : HttpRequestProcessor
    {
        private static bool UseSecureScheme => Settings.GetBoolSetting("CustomUrlEnforcer.EnforceSecureScheme", false);

        private static bool AlwaysIncludeServerUrl => Settings.GetBoolSetting("CustomUrlEnforcer.EnforceCanonicalHost", false);

        private static bool EnforceLowerCaseUrl => Settings.GetBoolSetting("CustomUrlEnforcer.EnforceLowerCaseUrl", false);

        private Uri _uri;
        private Uri ContextUri => _uri ?? (_uri = new Uri(LinkManager.GetItemUrl(Context.Item, new UrlOptions { AlwaysIncludeServerUrl = true })));

        public override void Process(HttpRequestArgs args)
        {
            if (Context.Item == null)
            {
                RedirectLoginRequest();
                return;
            }

            var redirectUri = args.Context.Request.Url;

            if (redirectUri.AbsolutePath.StartsWith("/_DEV"))
                return; //disable module for TDS deployment paths

            if (UseSecureScheme && !RequestSchemeIsHttps(args))
                redirectUri = ChangeToSecureScheme(redirectUri);

            if (AlwaysIncludeServerUrl && !RequestHostIsCanonical(args))
                redirectUri = ChangeToCanonicalHost(redirectUri);

            if (EnforceLowerCaseUrl)
                redirectUri = ChangeToLowerCase(redirectUri);

            if (redirectUri.ToString().Equals(args.Context.Request.Url.ToString(), StringComparison.InvariantCulture))
                return;

            args.Context.Response.RedirectPermanent(redirectUri.AbsoluteUri, true);
        }

        private Uri ChangeToLowerCase(Uri uri)
        {
            var lowercaseUri = new UriBuilder(uri) { Path = uri.AbsolutePath.ToLower() };
            return lowercaseUri.Uri;
        }

        private Uri ChangeToCanonicalHost(Uri uri)
        {
            var canonicalUri = new UriBuilder(uri) { Host = ContextUri.Host };
            return canonicalUri.Uri;
        }

        private bool RequestHostIsCanonical(HttpRequestArgs args)
        {
            return args.Context.Request.Url.Host.Equals(ContextUri.Host, StringComparison.InvariantCultureIgnoreCase);
        }

        private static bool RequestSchemeIsHttps(HttpRequestArgs args)
        {
            return args.Context.Request.Url.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.InvariantCultureIgnoreCase);
        }

        private static Uri ChangeToSecureScheme(Uri uri)
        {
            if (!uri.AbsoluteUri.StartsWith(Uri.UriSchemeHttp, StringComparison.InvariantCultureIgnoreCase))
                return uri;

            var secureUri = string.Concat(Uri.UriSchemeHttps, uri.AbsoluteUri.Substring(4));
            return new Uri(secureUri);
        }

        private void RedirectLoginRequest()
        {
            if (!UseSecureScheme)
                return;

            string absUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            string localUrl = HttpContext.Current.Request.Url.LocalPath;

            if (localUrl.StartsWith("/sitecore/login") && absUrl.StartsWith("http://") && !Context.IsLoggedIn)
            {
                HttpContext.Current.Response.Redirect(absUrl.Replace("http://", "https://"));
            }
        }

    }
}
