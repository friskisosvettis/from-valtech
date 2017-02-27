using Synthesis.Configuration.Registration;
using Synthesis.Templates;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Valtech.Foundation.Synthesis.Configuration;

namespace Valtech.Foundation.Synthesis
{
    public class ModularModelRegistration : SynthesisConfigurationRegistration
    {
        public string ModuleName { get; set; }

        public string ModuleType { get; set;}

        public string ProjectName { get; set; }

        protected override string ConfigurationName
        {
            get
            {
                //TODO JM: Fix this. Should probably be project.name + ModuleName
                return this.GetType().Assembly.GetName().Name;
            }
        }

        protected override IEnumerable<string> IncludedTemplates
        {
            get { yield return $"/sitecore/Templates/{this.ModuleType}/{this.ModuleName}"; }
        }

        protected override string NamespaceTemplatePathRoot => $"/sitecore/templates";

        protected override string ModelOutputFilePath
        {
            get
            {
                string projectRoot = Sitecore.Configuration.Settings.GetSetting("FOS.Website.Synthesis.ProjectRoot");
                if (String.IsNullOrEmpty(projectRoot))
                {
                    throw new ConfigurationErrorsException("Could not find setting FOS.Website.Synthesis.ProjectRoot");
                }
                string path = projectRoot + "\\" + ModuleType + "\\" + ProjectName + "\\" + ModuleType + "\\" + ModuleName + "\\Data\\" + ModuleName + "SynthesisModels.cs";
                return path;
            }
        }

        protected override string RootGeneratedNamespace
        {
            get
            {
                string namespaceRoot = Sitecore.Configuration.Settings.GetSetting("FOS.Website.Synthesis.ModuleRegistration.RootNamespace");
                if(String.IsNullOrEmpty(namespaceRoot))
                {
                    throw new ConfigurationErrorsException("Could not find setting FOS.Website.Synthesis.ModuleRegistration.RootNamespace");
                }
                string moduleNamespace = namespaceRoot;
                return moduleNamespace;
            }
        }
        
        protected override ITemplateInputProvider LoadTemplateInputProviderFromConfig()
        {
            var templates = new SilentConfigurationTemplateInputProvider();

            foreach (var path in IncludedTemplates)
            {
                templates.AddTemplatePath(path);
            }

            foreach (var path in ExcludedTemplates)
            {
                templates.AddTemplateExclusion(path);
            }

            foreach (var field in ExcludedFields)
            {
                templates.AddFieldExclusion(field);
            }

            return templates;
        }
    }
}