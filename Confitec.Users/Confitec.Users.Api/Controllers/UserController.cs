using Confitec.Users.Domain.Application.Commands.UpdateUser;
using Confitec.Users.Domain.Application.Commands.Users.AddUser;
using Confitec.Users.Domain.Application.Commands.Users.DeleteUser;
using Confitec.Users.Domain.Application.Queries.Users.GetAllUsers;
using Confitec.Users.Domain.Application.Queries.Users.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Confitec.Users.Api.Controllers
{
    [Route("api/users")]
    public class UserController : BaseController
    {
        public UserController(ILogger<UserController> logger, IMediator mediator) : base(logger, mediator)
        {
        }

        /// <summary>
        ///  Add new User
        /// </summary>
        /// <param name="command"> json containing the fields to Add the user </param>
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] AddUserCommand command)
        {
            return await ExecuteAsync(command);
        }


        /// <summary>
        ///  Update User
        /// </summary>
        /// <param name="command"> json containing the fields to update the User </param>
        /// <param name="id"> User identifier </param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            return await ExecuteAsync(command);
        }

        /// <summary>
        ///   Delete User by id
        /// </summary>
        /// <param name="id"> User identifier </param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            return await ExecuteAsync(new DeleteUserCommand(id));
        }

        /// <summary>
        ///   Get User by id
        /// </summary>
        /// <param name="id"> User identifier </param>
        /// <returns> User </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            return await ExecuteAsync(new GetUserByIdQuery(id));
        }

        /// <summary>
        ///   Get all Users
        /// </summary>
        /// <returns> all Users </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            return await ExecuteAsync(new GetAllUsersQuery());
        }
    }
}


