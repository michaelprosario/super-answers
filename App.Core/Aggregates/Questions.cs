using System.Collections.Generic;
using System.Linq;
using App.Core.Enums;
using App.Core.Handlers;
using App.Core.Interfaces;
using App.Core.Utilities;
using AutoMapper;
using Question = App.Core.Entities.Question;

namespace App.Core.Aggregates
{
    public interface IQuestions
    {
        GetQuestionResponse GetQuestion(GetQuestionRequest request);
        IEnumerable<Question> SearchByKeyword(string searchTerm);
        IEnumerable<Question> GetMostRecentQuestions();
    }

    public class Questions : IQuestions
    {
        private readonly IRepository<DbEntities.Question> _questionRepository;
        private readonly IQuestionsDataService _questionsDataService;
        private readonly IMapper _mapper;

        public Questions(IRepository<DbEntities.Question> questionRepository, IQuestionsDataService questionsDataService, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _questionsDataService = questionsDataService;
            _mapper = mapper;
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
                var question = _mapper.Map<Question>(dbRecord);
                response.Question = question;
                question.ContentAsMarkDown = question.Content;
                question.Content = Markdig.Markdown.ToHtml(question.Content);
                response.Question.Votes = _questionsDataService.GetQuestionVotes(response.Question.Id);
            }

            var answers = _questionsDataService.GetAnswersForQuestion(response.Question.Id);
            if(answers.Any()) {
                foreach (var answer in answers)
                {
                    answer.Answer = Markdig.Markdown.ToHtml(answer.Answer);
                }
                response.Answers = answers.OrderByDescending(r => r.Votes).ToList();
            }

            return response;
        }

        public IEnumerable<Question> SearchByKeyword(string searchTerm)
        {
            Require.ObjectNotNull(searchTerm, "searchTerm should not be null");
            return _questionsDataService.SearchByKeyword(searchTerm);
        }

        public IEnumerable<Question> GetMostRecentQuestions()
        {
            return _questionsDataService.GetMostRecentQuestions();
        }
    }
}