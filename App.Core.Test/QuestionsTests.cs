using App.Core.Aggregates;
using App.Core.DbEntities;
using App.Core.Entities;
using App.Core.Handlers;
using App.Core.Interfaces;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Core.Test
{
    [TestClass]
    public class QuestionsTests
    {
        [TestMethod]
        public void SearchByKeywordShouldSearchContentWhenSearchTermProvided()
        {
            // arrange
            var questionRepository = Substitute.For<IRepository<DbEntities.Question>>();
            var questionViewRepository = Substitute.For<IRepository<QuestionView>>();
            var questionsDataService = Substitute.For<IQuestionsDataService>();
            var mapper = Substitute.For<IMapper>();

            var questions = new Questions(questionRepository, questionsDataService, mapper, questionViewRepository);
            string searchTerm = "foo";

            IEnumerable<Entities.Question> collection = new List<Entities.Question>()
            {
                new Entities.Question()
                {
                    Content = "foo",
                    ContentAsMarkDown = "foo",
                    CreatedAt = DateTime.Now,
                    QuestionTitle = "foo",
                    CreatedBy = "bar",
                    Votes = 3
                }
            };

            questionsDataService.SearchByKeyword(searchTerm).Returns(collection);

            // act
            var questionsResults = questions.SearchByKeyword(searchTerm);

            // assert
            Assert.IsTrue(questions != null);
            Assert.IsTrue(questionsResults.Any());
        }

        [TestMethod]
        public void GetQuestionShouldReturnNotFoundWhenQueryIdBad()
        {
            var questionRepository = Substitute.For<IRepository<DbEntities.Question>>();
            var questionsDataService = Substitute.For<IQuestionsDataService>();
            var mapper = Substitute.For<IMapper>();
            var questionViewRepository = Substitute.For<IRepository<QuestionView>>();

            // arrange
            var query = new GetQuestionQuery();
            query.Id = "bad";
            var questions = new Questions(questionRepository, questionsDataService, mapper, questionViewRepository);

            // act
            var response = questions.GetQuestion(query);

            // assert
            Assert.AreEqual(App.Core.Enums.ResponseCode.NotFound, response.Code);
        }


        IRepository<DbEntities.Question> _questionRepository;
        IQuestionsDataService _questionsDataService;
        IMapper _mapper;
        IRepository<DbEntities.QuestionView> _questionViewRepository;
        [TestInitialize]
        public void SetupTests()
        {
            _questionRepository = Substitute.For<IRepository<DbEntities.Question>>();
            _questionsDataService = Substitute.For<IQuestionsDataService>();
            _mapper = Substitute.For<IMapper>();
            _questionViewRepository = Substitute.For<IRepository<QuestionView>>();
        }

        [TestMethod]
        public void GetQuestionShouldReturnQuestion()
        {
            // arrange
            var query = new GetQuestionQuery
            {
                Id = "123"
            };

            _questionsDataService.GetQuestion(query.Id).Returns(getQuestion());
            var questions = new Questions(_questionRepository, _questionsDataService, _mapper, _questionViewRepository);

            // act
            var response = questions.GetQuestion(query);

            // assert
            Assert.AreEqual(App.Core.Enums.ResponseCode.Success, response.Code);
        }

        [TestMethod]
        public void GetQuestionShouldReturnAnswersIfTheyExist()
        {
            // arrange
            var query = new GetQuestionQuery
            {
                Id = "123"
            };

            _questionsDataService.GetQuestion(query.Id).Returns(getQuestion());
            _questionsDataService.GetAnswersForQuestion(query.Id).Returns(getAnswers());
            var questions = new Questions(_questionRepository, _questionsDataService, _mapper, _questionViewRepository);

            // act
            var response = questions.GetQuestion(query);

            // assert
            Assert.AreEqual(App.Core.Enums.ResponseCode.Success, response.Code);
        }

        private IList<Entities.QuestionAnswer> getAnswers()
        {
            return new List<Entities.QuestionAnswer>()
            {
                new Entities.QuestionAnswer()
                {
                    Answer = "profound answer",
                    CreatedAt = DateTime.Now,
                    CreatedBy = "mrosario",
                    Id = "345",
                    QuestionId = "123",
                    Votes = 1
                }
            };
        }

        [TestMethod]
        public void GetQuestionShouldAddOneView()
        {
            // arrange
            var query = new GetQuestionQuery
            {
                Id = "123"
            };

            _questionsDataService.GetQuestion(query.Id).Returns(getQuestion());
            var questions = new Questions(_questionRepository, _questionsDataService, _mapper, _questionViewRepository);

            // act
            questions.GetQuestion(query);

            // assert
            _questionViewRepository.ReceivedWithAnyArgs().Add(null);
        }

        private static Entities.Question getQuestion()
        {
            return new Entities.Question()
            {
                CreatedAt = DateTime.Now,
                CreatedBy = "mrosario",
                Content = "content",
                Id = "123",
                QuestionTitle = "title",
                Tags = "tag1, tag2, tag3"
            };
        }
    }
}
