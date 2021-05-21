using Confitec.Users.Domain.Application.Commands.Users.DeleteUser;
using Confitec.Users.Domain.Application.Configurations;
using FluentValidation;

namespace Confitec.Users.Domain.Application.Queries.Users.GetUserById
{
    class GetUserByIdQueryValidator : AbstractValidator<DeleteUserCommand>
    {
        private readonly IResponseService _responseService;
        public GetUserByIdQueryValidator(IResponseService responseService)
        {
            _responseService = responseService;

            RuleFor(x => x.Id)
                    .NotEmpty().WithMessage(_responseService.GetNotification("FieldsFormValidate", "pr-BR"));
        }
    }
}
