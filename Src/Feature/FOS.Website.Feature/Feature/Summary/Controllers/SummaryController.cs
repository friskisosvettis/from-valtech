using FOS.Website.Feature.Summary;
using FOS.Website.Feature.Summary.Models;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOS.Website.Feature.Navigation.Data;
using Synthesis;
using Sitecore.Buckets.Extensions;
using Valtech.Foundation.SitecoreExtensions;
using Valtech.Foundation.Synthesis;
using Sitecore.Data.Items;
using Valtech.Foundation.DataSource;

namespace FOS.Website.Feature.Summary.Controllers
{

    public class SummaryController : Controller
    {
        private Item _datasourceItem = null;

        public Item DataSourceItem
        {
            get
            {
                if (_datasourceItem == null)
                {
                    _datasourceItem = DataSource.GetDataSourceItem(RenderingContext.Current);
                }
                return _datasourceItem;
            }
        }

        public ActionResult GetSummaryListView()
        {
            SummaryListModel summaryListModel = new SummaryListModel();
            if (DataSourceItem != null)
            {
                summaryListModel = new SummaryListModel(DataSourceItem);
            }

            return View(Constants.Views.Paths.SummaryList, summaryListModel);
        }


        public ActionResult GetSummarySpotView()
        {
            SummarySpotModel summarySpotModel = new SummarySpotModel();

            if (DataSourceItem != null)
            {
                summarySpotModel = new SummarySpotModel(DataSourceItem);
            }

            // TODO: Check if outcommented code is needed
            //if (RenderingContext.Current != null && RenderingContext.Current.Rendering != null)
            //{
            //    RenderingParameters renderingParameters = RenderingContext.Current.Rendering.Parameters;
            //    if (renderingParameters != null)
            //    {
            //        summarySpotModel.SummaryLink.Text =
            //            renderingParameters[SummarySpotParametersItem.LinkTextConstFieldName];
            //    }
            //}

            return View(Constants.Views.Paths.SummarySpot, summarySpotModel);
        }
    }
}