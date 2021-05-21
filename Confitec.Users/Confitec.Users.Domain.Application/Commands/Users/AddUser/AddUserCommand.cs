using Kamplish.Shared.Application.Core;
using System;

namespace Confitec.Users.Domain.Application.Commands.Users.AddUser
{
    public class AddUserCommand : Request
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public int EducationId { get; set; }
    }
}
