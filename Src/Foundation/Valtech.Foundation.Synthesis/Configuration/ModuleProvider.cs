using Sitecore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Valtech.Foundation.Synthesis.Configuration
{
    public class ModuleProvider
    {

        public static ModuleProvider GetModuleProvider()
        {
            return (ModuleProvider)Factory.CreateObject("/sitecore/synthesis/providers/moduleProvider", true);
        }

        private IList<ModuleConfiguration> _moduleConfigurations = new List<ModuleConfiguration>();
        
        public IEnumerable<ModuleConfiguration> ModuleConfigurations
        {
            get
            {
                return _moduleConfigurations;
            }
        }

        public void AddModule(XmlNode node)
        {
            if (node.Attributes == null || node.Attributes["name"] == null || node.Attributes["moduleType"] == null || node.Attributes["project"] == null) throw new ArgumentException("Invalid module mapping; must contain both name, type and project attributes");

            ModuleConfiguration configuration = new ModuleConfiguration();
            configuration.ModuleName = node.Attributes["name"].Value;
            configuration.ModuleType = node.Attributes["moduleType"].Value;
            configuration.ProjectName = node.Attributes["project"].Value;
            _moduleConfigurations.Add(configuration);

        }
    }
}