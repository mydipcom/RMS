using Rms.Admin.Models.Common;
using Rms.Web.Framework.Mvc;

namespace Rms.Admin.Models.Customers
{
    public partial class CustomerAddressModel : BaseNopModel
    {
        public int CustomerId { get; set; }

        public AddressModel Address { get; set; }
    }
}