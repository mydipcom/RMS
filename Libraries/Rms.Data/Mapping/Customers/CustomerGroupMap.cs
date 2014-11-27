using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rms.Core.Domain.Customers;

namespace Rms.Data.Mapping.Customers
{
    public partial class CustomerGroupMap : EntityTypeConfiguration<CustomerGrop>
    {
        public CustomerGroupMap()
        {
            this.ToTable("Customer_Group_Mapping");
            this.HasKey(cg => cg.Id);
            
            this.HasRequired(cg => cg.Group)
                .WithMany()
                .HasForeignKey(cg => cg.GroupId);

            this.HasRequired(cg => cg.Customer)
               .WithMany(c => c.CustomerGroupes)
               .HasForeignKey(cg => cg.CustomerId);
        }
    }
}