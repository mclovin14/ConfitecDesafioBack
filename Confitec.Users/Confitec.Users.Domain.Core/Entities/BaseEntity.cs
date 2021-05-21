using System;

namespace Confitec.Users.Domain.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime InsertAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
    }
}
