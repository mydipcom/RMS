using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rms.Core.Domain.Common;

namespace Rms.Data.Mapping.Common
{
    
    public partial class IndustryMap : EntityTypeConfiguration<Industry>
    {
        public IndustryMap()
        {
            this.ToTable("Industry");
            this.HasKey(a => a.Id); 
        }
    }
}
