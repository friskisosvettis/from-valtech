using System.Web.Http;
using Sitecore.Pipelines;

namespace FOS.Website.Feature.AutoComplete.Routing
{
    public class RegisterAutoCompleteRoutes
    {
        public virtual void Process(PipelineArgs args)
        {
            var config = GlobalConfiguration.Configuration;

            config.Routes.MapHttpRoute("AutoCompleteRoute", "__AutoComplete", new
            {
                controller = "AutoCompleteData",
                action = "GetAutoCompleteData"
            });
        }

    }
}