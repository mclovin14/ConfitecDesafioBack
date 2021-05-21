using Confitec.Users.Domain.Core.Entities;
using Confitec.Users.Domain.Core.Responses;
using Confitec.Users.Infrastructure.Data.Context.SqlServer;
using Confitec.Users.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confitec.Users.Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SqlServerContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<UserResponse>> GetAllUsersAsync()
        {
            return await BaseQuery().Select(x => new UserResponse
            {
                Id = x.Id,
                Email = x.Email,
                BirthDate = x.BirthDate.ToString("yyyy-MM-dd"),
                Name = x.Name,
                Surname = x.Surname,
                Education = x.Education.Description
            }).ToListAsync();
        }

        public async Task<UserResponse> GetUserByIdAsync(int id)
        {
            return await BaseQuery().Where(x => x.Id == id).Select(x => new UserResponse
            {
                Id = x.Id,
                Email = x.Email,
                BirthDate = x.BirthDate.ToString("yyyy-MM-dd"),
                Name = x.Name,
                Surname = x.Surname,
                EducationId = x.EducationId
            }).FirstOrDefaultAsync();
        }

        private IIncludableQueryable<User, Education> BaseQuery()
        {
            return DbSet.Include(x => x.Education);
        }
    }
}
