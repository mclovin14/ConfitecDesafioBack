using Confitec.Users.Domain.Core.Entities;
using Confitec.Users.Infrastructure.Data.Context.Maps;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Users.Infrastructure.Data.Context.SqlServer
{
    public class SqlServerContext : BaseContext
    {
        public SqlServerContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Education> Educations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EducationMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
