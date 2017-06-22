using FOS.Website.Feature.Summary;
using FOS.Website.Feature.Summary.Models;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOS.Website.Feature.ComponentBlock.Models;
using FOS.Website.Feature.Navigation.Data;
using Synthesis;
using Sitecore.Buckets.Extensions;
using Valtech.Foundation.SitecoreExtensions;
using Valtech.Foundation.Synthesis;
using Sitecore.Data.Items;
using Valtech.Foundation.DataSource;

namespace FOS.Website.Feature.ComponentBlock.Controllers
{

    public class ComponentBlockController : Controller
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

        public ActionResult GetComponentBlockView()
        {
            ComponentBlockModel componentBlockModel = new ComponentBlockModel();
            if (DataSourceItem != null)
            {
                componentBlockModel = new ComponentBlockModel(DataSourceItem);
            }
            else
            {
                componentBlockModel = new ComponentBlockModel(Sitecore.Context.Item);   
            }

            return View(Constants.Views.Paths.ComponentBlock, componentBlockModel);
        }


        public ActionResult GetComponentBlockGridView()
        {
            return View(Constants.Views.Paths.ComponentBlockGrid);
        }
    }
}