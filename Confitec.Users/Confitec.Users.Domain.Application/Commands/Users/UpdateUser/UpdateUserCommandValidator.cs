using Confitec.Users.Domain.Application.Configurations;
using FluentValidation;
using System;

namespace Confitec.Users.Domain.Application.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IResponseService _responseService;

        public UpdateUserCommandValidator(IResponseService responseService)
        {
            _responseService = responseService;

            RuleFor(x => x.Id)
                    .NotEmpty().WithMessage(_responseService.GetNotification("FieldsFormValidate", "pt-BR"));

            RuleFor(x => x.Email)
                  .NotEmpty().WithMessage(_responseService.GetNotification("FieldsFormValidate", "pt-BR"))
                  .EmailAddress().WithMessage(_responseService.GetNotification("EmailValidate", "pt-BR"));

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage(_responseService.GetNotification("FieldsFormValidate", "pt-BR"))
                .LessThan(DateTime.Now).WithMessage(_responseService.GetNotification("BirthDateValidate", "pt-BR"));

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_responseService.GetNotification("FieldsFormValidate", "pt-BR"))
                .MaximumLength(100).WithMessage(_responseService.GetNotification("FieldsLengthFormValidate", "pt-BR"));

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(_responseService.GetNotification("FieldsFormValidate", "pt-BR"))
                .MaximumLength(100).WithMessage(_responseService.GetNotification("FieldsLengthFormValidate", "pt-BR"));

            RuleFor(x => x.EducationId)
                .NotEmpty().WithMessage(_responseService.GetNotification("FieldsFormValidate", "pt-BR"));
        }
    }
}
