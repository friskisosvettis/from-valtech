namespace Valtech.Foundation.Assets
{
  using System.IO;
  using System.Web;
  using System.Web.Caching;
  using System.Web.Hosting;

  public class Fingerprint
  {
    public static string Add(string rootRelativePath)
    {
      var cacheKey = "Foundation.Fingerprint.Tag-" + rootRelativePath;

      if (HttpRuntime.Cache[cacheKey] != null)
      {
        return HttpRuntime.Cache[cacheKey] as string;
      }

      var absolute = HostingEnvironment.MapPath("~" + rootRelativePath);

      if (absolute == null || !File.Exists(absolute))
      {
        return rootRelativePath;
      }

      var date = File.GetLastWriteTime(absolute);
      var index = rootRelativePath.LastIndexOf('/');

      var result = rootRelativePath.Insert(index, "/assets-version-" + date.Ticks);
      HttpRuntime.Cache.Insert(cacheKey, result, new CacheDependency(absolute));

      return HttpRuntime.Cache[cacheKey] as string;
    }
  }
}