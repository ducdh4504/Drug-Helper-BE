using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Persistence.Seeding
{
    public static class SeedingConsultantSchedule
    {
        public static void SeedConsultantSchedule(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultantSchedule>().HasData(
                // 2 schedules linked to accepted appointments
                new ConsultantSchedule
                {
                    ConsultantScheduleID = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    AppointmentID = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    DayOfWeek = DayOfWeekEnum.Tuesday,
                    Date = new DateTime(2025, 9, 2),
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    IsAvailable = false,
                    Notes = "Attending a drug addiction seminar at the center."
                },
                new ConsultantSchedule
                {
                    ConsultantScheduleID = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000002"), 
                    AppointmentID = Guid.Parse("20000000-0000-0000-0000-000000000005"), 
                    DayOfWeek = DayOfWeekEnum.Friday,
                    Date = new DateTime(2025, 9, 5),
                    StartTime = new TimeSpan(11, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    IsAvailable = false,
                    Notes = "Providing direct counseling to a patient."
                },
                // 8 schedules not linked to accepted appointments
                new ConsultantSchedule
                {
                    ConsultantScheduleID = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    AppointmentID = null,
                    DayOfWeek = DayOfWeekEnum.Monday,
                    Date = new DateTime(2025, 9, 1),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    IsAvailable = false,
                    Notes = "Participating in internal training on counseling skills."
                },
                new ConsultantSchedule
                {
                    ConsultantScheduleID = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    AppointmentID = null,
                    DayOfWeek = DayOfWeekEnum.Wednesday,
                    Date = new DateTime(2025, 9, 3),
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    IsAvailable = false,
                    Notes = "Attending a professional meeting with psychologists."
                },
                new ConsultantSchedule
                {
                    ConsultantScheduleID = Guid.Parse("30000000-0000-0000-0000-000000000005"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    AppointmentID = null,
                    DayOfWeek = DayOfWeekEnum.Thursday,
                    Date = new DateTime(2025, 9, 4),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    IsAvailable = false,
                    Notes = "Preparing progress reports for the center management."
                },
                new ConsultantSchedule
                {
                    ConsultantScheduleID = Guid.Parse("30000000-0000-0000-0000-000000000006"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    AppointmentID = null,
                    DayOfWeek = DayOfWeekEnum.Friday,
                    Date = new DateTime(2025, 9, 5),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(9, 0, 0),
                    IsAvailable = false,
                    Notes = "Participating in a drug prevention communication program."
                },
                new ConsultantSchedule
                {
                    ConsultantScheduleID = Guid.Parse("30000000-0000-0000-0000-000000000007"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    AppointmentID = null,
                    DayOfWeek = DayOfWeekEnum.Saturday,
                    Date = new DateTime(2025, 9, 6),
                    StartTime = new TimeSpan(13, 0, 0),
                    EndTime = new TimeSpan(14, 0, 0),
                    IsAvailable = false,
                    Notes = "Attending a workshop to share counseling experiences."
                },
                new ConsultantSchedule
                {
                    ConsultantScheduleID = Guid.Parse("30000000-0000-0000-0000-000000000008"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    AppointmentID = null,
                    DayOfWeek = DayOfWeekEnum.Sunday,
                    Date = new DateTime(2025, 9, 7),
                    StartTime = new TimeSpan(15, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    IsAvailable = false,
                    Notes = "Joining community support extracurricular activities."
                },
                new ConsultantSchedule
                {
                    ConsultantScheduleID = Guid.Parse("30000000-0000-0000-0000-000000000009"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    AppointmentID = null,
                    DayOfWeek = DayOfWeekEnum.Monday,
                    Date = new DateTime(2025, 9, 8),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(10, 0, 0),
                    IsAvailable = false,
                    Notes = "Conducting group counseling for new patients."
                },
                new ConsultantSchedule
                {
                    ConsultantScheduleID = Guid.Parse("30000000-0000-0000-0000-000000000010"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    AppointmentID = null,
                    DayOfWeek = DayOfWeekEnum.Tuesday,
                    Date = new DateTime(2025, 9, 9),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    IsAvailable = false,
                    Notes = "Attending a soft skills training program for consultants."
                }
            );
        }
    }
}
