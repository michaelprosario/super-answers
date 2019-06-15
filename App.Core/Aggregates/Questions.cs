using App.Core.DbEntities;
using App.Core.Enums;
using App.Core.Handlers;
using App.Core.Interfaces;
using App.Core.Utilities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Question = App.Core.Entities.Question;

namespace App.Core.Aggregates
{
    public interface IQuestions
    {
        GetQuestionResponse GetQuestion(GetQuestionQuery request);
        IEnumerable<Question> SearchByKeyword(string searchTerm);
        IEnumerable<Question> GetMostRecentQuestions();
    }

    public class Questions : IQuestions
    {
        private readonly IRepository<DbEntities.Question> _questionRepository;
        private readonly IQuestionsDataService _questionsDataService;
        private readonly IMapper _mapper;
        private readonly IRepository<QuestionView> _questionViewRepository;

        public Questions(IRepository<DbEntities.Question> questionRepository, IQuestionsDataService questionsDataService, IMapper mapper, IRepository<QuestionView> questionViewRepository)
        {
            _questionRepository = questionRepository;
            _questionsDataService = questionsDataService;
            _mapper = mapper;
            _questionViewRepository = questionViewRepository;
        }

        public GetQuestionResponse GetQuestion(GetQuestionQuery query)
        {
            var response = new GetQuestionResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(query, "Query is null.");
            Entities.Question question = _questionsDataService.GetQuestion(query.Id);
            if (question == null)
            {
                response.Code = ResponseCode.NotFound;
            }
            else
            {
                response.Question = question;
                question.ContentAsMarkDown = question.Content;
                question.Content = Markdig.Markdown.ToHtml(question.Content);
            }

            var answers = _questionsDataService.GetAnswersForQuestion(response.Question.Id);
            if(answers.Any()) {
                foreach (var answer in answers)
                {
                    answer.Answer = Markdig.Markdown.ToHtml(answer.Answer);
                }
                response.Answers = answers.OrderByDescending(r => r.Votes).ToList();
            }

            var questionView = new QuestionView()
            {
                CreatedAt = DateTime.Now,
                CreatedBy = query.UserId,
                UpdatedAt = DateTime.Now,
                UpdatedBy = query.UserId,
                QuestionId = query.Id
            };

            _questionViewRepository.Add(questionView);

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