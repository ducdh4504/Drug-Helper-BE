using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.FluentAPIConfiguration;

public class ConsultantScheduleConfiguration : IEntityTypeConfiguration<ConsultantSchedule>
{
    public void Configure(EntityTypeBuilder<ConsultantSchedule> builder)
    {
        builder.HasKey(cs => cs.ConsultantScheduleID);

        builder.Property(cs => cs.DayOfWeek).HasConversion<string>().IsRequired().HasMaxLength(255);

        builder.Property(cs => cs.Date).IsRequired();
        builder.Property(cs => cs.StartTime).IsRequired();
        builder.Property(cs => cs.EndTime).IsRequired();
        builder.Property(cs => cs.IsAvailable).IsRequired();

        builder.HasOne(cs => cs.User)
               .WithMany(u => u.ConsultantSchedules)
               .HasForeignKey(cs => cs.UserID);

        builder.HasOne(cs => cs.Appointment)
               .WithMany(a => a.ConsultantSchedules)
               .HasForeignKey(cs => cs.AppointmentID)
               .IsRequired(false) 
               .OnDelete(DeleteBehavior.Restrict);
    }
}
