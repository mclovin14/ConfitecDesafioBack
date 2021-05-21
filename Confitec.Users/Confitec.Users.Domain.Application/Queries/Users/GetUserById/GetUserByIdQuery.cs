using Kamplish.Shared.Application.Core;

namespace Confitec.Users.Domain.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQuery : Request
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
