using System.Data.Entity.ModelConfiguration;
using Rms.Core.Domain.Customers;

namespace Rms.Data.Mapping.Customers
{
    public partial class CustomerAttributeMap : EntityTypeConfiguration<CustomerAttribute>
    {
        public CustomerAttributeMap()
        {
            this.ToTable("CustomerAttribute");
            this.HasKey(ca => ca.Id);
            this.Property(ca => ca.Name).IsRequired().HasMaxLength(400);

            this.Ignore(ca => ca.AttributeControlType);
        }
    }
}