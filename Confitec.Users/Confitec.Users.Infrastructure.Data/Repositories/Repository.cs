using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confitec.Users.Infrastructure.Data.Context.SqlServer;
using Confitec.Users.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Users.Infrastructure.Data.Repositories
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Property

        protected readonly BaseContext Context;
        protected DbSet<TEntity> DbSet;
        public Repository(BaseContext dbContext)
        {
            Context = dbContext;
            DbSet = Context.Set<TEntity>();
        }

        #endregion

        #region # Methods

        public async Task AddAsync(TEntity _obj)
        {
            await Context.Set<TEntity>().AddAsync(_obj);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task DeleteAsync(TEntity _obj)
        {
            Context.Set<TEntity>().Remove(_obj);
            Context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity _obj)
        {
            Context.Entry(_obj).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }
        #endregion
    }
}