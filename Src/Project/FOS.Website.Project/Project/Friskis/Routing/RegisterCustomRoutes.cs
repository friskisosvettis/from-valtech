using System.Web.Http;
using Sitecore.Pipelines;

namespace FOS.Website.Project.Friskis.Routing
{
    public class RegisterCustomRoutes
    {
        public virtual void Process(PipelineArgs args)
        {
            var config = GlobalConfiguration.Configuration;

            config.Routes.MapHttpRoute("DefaultServicesRoute", "Services", new { });
        }

    }
}