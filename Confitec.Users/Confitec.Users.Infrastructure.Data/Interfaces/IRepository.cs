using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Users.Infrastructure.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity _obj);
        Task UpdateAsync(TEntity _obj);
        Task DeleteAsync(TEntity _obj);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
    }
}
