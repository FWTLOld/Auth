using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace Auth.FWT.Domain.Entities.Identity
{
    public class UserRole : BaseEntity<byte>, IRole<byte>
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<RoleClaim> Claims { get; set; }
    }
}
