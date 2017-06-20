using FOS.Website.Feature.Summary;
using FOS.Website.Feature.Summary.Models;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOS.Website.Feature.Navigation.Data;
using FOS.Website.Feature.TrainingForm;
using FOS.Website.Feature.TrainingForm.Models;
using Synthesis;
using Sitecore.Buckets.Extensions;
using Valtech.Foundation.SitecoreExtensions;
using Valtech.Foundation.Synthesis;
using Sitecore.Data.Items;
using Valtech.Foundation.DataSource;

namespace FOS.Website.Feature.TrainingForm.Controllers
{

    public class TrainingFormController : Controller
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

        public ActionResult GetTrainingFormListView()
        {
            TrainingFormModel trainingFormModel;
            if (DataSourceItem != null)
            {
                trainingFormModel = new TrainingFormModel(DataSourceItem);
            }
            else
            {
                trainingFormModel = new TrainingFormModel(Sitecore.Context.Item);
            }
            
            return View(Constants.Views.Paths.TrainingFormList, trainingFormModel);
        }
    }
}