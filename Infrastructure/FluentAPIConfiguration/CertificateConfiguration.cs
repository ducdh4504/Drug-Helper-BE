using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration;

public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.HasKey(c => c.CertificateID);

        builder.Property(c => c.CertificateName).HasMaxLength(255);
        builder.Property(c => c.Status).HasConversion<string>().IsRequired().HasMaxLength(255);

        builder.HasOne(c => c.User)
               .WithMany(u => u.Certificates)
               .HasForeignKey(c => c.UserID);
    }
}
