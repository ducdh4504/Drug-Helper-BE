using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration;

public class CourseRegistrationConfiguration : IEntityTypeConfiguration<CourseRegistration>
{
    public void Configure(EntityTypeBuilder<CourseRegistration> builder)
    {
        builder.HasKey(cr => new { cr.UserID, cr.CourseID });

        builder.Property(cr => cr.RegisterTime).IsRequired();
        builder.Property(cr => cr.LearningStatus).HasConversion<string>().HasMaxLength(255).IsRequired();

        builder.HasOne(cr => cr.User)
               .WithMany(u => u.CourseRegistrations)
               .HasForeignKey(cr => cr.UserID);

        builder.HasOne(cr => cr.Course)
               .WithMany(c => c.CourseRegistrations)
               .HasForeignKey(cr => cr.CourseID);
    }
}
