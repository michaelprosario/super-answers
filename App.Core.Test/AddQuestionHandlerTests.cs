using App.Core.Handlers;
using App.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace App.Core.Test
{
    [TestClass]
    public class AddQuestionHandlerTests
    {
        private IRepository<DbEntities.Question> _repository;
        AddQuestionHandler _handler;

        [TestInitialize]
        public void Intialize()
        {
            _handler = new AddQuestionHandler(_repository);
        }

        [TestMethod]
        public void AddQuestionHandler__Execute__HappyCaseAsync()
        {
            // arrange
            var _repository = Substitute.For<IRepository<DbEntities.Question>>();
            _repository.Add(Arg.Any<DbEntities.Question>()).Returns(SetupQuestion());
            _handler = new AddQuestionHandler(_repository);

            var request = new AddQuestionRequest()
            {
                Content = "What is 2 + 2",
                QuestionTitle = "What is 2 +2",
                Tags = "TAG1,TAG2",
                UserId = "mrosario",
                NotifyMeOnResponse = true
            };

            // act
            var response =  _handler.Execute(request);

            // assert
            Assert.IsTrue(response != null);
        }

        [TestMethod]
        public void AddQuestionHandler__Execute__FailWhenContentEmptyAsync()
        {
            // arrange
            var questionRepository = Substitute.For<IRepository<DbEntities.Question>>();
            questionRepository.Add(Arg.Any<DbEntities.Question>()).Returns(SetupQuestion());
            var request = new AddQuestionRequest()
            {
                Content = "",
                QuestionTitle = "What is 2 +2",
                Tags = "TAG1,TAG2",
                UserId = "mrosario",
                NotifyMeOnResponse = true
            };

            // act
            var response = _handler.Execute(request);

            // assert
            Assert.IsTrue(response != null);
            Assert.IsTrue(response.ValidationErrors.Count > 0);
        }

        private DbEntities.Question SetupQuestion()
        {
            return new DbEntities.Question()
            {
                Content = "What is 2+2?",
                QuestionTitle = "What is 2+2",
                CreatedBy = "mrosario",
                CreatedAt = DateTime.Now
            };
        }
    }
}
