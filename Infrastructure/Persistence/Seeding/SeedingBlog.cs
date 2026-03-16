using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Persistence.Seeding
{
    public static class SeedingBlog
    {
        public static void SeedBlog(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    BlogID = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Understanding Drug Addiction",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog1.png?alt=media&token=00189be9-89fc-4201-9548-f45f03de24ad",
                    Content = "Drug addiction is a chronic disease characterized by compulsive drug seeking and use, despite harmful consequences. It affects the brain's structure and function, leading to changes in behavior, judgment, and decision-making. Understanding the root causes, such as genetics, environment, and mental health, is crucial for effective prevention and treatment. Education and support from family and community play a vital role in helping individuals recover and reintegrate into society. Early intervention and access to healthcare services can significantly improve outcomes for those struggling with addiction.",
                    PublishDate = new DateTime(2024, 1, 10),
                    Status = PaperStatusEnum.Opened,
                    ResultLevel = AssessmentResultEnum.Low
                },
                new Blog
                {
                    BlogID = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Prevention Strategies for Youth",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog2.png?alt=media&token=882b7961-1a12-49cf-ab39-bc730ed194ee",
                    Content = "Preventing drug abuse among youth requires a comprehensive approach involving families, schools, and communities. Education about the risks of drug use, building strong relationships, and promoting healthy activities are key strategies. Programs that teach life skills, resilience, and decision-making can empower young people to resist peer pressure. Parental involvement and open communication are essential in guiding youth towards positive choices. Community support, mentorship, and access to recreational opportunities also help reduce the likelihood of drug experimentation and abuse.",
                    PublishDate = new DateTime(2024, 1, 15),
                    Status = PaperStatusEnum.Opened,
                    ResultLevel = AssessmentResultEnum.Medium
                },
                new Blog
                {
                    BlogID = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "The Dangers of Synthetic Drugs",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog3.png?alt=media&token=c0c79651-a466-4564-a2b3-faa58c1d34b1",
                    Content = "Synthetic drugs, often known as designer drugs, are created to mimic the effects of illegal substances while avoiding legal restrictions. These drugs can be extremely dangerous due to their unpredictable chemical compositions. Users may experience severe health problems, including heart attacks, seizures, and even death. The lack of regulation and quality control increases the risk of contamination and overdose. Raising awareness about the dangers of synthetic drugs is essential for protecting individuals, especially young people, from their harmful effects.",
                    PublishDate = new DateTime(2024, 1, 20),
                    Status = PaperStatusEnum.Opened,
                    ResultLevel = AssessmentResultEnum.High
                },
                new Blog
                {
                    BlogID = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "How to Support a Friend with Addiction",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog4.png?alt=media&token=584216e6-487e-4bef-b202-35afda7f9275",
                    Content = "Supporting a friend with addiction requires empathy, patience, and understanding. Avoid judgment and offer a listening ear, encouraging them to seek professional help. Educate yourself about addiction to better understand their struggles. Set healthy boundaries and avoid enabling their behavior. Offer to accompany them to support groups or counseling sessions. Remind them that recovery is a journey and setbacks may occur. Your support can make a significant difference in their motivation and ability to overcome addiction.",
                    PublishDate = new DateTime(2024, 1, 25),
                    Status = PaperStatusEnum.Opened,
                    ResultLevel = AssessmentResultEnum.Low
                },
                new Blog
                {
                    BlogID = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Community Programs for Drug Prevention",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog5.png?alt=media&token=82bd707b-37fe-4a9b-9f61-625984719a0f",
                    Content = "Community programs play a vital role in preventing drug abuse by providing education, resources, and support to individuals and families. These programs often include workshops, outreach events, and recreational activities that promote healthy lifestyles. Collaboration between schools, law enforcement, healthcare providers, and local organizations enhances the effectiveness of prevention efforts. By fostering a sense of belonging and purpose, community programs help reduce the risk factors associated with drug use and encourage positive behaviors.",
                    PublishDate = new DateTime(2024, 2, 1),
                    Status = PaperStatusEnum.Opened,
                    ResultLevel = AssessmentResultEnum.Medium
                },
                new Blog
                {
                    BlogID = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Recognizing Early Signs of Drug Use",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog6.png?alt=media&token=a105ef96-fc98-4f31-8fe0-b19329fa9f30",
                    Content = "Recognizing the early signs of drug use can help prevent addiction and its consequences. Common indicators include changes in behavior, mood swings, withdrawal from family and friends, declining academic or work performance, and neglect of personal hygiene. Physical signs may include bloodshot eyes, sudden weight loss, or unusual smells. If you notice these signs, approach the individual with care and concern, and encourage them to seek help. Early intervention increases the chances of successful recovery.",
                    PublishDate = new DateTime(2024, 2, 5),
                    Status = PaperStatusEnum.Opened,
                    ResultLevel = AssessmentResultEnum.High
                },
                new Blog
                {
                    BlogID = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "The Impact of Drugs on Mental Health",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog7.png?alt=media&token=3346cd6f-524a-41f2-ad42-da1cc2ebe0c0",
                    Content = "Drug abuse can have a profound impact on mental health, leading to conditions such as depression, anxiety, and psychosis. Substance use may worsen existing mental health issues or trigger new ones. The relationship between drugs and mental health is complex, as individuals may use drugs to cope with emotional pain, creating a cycle of dependence. Integrated treatment that addresses both substance use and mental health is essential for effective recovery and long-term well-being.",
                    PublishDate = new DateTime(2024, 2, 10),
                    Status = PaperStatusEnum.Opened,
                    ResultLevel = AssessmentResultEnum.Medium
                },
                new Blog
                {
                    BlogID = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Legal Consequences of Drug Abuse",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog8.png?alt=media&token=98bbd811-ccfa-4be9-8ff6-5c1d2ff4e0e9",
                    Content = "Drug abuse can result in serious legal consequences, including arrest, fines, and imprisonment. Legal issues may also affect employment, education, and family life. Understanding the laws related to drug possession, distribution, and use is important for making informed decisions. Legal problems can complicate recovery and increase stress, making it harder to overcome addiction. Seeking help early and staying informed about the risks can help individuals avoid these negative outcomes.",
                    PublishDate = new DateTime(2024, 2, 15),
                    Status = PaperStatusEnum.Opened,
                    ResultLevel = AssessmentResultEnum.Low
                },
                new Blog
                {
                    BlogID = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "School-Based Drug Prevention Programs",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog9.png?alt=media&token=c6b08e9d-44e3-45f0-9fd2-f71c8779fb6c",
                    Content = "School-based drug prevention programs are designed to educate students about the dangers of drug use and equip them with skills to resist peer pressure. These programs often include interactive lessons, discussions, and activities that promote healthy choices. Involving parents and the wider community enhances their effectiveness. Early education and consistent messaging help create a supportive environment where students feel empowered to make positive decisions and avoid substance abuse.",
                    PublishDate = new DateTime(2024, 2, 20),
                    Status = PaperStatusEnum.Opened,
                    ResultLevel = AssessmentResultEnum.High
                },
                new Blog
                {
                    BlogID = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                    UserID = Guid.Parse("00000000-0000-0000-0000-000000000111"),
                    Title = "Healthy Alternatives to Drug Use",
                    ImgUrl = "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog10.png?alt=media&token=e87392a7-47ca-4cdd-a998-454bc5437eff",
                    Content = "Promoting healthy alternatives to drug use is essential for prevention. Encouraging participation in sports, arts, volunteering, and other positive activities provides individuals with a sense of purpose and belonging. These activities help build self-esteem, reduce stress, and foster supportive relationships. Communities and families can support prevention by providing access to resources and opportunities for engagement. By focusing on healthy alternatives, we can reduce the appeal of drugs and support long-term well-being.",
                    PublishDate = new DateTime(2024, 2, 25),
                    Status = PaperStatusEnum.Opened,
                    ResultLevel = AssessmentResultEnum.Medium
                }
            );
        }
    }
}
