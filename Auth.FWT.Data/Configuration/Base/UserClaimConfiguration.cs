using System.Data.Entity.ModelConfiguration;
using Auth.FWT.Core.DomainModels.Identity;

namespace Auth.FWT.Data.Base.Configuration
{
    public class UserClaimConfiguration : EntityTypeConfiguration<UserClaim>
    {
        public UserClaimConfiguration()
        {
            Property(x => x.ClaimType).IsRequired();
            Property(x => x.ClaimValue).IsRequired();
        }
    }
}