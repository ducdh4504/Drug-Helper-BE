using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Application.Services
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IAnswerRepository _answerRepository;
        private readonly IAssessmentResultRepository _assessmentResultRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICourseRepository _courseRepository;
        private readonly IGenericRepository<Blog> _blogRepository;
        private readonly IAssessmentQuestionRepository _assessmentQuestionRepository;
        private readonly IQuestionRepository _questionRepository;

        public AssessmentService(
            IAssessmentRepository assessmentRepository,
            IAssessmentResultRepository assessmentResultRepository,
            IAnswerRepository answerRepository,
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            ICourseRepository courseRepository,
            IGenericRepository<Blog> blogRepository,
            IAssessmentQuestionRepository assessmentQuestionRepository,
            IQuestionRepository questionRepository
        )
        {
            _assessmentRepository = assessmentRepository;
            _answerRepository = answerRepository;
            _assessmentResultRepository = assessmentResultRepository;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _courseRepository = courseRepository;
            _blogRepository = blogRepository;
            _assessmentQuestionRepository = assessmentQuestionRepository;
            _questionRepository = questionRepository;
        }

        public async Task<IEnumerable<AssessmentDto>> GetAllAsync()
        {
            var assessments = await _assessmentRepository.GetAllActiveAssessmentAsync();
            return assessments.Select(a => new AssessmentDto
            {
                AssessmentID = a.AssessmentID,
                AssessmentName = a.AssessmentName,
                Status = a.Status
            }).ToList();
        }

        public async Task<bool> CreateAssessmentAsync(CreateAssessmentDto dto)
        {
            var roleClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role);
            var role = roleClaim?.Value;

            if (role != RoleEnum.Staff.ToString())
            {
                return false;
            }

            var assessment = new Assessment
            {
                AssessmentName = dto.AssessmentName
            };

            await _assessmentRepository.AddAsync(assessment);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAssessmentAsync(Guid id, UpdateAssessmentDto dto)
        {
            var assessment = await _assessmentRepository.GetByIdAsync(id);
            if (assessment == null) return false;

            assessment.AssessmentName = dto.AssessmentName;
            assessment.Status = dto.Status;

            _assessmentRepository.Update(assessment);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<AssessmentQuestionResponseDto?> GetByIdAsync(Guid id)
        {
            var a = await _assessmentRepository.GetActiveAssessmentByIdAsync(id);
            if (a == null) return null;

            // Lấy danh sách các AssessmentQuestion đã liên kết với assessment này
            var assessmentQuestions = await _assessmentQuestionRepository.GetByAssessmentIdAsync(id);

            // Nếu không có câu hỏi nào liên kết
            if (assessmentQuestions == null || !assessmentQuestions.Any())
            {
                return new AssessmentQuestionResponseDto
                {
                    AssessmentId = a.AssessmentID,
                    LinkedQuestions = new List<QuestionDto>(),
                    TotalQuestionsLinked = 0,
                    IsRandomlyGenerated = false
                };
            }

            // Lấy danh sách các QuestionId đã liên kết
            var questionIds = assessmentQuestions.Select(aq => aq.QuestionID).ToList();

            var linkedQuestions = new List<QuestionDto>();
            foreach (var questionId in questionIds)
            {
                var question = await _questionRepository.GetQuestionsWithAnswersByIdAsync(questionId);
                if (question != null)
                {
                    linkedQuestions.Add(new QuestionDto
                    {
                        QuestionID = question.QuestionID,
                        Content = question.Content,
                        MaxScore = question.MaxScore,
                        Answers = question.Answers?.Select(ans => new AnswerDto
                        {
                            AnswerID = ans.AnswerID,
                            Content = ans.Content,
                            Score = ans.Score
                        }).ToList() ?? new List<AnswerDto>()
                    });
                }
            }

            return new AssessmentQuestionResponseDto
            {
                AssessmentId = a.AssessmentID,
                LinkedQuestions = linkedQuestions,
                TotalQuestionsLinked = linkedQuestions.Count,
                IsRandomlyGenerated = false
            };
        }
        public async Task<SubmitAssessmentResponseDto> SubmitAsync(SubmitAssessmentDto dto)
        {
            int totalScore = 0;

            foreach (var a in dto.Answers)
            {
                var answer = await _answerRepository.GetByIdAndQuestionAsync(a.AnswerId, a.QuestionId);

                if (answer != null)
                {
                    totalScore += answer.Score;
                }
            }

            AssessmentResultEnum resultLevel = AssessmentResultEnum.Low;
            if (totalScore >= 24)
            {
                resultLevel = AssessmentResultEnum.High;
            }
            else if (totalScore >= 3)
            {
                resultLevel = AssessmentResultEnum.Medium;
            }

            Guid resultId = Guid.NewGuid();

            var result = new AssessmentResult
            {
                ResultID = resultId,
                UserID = dto.UserId,
                AssessmentID = dto.AssessmentId,
                Score = totalScore,
                ResultLevel = resultLevel,
                TakeTime = DateTime.UtcNow
            };

            await _assessmentResultRepository.AddAsync(result);

            await _unitOfWork.SaveChangesAsync();

            return new SubmitAssessmentResponseDto
            {
                ResultId = resultId,
            };
        }

        public async Task<IEnumerable<object>> GetRecommendationsAsync(Guid resultId)
        {
            var results = await _assessmentResultRepository.FindAsync(r => r.ResultID == resultId);

            if (results == null || !results.Any())
                return Enumerable.Empty<object>();

            var recommendations = new List<object>();

            foreach (var result in results)
            {
                var courses = await _courseRepository.FindAsync(c =>
                    c.ResultLevel == result.ResultLevel && c.Status == ActivityStatusEnum.Active);

                var blogs = await _blogRepository.FindAsync(b =>
                    b.ResultLevel == result.ResultLevel && b.Status == PaperStatusEnum.Opened);

                recommendations.Add(new
                {
                    AssessmentId = result.AssessmentID,
                    ResultLevel = result.ResultLevel,
                    Courses = courses.Select(c => new
                    {
                        c.CourseID,
                        c.Title,
                        c.contentSummary,
                        c.Description,
                        c.ImgUrl,
                        c.StartDate,
                        c.EndDate
                    }).ToList(),
                    Blogs = blogs.Select(b => new
                    {
                        b.BlogID,
                        b.Title,
                        b.ImgUrl,
                        b.Content,
                        b.PublishDate
                    }).ToList()
                });
            }

            return recommendations;
        }
    }

}