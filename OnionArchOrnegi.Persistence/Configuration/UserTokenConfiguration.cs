using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchOrnegi.Domain.Identity;

namespace OnionArchOrnegi.Persistance.Configurations;

public sealed class UserTokenConfiguration : IEntityTypeConfiguration<AppUserToken>
{
    public void Configure(EntityTypeBuilder<AppUserToken> builder)
    {
        builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

        builder.Property(t => t.LoginProvider).HasMaxLength(191);
        builder.Property(t => t.Name).HasMaxLength(191);

        builder.ToTable("UserTokens");
    }
}