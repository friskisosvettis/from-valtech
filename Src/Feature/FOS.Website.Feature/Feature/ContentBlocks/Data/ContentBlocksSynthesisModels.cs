//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FOS.Website.Feature.ContentBlocks.Blocks {
    
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Blocks/ImageAndText template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{21EA2408-A9D6-4CA6-AFD1-80798B77B5DB}", "rUpDfQXoMEoHrjPYOc6B5VBP76s=", "Valtech.Foundation.Synthesis")]
    public partial interface IImageAndTextItem : global::FOS.Website.Feature.ContentBlocks.Data.IHeadingItem, global::FOS.Website.Feature.ContentBlocks.Data.IImageItem, global::FOS.Website.Feature.ContentBlocks.Data.IRichTextItem, global::FOS.Website.Feature.ContentBlocks.Data.Settings.IInvertContentItem, global::FOS.Website.Feature.ContentBlocks.Data.Settings.IStyleItem {
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Blocks/VideoAndText template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{F7ECA36A-F814-44CD-B4BF-84D321220CCF}", "WbApP1baVRKGIDZDX34B2UB7eOY=", "Valtech.Foundation.Synthesis")]
    public partial interface IVideoAndTextItem : global::FOS.Website.Feature.ContentBlocks.Data.IHeadingItem, global::FOS.Website.Feature.ContentBlocks.Data.IRichTextItem, global::FOS.Website.Feature.ContentBlocks.Data.IVideoItem, global::FOS.Website.Feature.ContentBlocks.Data.Settings.IInvertContentItem, global::FOS.Website.Feature.ContentBlocks.Data.Settings.IStyleItem {
    }
}
namespace FOS.Website.Feature.ContentBlocks.Data {
    
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Data/Heading template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{2F8D1730-8E48-4D2A-AC96-4547DD5CDC02}", "FcOSvfGM2nzMXd1mzYjMV8wY/Sk=", "Valtech.Foundation.Synthesis")]
    public partial interface IHeadingItem : Synthesis.IStandardTemplateItem {
        
