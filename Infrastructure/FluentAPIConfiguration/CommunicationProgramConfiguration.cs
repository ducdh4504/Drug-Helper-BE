using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration;

public class CommunicationProgramConfiguration : IEntityTypeConfiguration<CommunicationProgram>
{
    public void Configure(EntityTypeBuilder<CommunicationProgram> builder)
    {
        builder.HasKey(p => p.ProgramID);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.LocationType).HasConversion<string>().IsRequired().HasMaxLength(255);
        builder.Property(p => p.Location).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Speaker).HasMaxLength(255);
        builder.Property(u => u.Status)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(255);
    }
}
