using Confitec.Users.Domain.Application.Core;
using MediatR;
using System;

namespace Kamplish.Shared.Application.Core
{
    public class Request : IRequest<Response>, IBaseRequest
    {
    }
}
