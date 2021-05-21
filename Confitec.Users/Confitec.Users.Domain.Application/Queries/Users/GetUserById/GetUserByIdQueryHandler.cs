using Confitec.Users.Domain.Application.Configurations;
using Confitec.Users.Domain.Application.Core;
using Confitec.Users.Infrastructure.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Users.Domain.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQueryHandler : BaseHandler, IRequestHandler<GetUserByIdQuery, Response>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository,
                                     IResponseService responseService) : base(responseService)
        {
            _userRepository = userRepository;
        }

        public async Task<Response> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await SafeExecuteAsync(async () => {
                var user = await _userRepository.GetUserByIdAsync(request.Id);

                if (IsNull(user))
                    return _responseService.GetBadResponse("EntityNotFound", "pt-BR");

                return _responseService.GetSuccessResponse(user);
            });
        }
    }
}
