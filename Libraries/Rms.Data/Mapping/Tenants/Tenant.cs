using Rms.Core.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rms.Data.Mapping.Tenants
{
    public partial class TenantMap : EntityTypeConfiguration<Tenant>
    {
        public TenantMap()
        {
            this.ToTable("Tenant");
            this.HasKey(a => a.Id);
        }
    }
}