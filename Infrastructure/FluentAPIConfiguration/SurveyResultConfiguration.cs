using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration;

public class SurveyResultConfiguration : IEntityTypeConfiguration<SurveyResult>
{
    public void Configure(EntityTypeBuilder<SurveyResult> builder)
    {
        builder.HasKey(sr => new { sr.SurveyID, sr.ProgramID});

        builder.HasOne(sr => sr.Survey)
               .WithMany(s => s.SurveyResults)
               .HasForeignKey(sr => sr.SurveyID);

        builder.HasOne(sr => sr.CommunicationProgram)
               .WithMany(cp => cp.SurveyResults)
               .HasForeignKey(sr => sr.ProgramID);

        builder.HasOne(s => s.User)
                   .WithOne()
                   .HasForeignKey<SurveyResult>(sr => sr.UserID)
                   .IsRequired(false);
        builder.HasIndex(sr => sr.UserID).IsUnique();
    }
}
