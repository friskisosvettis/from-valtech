//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FOS.Website.Foundation.Settings {
    
    
    /// <summary>Represents the /sitecore/templates/Foundation/Settings/SettingsSelector template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{698E1ED5-91E5-4255-8E14-ABB46CF87B06}", "5/LtrKj6EpXR0YheZAngXfwKUVY=", "Valtech.Foundation.Synthesis")]
    public partial interface ISettingsSelectorItem : Synthesis.IStandardTemplateItem {
        
        /// <summary>Represents the Settings_SettingsRoot field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("settings_settingsroot")]
        Synthesis.FieldTypes.Interfaces.IItemReferenceField Settings_SettingsRoot {
            get;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FOS.Website.Concrete.Foundation.Settings {
    
    
    /// <summary>Represents the /sitecore/templates/Foundation/Settings/SettingsSelector template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class SettingsSelector : global::Synthesis.StandardTemplateItem, global::FOS.Website.Foundation.Settings.ISettingsSelectorItem {
        
        private Synthesis.FieldTypes.ItemReferenceField _settings_SettingsRoot;
        
        public SettingsSelector(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public SettingsSelector(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "SettingsSelector";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{698E1ED5-91E5-4255-8E14-ABB46CF87B06}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the Settings_SettingsRoot field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("settings_settingsroot")]
        public Synthesis.FieldTypes.Interfaces.IItemReferenceField Settings_SettingsRoot {
            get {
                if (_settings_SettingsRoot == null) {
                    _settings_SettingsRoot = new Synthesis.FieldTypes.ItemReferenceField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{E0303F65-4DBE-4C82-8F89-64BE2B92FD0F}"], "/sitecore/templates/Foundation/Settings/SettingsSelector", "Settings_SettingsRoot"), this.GetSearchFieldValue("settings_settingsroot"));
                }
                return _settings_SettingsRoot;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class SettingsSelectorInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{698E1ED5-91E5-4255-8E14-ABB46CF87B06}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new SettingsSelector(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new SettingsSelector(searchFields);
        }
    }
}
