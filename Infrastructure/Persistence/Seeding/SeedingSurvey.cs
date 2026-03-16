using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Persistence.Seeding
{
    public static class SeedingSurvey
    {
        public static void SeedSurvey(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>().HasData(
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "The causes of Drug Abuse",
                    Description = "What do you think the causes of drug abuse are?",
                    PublishDate = new DateTime(2024, 3, 1),
                    Type = SurveyTypeEnum.Pre,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Prevention Strategies for Drug Abuse",
                    Description = "What strategies do you think are effective in preventing drug abuse?",
                    PublishDate = new DateTime(2024, 3, 5),
                    Type = SurveyTypeEnum.Pre,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Attitudes Toward Drug Users",
                    Description = "What is your attitude towards individuals struggling with drug addiction?",
                    PublishDate = new DateTime(2024, 3, 10),
                    Type = SurveyTypeEnum.Post,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Effectiveness of School Drug Programs",
                    Description = "How effective do you think school-based drug prevention programs are?",
                    PublishDate = new DateTime(2024, 3, 15),
                    Type = SurveyTypeEnum.Post,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000005"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Community Involvement in Drug Prevention",
                    Description = "How can the community contribute to drug prevention activities?",
                    PublishDate = new DateTime(2024, 3, 20),
                    Type = SurveyTypeEnum.Pre,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000006"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Impact of Communication Programs",
                    Description = "How do communication and awareness programs impact drug prevention?",
                    PublishDate = new DateTime(2024, 3, 25),
                    Type = SurveyTypeEnum.Post,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000007"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Family Influence on Drug Abuse",
                    Description = "How does family environment influence drug abuse risk?",
                    PublishDate = new DateTime(2024, 3, 30),
                    Type = SurveyTypeEnum.Pre,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000008"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Peer Pressure and Substance Use",
                    Description = "How significant is peer pressure in leading to drug use?",
                    PublishDate = new DateTime(2024, 4, 2),
                    Type = SurveyTypeEnum.Pre,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000009"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Media Impact on Drug Perception",
                    Description = "How does media portrayal affect perceptions of drug use?",
                    PublishDate = new DateTime(2024, 4, 5),
                    Type = SurveyTypeEnum.Pre,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000010"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Knowledge of Drug Laws",
                    Description = "How well do you understand the laws regarding drug use?",
                    PublishDate = new DateTime(2024, 4, 8),
                    Type = SurveyTypeEnum.Pre,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000011"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Awareness of Drug Prevention Resources",
                    Description = "Are you aware of available resources for drug prevention?",
                    PublishDate = new DateTime(2024, 4, 11),
                    Type = SurveyTypeEnum.Pre,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000012"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Personal Beliefs About Drug Use",
                    Description = "What are your personal beliefs about drug use and its risks?",
                    PublishDate = new DateTime(2024, 4, 14),
                    Type = SurveyTypeEnum.Pre,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000013"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Support Systems for Recovery",
                    Description = "What support systems are most helpful for drug recovery?",
                    PublishDate = new DateTime(2024, 4, 17),
                    Type = SurveyTypeEnum.Post,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000014"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Barriers to Seeking Help",
                    Description = "What are the main barriers to seeking help for drug problems?",
                    PublishDate = new DateTime(2024, 4, 20),
                    Type = SurveyTypeEnum.Post,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000015"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Role of Schools in Prevention",
                    Description = "How can schools better support drug prevention efforts?",
                    PublishDate = new DateTime(2024, 4, 23),
                    Type = SurveyTypeEnum.Post,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000016"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Long-term Effects of Drug Use",
                    Description = "What do you know about the long-term effects of drug use?",
                    PublishDate = new DateTime(2024, 4, 26),
                    Type = SurveyTypeEnum.Post,
                    Status = PaperStatusEnum.Opened
                },
                new Survey
                {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000017"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Community Attitudes Toward Prevention",
                    Description = "How does your community view drug prevention efforts?",
                    PublishDate = new DateTime(2024, 4, 29),
                    Type = SurveyTypeEnum.Post,
                    Status = PaperStatusEnum.Opened
                }
            );

            modelBuilder.Entity<SurveyResult>().HasData(
                // Program 1
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000001"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000001") },
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000003"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000001") },

                // Program 2
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000002"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000002") },
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000004"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000002") },

                // Program 3
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000005"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000003") },
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000006"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000003") },

                // Program 4
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000007"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000004") },
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000013"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000004") },

                // Program 5
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000008"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000005") },
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000014"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000005") },

                // Program 6
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000009"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000006") },
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000015"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000006") },

                // Program 7
                new SurveyResult { 
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000010"), 
                    ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000007") 
                },
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000016"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000007") },

                // Program 8
                new SurveyResult {
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000011"), 
                    ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000008") 
                },
                new SurveyResult { 
                    SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000017"), 
                    ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000008") 
                },

                // Program 9
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000012"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000009") },
                new SurveyResult { SurveyID = Guid.Parse("30000000-0000-0000-0000-000000000015"), ProgramID = Guid.Parse("20000000-0000-0000-0000-000000000009") }
            );
        }
    }
}
