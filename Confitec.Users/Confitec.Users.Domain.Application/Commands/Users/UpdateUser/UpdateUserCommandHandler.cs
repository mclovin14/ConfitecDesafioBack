using AutoMapper;
using Confitec.Users.Domain.Application.Configurations;
using Confitec.Users.Domain.Application.Core;
using Confitec.Users.Infrastructure.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Users.Domain.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : BaseHandler, IRequestHandler<UpdateUserCommand, Response>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository,
                                        IResponseService responseService,
                                        IMapper mapper) : base (responseService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await SafeExecuteAsync(async () => 
            {
                var user = await _userRepository.GetByIdAsync(request.Id);

                if (IsNull(user))
                    return _responseService.GetBadResponse("UserNotFound", "pt-BR");

                user = _mapper.Map(request, user);

                await _userRepository.UpdateAsync(user);

                return _responseService.GetSuccessResponse("UpdateSuccess", "pt-BR");
            });
        }
    }
}
