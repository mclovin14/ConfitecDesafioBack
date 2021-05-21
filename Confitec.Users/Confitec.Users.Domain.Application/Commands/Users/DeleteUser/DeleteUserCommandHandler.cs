using Confitec.Users.Domain.Application.Commands.Users.DeleteUser;
using Confitec.Users.Domain.Application.Configurations;
using Confitec.Users.Domain.Application.Core;
using Confitec.Users.Infrastructure.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Users.Domain.Application.Commands.DeleteUser
{
    class DeleteUserCommandHandler : BaseHandler, IRequestHandler<DeleteUserCommand, Response>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository,
                                     IResponseService responseService) : base(responseService)
        {
            _userRepository = userRepository;
        }

        public async Task<Response> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await SafeExecuteAsync(async () => {
                var user = await _userRepository.GetByIdAsync(request.Id);

                if (IsNull(user))
                    return _responseService.GetBadResponse("EntityNotFound", "pt-BR");

                await _userRepository.DeleteAsync(user);

                return _responseService.GetSuccessResponse("Success", "pt-BR");
            });
        }
    }
}
