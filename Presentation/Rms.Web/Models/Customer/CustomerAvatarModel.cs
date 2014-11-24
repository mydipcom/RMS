using Rms.Web.Framework.Mvc;

namespace Rms.Web.Models.Customer
{
    public partial class CustomerAvatarModel : BaseNopModel
    {
        public string AvatarUrl { get; set; }
        public CustomerNavigationModel NavigationModel { get; set; }
    }
}