        /// <summary>Represents the Heading field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("heading")]
        Synthesis.FieldTypes.Interfaces.ITextField Heading1 {
            get;
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Data/Image template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{76F41557-F22A-4CFB-95E7-B3D9D1781FAC}", "ANLZ27SJAlExNxsS2heCIgRQ5Og=", "Valtech.Foundation.Synthesis")]
    public partial interface IImageItem : Synthesis.IStandardTemplateItem {
        
        /// <summary>Represents the Image field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("image")]
        Synthesis.FieldTypes.Interfaces.IImageField Image1 {
            get;
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Data/RichText template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{7A6E5726-35AD-4789-BE04-ED8575247C03}", "4cp66n1kmyYRX4EEgw9C7T1sRNc=", "Valtech.Foundation.Synthesis")]
    public partial interface IRichTextItem : Synthesis.IStandardTemplateItem {
        
        /// <summary>Represents the Text field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("text")]
        Synthesis.FieldTypes.Interfaces.IRichTextField Text {
            get;
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Data/Video template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{F717621B-4257-45DB-AECC-902A6F682FDB}", "tTxIj54zAqtGn7dLJb7OjNdyBa8=", "Valtech.Foundation.Synthesis")]
    public partial interface IVideoItem : Synthesis.IStandardTemplateItem {
        
        /// <summary>Represents the YoutubeID field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("youtubeid")]
        Synthesis.FieldTypes.Interfaces.ITextField YoutubeID {
            get;
        }
    }
}
namespace FOS.Website.Feature.ContentBlocks.Data.Settings {
    
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Data/Settings/InvertContent template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{045B2421-1361-42F0-8D39-DE0F1A9C6575}", "2mZAIdGmcV5dZ6TDuBVBY0IvR9o=", "Valtech.Foundation.Synthesis")]
    public partial interface IInvertContentItem : Synthesis.IStandardTemplateItem {
        
        /// <summary>Represents the InvertPositions field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("invertpositions")]
        Synthesis.FieldTypes.Interfaces.IBooleanField InvertPositions {
            get;
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Data/Settings/Style template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    [Synthesis.Synchronization.RepresentsSitecoreTemplateAttribute("{49A5DB17-079B-47C1-9F1B-101E72006B3A}", "0gJ94H6JRkwmkg3RaKvq0dxvgog=", "Valtech.Foundation.Synthesis")]
    public partial interface IStyleItem : Synthesis.IStandardTemplateItem {
        
        /// <summary>Represents the Style field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("style")]
        Synthesis.FieldTypes.Interfaces.IItemReferenceField Style1 {
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

namespace FOS.Website.Concrete.Feature.ContentBlocks.Blocks {
    
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Blocks/ImageAndText template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class ImageAndText : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.ContentBlocks.Blocks.IImageAndTextItem {
        
        private Synthesis.FieldTypes.TextField _heading1;
        
        private Synthesis.FieldTypes.ImageField _image1;
        
        private Synthesis.FieldTypes.RichTextField _text;
        
        private Synthesis.FieldTypes.BooleanField _invertPositions;
        
        private Synthesis.FieldTypes.ItemReferenceField _style1;
        
        public ImageAndText(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public ImageAndText(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "ImageAndText";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{21EA2408-A9D6-4CA6-AFD1-80798B77B5DB}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the Heading field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("heading")]
        public Synthesis.FieldTypes.Interfaces.ITextField Heading1 {
            get {
                if (_heading1 == null) {
                    _heading1 = new Synthesis.FieldTypes.TextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{172680EC-44BF-4CED-AAA6-DEC3A9E6CDC5}"], "/sitecore/templates/Feature/ContentBlocks/Blocks/ImageAndText", "Heading"), this.GetSearchFieldValue("heading"));
                }
                return _heading1;
            }
        }
        
        /// <summary>Represents the Image field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("image")]
        public Synthesis.FieldTypes.Interfaces.IImageField Image1 {
            get {
                if (_image1 == null) {
                    _image1 = new Synthesis.FieldTypes.ImageField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{61F71B9B-9ED2-45A9-9003-B4A3D81056B4}"], "/sitecore/templates/Feature/ContentBlocks/Blocks/ImageAndText", "Image"), this.GetSearchFieldValue("image"));
                }
                return _image1;
            }
        }
        
        /// <summary>Represents the Text field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("text")]
        public Synthesis.FieldTypes.Interfaces.IRichTextField Text {
            get {
                if (_text == null) {
                    _text = new Synthesis.FieldTypes.RichTextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{2EA03F17-AA46-4522-839C-B02F90CE87AD}"], "/sitecore/templates/Feature/ContentBlocks/Blocks/ImageAndText", "Text"), this.GetSearchFieldValue("text"));
                }
                return _text;
            }
        }
        
        /// <summary>Represents the InvertPositions field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("invertpositions")]
        public Synthesis.FieldTypes.Interfaces.IBooleanField InvertPositions {
            get {
                if (_invertPositions == null) {
                    _invertPositions = new Synthesis.FieldTypes.BooleanField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{2F4DFEFE-8EBC-4088-BE11-925B608FE2E4}"], "/sitecore/templates/Feature/ContentBlocks/Blocks/ImageAndText", "InvertPositions"), this.GetSearchFieldValue("invertpositions"));
                }
                return _invertPositions;
            }
        }
        
        /// <summary>Represents the Style field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("style")]
        public Synthesis.FieldTypes.Interfaces.IItemReferenceField Style1 {
            get {
                if (_style1 == null) {
                    _style1 = new Synthesis.FieldTypes.ItemReferenceField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{29F6CD5C-6EC6-4D39-99EA-35A1F6567BB8}"], "/sitecore/templates/Feature/ContentBlocks/Blocks/ImageAndText", "Style"), this.GetSearchFieldValue("style"));
                }
                return _style1;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class ImageAndTextInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{21EA2408-A9D6-4CA6-AFD1-80798B77B5DB}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new ImageAndText(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new ImageAndText(searchFields);
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Blocks/VideoAndText template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class VideoAndText : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.ContentBlocks.Blocks.IVideoAndTextItem {
        
        private Synthesis.FieldTypes.TextField _heading1;
        
        private Synthesis.FieldTypes.RichTextField _text;
        
        private Synthesis.FieldTypes.TextField _youtubeID;
        
        private Synthesis.FieldTypes.BooleanField _invertPositions;
        
        private Synthesis.FieldTypes.ItemReferenceField _style1;
        
        public VideoAndText(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public VideoAndText(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "VideoAndText";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{F7ECA36A-F814-44CD-B4BF-84D321220CCF}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the Heading field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("heading")]
        public Synthesis.FieldTypes.Interfaces.ITextField Heading1 {
            get {
                if (_heading1 == null) {
                    _heading1 = new Synthesis.FieldTypes.TextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{172680EC-44BF-4CED-AAA6-DEC3A9E6CDC5}"], "/sitecore/templates/Feature/ContentBlocks/Blocks/VideoAndText", "Heading"), this.GetSearchFieldValue("heading"));
                }
                return _heading1;
            }
        }
        
        /// <summary>Represents the Text field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("text")]
        public Synthesis.FieldTypes.Interfaces.IRichTextField Text {
            get {
                if (_text == null) {
                    _text = new Synthesis.FieldTypes.RichTextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{2EA03F17-AA46-4522-839C-B02F90CE87AD}"], "/sitecore/templates/Feature/ContentBlocks/Blocks/VideoAndText", "Text"), this.GetSearchFieldValue("text"));
                }
                return _text;
            }
        }
        
        /// <summary>Represents the YoutubeID field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("youtubeid")]
        public Synthesis.FieldTypes.Interfaces.ITextField YoutubeID {
            get {
                if (_youtubeID == null) {
                    _youtubeID = new Synthesis.FieldTypes.TextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{54D306E0-F243-4DBE-859D-248BBEC1A7D0}"], "/sitecore/templates/Feature/ContentBlocks/Blocks/VideoAndText", "YoutubeID"), this.GetSearchFieldValue("youtubeid"));
                }
                return _youtubeID;
            }
        }
        
        /// <summary>Represents the InvertPositions field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("invertpositions")]
        public Synthesis.FieldTypes.Interfaces.IBooleanField InvertPositions {
            get {
                if (_invertPositions == null) {
                    _invertPositions = new Synthesis.FieldTypes.BooleanField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{2F4DFEFE-8EBC-4088-BE11-925B608FE2E4}"], "/sitecore/templates/Feature/ContentBlocks/Blocks/VideoAndText", "InvertPositions"), this.GetSearchFieldValue("invertpositions"));
                }
                return _invertPositions;
            }
        }
        
        /// <summary>Represents the Style field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("style")]
        public Synthesis.FieldTypes.Interfaces.IItemReferenceField Style1 {
            get {
                if (_style1 == null) {
                    _style1 = new Synthesis.FieldTypes.ItemReferenceField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{29F6CD5C-6EC6-4D39-99EA-35A1F6567BB8}"], "/sitecore/templates/Feature/ContentBlocks/Blocks/VideoAndText", "Style"), this.GetSearchFieldValue("style"));
                }
                return _style1;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class VideoAndTextInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{F7ECA36A-F814-44CD-B4BF-84D321220CCF}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new VideoAndText(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new VideoAndText(searchFields);
        }
    }
}
namespace FOS.Website.Concrete.Feature.ContentBlocks.Data {
    
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Data/Heading template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class Heading : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.ContentBlocks.Data.IHeadingItem {
        
        private Synthesis.FieldTypes.TextField _heading1;
        
        public Heading(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public Heading(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "Heading";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{2F8D1730-8E48-4D2A-AC96-4547DD5CDC02}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the Heading field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("heading")]
        public Synthesis.FieldTypes.Interfaces.ITextField Heading1 {
            get {
                if (_heading1 == null) {
                    _heading1 = new Synthesis.FieldTypes.TextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{172680EC-44BF-4CED-AAA6-DEC3A9E6CDC5}"], "/sitecore/templates/Feature/ContentBlocks/Data/Heading", "Heading"), this.GetSearchFieldValue("heading"));
                }
                return _heading1;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class HeadingInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{2F8D1730-8E48-4D2A-AC96-4547DD5CDC02}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new Heading(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new Heading(searchFields);
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Data/Image template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class Image : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.ContentBlocks.Data.IImageItem {
        
        private Synthesis.FieldTypes.ImageField _image1;
        
        public Image(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public Image(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "Image";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{76F41557-F22A-4CFB-95E7-B3D9D1781FAC}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the Image field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("image")]
        public Synthesis.FieldTypes.Interfaces.IImageField Image1 {
            get {
                if (_image1 == null) {
                    _image1 = new Synthesis.FieldTypes.ImageField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{61F71B9B-9ED2-45A9-9003-B4A3D81056B4}"], "/sitecore/templates/Feature/ContentBlocks/Data/Image", "Image"), this.GetSearchFieldValue("image"));
                }
                return _image1;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class ImageInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{76F41557-F22A-4CFB-95E7-B3D9D1781FAC}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new Image(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new Image(searchFields);
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Data/RichText template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class RichText : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.ContentBlocks.Data.IRichTextItem {
        
        private Synthesis.FieldTypes.RichTextField _text;
        
        public RichText(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public RichText(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "RichText";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{7A6E5726-35AD-4789-BE04-ED8575247C03}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the Text field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("text")]
        public Synthesis.FieldTypes.Interfaces.IRichTextField Text {
            get {
                if (_text == null) {
                    _text = new Synthesis.FieldTypes.RichTextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{2EA03F17-AA46-4522-839C-B02F90CE87AD}"], "/sitecore/templates/Feature/ContentBlocks/Data/RichText", "Text"), this.GetSearchFieldValue("text"));
                }
                return _text;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class RichTextInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{7A6E5726-35AD-4789-BE04-ED8575247C03}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new RichText(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new RichText(searchFields);
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Data/Video template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class Video : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.ContentBlocks.Data.IVideoItem {
        
        private Synthesis.FieldTypes.TextField _youtubeID;
        
        public Video(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public Video(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "Video";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{F717621B-4257-45DB-AECC-902A6F682FDB}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the YoutubeID field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("youtubeid")]
        public Synthesis.FieldTypes.Interfaces.ITextField YoutubeID {
            get {
                if (_youtubeID == null) {
                    _youtubeID = new Synthesis.FieldTypes.TextField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{54D306E0-F243-4DBE-859D-248BBEC1A7D0}"], "/sitecore/templates/Feature/ContentBlocks/Data/Video", "YoutubeID"), this.GetSearchFieldValue("youtubeid"));
                }
                return _youtubeID;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class VideoInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{F717621B-4257-45DB-AECC-902A6F682FDB}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new Video(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new Video(searchFields);
        }
    }
}
namespace FOS.Website.Concrete.Feature.ContentBlocks.Data.Settings {
    
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Data/Settings/InvertContent template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class InvertContent : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.ContentBlocks.Data.Settings.IInvertContentItem {
        
        private Synthesis.FieldTypes.BooleanField _invertPositions;
        
        public InvertContent(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public InvertContent(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "InvertContent";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{045B2421-1361-42F0-8D39-DE0F1A9C6575}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the InvertPositions field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("invertpositions")]
        public Synthesis.FieldTypes.Interfaces.IBooleanField InvertPositions {
            get {
                if (_invertPositions == null) {
                    _invertPositions = new Synthesis.FieldTypes.BooleanField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{2F4DFEFE-8EBC-4088-BE11-925B608FE2E4}"], "/sitecore/templates/Feature/ContentBlocks/Data/Settings/InvertContent", "InvertPositions"), this.GetSearchFieldValue("invertpositions"));
                }
                return _invertPositions;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class InvertContentInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{045B2421-1361-42F0-8D39-DE0F1A9C6575}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new InvertContent(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new InvertContent(searchFields);
        }
    }
    
    /// <summary>Represents the /sitecore/templates/Feature/ContentBlocks/Data/Settings/Style template</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public partial class Style : global::Synthesis.StandardTemplateItem, global::FOS.Website.Feature.ContentBlocks.Data.Settings.IStyleItem {
        
        private Synthesis.FieldTypes.ItemReferenceField _style1;
        
        public Style(Sitecore.Data.Items.Item innerItem) : 
                base(innerItem) {
        }
        
        public Style(global::System.Collections.Generic.IDictionary<string, string> searchFields) : 
                base(searchFields) {
        }
        
        /// <summary>The name of the Sitecore Template that this class represents</summary>
        public static string TemplateName {
            get {
                return "Style";
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public static Sitecore.Data.ID ItemTemplateId {
            get {
                return new Sitecore.Data.ID("{49A5DB17-079B-47C1-9F1B-101E72006B3A}");
            }
        }
        
        /// <summary>The ID of the Sitecore Template that this class represents</summary>
        public override Sitecore.Data.ID TemplateId {
            get {
                return ItemTemplateId;
            }
        }
        
        /// <summary>Represents the Style field</summary>
        [Sitecore.ContentSearch.IndexFieldAttribute("style")]
        public Synthesis.FieldTypes.Interfaces.IItemReferenceField Style1 {
            get {
                if (_style1 == null) {
                    _style1 = new Synthesis.FieldTypes.ItemReferenceField(new global::Synthesis.FieldTypes.LazyField(() => InnerItem.Fields["{29F6CD5C-6EC6-4D39-99EA-35A1F6567BB8}"], "/sitecore/templates/Feature/ContentBlocks/Data/Settings/Style", "Style"), this.GetSearchFieldValue("style"));
                }
                return _style1;
            }
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Synthesis", "8.2")]
    public class StyleInitializer : Synthesis.Initializers.ITemplateInitializer {
        
        public Sitecore.Data.ID InitializesTemplateId {
            get {
                return new Sitecore.Data.ID("{49A5DB17-079B-47C1-9F1B-101E72006B3A}");
            }
        }
        
        public Synthesis.IStandardTemplateItem CreateInstance(Sitecore.Data.Items.Item innerItem) {
            return new Style(innerItem);
        }
        
        public Synthesis.IStandardTemplateItem CreateInstanceFromSearch(global::System.Collections.Generic.IDictionary<string, string> searchFields) {
            return new Style(searchFields);
        }
    }
}
