using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(a => a.AppointmentID);

        builder.Property(a => a.StartTime).IsRequired();
        builder.Property(a => a.EndTime).IsRequired();
        builder.Property(a => a.Date).IsRequired();
        builder.Property(a => a.Status).HasConversion<string>().IsRequired().HasMaxLength(255);

        builder.HasOne(a => a.Member)
               .WithMany(u => u.Appointments)
               .HasForeignKey(a => a.MemberID).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Consultant)
               .WithMany()
               .HasForeignKey(a => a.ConsultantID)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
