using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rms.Core.Domain.Groups;

namespace Rms.Data.Mapping.Groups
{
    public partial class GroupMap : EntityTypeConfiguration<Group>
    {
        public GroupMap()
        {
            this.ToTable("Group");
            this.HasKey(a => a.Id);

        }
    }
}