using Rms.Web.Framework.Mvc;

namespace Rms.Web.Models.Customer
{
    public partial class BackInStockSubscriptionModel : BaseNopEntityModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SeName { get; set; }
    }
}
