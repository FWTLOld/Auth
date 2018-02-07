namespace Auth.FWT.Core.Entities.Identity
{
    public class UserLogin : BaseEntity<int>
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        public virtual User User { get; set; }

        public int UserId { get; set; }
    }
}