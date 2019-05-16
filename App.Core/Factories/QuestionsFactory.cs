using System.Linq;
using App.Core.Entities;
using App.Core.Enums;
using App.Core.Handlers;
using App.Core.Interfaces;
using App.Core.Utilities;

namespace App.Core.Factories
{
    public interface IQuestionsFactory
    {
        GetQuestionResponse GetQuestion(GetQuestionRequest request);
    }

    public class QuestionsFactory : IQuestionsFactory
    {
        private readonly IRepository<DbEntities.Question> _questionRepository;
        private readonly IQuestionsDataService _questionsDataService;

        public QuestionsFactory(IRepository<DbEntities.Question> questionRepository, IQuestionsDataService questionsDataService)
        {
            _questionRepository = questionRepository;
            _questionsDataService = questionsDataService;
        }

        public GetQuestionResponse GetQuestion(GetQuestionRequest request)
        {
            var response = new GetQuestionResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var dbRecord = _questionRepository.GetById(request.Id);
            if (dbRecord == null)
            {
                response.Code = ResponseCode.NotFound;
            }
            else
            {
                var question = EntityMapper.GetEntity(dbRecord);
                response.Question = question;
            }

            var answers = _questionsDataService.GetAnswersForQuestion(response.Question.Id);
            if(answers.Any()) { 
                response.Answers = answers;
            }

            return response;
        }
    }
}
