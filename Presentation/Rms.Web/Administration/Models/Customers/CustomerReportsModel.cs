﻿using Rms.Web.Framework.Mvc;

namespace Rms.Admin.Models.Customers
{
    public partial class CustomerReportsModel : BaseNopModel
    {
        public BestCustomersReportModel BestCustomersByOrderTotal { get; set; }
        public BestCustomersReportModel BestCustomersByNumberOfOrders { get; set; }
    }
}