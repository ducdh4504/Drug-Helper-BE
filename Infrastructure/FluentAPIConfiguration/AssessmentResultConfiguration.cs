using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration;

public class AssessmentResultConfiguration : IEntityTypeConfiguration<AssessmentResult>
{
    public void Configure(EntityTypeBuilder<AssessmentResult> builder)
    {
        builder.HasKey(ar => ar.ResultID);

        builder.Property(ar => ar.ResultLevel).HasConversion<string>().IsRequired().HasMaxLength(255);
        builder.Property(ar => ar.Score).IsRequired();

        builder.HasOne(ar => ar.Assessment)
               .WithMany(a => a.AssessmentResults)
               .HasForeignKey(ar => ar.AssessmentID);

        builder.HasOne(ar => ar.User)
               .WithMany(u => u.AssessmentResults)
               .HasForeignKey(ar => ar.UserID);
    }
}
