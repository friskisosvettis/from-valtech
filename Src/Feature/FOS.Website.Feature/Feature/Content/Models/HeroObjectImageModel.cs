using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOS.Website.Feature.Content.Data;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using Synthesis;

namespace FOS.Website.Feature.Content.Models
{
    public class HeroObjectImageModel
    {
        public IHeroObjectImageItem HeroObjectImageItem = null;


        public HeroObjectImageModel(Item item)
        {
            var heroObject = RenderingContext.Current.Rendering.Item.As<IHeroObjectImageItem>();
            HeroObjectImageItem = (heroObject == null)
                ? Sitecore.Context.Item.As<IHeroObjectImageItem>()
                : heroObject;
        }
    }
}