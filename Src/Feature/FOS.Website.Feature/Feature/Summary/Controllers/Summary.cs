using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOS.Website.Feature.Summary.Controllers
{
    public class Summary
    {
        //#region With fallback...
        //public static ItemAndFieldName GetSummaryHeadingWithFallback(Item item)
        //{
        //    ItemAndFieldName summaryHeadingWithFallback = new ItemAndFieldName();
        //    if (item == null)
        //    {
        //        return summaryHeadingWithFallback;
        //    }

        //    summaryHeadingWithFallback = GetSummaryHeading(item);
        //    if (summaryHeadingWithFallback.IsValidAndHasContent() || summaryHeadingWithFallback.IsValidAndEditMode())
        //    {
        //        return summaryHeadingWithFallback;
        //    }

        //    summaryHeadingWithFallback = BasicContent.GetBasicContentHeadline(item);
        //    return summaryHeadingWithFallback;
        //}

        //public static ItemAndFieldName GetSummaryImageWithFallback(Item item)
        //{
        //    ItemAndFieldName summaryImageWithFallback = new ItemAndFieldName();
        //    if (item == null)
        //    {
        //        return summaryImageWithFallback;
        //    }

        //    summaryImageWithFallback = GetSummaryImage(item);
        //    if (summaryImageWithFallback.IsValidAndHasContent() || summaryImageWithFallback.IsValidAndEditMode())
        //    {
        //        return summaryImageWithFallback;
        //    }

        //    SummarySettingsItem summarySettingsItem = Settings.GetSiteSettingCustomItem<SummarySettingsItem>(item);
        //    if (SummarySettingsItem.IsValid(summarySettingsItem) && summarySettingsItem.SummaryImageFallback.MediaItem != null)
        //    {
        //        summaryImageWithFallback.FieldName = summarySettingsItem.SummaryImageFallbackFieldName;
        //        summaryImageWithFallback.Item = summarySettingsItem.InnerItem;
        //    }

        //    return summaryImageWithFallback;
        //}

        //public static ItemAndFieldName GetSummaryImageWithFallbackFromDifferentContext(Item item, Item fallbackBaseItem)
        //{
        //    ItemAndFieldName summaryImageWithFallback = new ItemAndFieldName();
        //    if (item == null)
        //    {
        //        return summaryImageWithFallback;
        //    }

        //    summaryImageWithFallback = GetSummaryImage(item);
        //    if (summaryImageWithFallback.IsValidAndHasContent() || summaryImageWithFallback.IsValidAndEditMode())
        //    {
        //        return summaryImageWithFallback;
        //    }

        //    if (fallbackBaseItem != null)
        //    {
        //        SummarySettingsItem summarySettingsItem = Settings.GetSiteSettingCustomItem<SummarySettingsItem>(fallbackBaseItem);
        //        if (SummarySettingsItem.IsValid(summarySettingsItem) && summarySettingsItem.SummaryImageFallback.MediaItem != null)
        //        {
        //            summaryImageWithFallback.FieldName = summarySettingsItem.SummaryImageFallbackFieldName;
        //            summaryImageWithFallback.Item = summarySettingsItem.InnerItem;
        //        }
        //    }

        //    return summaryImageWithFallback;
        //}

        //public static ItemAndFieldName GetSummaryTextWithFallback(Item item)
        //{
        //    ItemAndFieldName summaryTextWithFallback = GetSummaryText(item);

        //    if (summaryTextWithFallback.IsValidAndHasContent() || summaryTextWithFallback.IsValidAndEditMode())
        //    {
        //        return summaryTextWithFallback;
        //    }

        //    summaryTextWithFallback = BasicContent.GetBasicContentIntroduction(item);
        //    return summaryTextWithFallback;
        //}

        //public static ItemAndFieldName GetSummaryTypeLabelWithFallback(Item item)
        //{
        //    ItemAndFieldName summaryTypeLabel = GetSummaryTypeLabel(item);

        //    if (summaryTypeLabel.IsValidAndHasContent() || summaryTypeLabel.IsValidAndEditMode())
        //    {
        //        return summaryTypeLabel;
        //    }
        //    summaryTypeLabel = new ItemAndFieldName(Dictionary.GetItem("/Summary/SummaryTypeLabels", item.TemplateName, item.TemplateName), DictionaryentryItem.PhraseConstFieldName);
        //    return summaryTypeLabel;
        //}

        //#endregion

        //public static ItemAndFieldName GetSummaryText(Item item)
        //{
        //    ItemAndFieldName summaryText = new ItemAndFieldName();
        //    if (item == null)
        //    {
        //        return summaryText;
        //    }

        //    if (SummaryItem.IsValid(item))
        //    {
        //        var summaryItem = new SummaryItem(item);
        //        summaryText.FieldName = summaryItem.SummaryTextFieldName;
        //        summaryText.Item = summaryItem.InnerItem;
        //    }

        //    return summaryText;
        //}

        //public static ItemAndFieldName GetSummaryImage(Item item)
        //{
        //    ItemAndFieldName summaryImage = new ItemAndFieldName();
        //    if (item == null)
        //    {
        //        return summaryImage;
        //    }

        //    if (SummaryItem.IsValid(item))
        //    {
        //        var summaryItem = new SummaryItem(item);
        //        summaryImage.FieldName = summaryItem.SummaryImageFieldName;
        //        summaryImage.Item = summaryItem.InnerItem;
        //    }

        //    return summaryImage;
        //}

        //public static ItemAndFieldName GetSummaryHeading(Item item)
        //{
        //    ItemAndFieldName summaryHeading = new ItemAndFieldName();
        //    if (item == null)
        //    {
        //        return summaryHeading;
        //    }

        //    if (SummaryItem.IsValid(item))
        //    {
        //        var summaryItem = new SummaryItem(item);
        //        summaryHeading.FieldName = summaryItem.SummaryHeadingFieldName;
        //        summaryHeading.Item = summaryItem.InnerItem;
        //    }

        //    return summaryHeading;
        //}

        //public static LinkurlAndText GetSummaryLink(Item item)
        //{
        //    LinkurlAndText summaryLink = new LinkurlAndText();

        //    if (item == null)
        //    {
        //        return summaryLink;
        //    }

        //    summaryLink.Linkurl = LinkManager.GetItemUrl(item);
        //    summaryLink.Text = string.Empty;

        //    if (CourseItem.IsValid(item))
        //    {
        //        var courseItem = new CourseItem(item);
        //        if (courseItem.CourseLink != null)
        //        {
        //            summaryLink.Linkurl = courseItem.CourseLink.Url;
        //        }
        //    }
        //    return summaryLink;
        //}

        //public static ItemAndFieldName GetSummaryTypeLabel(Item item)
        //{
        //    ItemAndFieldName summaryTypeLabel = new ItemAndFieldName();

        //    if (SummaryItem.IsValid(item))
        //    {
        //        SummaryItem summaryItem = new SummaryItem(item);
        //        summaryTypeLabel = new ItemAndFieldName(item, SummaryItem.CustomTypeTextConstFieldName);
        //    }
        //    return summaryTypeLabel;
        //}
    }
}