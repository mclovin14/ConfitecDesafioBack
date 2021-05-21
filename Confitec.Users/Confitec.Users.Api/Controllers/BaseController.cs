using Confitec.Users.Domain.Application.Core;
using Confitec.Users.Domain.Core.Enums;
using Kamplish.Shared.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Users.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public BaseController(ILogger logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        protected async Task<IActionResult> ExecuteAsync(Request request)
        {
            var response = await _mediator.Send(request) as Response;
            if (response.Notifications.Any(x => x.Type == NotificationType.Error))
                return BadRequest(response);
            return Ok(response);
        }
    }
}
