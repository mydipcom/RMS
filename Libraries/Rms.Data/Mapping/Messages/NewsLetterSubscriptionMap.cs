using System.Data.Entity.ModelConfiguration;
using Rms.Core.Domain.Messages;

namespace Rms.Data.Mapping.Messages
{
    public partial class NewsLetterSubscriptionMap : EntityTypeConfiguration<NewsLetterSubscription>
    {
        public NewsLetterSubscriptionMap()
        {
            this.ToTable("NewsLetterSubscription");
            this.HasKey(nls => nls.Id);

            this.Property(nls => nls.Email).IsRequired().HasMaxLength(255);
        }
    }
}