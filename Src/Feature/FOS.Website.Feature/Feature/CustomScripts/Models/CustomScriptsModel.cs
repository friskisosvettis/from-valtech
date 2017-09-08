using System.Collections.Generic;
using FOS.Website.Feature.CustomScripts.Data;
using FOS.Website.Feature.CustomScripts.Services;
using Synthesis.FieldTypes.Interfaces;

namespace FOS.Website.Feature.CustomScripts.Models
{
    public class CustomScriptsModel
    {
        public IGlobalCustomScriptItem GlobalCustomScripts { get; set; }
        public IEnumerable<ISiteSpecificScriptItem> SiteSpecificScripts { get; set; }
        public IEnumerable<ITextField> PageSpecificAndInheritedScripts { get; set; }

        public CustomScriptsModel()
        {
            PageSpecificAndInheritedScripts = CustomScriptsService.GetInheritedScripts();

            SiteSpecificScripts = CustomScriptsService.GetSiteSpecificCustomScripts();

            //TODO impl. global custom scripts - templates exist, awaiting global settings structure and code to access global settings item
            //GlobalCustomScripts = CustomScriptsService.GetGlobalCustomScripts();
        }
    }
}