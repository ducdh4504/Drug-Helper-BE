using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Persistence.Seeding
{
    public static class SeedingCertificate
    {
        public static void SeedCertificate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>().HasData(
                // Certificates for Consultant 1
                new Certificate
                {
                    CertificateID = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    CertificateName = "Psychology in Drug Prevention",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate1-5-7-10.png?alt=media&token=0a04a34d-41dc-4fef-b21f-e18b305b2b1b",
                    DateAcquired = new DateTime(2022, 5, 10),
                    Status = ActivityStatusEnum.Active
                },
                new Certificate
                {
                    CertificateID = Guid.Parse("40000000-0000-0000-0000-000000000002"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    CertificateName = "Counseling Skills for Addictive Behaviors",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate2.png?alt=media&token=678f7712-3e1c-4f76-b2f7-8cfa8d28675f",
                    DateAcquired = new DateTime(2023, 3, 15),
                    Status = ActivityStatusEnum.Active
                },

                // Certificates for Consultant 2
                new Certificate
                {
                    CertificateID = Guid.Parse("40000000-0000-0000-0000-000000000003"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    CertificateName = "Dialogue Techniques in Drug Prevention",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate3.png?alt=media&token=3e8bdb4c-e507-46c5-ad6b-24f7ddec3ec6",
                    DateAcquired = new DateTime(2021, 8, 20),
                    Status = ActivityStatusEnum.Active
                },
                new Certificate
                {
                    CertificateID = Guid.Parse("40000000-0000-0000-0000-000000000004"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    CertificateName = "Advanced Psychology for Counselors",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate4.png?alt=media&token=f9a30bd4-3536-43ae-b186-0204db7e3e6b",
                    DateAcquired = new DateTime(2022, 11, 5),
                    Status = ActivityStatusEnum.Active
                },

                // Certificates for Consultant 3
                new Certificate
                {
                    CertificateID = Guid.Parse("40000000-0000-0000-0000-000000000005"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    CertificateName = "Drug Abuse Prevention and Intervention",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate1-5-7-10.png?alt=media&token=0a04a34d-41dc-4fef-b21f-e18b305b2b1b",
                    DateAcquired = new DateTime(2023, 1, 12),
                    Status = ActivityStatusEnum.Active
                },
                new Certificate
                {
                    CertificateID = Guid.Parse("40000000-0000-0000-0000-000000000006"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    CertificateName = "Effective Communication in Counseling",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate6.png?alt=media&token=b5c0caa9-ac2d-45d4-9dc4-de3987c7b94e",
                    DateAcquired = new DateTime(2022, 6, 18),
                    Status = ActivityStatusEnum.Active
                },

                // Certificates for Consultant 4
                new Certificate
                {
                    CertificateID = Guid.Parse("40000000-0000-0000-0000-000000000007"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    CertificateName = "Motivational Interviewing for Drug Users",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate1-5-7-10.png?alt=media&token=0a04a34d-41dc-4fef-b21f-e18b305b2b1b",
                    DateAcquired = new DateTime(2021, 9, 25),
                    Status = ActivityStatusEnum.Active
                },
                new Certificate
                {
                    CertificateID = Guid.Parse("40000000-0000-0000-0000-000000000008"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    CertificateName = "Family Therapy in Drug Prevention",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate8.png?alt=media&token=038ccee2-7eca-4cb1-8af5-89c78e2957b4",
                    DateAcquired = new DateTime(2023, 2, 14),
                    Status = ActivityStatusEnum.Active
                },

                // Certificates for Consultant 5
                new Certificate
                {
                    CertificateID = Guid.Parse("40000000-0000-0000-0000-000000000009"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    CertificateName = "Community-Based Drug Prevention",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate9.png?alt=media&token=fa3904d1-a2b2-4593-88a6-e35a26ce47c8",
                    DateAcquired = new DateTime(2022, 4, 30),
                    Status = ActivityStatusEnum.Active
                },
                new Certificate
                {
                    CertificateID = Guid.Parse("40000000-0000-0000-0000-000000000010"),
                    UserID = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    CertificateName = "Psychological Assessment in Counseling",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate1-5-7-10.png?alt=media&token=0a04a34d-41dc-4fef-b21f-e18b305b2b1b",
                    DateAcquired = new DateTime(2023, 7, 8),
                    Status = ActivityStatusEnum.Active
                }
            );
        }
    }
}
