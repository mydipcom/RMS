using Rms.Web.Framework;
using Rms.Web.Framework.Mvc;

namespace Rms.Admin.Models.Customers
{
    public partial class RegisteredCustomerReportLineModel : BaseNopModel
    {
        [NopResourceDisplayName("Admin.Customers.Reports.RegisteredCustomers.Fields.Period")]
        public string Period { get; set; }

        [NopResourceDisplayName("Admin.Customers.Reports.RegisteredCustomers.Fields.Customers")]
        public int Customers { get; set; }
    }
}