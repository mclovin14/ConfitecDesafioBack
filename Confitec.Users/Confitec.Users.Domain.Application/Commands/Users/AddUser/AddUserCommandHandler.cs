using AutoMapper;
using Confitec.Users.Domain.Application.Configurations;
using Confitec.Users.Domain.Application.Core;
using Confitec.Users.Domain.Core.Entities;
using Confitec.Users.Infrastructure.Data.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Users.Domain.Application.Commands.Users.AddUser
{
    public class AddUserCommandHandler : BaseHandler, IRequestHandler<AddUserCommand, Response>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IUserRepository userRepository,
                                     IResponseService responseService,
                                     IMapper mapper) : base(responseService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return await SafeExecuteAsync(async () => 
            {
                var user = _mapper.Map<User>(request);

                await _userRepository.AddAsync(user);

                return _responseService.GetSuccessResponse("InsertSuccess", "pt-BR");
            });
        }
    }
}
