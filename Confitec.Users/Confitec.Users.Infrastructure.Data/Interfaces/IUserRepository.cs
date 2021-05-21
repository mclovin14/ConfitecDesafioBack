using Confitec.Users.Domain.Core.Entities;
using Confitec.Users.Domain.Core.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Users.Infrastructure.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<UserResponse>> GetAllUsersAsync();
        Task<UserResponse> GetUserByIdAsync(int id);
    }
}
