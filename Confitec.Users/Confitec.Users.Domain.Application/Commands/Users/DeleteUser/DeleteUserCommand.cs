using Kamplish.Shared.Application.Core;

namespace Confitec.Users.Domain.Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommand : Request
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
