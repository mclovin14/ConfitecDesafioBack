using Confitec.Users.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Users.Infrastructure.Data.Context.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                  .HasColumnName("Id");

            builder.Property(x => x.Name)
                .HasColumnName("Name").IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email").IsRequired();

            builder.Property(x => x.Surname)
                .HasColumnName("Surname").IsRequired();

            builder.Property(x => x.EducationId)
                .HasColumnName("EducationId").IsRequired();
            
            builder.Property(x => x.BirthDate)
                .HasColumnName("BirthDate").IsRequired();

            builder.Property(x => x.InsertAt)
                .HasColumnName("InsertAt");

            builder.Property(x => x.UpdateAt)
                .HasColumnName("UpdateAt");

            builder.HasOne(x => x.Education)
               .WithMany(y => y.Users)
               .HasForeignKey(x => x.EducationId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();
        }
    }
}
