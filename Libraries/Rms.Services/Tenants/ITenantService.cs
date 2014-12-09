using Rms.Core;
using Rms.Core.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Services.Tenants
{
   
     public partial interface ITenantService
     {

         Tenant GetTenantById(int tenantId);


         void DeleteTenant(Tenant tenant);


         IPagedList<Tenant> GetAllTenantss(int pageIndex, int pageSize, bool showHidden = false);


         void InsertTenant(Tenant tenant);


         void UpdateTenant(Tenant tenant);

 
    }
}