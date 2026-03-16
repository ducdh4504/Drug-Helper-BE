using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.BlogID);

            builder.Property(b => b.Status).HasConversion<string>().IsRequired().HasMaxLength(255);
            builder.Property(b => b.ResultLevel).HasConversion<string>().IsRequired().HasMaxLength(255);
            builder.Property(b => b.Title).HasMaxLength(255);
            

            builder.HasOne(b => b.User)
                   .WithMany(u => u.Blogs)
                   .HasForeignKey(b => b.UserID);
        }
    }
}
