using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey( user => user.Id);

            builder.HasIndex( user => user.Email)
                .IsUnique();

            builder.Property( user => user.Name)
                .IsRequired()
                .HasMaxLength(60);
            
            builder.Property( user => user.Email)
                .HasMaxLength(100);
        }
    }
}
