using Confitec.Users.Domain.Application.Commands.Users.DeleteUser;
using Confitec.Users.Domain.Application.Configurations;
using FluentValidation;

namespace Confitec.Users.Domain.Application.Commands.DeleteUser
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        private readonly IResponseService _responseService;
        public DeleteUserCommandValidator(IResponseService responseService)
        {
            _responseService = responseService;

            RuleFor(x => x.Id)
                    .NotEmpty().WithMessage(_responseService.GetNotification("FieldsFormValidate", "pt-BR"));
        }
    }
}
