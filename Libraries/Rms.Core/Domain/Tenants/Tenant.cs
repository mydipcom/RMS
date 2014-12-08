using Rms.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Core.Domain.Tenants
{
    public partial class Tenant : BaseEntity
    {
        public string TenantName { get; set; }
  
        public string Alias { get; set; }

        public string MappedDomain { get; set; }

        public string Version { get; set; }

        public string VersionChange { get; set; }

        public string Language { get; set; }

        public string Timezone { get; set; } 

        public int StatusId { get; set; }

        public int IndustryId { get; set; }

        public bool IsPublic { get; set; }
        
        public DateTime StatusChanged { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastModified { get; set; }

        
    }
}
