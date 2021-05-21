using Confitec.Users.Domain.Core.Entities;
using Confitec.Users.Infrastructure.Data.Context.SqlServer;
using Confitec.Users.Infrastructure.Data.Interfaces;

namespace Confitec.Users.Infrastructure.Data.Repositories
{
    public class EducationRepository : Repository<Education>, IEducationRepository
    {
        public EducationRepository(SqlServerContext dbContext) : base(dbContext)
        {
        }
    }
}
