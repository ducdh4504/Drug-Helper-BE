using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration;

public class ProgramParticipationConfiguration : IEntityTypeConfiguration<ProgramParticipation>
{
    public void Configure(EntityTypeBuilder<ProgramParticipation> builder)
    {
        builder.HasKey(pp => new { pp.UserID, pp.ProgramID });

        builder.Property(u => u.Status)
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(pp => pp.User)
               .WithMany(u => u.Participations)
               .HasForeignKey(pp => pp.UserID);

        builder.HasOne(pp => pp.CommunicationProgram)
               .WithMany(p => p.Participants)
               .HasForeignKey(pp => pp.ProgramID);
    }
}
