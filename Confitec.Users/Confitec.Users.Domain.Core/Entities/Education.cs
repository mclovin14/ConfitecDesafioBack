using System.Collections.Generic;

namespace Confitec.Users.Domain.Core.Entities
{
    public class Education : BaseEntity
    {
        public string Description { get; private set; }
        public ICollection<User> Users { get; private set; }
    }
}
