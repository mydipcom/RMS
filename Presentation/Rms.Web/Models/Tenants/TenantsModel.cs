using Rms.Web.Framework.Mvc;

namespace Rms.Web.Models.Tenants
{
    public class TenantsModel : BaseNopEntityModel
    { 
        public string TenantName { get; set; }
        public string MappedDomain { get; set; }
        public string Version { get; set; }
        public string Timezone { get; set; }
        public bool IsPublic { get; set; }
        public string CreateDate { get; set; }
    }
}