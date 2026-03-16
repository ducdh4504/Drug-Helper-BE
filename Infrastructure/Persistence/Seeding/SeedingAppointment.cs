using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Seeding
{
    public static class SeedingAppointment
    {
        public static void SeedAppointment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasData(
                // Member 1 appointments
                new Appointment
                {
                    AppointmentID = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                    MemberID = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                    ConsultantID = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    StartTime = new DateTime(2025, 9, 1, 9, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 9, 1, 10, 0, 0, DateTimeKind.Utc),
                    Date = new DateTime(2025, 9, 1, 0, 0, 0, DateTimeKind.Utc),
                    Status = AppointmentResponseEnum.NoResponseYet,
                    Note = "Discuss prevention strategies"
                },
                new Appointment
                {
                    AppointmentID = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    MemberID = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                    ConsultantID = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    StartTime = new DateTime(2025, 9, 2, 14, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 9, 2, 15, 0, 0, DateTimeKind.Utc),
                    Date = new DateTime(2025, 9, 2, 0, 0, 0, DateTimeKind.Utc),
                    Status = AppointmentResponseEnum.Accepted,
                    Note = "Follow-up session"
                },
                new Appointment
                {
                    AppointmentID = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                    MemberID = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                    ConsultantID = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    StartTime = new DateTime(2025, 9, 3, 14, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 9, 3, 15, 0, 0, DateTimeKind.Utc),
                    Date = new DateTime(2025, 9, 3, 0, 0, 0, DateTimeKind.Utc),
                    Status = AppointmentResponseEnum.Rejected,
                    Note = "Consultation on family support"
                },
                // Member 2 appointments
                new Appointment
                {
                    AppointmentID = Guid.Parse("20000000-0000-0000-0000-000000000004"),
                    MemberID = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                    ConsultantID = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    StartTime = new DateTime(2025, 9, 4, 9, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 9, 4, 10, 0, 0, DateTimeKind.Utc),
                    Date = new DateTime(2025, 9, 4, 0, 0, 0, DateTimeKind.Utc),
                    Status = AppointmentResponseEnum.NoResponseYet,
                    Note = "Initial consultation"
                },
                new Appointment
                {
                    AppointmentID = Guid.Parse("20000000-0000-0000-0000-000000000005"),
                    MemberID = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                    ConsultantID = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    StartTime = new DateTime(2025, 9, 5, 11, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 9, 5, 12, 0, 0, DateTimeKind.Utc),
                    Date = new DateTime(2025, 9, 5, 0, 0, 0, DateTimeKind.Utc),
                    Status = AppointmentResponseEnum.Accepted,
                    Note = "Progress review"
                },
                new Appointment
                {
                    AppointmentID = Guid.Parse("20000000-0000-0000-0000-000000000006"),
                    MemberID = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                    ConsultantID = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    StartTime = new DateTime(2025, 9, 6, 14, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2025, 9, 6, 15, 0, 0, DateTimeKind.Utc),
                    Date = new DateTime(2025, 9, 6, 0, 0, 0, DateTimeKind.Utc),
                    Status = AppointmentResponseEnum.Rejected,
                    Note = "Discuss prevention plan"
                }
            );
        }
    }
}
