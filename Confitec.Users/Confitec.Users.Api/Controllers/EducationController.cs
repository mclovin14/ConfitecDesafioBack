using Confitec.Users.Domain.Application.Queries.Education;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Confitec.Users.Api.Controllers
{
    [Route("api/education")]
    public class EducationController : BaseController
    {
        public EducationController(ILogger<UserController> logger, IMediator mediator) : base(logger, mediator)
        {
        }


        /// <summary>
        ///   Get all Educations
        /// </summary>
        /// <returns> all Educations </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllEducationsAsync()
        {
            return await ExecuteAsync(new GetAllEducationsQuery());
        }
    }
}
