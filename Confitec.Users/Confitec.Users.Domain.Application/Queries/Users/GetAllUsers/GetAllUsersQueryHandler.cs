using Confitec.Users.Domain.Application.Configurations;
using Confitec.Users.Domain.Application.Core;
using Confitec.Users.Infrastructure.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Users.Domain.Application.Queries.Users.GetAllUsers
{
    public class GetAllUsersQueryHandler : BaseHandler, IRequestHandler<GetAllUsersQuery, Response>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository,
                                     IResponseService responseService) : base(responseService)
        {
            _userRepository = userRepository;
        }

        public async Task<Response> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await SafeExecuteAsync(async () =>
            {
                var users = await _userRepository.GetAllUsersAsync();

                return _responseService.GetSuccessResponse(users);
            });
        }
    }
}
