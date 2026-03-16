using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Persistence.Seeding
{
    public static class SeedingCommunicationProgram
    {
        public static void SeedCommunicationProgram(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommunicationProgram>().HasData(
                new CommunicationProgram
                {
                    ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                    Name = "Drug Awareness Seminar",
                    Description = "A seminar to raise awareness about the dangers of drug abuse and how to prevent it in the community.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram1.png?alt=media&token=1087b42b-d6aa-4954-900f-eb634e414775",
                    Date = new DateTime(2024, 3, 10),
                    StartTime = new TimeSpan(9, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0),
                    Speaker = "Dr. Nguyen Van A",
                    SpeakerImageUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker1.png?alt=media&token=1fe2a072-954e-4c08-81c4-b22e608a5b9d",
                    Status = ActivityStatusEnum.Active,
                    LocationType = LocationTypeEnum.offline,
                    Location = "Hanoi Youth Cultural Center"
                },
                new CommunicationProgram
                {
                    ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    Name = "Online Workshop: Preventing Drug Use in Schools",
                    Description = "An online workshop for teachers and parents on identifying and preventing drug use among students.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram2.png?alt=media&token=e61defc8-3fdc-4c50-b688-d08d949f543e",
                    Date = new DateTime(2024, 3, 15),
                    StartTime = new TimeSpan(14, 0, 0),
                    EndTime = new TimeSpan(16, 0, 0),
                    Speaker = "Ms. Tran Thi B",
                    SpeakerImageUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker2.png?alt=media&token=762f96cc-8ce0-4368-a326-0965e1ce35da",
                    Status = ActivityStatusEnum.Active,
                    LocationType = LocationTypeEnum.online,
                    Location = "Zoom"
                },
                new CommunicationProgram
                {
                    ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                    Name = "Youth Against Drugs Campaign",
                    Description = "A campaign encouraging youth to stay away from drugs and participate in healthy activities.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram3.png?alt=media&token=7631abe1-fa5d-4e27-8f81-4b1f266ccb39",
                    Date = new DateTime(2024, 3, 20),
                    StartTime = new TimeSpan(8, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    Speaker = "Park Huyhnjoon",
                    SpeakerImageUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker3.png?alt=media&token=3d670a5b-79b9-4b67-9f23-0102d2a6ef59",
                    Status = ActivityStatusEnum.Active,
                    LocationType = LocationTypeEnum.offline,
                    Location = "Da Nang City Park"
                },
                new CommunicationProgram
                {
                    ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000004"),
                    Name = "Family and Drug Prevention",
                    Description = "A program for families to learn about the importance of communication and support in preventing drug abuse.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram4.png?alt=media&token=4d95c8b7-056f-4cc1-b037-d4326890e323",
                    Date = new DateTime(2024, 3, 25),
                    StartTime = new TimeSpan(18, 0, 0),
                    EndTime = new TimeSpan(20, 0, 0),
                    Speaker = "Dr. Max LongHeat",
                    SpeakerImageUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker4.png?alt=media&token=d535e16d-3e0a-4efb-a830-fb11f090661b",
                    Status = ActivityStatusEnum.Active,
                    LocationType = LocationTypeEnum.online,
                    Location = "Google Meet"
                },
                new CommunicationProgram
                {
                    ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000005"),
                    Name = "Community Sports Day: Say No to Drugs",
                    Description = "A sports event promoting a healthy lifestyle and raising awareness about drug prevention.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram5.png?alt=media&token=0b5a8f01-e423-4f70-8ed1-80aa97460cb7",
                    Date = new DateTime(2024, 4, 1),
                    StartTime = new TimeSpan(7, 0, 0),
                    EndTime = new TimeSpan(12, 0, 0),
                    Speaker = "Local Sports Coach",
                    SpeakerImageUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker5.png?alt=media&token=d3aaad08-e195-4462-9089-fbdc79b6e77f",
                    Status = ActivityStatusEnum.Active,
                    LocationType = LocationTypeEnum.offline,
                    Location = "Ho Chi Minh City Stadium"
                },
                new CommunicationProgram
                {
                    ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000006"),
                    Name = "Panel Discussion: The Impact of Drugs on Society",
                    Description = "Experts discuss the social, economic, and health impacts of drug abuse in Vietnam.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram6.png?alt=media&token=a9e25f55-b4c2-4b7b-9b6c-812196a46647",
                    Date = new DateTime(2024, 4, 5),
                    StartTime = new TimeSpan(15, 0, 0),
                    EndTime = new TimeSpan(17, 0, 0),
                    Speaker = "Alex Nguyen An",
                    SpeakerImageUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker6.png?alt=media&token=cbcff7b2-da7d-467d-af35-2c33c27ac830",
                    Status = ActivityStatusEnum.Active,
                    LocationType = LocationTypeEnum.offline,
                    Location = "Hue University Hall"
                },
                new CommunicationProgram
                {
                    ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000007"),
                    Name = "Art Contest: Life Without Drugs",
                    Description = "An art contest for students to express their views on a drug-free life through paintings and drawings.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram7.png?alt=media&token=8365a34f-6983-4680-a598-1d9c80dc5285",
                    Date = new DateTime(2024, 4, 10),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(15, 0, 0),
                    Speaker = "Art Teacher Manny Drawback",
                    SpeakerImageUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker7.png?alt=media&token=c819fbb8-b0b4-40d1-8898-b5001f36baca",
                    Status = ActivityStatusEnum.Active,
                    LocationType = LocationTypeEnum.offline,
                    Location = "Vung Tau Children's Palace"
                },
                new CommunicationProgram
                {
                    ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000008"),
                    Name = "Webinar: Early Signs of Drug Abuse",
                    Description = "A webinar for parents and educators on recognizing early signs of drug abuse and intervention strategies.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram8.png?alt=media&token=40ff370d-0155-4f18-9d8e-5cda1252a32f",
                    Date = new DateTime(2024, 4, 15),
                    StartTime = new TimeSpan(19, 0, 0),
                    EndTime = new TimeSpan(21, 0, 0),
                    Speaker = "Psychologist Pham E",
                    SpeakerImageUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker8.png?alt=media&token=36a2cb05-144b-4632-84a0-5c62e7819c8f",
                    Status = ActivityStatusEnum.Active,
                    LocationType = LocationTypeEnum.online,
                    Location = "Microsoft Teams"
                },
                new CommunicationProgram
                {
                    ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000009"),
                    Name = "Music Festival: Beat Drugs",
                    Description = "A music festival featuring local bands and artists, spreading the message of a drug-free community.",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram9.png?alt=media&token=d52dfd7b-e97f-4011-a000-1babfdfc8dca",
                    Date = new DateTime(2024, 4, 20),
                    StartTime = new TimeSpan(17, 0, 0),
                    EndTime = new TimeSpan(22, 0, 0),
                    Speaker = "Robert Johnham",
                    SpeakerImageUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker9.png?alt=media&token=e32d4f2e-8a08-4ba0-8301-442b3a929f7f",
                    Status = ActivityStatusEnum.Active,
                    LocationType = LocationTypeEnum.offline,
                    Location = "Can Tho Riverside Stage"
                }
            );
        }
    }
}
