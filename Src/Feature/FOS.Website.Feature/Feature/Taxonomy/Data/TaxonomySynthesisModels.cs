//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FOS.Website.Feature.Taxonomy {
    
    
    /// <summary>Represents the /sitecore/templates/Feature/Taxonomy/TaxonomyFolder template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{2B50C834-0F76-4415-8991-C41F7A0FFEFE}", "f4HcYt2aoZvcK2kWoehjHsYN8Z0=", "Valtech.Foundation.Synthesis")]
    public partial interface ITaxonomyFolderItem : Synthesis.IStandardTemplateItem {
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/Taxonomy/TaxonomyGroup template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{18A7C9E9-B16C-47FC-A14F-0CE9B01E55C4}", "3f7IWTi8i7IB4eYciKMR8tgAZ8s=", "Valtech.Foundation.Synthesis")]
    public partial interface ITaxonomyGroupItem : Synthesis.IStandardTemplateItem {
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/Taxonomy/Taxonomy template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{F8376B7A-00E3-4517-943E-8E6BF0D1632E}", "LoMOpK+IXu04j1fC2nIyuVTIpGc=", "Valtech.Foundation.Synthesis")]
    public partial interface ITaxonomyItem : Synthesis.IStandardTemplateItem {
        
        /// <summary>Represents the Taxonomy field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("taxonomy")]
        Synthesis.FieldTypes.Interfaces.IItemReferenceListField Taxonomy1 {
            get;
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/Taxonomy/TaxonomyKeyword template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{C92E6A69-B38A-4DDC-B557-94F231B878E0}", "rZPZTtT5Gbgd96OcUum3OBdDDgw=", "Valtech.Foundation.Synthesis")]
    public partial interface ITaxonomyKeywordItem : Synthesis.IStandardTemplateItem {
        
        /// <summary>Represents the Keyword field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("keyword")]
        Synthesis.FieldTypes.Interfaces.ITextField Keyword {
            get;
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/Taxonomy/TaxonomyMonthsGroup template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{F26862F8-AC62-483C-8606-856543150F67}", "76DC+Xx90Vuf0cyJELHJUEwUn64=", "Valtech.Foundation.Synthesis")]
    public partial interface ITaxonomyMonthsGroupItem : Synthesis.IStandardTemplateItem {
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{05E2D62E-60B2-4049-8F55-C9AAC2B050B6}", "mZbTy2KNxJ6HQHQmhx2dTmHktcY=", "Valtech.Foundation.Synthesis")]
    public partial interface ITaxonomySpotParametersItem : global::FOS.Website.System.Layout.RenderingParameters.IStandardRenderingParametersItem {
        
        /// <summary>Represents the Variation field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("variation")]
        Synthesis.FieldTypes.Interfaces.IItemReferenceField Variation {
            get;
        }
        
        /// <summary>Represents the UseSpotParameterKeywords field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("usespotparameterkeywords")]
        Synthesis.FieldTypes.Interfaces.IBooleanField UseSpotParameterKeywords {
            get;
        }
        
        /// <summary>Represents the SpotParameterKeywords field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("spotparameterkeywords")]
        Synthesis.FieldTypes.Interfaces.IItemReferenceListField SpotParameterKeywords {
            get;
        }
        
        /// <summary>Represents the FallbackItem field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("fallbackitem")]
        Synthesis.FieldTypes.Interfaces.IItemReferenceField FallbackItem {
            get;
        }
        
        /// <summary>Represents the SearchRootItem field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("searchrootitem")]
        Synthesis.FieldTypes.Interfaces.IItemReferenceField SearchRootItem {
            get;
        }
        
        /// <summary>Represents the ResultTypes field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("resulttypes")]
        Synthesis.FieldTypes.Interfaces.IItemReferenceListField ResultTypes {
            get;
        }
        
        /// <summary>Represents the UseSeasonal field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("useseasonal")]
        Synthesis.FieldTypes.Interfaces.IBooleanField UseSeasonal {
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

namespace FOS.Website.Concrete.Feature.Taxonomy {
    
    
    /// <summary>Represents the /sitecore/templates/Feature/Taxonomy/Taxonomy template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class Taxonomy : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.Taxonomy.ITaxonomyItem {
        
        private Synthesis.FieldTypes.ItemReferenceListField _taxonomy1;
        
        public Taxonomy(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public Taxonomy(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "Taxonomy";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{F8376B7A-00E3-4517-943E-8E6BF0D1632E}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the Taxonomy field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("taxonomy")]
        public Synthesis.FieldTypes.Interfaces.IItemReferenceListField Taxonomy1 {
            get {
                if (_taxonomy1 == null) {
                    _taxonomy1 = new Synthesis.FieldTypes.ItemReferenceListField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{6A2D6A09-1D7A-48F4-80B7-3BBD2B28F623}"], "/sitecore/templates/Feature/Taxonomy/Taxonomy", "Taxonomy"), this.GetSearchFieldValue("taxonomy"));
                }
                return _taxonomy1;
            }
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/Taxonomy/TaxonomyFolder template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class TaxonomyFolder : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.Taxonomy.ITaxonomyFolderItem {
        
        public TaxonomyFolder(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public TaxonomyFolder(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "TaxonomyFolder";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{2B50C834-0F76-4415-8991-C41F7A0FFEFE}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class TaxonomyFolderInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{2B50C834-0F76-4415-8991-C41F7A0FFEFE}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new TaxonomyFolder(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new TaxonomyFolder(searchFields);
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/Taxonomy/TaxonomyGroup template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class TaxonomyGroup : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.Taxonomy.ITaxonomyGroupItem {
        
        public TaxonomyGroup(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public TaxonomyGroup(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "TaxonomyGroup";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{18A7C9E9-B16C-47FC-A14F-0CE9B01E55C4}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class TaxonomyGroupInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{18A7C9E9-B16C-47FC-A14F-0CE9B01E55C4}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new TaxonomyGroup(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new TaxonomyGroup(searchFields);
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class TaxonomyInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{F8376B7A-00E3-4517-943E-8E6BF0D1632E}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new Taxonomy(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new Taxonomy(searchFields);
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/Taxonomy/TaxonomyKeyword template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class TaxonomyKeyword : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.Taxonomy.ITaxonomyKeywordItem {
        
        private Synthesis.FieldTypes.TextField _keyword;
        
        public TaxonomyKeyword(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public TaxonomyKeyword(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "TaxonomyKeyword";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{C92E6A69-B38A-4DDC-B557-94F231B878E0}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the Keyword field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("keyword")]
        public Synthesis.FieldTypes.Interfaces.ITextField Keyword {
            get {
                if (_keyword == null) {
                    _keyword = new Synthesis.FieldTypes.TextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{F8A3DC3B-00B0-45DF-AF78-CAA6DD998311}"], "/sitecore/templates/Feature/Taxonomy/TaxonomyKeyword", "Keyword"), this.GetSearchFieldValue("keyword"));
                }
                return _keyword;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class TaxonomyKeywordInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{C92E6A69-B38A-4DDC-B557-94F231B878E0}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new TaxonomyKeyword(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new TaxonomyKeyword(searchFields);
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/Taxonomy/TaxonomyMonthsGroup template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class TaxonomyMonthsGroup : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.Taxonomy.ITaxonomyMonthsGroupItem {
        
        public TaxonomyMonthsGroup(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public TaxonomyMonthsGroup(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "TaxonomyMonthsGroup";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{F26862F8-AC62-483C-8606-856543150F67}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class TaxonomyMonthsGroupInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{F26862F8-AC62-483C-8606-856543150F67}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new TaxonomyMonthsGroup(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new TaxonomyMonthsGroup(searchFields);
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class TaxonomySpotParameters : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.Taxonomy.ITaxonomySpotParametersItem {
        
        private Synthesis.FieldTypes.TextField _caching;
        
        private Synthesis.FieldTypes.TextField _personalization;
        
        private Synthesis.FieldTypes.TextField _placeholder;
        
        private Synthesis.FieldTypes.PathItemReferenceField _tests;
        
        private Synthesis.FieldTypes.ItemReferenceField _variation;
        
        private Synthesis.FieldTypes.TextField _dataSource;
        
        private Synthesis.FieldTypes.BooleanField _useSpotParameterKeywords;
        
        private Synthesis.FieldTypes.DictionaryField _additionalParameters;
        
        private Synthesis.FieldTypes.ItemReferenceListField _spotParameterKeywords;
        
        private Synthesis.FieldTypes.ItemReferenceField _fallbackItem;
        
        private Synthesis.FieldTypes.ItemReferenceField _searchRootItem;
        
        private Synthesis.FieldTypes.ItemReferenceListField _resultTypes;
        
        private Synthesis.FieldTypes.BooleanField _useSeasonal;
        
        public TaxonomySpotParameters(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public TaxonomySpotParameters(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "TaxonomySpotParameters";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{05E2D62E-60B2-4049-8F55-C9AAC2B050B6}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the Caching field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("caching")]
        public Synthesis.FieldTypes.Interfaces.ITextField Caching {
            get {
                if (_caching == null) {
                    _caching = new Synthesis.FieldTypes.TextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{3094D236-5985-4C4F-AE6A-E30740885532}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "Caching"), this.GetSearchFieldValue("caching"));
                }
                return _caching;
            }
        }
        
        /// <summary>Represents the Personalization field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("personalization")]
        public Synthesis.FieldTypes.Interfaces.ITextField Personalization {
            get {
                if (_personalization == null) {
                    _personalization = new Synthesis.FieldTypes.TextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{C502BDEB-F5DA-4AD0-8095-D7CC1D0E1EEC}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "Personalization"), this.GetSearchFieldValue("personalization"));
                }
                return _personalization;
            }
        }
        
        /// <summary>Represents the Placeholder field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("placeholder")]
        public Synthesis.FieldTypes.Interfaces.ITextField Placeholder {
            get {
                if (_placeholder == null) {
                    _placeholder = new Synthesis.FieldTypes.TextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{E42027F4-766D-45A7-8CF4-29E5C94326F7}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "Placeholder"), this.GetSearchFieldValue("placeholder"));
                }
                return _placeholder;
            }
        }
        
        /// <summary>Represents the Tests field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("tests")]
        public Synthesis.FieldTypes.Interfaces.IPathItemReferenceField Tests {
            get {
                if (_tests == null) {
                    _tests = new Synthesis.FieldTypes.PathItemReferenceField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{0FA4635B-8BF4-46DF-994D-621B76F0A7AD}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "Tests"), this.GetSearchFieldValue("tests"));
                }
                return _tests;
            }
        }
        
        /// <summary>Represents the Variation field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("variation")]
        public Synthesis.FieldTypes.Interfaces.IItemReferenceField Variation {
            get {
                if (_variation == null) {
                    _variation = new Synthesis.FieldTypes.ItemReferenceField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{550DAF21-E5EE-4DEC-A754-3AB2EFC58234}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "Variation"), this.GetSearchFieldValue("variation"));
                }
                return _variation;
            }
        }
        
        /// <summary>Represents the Data Source field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("data_source")]
        public Synthesis.FieldTypes.Interfaces.ITextField DataSource {
            get {
                if (_dataSource == null) {
                    _dataSource = new Synthesis.FieldTypes.TextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{0793DCFF-0EE7-48AD-B9D4-EF1DD24EB59B}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "Data Source"), this.GetSearchFieldValue("data_source"));
                }
                return _dataSource;
            }
        }
        
        /// <summary>Represents the UseSpotParameterKeywords field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("usespotparameterkeywords")]
        public Synthesis.FieldTypes.Interfaces.IBooleanField UseSpotParameterKeywords {
            get {
                if (_useSpotParameterKeywords == null) {
                    _useSpotParameterKeywords = new Synthesis.FieldTypes.BooleanField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{C3CBFF78-FE4D-42E9-B62F-9FEB1DF35AB8}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "UseSpotParameterKeywords"), this.GetSearchFieldValue("usespotparameterkeywords"));
                }
                return _useSpotParameterKeywords;
            }
        }
        
        /// <summary>Represents the Additional Parameters field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("additional_parameters")]
        public Synthesis.FieldTypes.Interfaces.IDictionaryField AdditionalParameters {
            get {
                if (_additionalParameters == null) {
                    _additionalParameters = new Synthesis.FieldTypes.DictionaryField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{485E33D4-79F1-428F-8258-2CB29BB7CC6B}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "Additional Parameters"), this.GetSearchFieldValue("additional_parameters"));
                }
                return _additionalParameters;
            }
        }
        
        /// <summary>Represents the SpotParameterKeywords field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("spotparameterkeywords")]
        public Synthesis.FieldTypes.Interfaces.IItemReferenceListField SpotParameterKeywords {
            get {
                if (_spotParameterKeywords == null) {
                    _spotParameterKeywords = new Synthesis.FieldTypes.ItemReferenceListField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{4AB254E2-75FA-4283-9479-9CE1E42B4AB7}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "SpotParameterKeywords"), this.GetSearchFieldValue("spotparameterkeywords"));
                }
                return _spotParameterKeywords;
            }
        }
        
        /// <summary>Represents the FallbackItem field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("fallbackitem")]
        public Synthesis.FieldTypes.Interfaces.IItemReferenceField FallbackItem {
            get {
                if (_fallbackItem == null) {
                    _fallbackItem = new Synthesis.FieldTypes.ItemReferenceField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{CCBD5910-A22F-4CD7-9BB7-9491CA52AF7F}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "FallbackItem"), this.GetSearchFieldValue("fallbackitem"));
                }
                return _fallbackItem;
            }
        }
        
        /// <summary>Represents the SearchRootItem field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("searchrootitem")]
        public Synthesis.FieldTypes.Interfaces.IItemReferenceField SearchRootItem {
            get {
                if (_searchRootItem == null) {
                    _searchRootItem = new Synthesis.FieldTypes.ItemReferenceField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{F62655A9-75C0-4A01-BBB1-970682B99E88}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "SearchRootItem"), this.GetSearchFieldValue("searchrootitem"));
                }
                return _searchRootItem;
            }
        }
        
        /// <summary>Represents the ResultTypes field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("resulttypes")]
        public Synthesis.FieldTypes.Interfaces.IItemReferenceListField ResultTypes {
            get {
                if (_resultTypes == null) {
                    _resultTypes = new Synthesis.FieldTypes.ItemReferenceListField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{C2701480-8285-43DD-A5A1-36E9B8C82537}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "ResultTypes"), this.GetSearchFieldValue("resulttypes"));
                }
                return _resultTypes;
            }
        }
        
        /// <summary>Represents the UseSeasonal field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("useseasonal")]
        public Synthesis.FieldTypes.Interfaces.IBooleanField UseSeasonal {
            get {
                if (_useSeasonal == null) {
                    _useSeasonal = new Synthesis.FieldTypes.BooleanField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{F65680B2-59D7-477C-ABAE-FCB04B970A0F}"], "/sitecore/templates/Feature/Taxonomy/TaxonomySpotParameters", "UseSeasonal"), this.GetSearchFieldValue("useseasonal"));
                }
                return _useSeasonal;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class TaxonomySpotParametersInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{05E2D62E-60B2-4049-8F55-C9AAC2B050B6}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new TaxonomySpotParameters(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new TaxonomySpotParameters(searchFields);
        }
    }
}
