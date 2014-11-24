using System.Data.Entity.ModelConfiguration;
using Rms.Core.Domain.Common;

namespace Rms.Data.Mapping.Common
{
    public partial class SearchTermMap : EntityTypeConfiguration<SearchTerm>
    {
        public SearchTermMap()
        {
            this.ToTable("SearchTerm");
            this.HasKey(st => st.Id);
        }
    }
}
