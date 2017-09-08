using System.Web;
using FOS.Website.Feature.Content.Data;
using Valtech.Foundation.Dictionary;

namespace FOS.Website.Feature.Content.Models
{
    public class ExpandableSectionModel
    {
        public ExpandableSectionModel(IExpandableSectionItem item)
        {
            ExpandableItem = item;
        }

        private IExpandableSectionItem ExpandableItem { get; set; }

        public IHtmlString ReadMoreText
        {
            get
            {
                if (ExpandableItem == null)
                {
                    string dictionaryText = DictionaryRepository.Default.GetText("/Content/ExpandableSection", "ReadMoreText", "CREATE: Read more", true);
                    return new HtmlString(dictionaryText);
                }
                else
                {
                    return new HtmlString(ExpandableItem.Content_ReadMoreText.RenderedValue);
                }
            }
            
        }
    }
}