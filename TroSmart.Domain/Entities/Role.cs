using TroSmart.Domain.Enums;

namespace TroSmart.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public RoleName Name { get; set; }
        public virtual ICollection<Account>? Accounts { get; set; }
    }
}