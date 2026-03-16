using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class AssessmentQuestionService : IAssessmentQuestionService
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAssessmentQuestionRepository _assessmentQuestionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AssessmentQuestionService(
            IAssessmentRepository assessmentRepository,
            IQuestionRepository questionRepository,
            IAssessmentQuestionRepository assessmentQuestionRepository,
            IUnitOfWork unitOfWork)
        {
            _assessmentRepository = assessmentRepository;
            _questionRepository = questionRepository;
            _assessmentQuestionRepository = assessmentQuestionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Guid>> GetRandomQuestionIdsAsync(int count, Guid? excludeAssessmentId = null)
        {
            var allQuestions = await _questionRepository.GetAllAsync();
            var query = allQuestions.AsQueryable();

            if (excludeAssessmentId.HasValue)
            {
                var linkedQuestionIds = await _assessmentQuestionRepository.GetQueryable()
                    .Where(aq => aq.AssessmentID == excludeAssessmentId.Value)
                    .Select(aq => aq.QuestionID)
                    .ToListAsync();

                query = query.Where(q => !linkedQuestionIds.Contains(q.QuestionID));
            }

            var questions = query
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .Select(q => q.QuestionID)
                .ToList();

            return questions;
        }

        public async Task<bool> IsAssessmentExistsAsync(Guid assessmentId)
        {
            return await _assessmentRepository.GetByIdAsync(assessmentId) != null;
        }

        public async Task<bool> IsQuestionAlreadyLinkedAsync(Guid assessmentId, Guid questionId)
        {
            return await _assessmentQuestionRepository.GetQueryable()
                .AnyAsync(aq => aq.AssessmentID == assessmentId && aq.QuestionID == questionId);
        }

        public async Task<bool> IsQuestionExistsAsync(Guid questionId)
        {
            return await _questionRepository.GetQueryable()
                .AnyAsync(q => q.QuestionID == questionId);
        }

        public async Task<AssessmentQuestionResponseDto> LinkQuestionToAssessmentAsync(AssessmentQuestionRequestDto request)
        {
            if (!await IsAssessmentExistsAsync(request.AssessmentId))
                throw new InvalidOperationException("Assessment không tồn tại");

            if (request.QuestionId.HasValue)
            {
                return await LinkSpecificQuestionAsync(request.AssessmentId, request.QuestionId.Value);
            }
            else
            {
                return await LinkRandomQuestionsToAssessmentAsync(request.AssessmentId, request.RandomQuestionCount ?? 1);
            }
        }

        public async Task<AssessmentQuestionResponseDto> LinkRandomQuestionsToAssessmentAsync(Guid assessmentId, int questionCount)
        {
            var randomQuestionIds = await GetRandomQuestionIdsAsync(questionCount, assessmentId);

            if (randomQuestionIds == null || !randomQuestionIds.Any())
            {
                return new AssessmentQuestionResponseDto
                {
                    AssessmentId = assessmentId,
                    LinkedQuestions = new List<QuestionDto>(),
                    TotalQuestionsLinked = 0,
                    IsRandomlyGenerated = true
                };
            }

            var linkedQuestions = new List<QuestionDto>();

            foreach (var questionId in randomQuestionIds)
            {
                var alreadyLinked = await _assessmentQuestionRepository.GetQueryable()
                    .AnyAsync(aq => aq.AssessmentID == assessmentId && aq.QuestionID == questionId);
                if (alreadyLinked)
                    continue;

                var assessmentQuestion = new AssessmentQuestion
                {
                    AssessmentID = assessmentId,
                    QuestionID = questionId
                };
                await _assessmentQuestionRepository.AddAsync(assessmentQuestion);

                var question = await _questionRepository.GetByIdAsync(questionId);
                if (question != null)
                {
                    linkedQuestions.Add(new QuestionDto
                    {
                        QuestionID = question.QuestionID,
                        Content = question.Content,
                        MaxScore = question.MaxScore,
                        Answers = question.Answers.Select(ans => new AnswerDto
                        {
                            AnswerID = ans.AnswerID,
                            Content = ans.Content,
                            Score = ans.Score
                        }).ToList()
                    });
                }
            }

            await _unitOfWork.SaveChangesAsync();

            return new AssessmentQuestionResponseDto
            {
                AssessmentId = assessmentId,
                LinkedQuestions = linkedQuestions,
                TotalQuestionsLinked = linkedQuestions.Count,
                IsRandomlyGenerated = true
            };
        }

        public async Task<AssessmentQuestionResponseDto> LinkSpecificQuestionAsync(Guid assessmentId, Guid questionId)
        {
            if (!await IsQuestionExistsAsync(questionId))
                throw new InvalidOperationException("Question không tồn tại");

            if (await IsQuestionAlreadyLinkedAsync(assessmentId, questionId))
                throw new InvalidOperationException("Question đã được liên kết với Assessment này");

            var assessmentQuestion = new AssessmentQuestion
            {
                AssessmentID = assessmentId,
                QuestionID = questionId,
            };

            await _assessmentQuestionRepository.AddAsync(assessmentQuestion);
            await _unitOfWork.SaveChangesAsync();

            var question = await _questionRepository.GetByIdAsync(questionId);

            return new AssessmentQuestionResponseDto
            {
                AssessmentId = assessmentId,
                LinkedQuestions = new List<QuestionDto>
                {
                    new QuestionDto
                    {
                        QuestionID = questionId,
                        Content = question.Content,
                        MaxScore = question.MaxScore,
                        Answers = question.Answers.Select(ans => new AnswerDto{
                            AnswerID = ans.AnswerID,
                            Content = ans.Content,
                            Score = ans.Score
                        }).ToList()
                    }
                },
                TotalQuestionsLinked = 1,
                IsRandomlyGenerated = false
            };
        }

        public async Task<bool> RemoveQuestionFromAssessmentAsync(Guid assessmentId, Guid questionId)
        {
            var exists = await _assessmentQuestionRepository.IsQuestionLinkedToAssessmentAsync(assessmentId, questionId);
            if (!exists)
                return false;

            var removed = await _assessmentQuestionRepository.RemoveQuestionFromAssessmentAsync(assessmentId, questionId);
            if (removed)
                await _unitOfWork.SaveChangesAsync();
            return removed;
        }
    }
}