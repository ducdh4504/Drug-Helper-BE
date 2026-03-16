using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.CourseID);

        builder.Property(c => c.Title).IsRequired().HasMaxLength(255);
        builder.Property(c => c.contentSummary).IsRequired().HasMaxLength(500);
        builder.Property(c => c.StartDate).IsRequired();
        builder.Property(c => c.EndDate).IsRequired();
        builder.Property(c => c.Status).HasConversion<string>().IsRequired().HasMaxLength(255);
        builder.Property(c => c.ResultLevel).HasConversion<string>().IsRequired().HasMaxLength(255);

        builder.Property(c => c.AgeMin);
        builder.Property(c => c.Capacity);
    }
}
