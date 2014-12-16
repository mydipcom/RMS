using System.ComponentModel.DataAnnotations;
using Rms.Web.Framework.Mvc;

namespace Rms.Web.Models.Tenants
{
    public class TenantsModel : BaseNopEntityModel
    {
        [Required(ErrorMessage = "Tenants.Fields.TenantName.Required")]
        public string TenantName { get; set; }

        [Required(ErrorMessage = "Tenants.Fields.MappedDomain.Required")]
        public string MappedDomain { get; set; }

        public string Version { get; set; }
        public string Timezone { get; set; }
        public bool IsPublic { get; set; }
        public string CreateDate { get; set; }
    }
}