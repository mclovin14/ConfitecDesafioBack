using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Confitec.Users.Domain.Application.Core;
using Confitec.Users.Domain.Core.Enums;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Confitec.Users.Domain.Application.Commands.Behaviors
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : Response
    {
        private readonly IEnumerable<IValidator> _validators;

        public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any()
                ? Errors(failures)
                : next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new Response();

            foreach (var failure in failures)
            {
                var notification = new Notification( failure.ErrorMessage, NotificationType.Error);
                response.AddNotification(notification);
            }

            return Task.FromResult(response as TResponse);
        }
    }
}