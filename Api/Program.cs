using Api.Middlewares;
using Application.Interfaces;
using Application.Services;
using Application.Validators;
using FirebaseAdmin;
using FluentValidation;
using Google.Apis.Auth.OAuth2;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ======= Register services to the container =======

// 1. Configure DbContext with connection string from appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Register dependencies for services (Dependency Injection)
//2.1 services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthenService, AuthenService>();
builder.Services.AddScoped<ICourseRegistrationService, CourseRegistrationService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IAssessmentService, AssessmentService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IConsultantScheduleService, ConsultantScheduleService>();
builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddScoped<ISurveyResultService, SurveyResultService>();
builder.Services.AddScoped<ICommunicationProgramService, CommunicationProgramService>();
builder.Services.AddScoped<IProgramParticipationService, ProgramParticipationService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<ICourseContentService, CourseContentService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICertificateService, CertificateService>();
builder.Services.AddScoped<IAssessmentQuestionService, AssessmentQuestionService>();

//2.2 repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAssessmentRepository, AssessmentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IAssessmentResultRepository, AssessmentResultRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IRegistrationCourseRepository, RegistrationCourseRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IAssessmentQuestionRepository, AssessmentQuestionRepository>();
builder.Services.AddScoped<IConsultantScheduleRepository, ConsultantScheduleRepository>();
builder.Services.AddScoped<ISurveyRepository, SurveyRepository>();
builder.Services.AddScoped<ISurveyResultRepository,SurveyResultRepository>();
builder.Services.AddScoped<ICommunicationProgramRepository, CommunicationProgramRepository>();
builder.Services.AddScoped<IProgramParticipationRepository, ProgramParticipationRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IConsultantScheduleRepository, ConsultantScheduleRepository>();
builder.Services.AddScoped<ICourseContentRepository, CourseContentRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();

// 3. Add Controllers and Swagger for API documentation
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateProfileDtoValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 4. Configure JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
            )
        };
    });
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Drug-helper API", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter 'Bearer' followed by your token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new[] { "Bearer" } }
    });
});

builder.Services.AddAuthorization();

// 5. Configure CORS to proxy to port 5173 (Vite development server)
var AllowFrontend = "_allowFrontend";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowFrontend,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173") // Vite
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

//6. Firebase Admin SDK
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("serviceAccountKey.json")
});


// ======= Build and Configure Application Pipeline =======
var app = builder.Build();

// Swagger (dev only)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Auto migrate database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// Middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseCors(AllowFrontend);

app.UseAuthentication(); 
app.UseAuthorization();

app.UseDefaultFiles();   
app.UseStaticFiles();  

app.MapFallbackToFile("index.html");

app.MapControllers();

app.Run();