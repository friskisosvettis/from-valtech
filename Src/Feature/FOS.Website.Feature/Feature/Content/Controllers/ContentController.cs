using FOS.Website.Feature.Content.Data;
using FOS.Website.Feature.Content.PresentationData;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Synthesis;
using FOS.Website.Feature.Content.Models;
using Sitecore.Buckets.Extensions;
using Valtech.Foundation.SitecoreExtensions;
using Valtech.Foundation.Synthesis;
using Sitecore.Data.Items;

namespace FOS.Website.Feature.Content.Controllers
{
    public class ContentController : Controller
    {
        public ActionResult GeAssociationIntroductionModuleView()
        {
            var model = new AssociationIntroductionModuleModel()
            {
                AssociationIntroductionModuleItem = Sitecore.Context.Item.As<IAssociationIntroductionModuleItem>(),
                AssociationName = Sitecore.Context.Item.DisplayName
            };
            return View(Constants.Views.Paths.AssociationIntroductionModule, model);
        }

        public ActionResult GetAssociationTopBarView()
        {
            AssociationTopBarModel model = new AssociationTopBarModel(); ;
            var associationItem = Sitecore.Context.Item.ClosestAscendantItemOfType<IAssociationFlagTemplateItem>();
            if (associationItem != null)
            {
                model.AssociationItem = associationItem.InnerItem;
                model.TopBarData = associationItem.InnerItem.ClosestAscendantItemOfType<IAssociationTopBarDataItem>();
            }

            return View(Constants.Views.Paths.AssociationTopBar, model);
        }

        public ActionResult GetBasicHeadingView()
        {
            BasicHeadingModel model = new BasicHeadingModel(Sitecore.Context.Item);
            return View(Constants.Views.Paths.BasicHeading, model);
        }

        public ActionResult GetHeadingTrainingCenterView()
        {
            HeadingTrainingCenterModel model = new HeadingTrainingCenterModel(Sitecore.Context.Item);
            return View(Constants.Views.Paths.HeadingTrainingCenterView, model);
        }

        public ActionResult GetExpandableSectionView()
        {
            IExpandableSectionItem expandableItem = RenderingContext.Current.Rendering.Item.As<IExpandableSectionItem>();
            ExpandableSectionModel model = new ExpandableSectionModel(expandableItem);
            return View(Constants.Views.Paths.ExpandableSection, model);
        }

        public ActionResult GetImageCollageView()
        {
            IImageCollageItem collageItem = RenderingContext.Current.Rendering.Item.As<IImageCollageItem>();
            ImageCollageModel model = null;
            if (collageItem != null)
            {
                model = new ImageCollageModel(collageItem);
            }
            return View(Constants.Views.Paths.ImageCollage, model);
        }

        public ActionResult GetQuoteView()
        {
            IQuoteItem quoteItem = RenderingContext.Current.Rendering.Item.As<IQuoteItem>();
            string contentSizeName = FieldHelper.GetFieldName((IQuotePresentationPropertiesItem i) => i.Content_Size); 
            string contentAlignmentName = FieldHelper.GetFieldName((IQuotePresentationPropertiesItem i) => i.Content_Align);
            IContentSizeItem targetContentSizeItem = RenderingContext.Current.Rendering.Parameters.GetItemFromLookupField(contentSizeName, RenderingContext.Current.PageContext.Database).As<IContentSizeItem>();
            IContentAlignmentItem targetContentAlignment = RenderingContext.Current.Rendering.Parameters.GetItemFromLookupField(contentAlignmentName, RenderingContext.Current.PageContext.Database).As<IContentAlignmentItem>();
            QuoteModel model = new QuoteModel(quoteItem, targetContentSizeItem, targetContentAlignment);
            return View(Constants.Views.Paths.Quote, model);
        }

        public ActionResult GetQuoteContainedView()
        {
            IQuoteItem quoteItem = RenderingContext.Current.Rendering.Item.As<IQuoteItem>();
            QuoteModel model = new QuoteModel(quoteItem, true);
            return View(Constants.Views.Paths.Quote, model);
        }

        public ActionResult GetHeadlineView()
        {
            IHeadlineItem headlineItem = RenderingContext.Current.Rendering.Item.As<IHeadlineItem>();
            return View(Constants.Views.Paths.Headline, headlineItem);
        }

        public ActionResult GetTeaserView()
        {
            ITeaserItem teaserItem = RenderingContext.Current.Rendering.Item.As<ITeaserItem>();
            return View(Constants.Views.Paths.Teaser, teaserItem);
        }

        public ActionResult GetMediaView()
        {
            IMediaItem mediaItem = RenderingContext.Current.Rendering.Item.As<IMediaItem>();
            return View(Constants.Views.Paths.Media, mediaItem);
        }

        public ActionResult GetCollageView()
        {
            return View(Constants.Views.Paths.Collage);
        }
    }
}