using System;

namespace Confitec.Users.Domain.Core.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }

        public int EducationId { get; private set; }
        public Education Education { get; private set; }
    }
}
