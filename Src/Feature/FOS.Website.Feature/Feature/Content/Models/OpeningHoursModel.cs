using FOS.Website.Feature.Content.Data;
using FOS.Website.Feature.ContentBlocks.Helpers;
using Synthesis.FieldTypes.Interfaces;

namespace FOS.Website.Feature.Content.Models
{
    public class OpeningHoursModel
    {
        public IOpeningHoursItem OpeningHoursItem { get; set; } = RenderingHelper.GetRenderingContextOrDefault<IOpeningHoursItem>();

        //public  GoogleMapsApiKey {
        //    get
        //    {
        //        return 
        //    }
        //}
    }
}