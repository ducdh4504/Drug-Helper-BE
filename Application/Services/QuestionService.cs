using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IAssessmentQuestionRepository _assessmentQuestionRepository;
        private readonly IAnswerRepository _answerRepository;
        private IUnitOfWork _unitOfWork;

        public QuestionService(
            IQuestionRepository questionRepository,
            IAssessmentRepository assessmentRepository,
            IAssessmentQuestionRepository assessmentQuestionRepository,
            IAnswerRepository answerRepository,
            IUnitOfWork unitOfWork)
        {
            _questionRepository = questionRepository;
            _assessmentRepository = assessmentRepository;
            _assessmentQuestionRepository = assessmentQuestionRepository;
            _answerRepository = answerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<QuestionDto?> CreateQuestionAsync(CreateQuestionDto dto)
        {
            var question = new Question
            {
                QuestionID = Guid.NewGuid(),
                Content = dto.Content,
                MaxScore = dto.MaxScore,
                Answers = dto.Answers.Select(a => new Answer
                {
                    Content = a.Content,
                    Score = a.Score
                }).ToList()
            };

            await _questionRepository.AddAsync(question);
            await _unitOfWork.SaveChangesAsync();

            return new QuestionDto
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
            };
        }

        public async Task<bool> DeleteQuestionAsync(Guid questionId)
        {
            // Tìm câu hỏi và include các quan hệ
            var question = await _questionRepository.GetQuestionWithRelationsAsync(questionId);

            if (question == null)
                return false;

            // Xóa các bản ghi trong bảng liên kết AssessmentQuestions
            _assessmentQuestionRepository.RemoveRange(question.AssessmentQuestions);

            // Xóa các đáp án của câu hỏi
            _answerRepository.RemoveRange(question.Answers);
            // Xóa câu hỏi chính
            _questionRepository.Remove(question);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync()
        {
            var questions = await _questionRepository.GetQuestionsWithAnswersAsync();

            return questions.Select(q => new QuestionDto
            {
                QuestionID = q.QuestionID,
                Content = q.Content,
                MaxScore = q.MaxScore,
                Answers = q.Answers.Select(a => new AnswerDto
                {
                    AnswerID = a.AnswerID,
                    Content = a.Content,
                    Score = a.Score
                }).ToList()
            });
        }
        public async Task<QuestionDto?> UpdateAsync(Guid questionId, UpdateQuestionDto dto)
        {
            var question = await _questionRepository.GetQuestionWithAnswersAsync(questionId);
            if (question == null)
                return null;

            // Cập nhật thông tin
            question.Content = dto.Content;
            question.MaxScore = dto.MaxScore;

            // Xoá toàn bộ answers cũ một cách an toàn từ DB
            await _answerRepository.DeleteByQuestionIdAsync(questionId);

            // Gán danh sách answer mới
            var newAnswers = dto.Answers.Select(a => new Answer
            {
                AnswerID = Guid.NewGuid(),
                QuestionID = questionId,
                Content = a.Content,
                Score = a.Score
            }).ToList();

            _answerRepository.AddRangeAsync(newAnswers);

            await _unitOfWork.SaveChangesAsync();

            return new QuestionDto
            {
                QuestionID = question.QuestionID,
                Content = question.Content,
                MaxScore = question.MaxScore,
                Answers = question.Answers.Select(a => new AnswerDto
                {
                    AnswerID = a.AnswerID,
                    Content = a.Content,
                    Score = a.Score
                }).ToList()
            };
        }


    }
}
