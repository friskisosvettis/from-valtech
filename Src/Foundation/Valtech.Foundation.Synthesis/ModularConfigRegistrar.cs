using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;
using Synthesis.Configuration;
using Synthesis.Configuration.Registration;
using Synthesis.Utility;
using Valtech.Foundation.Synthesis.Configuration;

namespace Valtech.Foundation.Synthesis
{
    public class ModularConfigRegistrar
    {
        private readonly List<Assembly> _assemblies = new List<Assembly>();

        public virtual void Process(PipelineArgs args)
        {
            IEnumerable<Type> types = GetTypesInRegisteredAssemblies();
            IEnumerable<ISynthesisConfigurationRegistration> configurations = GetConfigurationsFromTypes(types);

            foreach (var configRegistration in configurations)
            {
                ProviderResolver.RegisterConfiguration(configRegistration.GetConfiguration());
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "We want to ignore all load errors on assembly types")]
        protected virtual IEnumerable<Type> GetTypesInRegisteredAssemblies()
        {
            if (_assemblies.Count == 0) throw new InvalidOperationException("You must specify the assemblies to scan for Synthesis configurations, e.g. <assemblies hint=\"list: AddAssembly\"><default>Synthesis</default></assemblies>");

            IEnumerable<Assembly> assemblies = _assemblies;

            return assemblies.SelectMany(delegate (Assembly x)
            {
                try { return x.GetExportedTypes(); }
                catch (ReflectionTypeLoadException rex) { return rex.Types.Where(y => y != null).ToArray(); } // http://haacked.com/archive/2012/07/23/get-all-types-in-an-assembly.aspx
                catch { return new Type[] { }; }
            }).ToList();
        }

        protected virtual IEnumerable<ISynthesisConfigurationRegistration> GetConfigurationsFromTypes(IEnumerable<Type> types)
        {
            var registrations = new List<ISynthesisConfigurationRegistration>();
            foreach(var type in types)
            {
                if(typeof(ISynthesisConfigurationRegistration).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                {
                    var registration = Activator.CreateInstance(type);
                    if(registration is ModularModelRegistration)
                    {
                        IEnumerable<ModuleConfiguration> moduleConfigurations = GetModuleConfigurations();
                        foreach(var moduleConfiguration in moduleConfigurations)
                        {
                            ModularModelRegistration moduleRegistration = new ModularModelRegistration();
                            moduleRegistration.ModuleName = moduleConfiguration.ModuleName;
                            moduleRegistration.ModuleType = moduleConfiguration.ModuleType;
                            moduleRegistration.ProjectName = moduleConfiguration.ProjectName;
                            registrations.Add(moduleRegistration);
                        }
                    }
                    else
                    {
                        registrations.Add((ISynthesisConfigurationRegistration)registration);
                    }
                }
            }
            return registrations;
            //TODO JM: Caching?
        }

        private IEnumerable<ModuleConfiguration> GetModuleConfigurations()
        {
            ModuleProvider provider = ModuleProvider.GetModuleProvider();
            return provider.ModuleConfigurations;
        }

        public void AddAssembly(string name)
        {
            // ignore assemblies already added
            if (_assemblies.Any(existing => existing.GetName().Name.Equals(name, StringComparison.Ordinal))) return;

            if (name.Contains("*"))
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assembly in assemblies)
                {
                    var assemblyName = assembly.GetName().Name;
                    if (WildcardUtility.IsWildcardMatch(assemblyName, name)) AddAssembly(assemblyName);
                }

                return;
            }

            Assembly a = Assembly.Load(name);
            if (a == null) throw new ArgumentException("The assembly name was not valid");

            _assemblies.Add(a);
        }
    }
}