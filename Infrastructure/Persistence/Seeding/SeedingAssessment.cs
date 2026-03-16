using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Seeding
{
    public static class SeedingAssessment
    {
        public static void SeedAssessment(this ModelBuilder modelBuilder)
        {
            int questNumb = 8;
            // 1. Seed 30 Questions
            var questions = new[]
            {
                // 1-8: Original
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000001"), Content = "In your life, how many times have you used any illicit drugs (excluding alcohol and tobacco)?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000002"), Content = "In the past 3 months, how often have you used any illicit drugs?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000003"), Content = "In the past 3 months, how often have you had a strong desire or urge to use drugs?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000004"), Content = "In the past 3 months, how often has your drug use led to health, social, legal, or financial problems?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000005"), Content = "In the past 3 months, how often have you failed to do what was normally expected of you because of your drug use?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000006"), Content = "Has a friend or relative or anyone else ever expressed concern about your drug use? (not in the past 3 months)" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000007"), Content = "Has a friend or relative or anyone else ever expressed concern about your drug use? (in the past 3 months)" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000008"), Content = "Have you ever tried and failed to control, cut down, or stop using drugs?" },

                // 9-30: Paraphrased
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000009"), Content = "How many times in your life have you experimented with illegal drugs (excluding alcohol and tobacco)?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000010"), Content = "During the last 3 months, how frequently have you consumed any illicit drugs?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000011"), Content = "In the last 3 months, how often did you feel a strong need or craving to use drugs?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000012"), Content = "Over the past 3 months, how often did your drug use cause you problems with health, relationships, law, or money?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000013"), Content = "In the last 3 months, how often did you neglect your responsibilities because of drug use?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000014"), Content = "Has anyone ever told you they were worried about your drug use? (not in the last 3 months)" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000015"), Content = "Has anyone expressed concern about your drug use in the past 3 months?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000016"), Content = "Have you ever unsuccessfully tried to quit or reduce your drug use?" },

                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000017"), Content = "Have you ever used illegal drugs, even just once, in your lifetime (excluding alcohol and tobacco)?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000018"), Content = "How often have you taken illicit drugs in the last three months?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000019"), Content = "During the past 3 months, how frequently did you experience a desire to use drugs?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000020"), Content = "In the last 3 months, how often did drug use result in negative consequences for you?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000021"), Content = "How often in the past 3 months did you fail to meet obligations due to drug use?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000022"), Content = "Has someone ever shown concern about your drug habits? (not in the last 3 months)" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000023"), Content = "Has anyone close to you voiced concern about your drug use in the last 3 months?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000024"), Content = "Have you ever attempted to stop using drugs but failed?" },

                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000025"), Content = "Have you ever tried any illegal drugs in your life (excluding alcohol and tobacco)?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000026"), Content = "In the last 3 months, how many times have you used illicit drugs?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000027"), Content = "How often in the past 3 months did you feel a strong urge to use drugs?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000028"), Content = "During the past 3 months, how often did your drug use cause you any kind of trouble?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000029"), Content = "How often have you failed to fulfill your duties in the last 3 months because of drug use?" },
                new { Id = Guid.Parse("20000000-0000-0000-0000-000000000030"), Content = "Has anyone ever been concerned about your drug use? (not in the last 3 months)" }
            };

            modelBuilder.Entity<Question>().HasData(
                questions.Select(q => new Question
                {
                    QuestionID = q.Id,
                    Content = q.Content,
                    MaxScore = 6
                })
            );

            // 2. Seed Answers for each Question 
            var answers = new List<Answer>();
            for (int i = 0; i < questions.Length; i++)
            {
                var q = questions[i];
                int qNum = i + 1;

                // Helper để tạo AnswerID hợp lệ (36 ký tự, phần cuối là 12 số)
                string MakeAnswerId(int questionIndex, int answerIndex)
                    => $"30000000-0000-0000-0000-{questionIndex.ToString("D4")}{answerIndex.ToString("D4")}0000";

                // Question 1, 9, 17, 25
                if (q.Content.StartsWith("In your life") || q.Content.StartsWith("How many times in your life") || q.Content.StartsWith("Have you ever used") || q.Content.StartsWith("Have you ever tried") || q.Content.StartsWith("How often"))
                {
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 1)), QuestionID = q.Id, Content = "Never used", Score = 0 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 2)), QuestionID = q.Id, Content = "Used 1-2 times", Score = 2 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 3)), QuestionID = q.Id, Content = "Used monthly", Score = 3 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 4)), QuestionID = q.Id, Content = "Used weekly", Score = 4 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 5)), QuestionID = q.Id, Content = "Used daily or almost daily", Score = 6 });
                }
                // Question 2-5, 10-13, 18-21, 26-29 
                else if (q.Content.StartsWith("In the past 3 months") || q.Content.StartsWith("During the last 3 months") || q.Content.StartsWith("How often have you taken") || q.Content.StartsWith("How often in the past 3 months") || q.Content.StartsWith("In the last 3 months") || q.Content.StartsWith("Over the past 3 months") || q.Content.StartsWith("During the past 3 months"))
                {
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 1)), QuestionID = q.Id, Content = "Never", Score = 0 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 2)), QuestionID = q.Id, Content = "Once a month", Score = 2 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 3)), QuestionID = q.Id, Content = "2-4 times a month", Score = 3 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 4)), QuestionID = q.Id, Content = "2-3 times a week", Score = 4 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 5)), QuestionID = q.Id, Content = "4 or more times a week", Score = 6 });
                }
                // Question 6, 14, 22, 30 
                else if (q.Content.StartsWith("Has a friend or relative") || q.Content.StartsWith("Has anyone ever told you") || q.Content.StartsWith("Has someone ever shown concern") || q.Content.StartsWith("Has anyone ever been concerned"))
                {
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 1)), QuestionID = q.Id, Content = "Never", Score = 0 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 2)), QuestionID = q.Id, Content = "Yes, but not in the past 3 months", Score = 2 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 3)), QuestionID = q.Id, Content = "Yes, in the past 3 months", Score = 6 });
                }
                // Question 7, 15, 23
                else if (q.Content.StartsWith("Has a friend or relative") || q.Content.StartsWith("Has anyone expressed concern") || q.Content.StartsWith("Has anyone close to you voiced concern"))
                {
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 1)), QuestionID = q.Id, Content = "Never", Score = 0 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 2)), QuestionID = q.Id, Content = "Yes, but not in the past 3 months", Score = 2 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 3)), QuestionID = q.Id, Content = "Yes, in the past 3 months", Score = 6 });
                }
                // Question 8, 16, 24 
                else if (q.Content.StartsWith("Have you ever tried and failed") || q.Content.StartsWith("Have you ever unsuccessfully tried") || q.Content.StartsWith("Have you ever attempted to stop"))
                {
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 1)), QuestionID = q.Id, Content = "Never", Score = 0 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 2)), QuestionID = q.Id, Content = "Yes, but not in the past 3 months", Score = 3 });
                    answers.Add(new Answer { AnswerID = Guid.Parse(MakeAnswerId(qNum, 3)), QuestionID = q.Id, Content = "Yes, in the past 3 months", Score = 6 });
                }
            }
            modelBuilder.Entity<Answer>().HasData(answers);

            // 3. Seed 8 Assessments
            var assessments = Enumerable.Range(1, 8).Select(i => new
            {
                Id = Guid.Parse($"40000000-0000-0000-0000-{i.ToString("D12")}"),
                Name = $"Drug Addiction Level Assessment - {i}"
            }).ToArray();

            modelBuilder.Entity<Assessment>().HasData(
                assessments.Select(a => new Assessment
                {
                    AssessmentID = a.Id,
                    AssessmentName = a.Name,
                    Status = ActivityStatusEnum.Active
                })
            );

            // 4. Seed AssessmentQuestion (each assessment has 6 questions, arbitrary order)
            var assessmentQuestions = new List<AssessmentQuestion>();
            var questionIds = questions.Select(q => q.Id).ToList();

            for (int i = 0; i < assessments.Length; i++)
            {
                var selectedQuestions = questionIds.Skip(i * 3).Take(questNumb).ToList();
                if (selectedQuestions.Count < questNumb)
                    selectedQuestions.AddRange(questionIds.Take(questNumb - selectedQuestions.Count));
                foreach (var qid in selectedQuestions)
                {
                    assessmentQuestions.Add(new AssessmentQuestion
                    {
                        AssessmentID = assessments[i].Id,
                        QuestionID = qid
                    });
                }
            }
            modelBuilder.Entity<AssessmentQuestion>().HasData(assessmentQuestions);
        }
    }
}
