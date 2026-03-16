using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Seeding
{
    public static class SeedingCourse
    {
        public static void SeedCourse(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Title = "Introduction to Drug Prevention",
                    contentSummary = "Overview of drug prevention basics.",
                    Description = "Basic knowledge to prevent drug abuse.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/courseImage%2Fcourse1.png?alt=media&token=9739c97e-6bca-4d94-a09c-11ac5886fdd1",
                    StartDate = new DateTime(2023, 1, 10, 8, 0, 0, DateTimeKind.Utc),
                    EndDate = new DateTime(2023, 4, 10, 17, 0, 0, DateTimeKind.Utc),
                    Status = ActivityStatusEnum.Active,
                    ResultLevel = AssessmentResultEnum.Low,
                    AgeMin = 15,
                    Capacity = 30
                },
                new Course
                {
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Title = "Understanding Drug Addiction",
                    contentSummary = "Causes and effects of addiction.",
                    Description = "Learn about the causes and effects of drug addiction.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/courseImage%2Fcourse2.png?alt=media&token=1340a031-239c-481d-bc63-7642ad069b27",
                    StartDate = new DateTime(2023, 2, 5, 8, 0, 0, DateTimeKind.Utc),
                    EndDate = new DateTime(2023, 5, 5, 17, 0, 0, DateTimeKind.Utc),
                    Status = ActivityStatusEnum.Active,
                    ResultLevel = AssessmentResultEnum.Medium,
                    AgeMin = 16,
                    Capacity = 25
                },
                new Course
                {
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Title = "Youth and Drug Prevention",
                    contentSummary = "Prevention strategies for youth.",
                    Description = "Strategies for youth to avoid drug abuse.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/courseImage%2Fcourse3.png?alt=media&token=eaa3e3d3-1772-446e-984c-04e59943ac49",
                    StartDate = new DateTime(2023, 3, 1, 8, 0, 0, DateTimeKind.Utc),
                    EndDate = new DateTime(2023, 6, 1, 17, 0, 0, DateTimeKind.Utc),
                    Status = ActivityStatusEnum.Active,
                    ResultLevel = AssessmentResultEnum.Low,
                    AgeMin = 13,
                    Capacity = 40
                },
                new Course
                {
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Title = "Community Approaches to Drug Prevention",
                    contentSummary = "Community-based prevention methods.",
                    Description = "Community-based methods to prevent drug use.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/courseImage%2Fcourse4.png?alt=media&token=cef4547f-d5b6-46dc-a998-c1933fc38db1",
                    StartDate = new DateTime(2023, 4, 15, 8, 0, 0, DateTimeKind.Utc),
                    EndDate = new DateTime(2023, 7, 15, 17, 0, 0, DateTimeKind.Utc),
                    Status = ActivityStatusEnum.Active,
                    ResultLevel = AssessmentResultEnum.Medium,
                    AgeMin = 18,
                    Capacity = 35
                },
                new Course
                {
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Title = "Drug Prevention in Schools",
                    contentSummary = "School-based prevention programs.",
                    Description = "Educational programs for drug prevention in schools.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/courseImage%2Fcourse5.png?alt=media&token=c43e615c-b23a-484c-aec1-b0c2dc6e629a",
                    StartDate = new DateTime(2023, 5, 20, 8, 0, 0, DateTimeKind.Utc),
                    EndDate = new DateTime(2023, 8, 20, 17, 0, 0, DateTimeKind.Utc),
                    Status = ActivityStatusEnum.Active,
                    ResultLevel = AssessmentResultEnum.High,
                    AgeMin = 12,
                    Capacity = 50
                },
                new Course
                {
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000006"),
                    Title = "Family Role in Drug Prevention",
                    contentSummary = "Family involvement in prevention.",
                    Description = "How families can help prevent drug abuse.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/courseImage%2Fcourse6.png?alt=media&token=bf2177d3-9885-4f88-8aa3-a3ee2d7fdfc4",
                    StartDate = new DateTime(2023, 6, 10, 8, 0, 0, DateTimeKind.Utc),
                    EndDate = new DateTime(2023, 9, 10, 17, 0, 0, DateTimeKind.Utc),
                    Status = ActivityStatusEnum.Active,
                    ResultLevel = AssessmentResultEnum.Low,
                    AgeMin = 10,
                    Capacity = 20
                }
            );

            modelBuilder.Entity<CourseContent>().HasData(
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Title = "What are Drugs?",
                    content = "Definition, types, and effects of drugs.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000001")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    Title = "Causes of Addiction",
                    content = "Factors leading to drug addiction.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000002")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    Title = "Peer Pressure and Youth",
                    content = "How peer pressure influences drug use among youth.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000003")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    Title = "Community Programs",
                    content = "Examples of successful community prevention programs.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000004")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    Title = "School Education",
                    content = "Role of schools in drug prevention.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000005")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                    Title = "Family Support",
                    content = "How family involvement reduces drug risk.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000006")
                },
                // Course 1
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                    Title = "What are Drugs?",
                    content = "Definition, types, and effects of drugs.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000001")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                    Title = "Drug Prevention Basics",
                    content = "Basic strategies for drug prevention.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000001")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000013"),
                    Title = "Risks of Drug Abuse",
                    content = "Health and social risks of drug abuse.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000001")
                },
                // Course 2
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000021"),
                    Title = "Causes of Addiction",
                    content = "Factors leading to drug addiction.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000002")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000022"),
                    Title = "Effects of Addiction",
                    content = "Physical and mental effects of addiction.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000002")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000023"),
                    Title = "Addiction Recovery",
                    content = "Methods and support for recovery.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000002")
                },
                // Course 3
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000031"),
                    Title = "Peer Pressure and Youth",
                    content = "How peer pressure influences drug use among youth.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000003")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000032"),
                    Title = "Youth Prevention Strategies",
                    content = "Effective strategies for youth drug prevention.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000003")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000033"),
                    Title = "Youth Support Networks",
                    content = "Role of support networks for youth.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000003")
                },
                // Course 4
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000041"),
                    Title = "Community Programs",
                    content = "Examples of successful community prevention programs.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000004")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000042"),
                    Title = "Community Engagement",
                    content = "How to engage communities in prevention.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000004")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000043"),
                    Title = "Community Resources",
                    content = "Resources available for community prevention.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000004")
                },
                // Course 5
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000051"),
                    Title = "School Education",
                    content = "Role of schools in drug prevention.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000005")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000052"),
                    Title = "School Programs",
                    content = "Examples of school-based prevention programs.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000005")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000053"),
                    Title = "School Community",
                    content = "How schools and communities work together.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000005")
                },
                // Course 6
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000061"),
                    Title = "Family Support",
                    content = "How family involvement reduces drug risk.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000006")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000062"),
                    Title = "Family Communication",
                    content = "Effective communication in families for prevention.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000006")
                },
                new
                {
                    CourseContentID = Guid.Parse("10000000-0000-0000-0000-000000000063"),
                    Title = "Family Prevention Strategies",
                    content = "Strategies families can use to prevent drug abuse.",
                    CourseID = Guid.Parse("00000000-0000-0000-0000-000000000006")
                }
            );
        }
    }
}
