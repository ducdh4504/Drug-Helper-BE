using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.HasKey(s => s.SurveyID);

            builder.Property(s => s.Title).HasMaxLength(255);
            builder.Property(s => s.Type).HasConversion<string>().HasMaxLength(255);
            builder.Property(s => s.Status).HasConversion<string>();

            builder.HasOne(s => s.User)
                   .WithMany(u => u.Surveys)
                   .HasForeignKey(s => s.UserID);
        }
    }
}
