using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjAgil.Dominio.Identity;

namespace ProjAgil.Infra.Data.IdentityMappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();

            builder.HasOne(x => x.User)
               .WithMany(x => x.UserRoles)
               .HasForeignKey(x => x.UserId)
               .IsRequired();
        }
    }
}
