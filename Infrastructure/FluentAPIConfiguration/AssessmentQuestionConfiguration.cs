using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration;

public class AssessmentQuestionConfiguration : IEntityTypeConfiguration<AssessmentQuestion>
{
    public void Configure(EntityTypeBuilder<AssessmentQuestion> builder)
    {
        builder.HasKey(aq => new { aq.AssessmentID, aq.QuestionID });

        builder.HasOne(aq => aq.Assessment)
               .WithMany(a => a.AssessmentQuestions)
               .HasForeignKey(aq => aq.AssessmentID);

        builder.HasOne(aq => aq.Question)
               .WithMany(q => q.AssessmentQuestions)
               .HasForeignKey(aq => aq.QuestionID);
    }
}
