using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    AssessmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssessmentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.AssessmentID);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationPrograms",
                columns: table => new
                {
                    ProgramID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Speaker = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SpeakerImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LocationType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationPrograms", x => x.ProgramID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    contentSummary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ResultLevel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AgeMin = table.Column<int>(type: "int", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "CourseContents",
                columns: table => new
                {
                    CourseContentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseContents", x => x.CourseContentID);
                    table.ForeignKey(
                        name: "FK_CourseContents_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentQuestions",
                columns: table => new
                {
                    AssessmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentQuestions", x => new { x.AssessmentID, x.QuestionID });
                    table.ForeignKey(
                        name: "FK_AssessmentQuestions_Assessments_AssessmentID",
                        column: x => x.AssessmentID,
                        principalTable: "Assessments",
                        principalColumn: "AssessmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentQuestions_Questions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Questions",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsultantID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_ConsultantID",
                        column: x => x.ConsultantID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentResults",
                columns: table => new
                {
                    ResultID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssessmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResultLevel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    TakeTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentResults", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK_AssessmentResults_Assessments_AssessmentID",
                        column: x => x.AssessmentID,
                        principalTable: "Assessments",
                        principalColumn: "AssessmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentResults_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ResultLevel = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    CertificateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateAcquired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateID);
                    table.ForeignKey(
                        name: "FK_Certificates_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseRegistrations",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LearningStatus = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRegistrations", x => new { x.UserID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_CourseRegistrations_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseRegistrations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramParticipations",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoinTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramParticipations", x => new { x.UserID, x.ProgramID });
                    table.ForeignKey(
                        name: "FK_ProgramParticipations_CommunicationPrograms_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "CommunicationPrograms",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramParticipations_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    SurveyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.SurveyID);
                    table.ForeignKey(
                        name: "FK_Surveys_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultantSchedules",
                columns: table => new
                {
                    ConsultantScheduleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DayOfWeek = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantSchedules", x => x.ConsultantScheduleID);
                    table.ForeignKey(
                        name: "FK_ConsultantSchedules_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsultantSchedules_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResults",
                columns: table => new
                {
                    SurveyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResponseData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmitTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResults", x => new { x.SurveyID, x.ProgramID });
                    table.ForeignKey(
                        name: "FK_SurveyResults_CommunicationPrograms_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "CommunicationPrograms",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyResults_Surveys_SurveyID",
                        column: x => x.SurveyID,
                        principalTable: "Surveys",
                        principalColumn: "SurveyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyResults_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.InsertData(
                table: "Assessments",
                columns: new[] { "AssessmentID", "AssessmentName", "Status" },
                values: new object[,]
                {
                    { new Guid("40000000-0000-0000-0000-000000000001"), "Drug Addiction Level Assessment - 1", "Active" },
                    { new Guid("40000000-0000-0000-0000-000000000002"), "Drug Addiction Level Assessment - 2", "Active" },
                    { new Guid("40000000-0000-0000-0000-000000000003"), "Drug Addiction Level Assessment - 3", "Active" },
                    { new Guid("40000000-0000-0000-0000-000000000004"), "Drug Addiction Level Assessment - 4", "Active" },
                    { new Guid("40000000-0000-0000-0000-000000000005"), "Drug Addiction Level Assessment - 5", "Active" },
                    { new Guid("40000000-0000-0000-0000-000000000006"), "Drug Addiction Level Assessment - 6", "Active" },
                    { new Guid("40000000-0000-0000-0000-000000000007"), "Drug Addiction Level Assessment - 7", "Active" },
                    { new Guid("40000000-0000-0000-0000-000000000008"), "Drug Addiction Level Assessment - 8", "Active" }
                });

            migrationBuilder.InsertData(
                table: "CommunicationPrograms",
                columns: new[] { "ProgramID", "Date", "Description", "EndTime", "ImgUrl", "Location", "LocationType", "Name", "Speaker", "SpeakerImageUrl", "StartTime", "Status" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "A seminar to raise awareness about the dangers of drug abuse and how to prevent it in the community.", new TimeSpan(0, 11, 0, 0, 0), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram1.png?alt=media&token=1087b42b-d6aa-4954-900f-eb634e414775", "Hanoi Youth Cultural Center", "offline", "Drug Awareness Seminar", "Dr. Nguyen Van A", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker1.png?alt=media&token=1fe2a072-954e-4c08-81c4-b22e608a5b9d", new TimeSpan(0, 9, 0, 0, 0), "Active" },
                    { new Guid("20000000-0000-0000-0000-000000000002"), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "An online workshop for teachers and parents on identifying and preventing drug use among students.", new TimeSpan(0, 16, 0, 0, 0), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram2.png?alt=media&token=e61defc8-3fdc-4c50-b688-d08d949f543e", "Zoom", "online", "Online Workshop: Preventing Drug Use in Schools", "Ms. Tran Thi B", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker2.png?alt=media&token=762f96cc-8ce0-4368-a326-0965e1ce35da", new TimeSpan(0, 14, 0, 0, 0), "Active" },
                    { new Guid("20000000-0000-0000-0000-000000000003"), new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "A campaign encouraging youth to stay away from drugs and participate in healthy activities.", new TimeSpan(0, 12, 0, 0, 0), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram3.png?alt=media&token=7631abe1-fa5d-4e27-8f81-4b1f266ccb39", "Da Nang City Park", "offline", "Youth Against Drugs Campaign", "Park Huyhnjoon", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker3.png?alt=media&token=3d670a5b-79b9-4b67-9f23-0102d2a6ef59", new TimeSpan(0, 8, 0, 0, 0), "Active" },
                    { new Guid("20000000-0000-0000-0000-000000000004"), new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "A program for families to learn about the importance of communication and support in preventing drug abuse.", new TimeSpan(0, 20, 0, 0, 0), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram4.png?alt=media&token=4d95c8b7-056f-4cc1-b037-d4326890e323", "Google Meet", "online", "Family and Drug Prevention", "Dr. Max LongHeat", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker4.png?alt=media&token=d535e16d-3e0a-4efb-a830-fb11f090661b", new TimeSpan(0, 18, 0, 0, 0), "Active" },
                    { new Guid("20000000-0000-0000-0000-000000000005"), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A sports event promoting a healthy lifestyle and raising awareness about drug prevention.", new TimeSpan(0, 12, 0, 0, 0), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram5.png?alt=media&token=0b5a8f01-e423-4f70-8ed1-80aa97460cb7", "Ho Chi Minh City Stadium", "offline", "Community Sports Day: Say No to Drugs", "Local Sports Coach", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker5.png?alt=media&token=d3aaad08-e195-4462-9089-fbdc79b6e77f", new TimeSpan(0, 7, 0, 0, 0), "Active" },
                    { new Guid("20000000-0000-0000-0000-000000000006"), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Experts discuss the social, economic, and health impacts of drug abuse in Vietnam.", new TimeSpan(0, 17, 0, 0, 0), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram6.png?alt=media&token=a9e25f55-b4c2-4b7b-9b6c-812196a46647", "Hue University Hall", "offline", "Panel Discussion: The Impact of Drugs on Society", "Alex Nguyen An", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker6.png?alt=media&token=cbcff7b2-da7d-467d-af35-2c33c27ac830", new TimeSpan(0, 15, 0, 0, 0), "Active" },
                    { new Guid("20000000-0000-0000-0000-000000000007"), new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "An art contest for students to express their views on a drug-free life through paintings and drawings.", new TimeSpan(0, 15, 0, 0, 0), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram7.png?alt=media&token=8365a34f-6983-4680-a598-1d9c80dc5285", "Vung Tau Children's Palace", "offline", "Art Contest: Life Without Drugs", "Art Teacher Manny Drawback", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker7.png?alt=media&token=c819fbb8-b0b4-40d1-8898-b5001f36baca", new TimeSpan(0, 10, 0, 0, 0), "Active" },
                    { new Guid("20000000-0000-0000-0000-000000000008"), new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A webinar for parents and educators on recognizing early signs of drug abuse and intervention strategies.", new TimeSpan(0, 21, 0, 0, 0), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram8.png?alt=media&token=40ff370d-0155-4f18-9d8e-5cda1252a32f", "Microsoft Teams", "online", "Webinar: Early Signs of Drug Abuse", "Psychologist Pham E", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker8.png?alt=media&token=36a2cb05-144b-4632-84a0-5c62e7819c8f", new TimeSpan(0, 19, 0, 0, 0), "Active" },
                    { new Guid("20000000-0000-0000-0000-000000000009"), new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "A music festival featuring local bands and artists, spreading the message of a drug-free community.", new TimeSpan(0, 22, 0, 0, 0), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/programImage%2Fprogram9.png?alt=media&token=d52dfd7b-e97f-4011-a000-1babfdfc8dca", "Can Tho Riverside Stage", "offline", "Music Festival: Beat Drugs", "Robert Johnham", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/speakerImage%2Fspeaker9.png?alt=media&token=e32d4f2e-8a08-4ba0-8301-442b3a929f7f", new TimeSpan(0, 17, 0, 0, 0), "Active" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "AgeMin", "Capacity", "Description", "EndDate", "ImgUrl", "ResultLevel", "StartDate", "Status", "Title", "contentSummary" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 15, 30, "Basic knowledge to prevent drug abuse.", new DateTime(2023, 4, 10, 17, 0, 0, 0, DateTimeKind.Utc), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/courseImage%2Fcourse1.png?alt=media&token=9739c97e-6bca-4d94-a09c-11ac5886fdd1", "Low", new DateTime(2023, 1, 10, 8, 0, 0, 0, DateTimeKind.Utc), "Active", "Introduction to Drug Prevention", "Overview of drug prevention basics." },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 16, 25, "Learn about the causes and effects of drug addiction.", new DateTime(2023, 5, 5, 17, 0, 0, 0, DateTimeKind.Utc), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/courseImage%2Fcourse2.png?alt=media&token=1340a031-239c-481d-bc63-7642ad069b27", "Medium", new DateTime(2023, 2, 5, 8, 0, 0, 0, DateTimeKind.Utc), "Active", "Understanding Drug Addiction", "Causes and effects of addiction." },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 13, 40, "Strategies for youth to avoid drug abuse.", new DateTime(2023, 6, 1, 17, 0, 0, 0, DateTimeKind.Utc), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/courseImage%2Fcourse3.png?alt=media&token=eaa3e3d3-1772-446e-984c-04e59943ac49", "Low", new DateTime(2023, 3, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Active", "Youth and Drug Prevention", "Prevention strategies for youth." },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 18, 35, "Community-based methods to prevent drug use.", new DateTime(2023, 7, 15, 17, 0, 0, 0, DateTimeKind.Utc), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/courseImage%2Fcourse4.png?alt=media&token=cef4547f-d5b6-46dc-a998-c1933fc38db1", "Medium", new DateTime(2023, 4, 15, 8, 0, 0, 0, DateTimeKind.Utc), "Active", "Community Approaches to Drug Prevention", "Community-based prevention methods." },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 12, 50, "Educational programs for drug prevention in schools.", new DateTime(2023, 8, 20, 17, 0, 0, 0, DateTimeKind.Utc), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/courseImage%2Fcourse5.png?alt=media&token=c43e615c-b23a-484c-aec1-b0c2dc6e629a", "High", new DateTime(2023, 5, 20, 8, 0, 0, 0, DateTimeKind.Utc), "Active", "Drug Prevention in Schools", "School-based prevention programs." },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 10, 20, "How families can help prevent drug abuse.", new DateTime(2023, 9, 10, 17, 0, 0, 0, DateTimeKind.Utc), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/courseImage%2Fcourse6.png?alt=media&token=bf2177d3-9885-4f88-8aa3-a3ee2d7fdfc4", "Low", new DateTime(2023, 6, 10, 8, 0, 0, 0, DateTimeKind.Utc), "Active", "Family Role in Drug Prevention", "Family involvement in prevention." }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "Content", "MaxScore" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), "In your life, how many times have you used any illicit drugs (excluding alcohol and tobacco)?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "In the past 3 months, how often have you used any illicit drugs?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "In the past 3 months, how often have you had a strong desire or urge to use drugs?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000004"), "In the past 3 months, how often has your drug use led to health, social, legal, or financial problems?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000005"), "In the past 3 months, how often have you failed to do what was normally expected of you because of your drug use?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000006"), "Has a friend or relative or anyone else ever expressed concern about your drug use? (not in the past 3 months)", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000007"), "Has a friend or relative or anyone else ever expressed concern about your drug use? (in the past 3 months)", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000008"), "Have you ever tried and failed to control, cut down, or stop using drugs?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000009"), "How many times in your life have you experimented with illegal drugs (excluding alcohol and tobacco)?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000010"), "During the last 3 months, how frequently have you consumed any illicit drugs?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000011"), "In the last 3 months, how often did you feel a strong need or craving to use drugs?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000012"), "Over the past 3 months, how often did your drug use cause you problems with health, relationships, law, or money?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000013"), "In the last 3 months, how often did you neglect your responsibilities because of drug use?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000014"), "Has anyone ever told you they were worried about your drug use? (not in the last 3 months)", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000015"), "Has anyone expressed concern about your drug use in the past 3 months?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000016"), "Have you ever unsuccessfully tried to quit or reduce your drug use?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000017"), "Have you ever used illegal drugs, even just once, in your lifetime (excluding alcohol and tobacco)?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000018"), "How often have you taken illicit drugs in the last three months?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000019"), "During the past 3 months, how frequently did you experience a desire to use drugs?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000020"), "In the last 3 months, how often did drug use result in negative consequences for you?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000021"), "How often in the past 3 months did you fail to meet obligations due to drug use?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000022"), "Has someone ever shown concern about your drug habits? (not in the last 3 months)", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000023"), "Has anyone close to you voiced concern about your drug use in the last 3 months?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000024"), "Have you ever attempted to stop using drugs but failed?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000025"), "Have you ever tried any illegal drugs in your life (excluding alcohol and tobacco)?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000026"), "In the last 3 months, how many times have you used illicit drugs?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000027"), "How often in the past 3 months did you feel a strong urge to use drugs?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000028"), "During the past 3 months, how often did your drug use cause you any kind of trouble?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000029"), "How often have you failed to fulfill your duties in the last 3 months because of drug use?", 6 },
                    { new Guid("20000000-0000-0000-0000-000000000030"), "Has anyone ever been concerned about your drug use? (not in the last 3 months)", 6 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Address", "DateOfBirth", "Email", "FullName", "ImgUrl", "Password", "Phone", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), null, null, "admin@example.com", "Administrator", null, "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", null, "Admin", "Active", "admin" },
                    { new Guid("00000000-0000-0000-0000-000000000111"), null, null, "lyphongstaff@example.com", "Ly Tuan Phong", null, "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", null, "Staff", "Active", "LyPhongstaff" },
                    { new Guid("00000000-0000-0000-0000-000000000112"), null, null, "goothstaff@example.com", "Gooth Yunoly", null, "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", null, "Staff", "Active", "GoothStaff" },
                    { new Guid("00000000-0000-0000-0000-200000000222"), null, null, "khahomanager@example.com", "Ho Kha", null, "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", null, "Manager", "Active", "HoKhaManager" },
                    { new Guid("10000000-0000-0000-0000-000000000001"), "123 Nguyen Trai, Ha Noi", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nhatbn1@example.com", "Nguyen Ba Nhat", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/consultantImage%2Fconsultant1.png?alt=media&token=d2177c39-baa2-415b-9e2a-02c1e7ad0386", "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", "0901001001", "Consultant", "Active", "NhatNguyen" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "456 Le Loi, Da Nang", new DateTime(1988, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "joinp2@example.com", "John Potter", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/consultantImage%2Fconsultant2.png?alt=media&token=389c0581-31f9-4cea-8e67-b8c552dfd492", "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", "0901000232", "Consultant", "Active", "JoinPotter" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "789 Tran Phu, Ho Chi Minh", new DateTime(1992, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "maryj3@example.com", "Mary Jarry", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/consultantImage%2Fconsultant3.png?alt=media&token=eb17235b-0ccc-441a-8f13-52d91cdf6463", "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", "0901708003", "Consultant", "Active", "MaryJarry" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "101 Nguyen Hue, Hue", new DateTime(1991, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "sanghl4@example.com", "Lee Sang-hyeok", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/consultantImage%2Fconsutant4.png?alt=media&token=54968421-4493-4d2c-9df3-1ee0ef4bc6fe", "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", "0901984564", "Consultant", "Active", "LeeSanghyeok" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "202 Vo Thi Sau, Vung Tau", new DateTime(1993, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "vylt5@example.com", "Le Tuong Vy", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/consultantImage%2Fconsultant5.png?alt=media&token=35292f58-6cf4-4d3f-b099-8b2e550d6811", "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", "0901003005", "Consultant", "Active", "VyLe" },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "252 Vo Thi Sau, Go Vap, Ho Chi Minh", new DateTime(1969, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "vykhat5@example.com", "Le Vy Kha", null, "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", "0901693005", "Member", "Active", "Khayeudo" },
                    { new Guid("10000000-0000-0000-0000-000000000007"), "250 Vo Thi Sau, Con Dao", new DateTime(2000, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "taikdau9@example.com", "Khong Tai Dau", null, "$2a$12$M/9qXAuJPl0OPKAPAqcRH.3ng.vEAo6h9xnqQi5ktntEMG/YS7b1u", "0110693005", "Member", "Active", "KhongTaiDau" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerID", "Content", "QuestionID", "Score" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000100010000"), "Never used", new Guid("20000000-0000-0000-0000-000000000001"), 0 },
                    { new Guid("30000000-0000-0000-0000-000100020000"), "Used 1-2 times", new Guid("20000000-0000-0000-0000-000000000001"), 2 },
                    { new Guid("30000000-0000-0000-0000-000100030000"), "Used monthly", new Guid("20000000-0000-0000-0000-000000000001"), 3 },
                    { new Guid("30000000-0000-0000-0000-000100040000"), "Used weekly", new Guid("20000000-0000-0000-0000-000000000001"), 4 },
                    { new Guid("30000000-0000-0000-0000-000100050000"), "Used daily or almost daily", new Guid("20000000-0000-0000-0000-000000000001"), 6 },
                    { new Guid("30000000-0000-0000-0000-000200010000"), "Never", new Guid("20000000-0000-0000-0000-000000000002"), 0 },
                    { new Guid("30000000-0000-0000-0000-000200020000"), "Once a month", new Guid("20000000-0000-0000-0000-000000000002"), 2 },
                    { new Guid("30000000-0000-0000-0000-000200030000"), "2-4 times a month", new Guid("20000000-0000-0000-0000-000000000002"), 3 },
                    { new Guid("30000000-0000-0000-0000-000200040000"), "2-3 times a week", new Guid("20000000-0000-0000-0000-000000000002"), 4 },
                    { new Guid("30000000-0000-0000-0000-000200050000"), "4 or more times a week", new Guid("20000000-0000-0000-0000-000000000002"), 6 },
                    { new Guid("30000000-0000-0000-0000-000300010000"), "Never", new Guid("20000000-0000-0000-0000-000000000003"), 0 },
                    { new Guid("30000000-0000-0000-0000-000300020000"), "Once a month", new Guid("20000000-0000-0000-0000-000000000003"), 2 },
                    { new Guid("30000000-0000-0000-0000-000300030000"), "2-4 times a month", new Guid("20000000-0000-0000-0000-000000000003"), 3 },
                    { new Guid("30000000-0000-0000-0000-000300040000"), "2-3 times a week", new Guid("20000000-0000-0000-0000-000000000003"), 4 },
                    { new Guid("30000000-0000-0000-0000-000300050000"), "4 or more times a week", new Guid("20000000-0000-0000-0000-000000000003"), 6 },
                    { new Guid("30000000-0000-0000-0000-000400010000"), "Never", new Guid("20000000-0000-0000-0000-000000000004"), 0 },
                    { new Guid("30000000-0000-0000-0000-000400020000"), "Once a month", new Guid("20000000-0000-0000-0000-000000000004"), 2 },
                    { new Guid("30000000-0000-0000-0000-000400030000"), "2-4 times a month", new Guid("20000000-0000-0000-0000-000000000004"), 3 },
                    { new Guid("30000000-0000-0000-0000-000400040000"), "2-3 times a week", new Guid("20000000-0000-0000-0000-000000000004"), 4 },
                    { new Guid("30000000-0000-0000-0000-000400050000"), "4 or more times a week", new Guid("20000000-0000-0000-0000-000000000004"), 6 },
                    { new Guid("30000000-0000-0000-0000-000500010000"), "Never", new Guid("20000000-0000-0000-0000-000000000005"), 0 },
                    { new Guid("30000000-0000-0000-0000-000500020000"), "Once a month", new Guid("20000000-0000-0000-0000-000000000005"), 2 },
                    { new Guid("30000000-0000-0000-0000-000500030000"), "2-4 times a month", new Guid("20000000-0000-0000-0000-000000000005"), 3 },
                    { new Guid("30000000-0000-0000-0000-000500040000"), "2-3 times a week", new Guid("20000000-0000-0000-0000-000000000005"), 4 },
                    { new Guid("30000000-0000-0000-0000-000500050000"), "4 or more times a week", new Guid("20000000-0000-0000-0000-000000000005"), 6 },
                    { new Guid("30000000-0000-0000-0000-000600010000"), "Never", new Guid("20000000-0000-0000-0000-000000000006"), 0 },
                    { new Guid("30000000-0000-0000-0000-000600020000"), "Yes, but not in the past 3 months", new Guid("20000000-0000-0000-0000-000000000006"), 2 },
                    { new Guid("30000000-0000-0000-0000-000600030000"), "Yes, in the past 3 months", new Guid("20000000-0000-0000-0000-000000000006"), 6 },
                    { new Guid("30000000-0000-0000-0000-000700010000"), "Never", new Guid("20000000-0000-0000-0000-000000000007"), 0 },
                    { new Guid("30000000-0000-0000-0000-000700020000"), "Yes, but not in the past 3 months", new Guid("20000000-0000-0000-0000-000000000007"), 2 },
                    { new Guid("30000000-0000-0000-0000-000700030000"), "Yes, in the past 3 months", new Guid("20000000-0000-0000-0000-000000000007"), 6 },
                    { new Guid("30000000-0000-0000-0000-000800010000"), "Never used", new Guid("20000000-0000-0000-0000-000000000008"), 0 },
                    { new Guid("30000000-0000-0000-0000-000800020000"), "Used 1-2 times", new Guid("20000000-0000-0000-0000-000000000008"), 2 },
                    { new Guid("30000000-0000-0000-0000-000800030000"), "Used monthly", new Guid("20000000-0000-0000-0000-000000000008"), 3 },
                    { new Guid("30000000-0000-0000-0000-000800040000"), "Used weekly", new Guid("20000000-0000-0000-0000-000000000008"), 4 },
                    { new Guid("30000000-0000-0000-0000-000800050000"), "Used daily or almost daily", new Guid("20000000-0000-0000-0000-000000000008"), 6 },
                    { new Guid("30000000-0000-0000-0000-000900010000"), "Never used", new Guid("20000000-0000-0000-0000-000000000009"), 0 },
                    { new Guid("30000000-0000-0000-0000-000900020000"), "Used 1-2 times", new Guid("20000000-0000-0000-0000-000000000009"), 2 },
                    { new Guid("30000000-0000-0000-0000-000900030000"), "Used monthly", new Guid("20000000-0000-0000-0000-000000000009"), 3 },
                    { new Guid("30000000-0000-0000-0000-000900040000"), "Used weekly", new Guid("20000000-0000-0000-0000-000000000009"), 4 },
                    { new Guid("30000000-0000-0000-0000-000900050000"), "Used daily or almost daily", new Guid("20000000-0000-0000-0000-000000000009"), 6 },
                    { new Guid("30000000-0000-0000-0000-001000010000"), "Never", new Guid("20000000-0000-0000-0000-000000000010"), 0 },
                    { new Guid("30000000-0000-0000-0000-001000020000"), "Once a month", new Guid("20000000-0000-0000-0000-000000000010"), 2 },
                    { new Guid("30000000-0000-0000-0000-001000030000"), "2-4 times a month", new Guid("20000000-0000-0000-0000-000000000010"), 3 },
                    { new Guid("30000000-0000-0000-0000-001000040000"), "2-3 times a week", new Guid("20000000-0000-0000-0000-000000000010"), 4 },
                    { new Guid("30000000-0000-0000-0000-001000050000"), "4 or more times a week", new Guid("20000000-0000-0000-0000-000000000010"), 6 },
                    { new Guid("30000000-0000-0000-0000-001100010000"), "Never", new Guid("20000000-0000-0000-0000-000000000011"), 0 },
                    { new Guid("30000000-0000-0000-0000-001100020000"), "Once a month", new Guid("20000000-0000-0000-0000-000000000011"), 2 },
                    { new Guid("30000000-0000-0000-0000-001100030000"), "2-4 times a month", new Guid("20000000-0000-0000-0000-000000000011"), 3 },
                    { new Guid("30000000-0000-0000-0000-001100040000"), "2-3 times a week", new Guid("20000000-0000-0000-0000-000000000011"), 4 },
                    { new Guid("30000000-0000-0000-0000-001100050000"), "4 or more times a week", new Guid("20000000-0000-0000-0000-000000000011"), 6 },
                    { new Guid("30000000-0000-0000-0000-001200010000"), "Never", new Guid("20000000-0000-0000-0000-000000000012"), 0 },
                    { new Guid("30000000-0000-0000-0000-001200020000"), "Once a month", new Guid("20000000-0000-0000-0000-000000000012"), 2 },
                    { new Guid("30000000-0000-0000-0000-001200030000"), "2-4 times a month", new Guid("20000000-0000-0000-0000-000000000012"), 3 },
                    { new Guid("30000000-0000-0000-0000-001200040000"), "2-3 times a week", new Guid("20000000-0000-0000-0000-000000000012"), 4 },
                    { new Guid("30000000-0000-0000-0000-001200050000"), "4 or more times a week", new Guid("20000000-0000-0000-0000-000000000012"), 6 },
                    { new Guid("30000000-0000-0000-0000-001300010000"), "Never", new Guid("20000000-0000-0000-0000-000000000013"), 0 },
                    { new Guid("30000000-0000-0000-0000-001300020000"), "Once a month", new Guid("20000000-0000-0000-0000-000000000013"), 2 },
                    { new Guid("30000000-0000-0000-0000-001300030000"), "2-4 times a month", new Guid("20000000-0000-0000-0000-000000000013"), 3 },
                    { new Guid("30000000-0000-0000-0000-001300040000"), "2-3 times a week", new Guid("20000000-0000-0000-0000-000000000013"), 4 },
                    { new Guid("30000000-0000-0000-0000-001300050000"), "4 or more times a week", new Guid("20000000-0000-0000-0000-000000000013"), 6 },
                    { new Guid("30000000-0000-0000-0000-001400010000"), "Never", new Guid("20000000-0000-0000-0000-000000000014"), 0 },
                    { new Guid("30000000-0000-0000-0000-001400020000"), "Yes, but not in the past 3 months", new Guid("20000000-0000-0000-0000-000000000014"), 2 },
                    { new Guid("30000000-0000-0000-0000-001400030000"), "Yes, in the past 3 months", new Guid("20000000-0000-0000-0000-000000000014"), 6 },
                    { new Guid("30000000-0000-0000-0000-001500010000"), "Never", new Guid("20000000-0000-0000-0000-000000000015"), 0 },
                    { new Guid("30000000-0000-0000-0000-001500020000"), "Yes, but not in the past 3 months", new Guid("20000000-0000-0000-0000-000000000015"), 2 },
                    { new Guid("30000000-0000-0000-0000-001500030000"), "Yes, in the past 3 months", new Guid("20000000-0000-0000-0000-000000000015"), 6 },
                    { new Guid("30000000-0000-0000-0000-001600010000"), "Never", new Guid("20000000-0000-0000-0000-000000000016"), 0 },
                    { new Guid("30000000-0000-0000-0000-001600020000"), "Yes, but not in the past 3 months", new Guid("20000000-0000-0000-0000-000000000016"), 3 },
                    { new Guid("30000000-0000-0000-0000-001600030000"), "Yes, in the past 3 months", new Guid("20000000-0000-0000-0000-000000000016"), 6 },
                    { new Guid("30000000-0000-0000-0000-001700010000"), "Never used", new Guid("20000000-0000-0000-0000-000000000017"), 0 },
                    { new Guid("30000000-0000-0000-0000-001700020000"), "Used 1-2 times", new Guid("20000000-0000-0000-0000-000000000017"), 2 },
                    { new Guid("30000000-0000-0000-0000-001700030000"), "Used monthly", new Guid("20000000-0000-0000-0000-000000000017"), 3 },
                    { new Guid("30000000-0000-0000-0000-001700040000"), "Used weekly", new Guid("20000000-0000-0000-0000-000000000017"), 4 },
                    { new Guid("30000000-0000-0000-0000-001700050000"), "Used daily or almost daily", new Guid("20000000-0000-0000-0000-000000000017"), 6 },
                    { new Guid("30000000-0000-0000-0000-001800010000"), "Never used", new Guid("20000000-0000-0000-0000-000000000018"), 0 },
                    { new Guid("30000000-0000-0000-0000-001800020000"), "Used 1-2 times", new Guid("20000000-0000-0000-0000-000000000018"), 2 },
                    { new Guid("30000000-0000-0000-0000-001800030000"), "Used monthly", new Guid("20000000-0000-0000-0000-000000000018"), 3 },
                    { new Guid("30000000-0000-0000-0000-001800040000"), "Used weekly", new Guid("20000000-0000-0000-0000-000000000018"), 4 },
                    { new Guid("30000000-0000-0000-0000-001800050000"), "Used daily or almost daily", new Guid("20000000-0000-0000-0000-000000000018"), 6 },
                    { new Guid("30000000-0000-0000-0000-001900010000"), "Never", new Guid("20000000-0000-0000-0000-000000000019"), 0 },
                    { new Guid("30000000-0000-0000-0000-001900020000"), "Once a month", new Guid("20000000-0000-0000-0000-000000000019"), 2 },
                    { new Guid("30000000-0000-0000-0000-001900030000"), "2-4 times a month", new Guid("20000000-0000-0000-0000-000000000019"), 3 },
                    { new Guid("30000000-0000-0000-0000-001900040000"), "2-3 times a week", new Guid("20000000-0000-0000-0000-000000000019"), 4 },
                    { new Guid("30000000-0000-0000-0000-001900050000"), "4 or more times a week", new Guid("20000000-0000-0000-0000-000000000019"), 6 },
                    { new Guid("30000000-0000-0000-0000-002000010000"), "Never", new Guid("20000000-0000-0000-0000-000000000020"), 0 },
                    { new Guid("30000000-0000-0000-0000-002000020000"), "Once a month", new Guid("20000000-0000-0000-0000-000000000020"), 2 },
                    { new Guid("30000000-0000-0000-0000-002000030000"), "2-4 times a month", new Guid("20000000-0000-0000-0000-000000000020"), 3 },
                    { new Guid("30000000-0000-0000-0000-002000040000"), "2-3 times a week", new Guid("20000000-0000-0000-0000-000000000020"), 4 },
                    { new Guid("30000000-0000-0000-0000-002000050000"), "4 or more times a week", new Guid("20000000-0000-0000-0000-000000000020"), 6 },
                    { new Guid("30000000-0000-0000-0000-002100010000"), "Never used", new Guid("20000000-0000-0000-0000-000000000021"), 0 },
                    { new Guid("30000000-0000-0000-0000-002100020000"), "Used 1-2 times", new Guid("20000000-0000-0000-0000-000000000021"), 2 },
                    { new Guid("30000000-0000-0000-0000-002100030000"), "Used monthly", new Guid("20000000-0000-0000-0000-000000000021"), 3 },
                    { new Guid("30000000-0000-0000-0000-002100040000"), "Used weekly", new Guid("20000000-0000-0000-0000-000000000021"), 4 },
                    { new Guid("30000000-0000-0000-0000-002100050000"), "Used daily or almost daily", new Guid("20000000-0000-0000-0000-000000000021"), 6 },
                    { new Guid("30000000-0000-0000-0000-002200010000"), "Never", new Guid("20000000-0000-0000-0000-000000000022"), 0 },
                    { new Guid("30000000-0000-0000-0000-002200020000"), "Yes, but not in the past 3 months", new Guid("20000000-0000-0000-0000-000000000022"), 2 },
                    { new Guid("30000000-0000-0000-0000-002200030000"), "Yes, in the past 3 months", new Guid("20000000-0000-0000-0000-000000000022"), 6 },
                    { new Guid("30000000-0000-0000-0000-002300010000"), "Never", new Guid("20000000-0000-0000-0000-000000000023"), 0 },
                    { new Guid("30000000-0000-0000-0000-002300020000"), "Yes, but not in the past 3 months", new Guid("20000000-0000-0000-0000-000000000023"), 2 },
                    { new Guid("30000000-0000-0000-0000-002300030000"), "Yes, in the past 3 months", new Guid("20000000-0000-0000-0000-000000000023"), 6 },
                    { new Guid("30000000-0000-0000-0000-002400010000"), "Never", new Guid("20000000-0000-0000-0000-000000000024"), 0 },
                    { new Guid("30000000-0000-0000-0000-002400020000"), "Yes, but not in the past 3 months", new Guid("20000000-0000-0000-0000-000000000024"), 3 },
                    { new Guid("30000000-0000-0000-0000-002400030000"), "Yes, in the past 3 months", new Guid("20000000-0000-0000-0000-000000000024"), 6 },
                    { new Guid("30000000-0000-0000-0000-002500010000"), "Never used", new Guid("20000000-0000-0000-0000-000000000025"), 0 },
                    { new Guid("30000000-0000-0000-0000-002500020000"), "Used 1-2 times", new Guid("20000000-0000-0000-0000-000000000025"), 2 },
                    { new Guid("30000000-0000-0000-0000-002500030000"), "Used monthly", new Guid("20000000-0000-0000-0000-000000000025"), 3 },
                    { new Guid("30000000-0000-0000-0000-002500040000"), "Used weekly", new Guid("20000000-0000-0000-0000-000000000025"), 4 },
                    { new Guid("30000000-0000-0000-0000-002500050000"), "Used daily or almost daily", new Guid("20000000-0000-0000-0000-000000000025"), 6 },
                    { new Guid("30000000-0000-0000-0000-002600010000"), "Never", new Guid("20000000-0000-0000-0000-000000000026"), 0 },
                    { new Guid("30000000-0000-0000-0000-002600020000"), "Once a month", new Guid("20000000-0000-0000-0000-000000000026"), 2 },
                    { new Guid("30000000-0000-0000-0000-002600030000"), "2-4 times a month", new Guid("20000000-0000-0000-0000-000000000026"), 3 },
                    { new Guid("30000000-0000-0000-0000-002600040000"), "2-3 times a week", new Guid("20000000-0000-0000-0000-000000000026"), 4 },
                    { new Guid("30000000-0000-0000-0000-002600050000"), "4 or more times a week", new Guid("20000000-0000-0000-0000-000000000026"), 6 },
                    { new Guid("30000000-0000-0000-0000-002700010000"), "Never used", new Guid("20000000-0000-0000-0000-000000000027"), 0 },
                    { new Guid("30000000-0000-0000-0000-002700020000"), "Used 1-2 times", new Guid("20000000-0000-0000-0000-000000000027"), 2 },
                    { new Guid("30000000-0000-0000-0000-002700030000"), "Used monthly", new Guid("20000000-0000-0000-0000-000000000027"), 3 },
                    { new Guid("30000000-0000-0000-0000-002700040000"), "Used weekly", new Guid("20000000-0000-0000-0000-000000000027"), 4 },
                    { new Guid("30000000-0000-0000-0000-002700050000"), "Used daily or almost daily", new Guid("20000000-0000-0000-0000-000000000027"), 6 },
                    { new Guid("30000000-0000-0000-0000-002800010000"), "Never", new Guid("20000000-0000-0000-0000-000000000028"), 0 },
                    { new Guid("30000000-0000-0000-0000-002800020000"), "Once a month", new Guid("20000000-0000-0000-0000-000000000028"), 2 },
                    { new Guid("30000000-0000-0000-0000-002800030000"), "2-4 times a month", new Guid("20000000-0000-0000-0000-000000000028"), 3 },
                    { new Guid("30000000-0000-0000-0000-002800040000"), "2-3 times a week", new Guid("20000000-0000-0000-0000-000000000028"), 4 },
                    { new Guid("30000000-0000-0000-0000-002800050000"), "4 or more times a week", new Guid("20000000-0000-0000-0000-000000000028"), 6 },
                    { new Guid("30000000-0000-0000-0000-002900010000"), "Never used", new Guid("20000000-0000-0000-0000-000000000029"), 0 },
                    { new Guid("30000000-0000-0000-0000-002900020000"), "Used 1-2 times", new Guid("20000000-0000-0000-0000-000000000029"), 2 },
                    { new Guid("30000000-0000-0000-0000-002900030000"), "Used monthly", new Guid("20000000-0000-0000-0000-000000000029"), 3 },
                    { new Guid("30000000-0000-0000-0000-002900040000"), "Used weekly", new Guid("20000000-0000-0000-0000-000000000029"), 4 },
                    { new Guid("30000000-0000-0000-0000-002900050000"), "Used daily or almost daily", new Guid("20000000-0000-0000-0000-000000000029"), 6 },
                    { new Guid("30000000-0000-0000-0000-003000010000"), "Never", new Guid("20000000-0000-0000-0000-000000000030"), 0 },
                    { new Guid("30000000-0000-0000-0000-003000020000"), "Yes, but not in the past 3 months", new Guid("20000000-0000-0000-0000-000000000030"), 2 },
                    { new Guid("30000000-0000-0000-0000-003000030000"), "Yes, in the past 3 months", new Guid("20000000-0000-0000-0000-000000000030"), 6 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentID", "ConsultantID", "Date", "EndTime", "MemberID", "Note", "StartTime", "Status" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), new Guid("10000000-0000-0000-0000-000000000001"), new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 1, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000006"), "Discuss prevention strategies", new DateTime(2025, 9, 1, 9, 0, 0, 0, DateTimeKind.Utc), "NoResponseYet" },
                    { new Guid("20000000-0000-0000-0000-000000000002"), new Guid("10000000-0000-0000-0000-000000000002"), new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 15, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000006"), "Follow-up session", new DateTime(2025, 9, 2, 14, 0, 0, 0, DateTimeKind.Utc), "Accepted" },
                    { new Guid("20000000-0000-0000-0000-000000000003"), new Guid("10000000-0000-0000-0000-000000000003"), new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 3, 15, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000006"), "Consultation on family support", new DateTime(2025, 9, 3, 14, 0, 0, 0, DateTimeKind.Utc), "Rejected" },
                    { new Guid("20000000-0000-0000-0000-000000000004"), new Guid("10000000-0000-0000-0000-000000000001"), new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 4, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000007"), "Initial consultation", new DateTime(2025, 9, 4, 9, 0, 0, 0, DateTimeKind.Utc), "NoResponseYet" },
                    { new Guid("20000000-0000-0000-0000-000000000005"), new Guid("10000000-0000-0000-0000-000000000002"), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 5, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000007"), "Progress review", new DateTime(2025, 9, 5, 11, 0, 0, 0, DateTimeKind.Utc), "Accepted" },
                    { new Guid("20000000-0000-0000-0000-000000000006"), new Guid("10000000-0000-0000-0000-000000000003"), new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 6, 15, 0, 0, 0, DateTimeKind.Utc), new Guid("10000000-0000-0000-0000-000000000007"), "Discuss prevention plan", new DateTime(2025, 9, 6, 14, 0, 0, 0, DateTimeKind.Utc), "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "AssessmentQuestions",
                columns: new[] { "AssessmentID", "QuestionID" },
                values: new object[,]
                {
                    { new Guid("40000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000001") },
                    { new Guid("40000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000002") },
                    { new Guid("40000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000003") },
                    { new Guid("40000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000004") },
                    { new Guid("40000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000005") },
                    { new Guid("40000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000006") },
                    { new Guid("40000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000007") },
                    { new Guid("40000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000008") },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new Guid("20000000-0000-0000-0000-000000000004") },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new Guid("20000000-0000-0000-0000-000000000005") },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new Guid("20000000-0000-0000-0000-000000000006") },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new Guid("20000000-0000-0000-0000-000000000007") },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new Guid("20000000-0000-0000-0000-000000000008") },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new Guid("20000000-0000-0000-0000-000000000009") },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new Guid("20000000-0000-0000-0000-000000000010") },
                    { new Guid("40000000-0000-0000-0000-000000000002"), new Guid("20000000-0000-0000-0000-000000000011") },
                    { new Guid("40000000-0000-0000-0000-000000000003"), new Guid("20000000-0000-0000-0000-000000000007") },
                    { new Guid("40000000-0000-0000-0000-000000000003"), new Guid("20000000-0000-0000-0000-000000000008") },
                    { new Guid("40000000-0000-0000-0000-000000000003"), new Guid("20000000-0000-0000-0000-000000000009") },
                    { new Guid("40000000-0000-0000-0000-000000000003"), new Guid("20000000-0000-0000-0000-000000000010") },
                    { new Guid("40000000-0000-0000-0000-000000000003"), new Guid("20000000-0000-0000-0000-000000000011") },
                    { new Guid("40000000-0000-0000-0000-000000000003"), new Guid("20000000-0000-0000-0000-000000000012") },
                    { new Guid("40000000-0000-0000-0000-000000000003"), new Guid("20000000-0000-0000-0000-000000000013") },
                    { new Guid("40000000-0000-0000-0000-000000000003"), new Guid("20000000-0000-0000-0000-000000000014") },
                    { new Guid("40000000-0000-0000-0000-000000000004"), new Guid("20000000-0000-0000-0000-000000000010") },
                    { new Guid("40000000-0000-0000-0000-000000000004"), new Guid("20000000-0000-0000-0000-000000000011") },
                    { new Guid("40000000-0000-0000-0000-000000000004"), new Guid("20000000-0000-0000-0000-000000000012") },
                    { new Guid("40000000-0000-0000-0000-000000000004"), new Guid("20000000-0000-0000-0000-000000000013") },
                    { new Guid("40000000-0000-0000-0000-000000000004"), new Guid("20000000-0000-0000-0000-000000000014") },
                    { new Guid("40000000-0000-0000-0000-000000000004"), new Guid("20000000-0000-0000-0000-000000000015") },
                    { new Guid("40000000-0000-0000-0000-000000000004"), new Guid("20000000-0000-0000-0000-000000000016") },
                    { new Guid("40000000-0000-0000-0000-000000000004"), new Guid("20000000-0000-0000-0000-000000000017") },
                    { new Guid("40000000-0000-0000-0000-000000000005"), new Guid("20000000-0000-0000-0000-000000000013") },
                    { new Guid("40000000-0000-0000-0000-000000000005"), new Guid("20000000-0000-0000-0000-000000000014") },
                    { new Guid("40000000-0000-0000-0000-000000000005"), new Guid("20000000-0000-0000-0000-000000000015") },
                    { new Guid("40000000-0000-0000-0000-000000000005"), new Guid("20000000-0000-0000-0000-000000000016") },
                    { new Guid("40000000-0000-0000-0000-000000000005"), new Guid("20000000-0000-0000-0000-000000000017") },
                    { new Guid("40000000-0000-0000-0000-000000000005"), new Guid("20000000-0000-0000-0000-000000000018") },
                    { new Guid("40000000-0000-0000-0000-000000000005"), new Guid("20000000-0000-0000-0000-000000000019") },
                    { new Guid("40000000-0000-0000-0000-000000000005"), new Guid("20000000-0000-0000-0000-000000000020") },
                    { new Guid("40000000-0000-0000-0000-000000000006"), new Guid("20000000-0000-0000-0000-000000000016") },
                    { new Guid("40000000-0000-0000-0000-000000000006"), new Guid("20000000-0000-0000-0000-000000000017") },
                    { new Guid("40000000-0000-0000-0000-000000000006"), new Guid("20000000-0000-0000-0000-000000000018") },
                    { new Guid("40000000-0000-0000-0000-000000000006"), new Guid("20000000-0000-0000-0000-000000000019") },
                    { new Guid("40000000-0000-0000-0000-000000000006"), new Guid("20000000-0000-0000-0000-000000000020") },
                    { new Guid("40000000-0000-0000-0000-000000000006"), new Guid("20000000-0000-0000-0000-000000000021") },
                    { new Guid("40000000-0000-0000-0000-000000000006"), new Guid("20000000-0000-0000-0000-000000000022") },
                    { new Guid("40000000-0000-0000-0000-000000000006"), new Guid("20000000-0000-0000-0000-000000000023") },
                    { new Guid("40000000-0000-0000-0000-000000000007"), new Guid("20000000-0000-0000-0000-000000000019") },
                    { new Guid("40000000-0000-0000-0000-000000000007"), new Guid("20000000-0000-0000-0000-000000000020") },
                    { new Guid("40000000-0000-0000-0000-000000000007"), new Guid("20000000-0000-0000-0000-000000000021") },
                    { new Guid("40000000-0000-0000-0000-000000000007"), new Guid("20000000-0000-0000-0000-000000000022") },
                    { new Guid("40000000-0000-0000-0000-000000000007"), new Guid("20000000-0000-0000-0000-000000000023") },
                    { new Guid("40000000-0000-0000-0000-000000000007"), new Guid("20000000-0000-0000-0000-000000000024") },
                    { new Guid("40000000-0000-0000-0000-000000000007"), new Guid("20000000-0000-0000-0000-000000000025") },
                    { new Guid("40000000-0000-0000-0000-000000000007"), new Guid("20000000-0000-0000-0000-000000000026") },
                    { new Guid("40000000-0000-0000-0000-000000000008"), new Guid("20000000-0000-0000-0000-000000000022") },
                    { new Guid("40000000-0000-0000-0000-000000000008"), new Guid("20000000-0000-0000-0000-000000000023") },
                    { new Guid("40000000-0000-0000-0000-000000000008"), new Guid("20000000-0000-0000-0000-000000000024") },
                    { new Guid("40000000-0000-0000-0000-000000000008"), new Guid("20000000-0000-0000-0000-000000000025") },
                    { new Guid("40000000-0000-0000-0000-000000000008"), new Guid("20000000-0000-0000-0000-000000000026") },
                    { new Guid("40000000-0000-0000-0000-000000000008"), new Guid("20000000-0000-0000-0000-000000000027") },
                    { new Guid("40000000-0000-0000-0000-000000000008"), new Guid("20000000-0000-0000-0000-000000000028") },
                    { new Guid("40000000-0000-0000-0000-000000000008"), new Guid("20000000-0000-0000-0000-000000000029") }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "BlogID", "Content", "ImgUrl", "PublishDate", "ResultLevel", "Status", "Title", "UserID" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Drug addiction is a chronic disease characterized by compulsive drug seeking and use, despite harmful consequences. It affects the brain's structure and function, leading to changes in behavior, judgment, and decision-making. Understanding the root causes, such as genetics, environment, and mental health, is crucial for effective prevention and treatment. Education and support from family and community play a vital role in helping individuals recover and reintegrate into society. Early intervention and access to healthcare services can significantly improve outcomes for those struggling with addiction.", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog1.png?alt=media&token=00189be9-89fc-4201-9548-f45f03de24ad", new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Low", "Opened", "Understanding Drug Addiction", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Preventing drug abuse among youth requires a comprehensive approach involving families, schools, and communities. Education about the risks of drug use, building strong relationships, and promoting healthy activities are key strategies. Programs that teach life skills, resilience, and decision-making can empower young people to resist peer pressure. Parental involvement and open communication are essential in guiding youth towards positive choices. Community support, mentorship, and access to recreational opportunities also help reduce the likelihood of drug experimentation and abuse.", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog2.png?alt=media&token=882b7961-1a12-49cf-ab39-bc730ed194ee", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medium", "Opened", "Prevention Strategies for Youth", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Synthetic drugs, often known as designer drugs, are created to mimic the effects of illegal substances while avoiding legal restrictions. These drugs can be extremely dangerous due to their unpredictable chemical compositions. Users may experience severe health problems, including heart attacks, seizures, and even death. The lack of regulation and quality control increases the risk of contamination and overdose. Raising awareness about the dangers of synthetic drugs is essential for protecting individuals, especially young people, from their harmful effects.", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog3.png?alt=media&token=c0c79651-a466-4564-a2b3-faa58c1d34b1", new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "High", "Opened", "The Dangers of Synthetic Drugs", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "Supporting a friend with addiction requires empathy, patience, and understanding. Avoid judgment and offer a listening ear, encouraging them to seek professional help. Educate yourself about addiction to better understand their struggles. Set healthy boundaries and avoid enabling their behavior. Offer to accompany them to support groups or counseling sessions. Remind them that recovery is a journey and setbacks may occur. Your support can make a significant difference in their motivation and ability to overcome addiction.", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog4.png?alt=media&token=584216e6-487e-4bef-b202-35afda7f9275", new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Low", "Opened", "How to Support a Friend with Addiction", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "Community programs play a vital role in preventing drug abuse by providing education, resources, and support to individuals and families. These programs often include workshops, outreach events, and recreational activities that promote healthy lifestyles. Collaboration between schools, law enforcement, healthcare providers, and local organizations enhances the effectiveness of prevention efforts. By fostering a sense of belonging and purpose, community programs help reduce the risk factors associated with drug use and encourage positive behaviors.", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog5.png?alt=media&token=82bd707b-37fe-4a9b-9f61-625984719a0f", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medium", "Opened", "Community Programs for Drug Prevention", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "Recognizing the early signs of drug use can help prevent addiction and its consequences. Common indicators include changes in behavior, mood swings, withdrawal from family and friends, declining academic or work performance, and neglect of personal hygiene. Physical signs may include bloodshot eyes, sudden weight loss, or unusual smells. If you notice these signs, approach the individual with care and concern, and encourage them to seek help. Early intervention increases the chances of successful recovery.", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog6.png?alt=media&token=a105ef96-fc98-4f31-8fe0-b19329fa9f30", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "High", "Opened", "Recognizing Early Signs of Drug Use", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("10000000-0000-0000-0000-000000000007"), "Drug abuse can have a profound impact on mental health, leading to conditions such as depression, anxiety, and psychosis. Substance use may worsen existing mental health issues or trigger new ones. The relationship between drugs and mental health is complex, as individuals may use drugs to cope with emotional pain, creating a cycle of dependence. Integrated treatment that addresses both substance use and mental health is essential for effective recovery and long-term well-being.", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog7.png?alt=media&token=3346cd6f-524a-41f2-ad42-da1cc2ebe0c0", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medium", "Opened", "The Impact of Drugs on Mental Health", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("10000000-0000-0000-0000-000000000008"), "Drug abuse can result in serious legal consequences, including arrest, fines, and imprisonment. Legal issues may also affect employment, education, and family life. Understanding the laws related to drug possession, distribution, and use is important for making informed decisions. Legal problems can complicate recovery and increase stress, making it harder to overcome addiction. Seeking help early and staying informed about the risks can help individuals avoid these negative outcomes.", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog8.png?alt=media&token=98bbd811-ccfa-4be9-8ff6-5c1d2ff4e0e9", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Low", "Opened", "Legal Consequences of Drug Abuse", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("10000000-0000-0000-0000-000000000009"), "School-based drug prevention programs are designed to educate students about the dangers of drug use and equip them with skills to resist peer pressure. These programs often include interactive lessons, discussions, and activities that promote healthy choices. Involving parents and the wider community enhances their effectiveness. Early education and consistent messaging help create a supportive environment where students feel empowered to make positive decisions and avoid substance abuse.", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog9.png?alt=media&token=c6b08e9d-44e3-45f0-9fd2-f71c8779fb6c", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "High", "Opened", "School-Based Drug Prevention Programs", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("10000000-0000-0000-0000-000000000010"), "Promoting healthy alternatives to drug use is essential for prevention. Encouraging participation in sports, arts, volunteering, and other positive activities provides individuals with a sense of purpose and belonging. These activities help build self-esteem, reduce stress, and foster supportive relationships. Communities and families can support prevention by providing access to resources and opportunities for engagement. By focusing on healthy alternatives, we can reduce the appeal of drugs and support long-term well-being.", "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/blogImage%2Fblog10.png?alt=media&token=e87392a7-47ca-4cdd-a998-454bc5437eff", new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medium", "Opened", "Healthy Alternatives to Drug Use", new Guid("00000000-0000-0000-0000-000000000111") }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "CertificateID", "CertificateName", "DateAcquired", "ImgUrl", "Status", "UserID" },
                values: new object[,]
                {
                    { new Guid("40000000-0000-0000-0000-000000000001"), "Psychology in Drug Prevention", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate1-5-7-10.png?alt=media&token=0a04a34d-41dc-4fef-b21f-e18b305b2b1b", "Active", new Guid("10000000-0000-0000-0000-000000000001") },
                    { new Guid("40000000-0000-0000-0000-000000000002"), "Counseling Skills for Addictive Behaviors", new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate2.png?alt=media&token=678f7712-3e1c-4f76-b2f7-8cfa8d28675f", "Active", new Guid("10000000-0000-0000-0000-000000000001") },
                    { new Guid("40000000-0000-0000-0000-000000000003"), "Dialogue Techniques in Drug Prevention", new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate3.png?alt=media&token=3e8bdb4c-e507-46c5-ad6b-24f7ddec3ec6", "Active", new Guid("10000000-0000-0000-0000-000000000002") },
                    { new Guid("40000000-0000-0000-0000-000000000004"), "Advanced Psychology for Counselors", new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate4.png?alt=media&token=f9a30bd4-3536-43ae-b186-0204db7e3e6b", "Active", new Guid("10000000-0000-0000-0000-000000000002") },
                    { new Guid("40000000-0000-0000-0000-000000000005"), "Drug Abuse Prevention and Intervention", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate1-5-7-10.png?alt=media&token=0a04a34d-41dc-4fef-b21f-e18b305b2b1b", "Active", new Guid("10000000-0000-0000-0000-000000000003") },
                    { new Guid("40000000-0000-0000-0000-000000000006"), "Effective Communication in Counseling", new DateTime(2022, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate6.png?alt=media&token=b5c0caa9-ac2d-45d4-9dc4-de3987c7b94e", "Active", new Guid("10000000-0000-0000-0000-000000000003") },
                    { new Guid("40000000-0000-0000-0000-000000000007"), "Motivational Interviewing for Drug Users", new DateTime(2021, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate1-5-7-10.png?alt=media&token=0a04a34d-41dc-4fef-b21f-e18b305b2b1b", "Active", new Guid("10000000-0000-0000-0000-000000000004") },
                    { new Guid("40000000-0000-0000-0000-000000000008"), "Family Therapy in Drug Prevention", new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate8.png?alt=media&token=038ccee2-7eca-4cb1-8af5-89c78e2957b4", "Active", new Guid("10000000-0000-0000-0000-000000000004") },
                    { new Guid("40000000-0000-0000-0000-000000000009"), "Community-Based Drug Prevention", new DateTime(2022, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate9.png?alt=media&token=fa3904d1-a2b2-4593-88a6-e35a26ce47c8", "Active", new Guid("10000000-0000-0000-0000-000000000005") },
                    { new Guid("40000000-0000-0000-0000-000000000010"), "Psychological Assessment in Counseling", new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://firebasestorage.googleapis.com/v0/b/drug-helper-1c86b.firebasestorage.app/o/certificateImage%2Fcertificate1-5-7-10.png?alt=media&token=0a04a34d-41dc-4fef-b21f-e18b305b2b1b", "Active", new Guid("10000000-0000-0000-0000-000000000005") }
                });

            migrationBuilder.InsertData(
                table: "ConsultantSchedules",
                columns: new[] { "ConsultantScheduleID", "AppointmentID", "Date", "DayOfWeek", "EndTime", "IsAvailable", "Notes", "StartTime", "UserID" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000003"), null, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monday", new TimeSpan(0, 10, 0, 0, 0), false, "Participating in internal training on counseling skills.", new TimeSpan(0, 9, 0, 0, 0), new Guid("10000000-0000-0000-0000-000000000001") },
                    { new Guid("30000000-0000-0000-0000-000000000004"), null, new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wednesday", new TimeSpan(0, 15, 0, 0, 0), false, "Attending a professional meeting with psychologists.", new TimeSpan(0, 14, 0, 0, 0), new Guid("10000000-0000-0000-0000-000000000003") },
                    { new Guid("30000000-0000-0000-0000-000000000005"), null, new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thursday", new TimeSpan(0, 12, 0, 0, 0), false, "Preparing progress reports for the center management.", new TimeSpan(0, 10, 0, 0, 0), new Guid("10000000-0000-0000-0000-000000000004") },
                    { new Guid("30000000-0000-0000-0000-000000000006"), null, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friday", new TimeSpan(0, 9, 0, 0, 0), false, "Participating in a drug prevention communication program.", new TimeSpan(0, 8, 0, 0, 0), new Guid("10000000-0000-0000-0000-000000000005") },
                    { new Guid("30000000-0000-0000-0000-000000000007"), null, new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saturday", new TimeSpan(0, 14, 0, 0, 0), false, "Attending a workshop to share counseling experiences.", new TimeSpan(0, 13, 0, 0, 0), new Guid("10000000-0000-0000-0000-000000000001") },
                    { new Guid("30000000-0000-0000-0000-000000000008"), null, new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunday", new TimeSpan(0, 16, 0, 0, 0), false, "Joining community support extracurricular activities.", new TimeSpan(0, 15, 0, 0, 0), new Guid("10000000-0000-0000-0000-000000000003") },
                    { new Guid("30000000-0000-0000-0000-000000000009"), null, new DateTime(2025, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monday", new TimeSpan(0, 10, 0, 0, 0), false, "Conducting group counseling for new patients.", new TimeSpan(0, 9, 0, 0, 0), new Guid("10000000-0000-0000-0000-000000000004") },
                    { new Guid("30000000-0000-0000-0000-000000000010"), null, new DateTime(2025, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuesday", new TimeSpan(0, 11, 0, 0, 0), false, "Attending a soft skills training program for consultants.", new TimeSpan(0, 10, 0, 0, 0), new Guid("10000000-0000-0000-0000-000000000005") }
                });

            migrationBuilder.InsertData(
                table: "CourseContents",
                columns: new[] { "CourseContentID", "Content", "CourseID", "Title" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), null, new Guid("00000000-0000-0000-0000-000000000001"), "What are Drugs?" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), null, new Guid("00000000-0000-0000-0000-000000000002"), "Causes of Addiction" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), null, new Guid("00000000-0000-0000-0000-000000000003"), "Peer Pressure and Youth" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), null, new Guid("00000000-0000-0000-0000-000000000004"), "Community Programs" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), null, new Guid("00000000-0000-0000-0000-000000000005"), "School Education" },
                    { new Guid("10000000-0000-0000-0000-000000000006"), null, new Guid("00000000-0000-0000-0000-000000000006"), "Family Support" },
                    { new Guid("10000000-0000-0000-0000-000000000011"), null, new Guid("00000000-0000-0000-0000-000000000001"), "What are Drugs?" },
                    { new Guid("10000000-0000-0000-0000-000000000012"), null, new Guid("00000000-0000-0000-0000-000000000001"), "Drug Prevention Basics" },
                    { new Guid("10000000-0000-0000-0000-000000000013"), null, new Guid("00000000-0000-0000-0000-000000000001"), "Risks of Drug Abuse" },
                    { new Guid("10000000-0000-0000-0000-000000000021"), null, new Guid("00000000-0000-0000-0000-000000000002"), "Causes of Addiction" },
                    { new Guid("10000000-0000-0000-0000-000000000022"), null, new Guid("00000000-0000-0000-0000-000000000002"), "Effects of Addiction" },
                    { new Guid("10000000-0000-0000-0000-000000000023"), null, new Guid("00000000-0000-0000-0000-000000000002"), "Addiction Recovery" },
                    { new Guid("10000000-0000-0000-0000-000000000031"), null, new Guid("00000000-0000-0000-0000-000000000003"), "Peer Pressure and Youth" },
                    { new Guid("10000000-0000-0000-0000-000000000032"), null, new Guid("00000000-0000-0000-0000-000000000003"), "Youth Prevention Strategies" },
                    { new Guid("10000000-0000-0000-0000-000000000033"), null, new Guid("00000000-0000-0000-0000-000000000003"), "Youth Support Networks" },
                    { new Guid("10000000-0000-0000-0000-000000000041"), null, new Guid("00000000-0000-0000-0000-000000000004"), "Community Programs" },
                    { new Guid("10000000-0000-0000-0000-000000000042"), null, new Guid("00000000-0000-0000-0000-000000000004"), "Community Engagement" },
                    { new Guid("10000000-0000-0000-0000-000000000043"), null, new Guid("00000000-0000-0000-0000-000000000004"), "Community Resources" },
                    { new Guid("10000000-0000-0000-0000-000000000051"), null, new Guid("00000000-0000-0000-0000-000000000005"), "School Education" },
                    { new Guid("10000000-0000-0000-0000-000000000052"), null, new Guid("00000000-0000-0000-0000-000000000005"), "School Programs" },
                    { new Guid("10000000-0000-0000-0000-000000000053"), null, new Guid("00000000-0000-0000-0000-000000000005"), "School Community" },
                    { new Guid("10000000-0000-0000-0000-000000000061"), null, new Guid("00000000-0000-0000-0000-000000000006"), "Family Support" },
                    { new Guid("10000000-0000-0000-0000-000000000062"), null, new Guid("00000000-0000-0000-0000-000000000006"), "Family Communication" },
                    { new Guid("10000000-0000-0000-0000-000000000063"), null, new Guid("00000000-0000-0000-0000-000000000006"), "Family Prevention Strategies" }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "SurveyID", "Description", "PublishDate", "Status", "Title", "Type", "UserID" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000001"), "What do you think the causes of drug abuse are?", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "The causes of Drug Abuse", "Pre", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000002"), "What strategies do you think are effective in preventing drug abuse?", new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Prevention Strategies for Drug Abuse", "Pre", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000003"), "What is your attitude towards individuals struggling with drug addiction?", new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Attitudes Toward Drug Users", "Post", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000004"), "How effective do you think school-based drug prevention programs are?", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Effectiveness of School Drug Programs", "Post", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000005"), "How can the community contribute to drug prevention activities?", new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Community Involvement in Drug Prevention", "Pre", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000006"), "How do communication and awareness programs impact drug prevention?", new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Impact of Communication Programs", "Post", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000007"), "How does family environment influence drug abuse risk?", new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Family Influence on Drug Abuse", "Pre", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000008"), "How significant is peer pressure in leading to drug use?", new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Peer Pressure and Substance Use", "Pre", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000009"), "How does media portrayal affect perceptions of drug use?", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Media Impact on Drug Perception", "Pre", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000010"), "How well do you understand the laws regarding drug use?", new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Knowledge of Drug Laws", "Pre", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000011"), "Are you aware of available resources for drug prevention?", new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Awareness of Drug Prevention Resources", "Pre", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000012"), "What are your personal beliefs about drug use and its risks?", new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Personal Beliefs About Drug Use", "Pre", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000013"), "What support systems are most helpful for drug recovery?", new DateTime(2024, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Support Systems for Recovery", "Post", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000014"), "What are the main barriers to seeking help for drug problems?", new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Barriers to Seeking Help", "Post", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000015"), "How can schools better support drug prevention efforts?", new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Role of Schools in Prevention", "Post", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000016"), "What do you know about the long-term effects of drug use?", new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Long-term Effects of Drug Use", "Post", new Guid("00000000-0000-0000-0000-000000000111") },
                    { new Guid("30000000-0000-0000-0000-000000000017"), "How does your community view drug prevention efforts?", new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Opened", "Community Attitudes Toward Prevention", "Post", new Guid("00000000-0000-0000-0000-000000000111") }
                });

            migrationBuilder.InsertData(
                table: "ConsultantSchedules",
                columns: new[] { "ConsultantScheduleID", "AppointmentID", "Date", "DayOfWeek", "EndTime", "IsAvailable", "Notes", "StartTime", "UserID" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000002"), new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuesday", new TimeSpan(0, 15, 0, 0, 0), false, "Attending a drug addiction seminar at the center.", new TimeSpan(0, 14, 0, 0, 0), new Guid("10000000-0000-0000-0000-000000000002") },
                    { new Guid("30000000-0000-0000-0000-000000000002"), new Guid("20000000-0000-0000-0000-000000000005"), new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friday", new TimeSpan(0, 12, 0, 0, 0), false, "Providing direct counseling to a patient.", new TimeSpan(0, 11, 0, 0, 0), new Guid("10000000-0000-0000-0000-000000000002") }
                });

            migrationBuilder.InsertData(
                table: "SurveyResults",
                columns: new[] { "ProgramID", "SurveyID", "ResponseData", "SubmitTime", "UserID" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), new Guid("30000000-0000-0000-0000-000000000001"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000002"), new Guid("30000000-0000-0000-0000-000000000002"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000001"), new Guid("30000000-0000-0000-0000-000000000003"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000002"), new Guid("30000000-0000-0000-0000-000000000004"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000003"), new Guid("30000000-0000-0000-0000-000000000005"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000003"), new Guid("30000000-0000-0000-0000-000000000006"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000004"), new Guid("30000000-0000-0000-0000-000000000007"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000005"), new Guid("30000000-0000-0000-0000-000000000008"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000006"), new Guid("30000000-0000-0000-0000-000000000009"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000007"), new Guid("30000000-0000-0000-0000-000000000010"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000008"), new Guid("30000000-0000-0000-0000-000000000011"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000009"), new Guid("30000000-0000-0000-0000-000000000012"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000004"), new Guid("30000000-0000-0000-0000-000000000013"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000005"), new Guid("30000000-0000-0000-0000-000000000014"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000006"), new Guid("30000000-0000-0000-0000-000000000015"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000009"), new Guid("30000000-0000-0000-0000-000000000015"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000007"), new Guid("30000000-0000-0000-0000-000000000016"), null, null, null },
                    { new Guid("20000000-0000-0000-0000-000000000008"), new Guid("30000000-0000-0000-0000-000000000017"), null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionID",
                table: "Answers",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ConsultantID",
                table: "Appointments",
                column: "ConsultantID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_MemberID",
                table: "Appointments",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentQuestions_QuestionID",
                table: "AssessmentQuestions",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentResults_AssessmentID",
                table: "AssessmentResults",
                column: "AssessmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentResults_UserID",
                table: "AssessmentResults",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserID",
                table: "Blogs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_UserID",
                table: "Certificates",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantSchedules_AppointmentID",
                table: "ConsultantSchedules",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantSchedules_UserID",
                table: "ConsultantSchedules",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseContents_CourseID",
                table: "CourseContents",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegistrations_CourseID",
                table: "CourseRegistrations",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramParticipations_ProgramID",
                table: "ProgramParticipations",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResults_ProgramID",
                table: "SurveyResults",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResults_UserID",
                table: "SurveyResults",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_UserID",
                table: "Surveys",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AssessmentQuestions");

            migrationBuilder.DropTable(
                name: "AssessmentResults");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "ConsultantSchedules");

            migrationBuilder.DropTable(
                name: "CourseContents");

            migrationBuilder.DropTable(
                name: "CourseRegistrations");

            migrationBuilder.DropTable(
                name: "ProgramParticipations");

            migrationBuilder.DropTable(
                name: "SurveyResults");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CommunicationPrograms");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
