﻿using Rms.Web.Framework;
using Rms.Web.Framework.Mvc;

namespace Rms.Admin.Models.Settings
{
    public partial class MediaSettingsModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }



        [NopResourceDisplayName("Admin.Configuration.Settings.Media.PicturesStoredIntoDatabase")]
        public bool PicturesStoredIntoDatabase { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.Media.AvatarPictureSize")]
        public int AvatarPictureSize { get; set; }
        public bool AvatarPictureSize_OverrideForStore { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.Media.ProductThumbPictureSize")]
        public int ProductThumbPictureSize { get; set; }
        public bool ProductThumbPictureSize_OverrideForStore { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.Media.ProductDetailsPictureSize")]
        public int ProductDetailsPictureSize { get; set; }
        public bool ProductDetailsPictureSize_OverrideForStore { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.Media.ProductThumbPictureSizeOnProductDetailsPage")]
        public int ProductThumbPictureSizeOnProductDetailsPage { get; set; }
        public bool ProductThumbPictureSizeOnProductDetailsPage_OverrideForStore { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.Media.AssociatedProductPictureSize")]
        public int AssociatedProductPictureSize { get; set; }
        public bool AssociatedProductPictureSize_OverrideForStore { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.Media.CategoryThumbPictureSize")]
        public int CategoryThumbPictureSize { get; set; }
        public bool CategoryThumbPictureSize_OverrideForStore { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.Media.ManufacturerThumbPictureSize")]
        public int ManufacturerThumbPictureSize { get; set; }
        public bool ManufacturerThumbPictureSize_OverrideForStore { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.Media.CartThumbPictureSize")]
        public int CartThumbPictureSize { get; set; }
        public bool CartThumbPictureSize_OverrideForStore { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.Media.MiniCartThumbPictureSize")]
        public int MiniCartThumbPictureSize { get; set; }
        public bool MiniCartThumbPictureSize_OverrideForStore { get; set; }

        [NopResourceDisplayName("Admin.Configuration.Settings.Media.MaximumImageSize")]
        public int MaximumImageSize { get; set; }
        public bool MaximumImageSize_OverrideForStore { get; set; }
    }
}