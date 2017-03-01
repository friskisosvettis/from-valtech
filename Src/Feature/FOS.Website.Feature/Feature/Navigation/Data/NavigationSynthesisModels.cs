//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FOS.Website.Feature.Navigation.Data {
    
    
    /// <summary>Represents the /sitecore/templates/Feature/Navigation/Data/NavigationData template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{A2B8D74F-1F5A-4A8D-BB21-599CBC277098}", "211ow3WkQ8RZJth8G98+cLCkzbw=", "Valtech.Foundation.Synthesis")]
    public partial interface INavigationDataItem : Synthesis.IStandardTemplateItem {
        
        /// <summary>Represents the Navigation_NavigationTitle field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("navigation_navigationtitle")]
        Synthesis.FieldTypes.Interfaces.ITextField Navigation_NavigationTitle {
            get;
        }
        
        /// <summary>Represents the Navigation_ShowInMenu field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("navigation_showinmenu")]
        Synthesis.FieldTypes.Interfaces.IBooleanField Navigation_ShowInMenu {
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

namespace FOS.Website.Concrete.Feature.Navigation.Data {
    
    
    /// <summary>Represents the /sitecore/templates/Feature/Navigation/Data/NavigationData template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class NavigationData : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.Navigation.Data.INavigationDataItem {
        
        private Synthesis.FieldTypes.TextField _navigation_NavigationTitle;
        
        private Synthesis.FieldTypes.BooleanField _navigation_ShowInMenu;
        
        public NavigationData(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public NavigationData(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "NavigationData";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{A2B8D74F-1F5A-4A8D-BB21-599CBC277098}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the Navigation_NavigationTitle field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("navigation_navigationtitle")]
        public Synthesis.FieldTypes.Interfaces.ITextField Navigation_NavigationTitle {
            get {
                if (_navigation_NavigationTitle == null) {
                    _navigation_NavigationTitle = new Synthesis.FieldTypes.TextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{0E12FF8A-DC4F-43F0-8D43-6C2BE8CF4021}"], "/sitecore/templates/Feature/Navigation/Data/NavigationData", "Navigation_NavigationTitle"), this.GetSearchFieldValue("navigation_navigationtitle"));
                }
                return _navigation_NavigationTitle;
            }
        }
        
        /// <summary>Represents the Navigation_ShowInMenu field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("navigation_showinmenu")]
        public Synthesis.FieldTypes.Interfaces.IBooleanField Navigation_ShowInMenu {
            get {
                if (_navigation_ShowInMenu == null) {
                    _navigation_ShowInMenu = new Synthesis.FieldTypes.BooleanField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{F60E9BBE-8B37-4EB3-A293-A072E18C67D5}"], "/sitecore/templates/Feature/Navigation/Data/NavigationData", "Navigation_ShowInMenu"), this.GetSearchFieldValue("navigation_showinmenu"));
                }
                return _navigation_ShowInMenu;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class NavigationDataInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{A2B8D74F-1F5A-4A8D-BB21-599CBC277098}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new NavigationData(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new NavigationData(searchFields);
        }
    }
}
