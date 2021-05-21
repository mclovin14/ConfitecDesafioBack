using Confitec.Users.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confitec.Users.Infrastructure.Data.Context.Maps
{
    public class EducationMap : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("Education", "dbo");
            
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id)
                .HasColumnName("Id");
           
            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(30);

            builder.Property(x => x.InsertAt)
                .HasColumnName("InsertAt");

            builder.Property(x => x.UpdateAt)
                .HasColumnName("UpdateAt");
        }
    }
}

