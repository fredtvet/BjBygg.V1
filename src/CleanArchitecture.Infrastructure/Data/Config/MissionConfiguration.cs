using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Data.Config
{
    public class MissionConfiguration : BaseEntityConfiguration<Mission>
    {
        public override void Configure(EntityTypeBuilder<Mission> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.PhoneNumber).HasMaxLength(12);
            builder.Property(e => e.Description).HasMaxLength(400);
        }
    }
}
