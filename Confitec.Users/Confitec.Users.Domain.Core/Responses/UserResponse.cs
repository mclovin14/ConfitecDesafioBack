using System;

namespace Confitec.Users.Domain.Core.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string Education { get; set; }
        public int EducationId { get; set; }
    }
}
