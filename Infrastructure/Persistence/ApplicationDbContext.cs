using Domain.Entities;
using Infrastructure.Persistence.Seeding;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        // DbSet for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<CommunicationProgram> CommunicationPrograms { get; set; }
        public DbSet<ProgramParticipation> ProgramParticipations { get; set; }
        public DbSet<SurveyResult> SurveyResults { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseContent> CourseContents { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ConsultantSchedule> ConsultantSchedules { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AssessmentQuestion> AssessmentQuestions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AssessmentResult> AssessmentResults { get; set; }


        // Override OnModelCreating to apply configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  Using Fluent API to configured entities (FluentAPIConfiguration - has IEntityTypeConfiguration)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.SeedUser();
            modelBuilder.SeedCourse();
            modelBuilder.SeedAssessment();
            modelBuilder.SeedBlog();
            modelBuilder.SeedCommunicationProgram();
            modelBuilder.SeedSurvey();
            modelBuilder.SeedCertificate();
            modelBuilder.SeedAppointment();
            modelBuilder.SeedConsultantSchedule();
        }
    }
}
