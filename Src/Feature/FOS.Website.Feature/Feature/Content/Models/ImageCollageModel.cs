using FOS.Website.Feature.Content.Data;
using Sitecore.Diagnostics;

namespace FOS.Website.Feature.Content.Models
{
    public class ImageCollageModel
    {
        public ImageCollageModel(IImageCollageItem collageItem)
        {
            Assert.ArgumentNotNull(collageItem, "collageItem");

            ImageCollageItem = collageItem;
        }

        public IImageCollageItem ImageCollageItem { get; private set; }
    }
}