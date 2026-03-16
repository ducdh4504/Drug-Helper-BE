using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration
{
    public class CourseContentConfiguration : IEntityTypeConfiguration<CourseContent>
    {
        public void Configure(EntityTypeBuilder<CourseContent> builder)
        {
            builder.HasKey(cc => cc.CourseContentID);
            builder.Property(cc => cc.Title).IsRequired().HasMaxLength(255);
        }
    }
}
