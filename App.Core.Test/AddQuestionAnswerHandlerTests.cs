using App.Core.Handlers;
using App.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace App.Core.Test
{
    [TestClass]
    public class AddQuestionAnswerHandlerTests
    {
        private IRepository<DbEntities.QuestionAnswer> _repository;
        AddQuestionAnswerHandler _handler;

        [TestInitialize]
        public void Intialize()
        {
            _handler = new AddQuestionAnswerHandler(_repository);
        }

        [TestMethod]
        public void HandlerShouldWorkWhenCommandIsFilledOut()
        {
            // arrange
            var _repository = Substitute.For<IRepository<DbEntities.QuestionAnswer>>();
            _repository.Add(Arg.Any<DbEntities.QuestionAnswer>()).Returns(SetupQuestion());
            _handler = new AddQuestionAnswerHandler(_repository);

            var command = new AddQuestionAnswerCommand()
            {
                Answer = "Answer goes here",
                QuestionId = "questionId",
                UserId = "UserId"
            };

            // act
            var response = _handler.Execute(command);

            // assert
            Assert.IsTrue(response != null);
        }

        [TestMethod]
        public void HandlerShouldFailWhenContentNotProvided()
        {
            // arrange
            var repository = Substitute.For<IRepository<DbEntities.QuestionAnswer>>();
            repository.Add(Arg.Any<DbEntities.QuestionAnswer>()).Returns(SetupQuestion());
            var command = new AddQuestionAnswerCommand()
            {
                Answer = "",
                QuestionId = "questionId",
                UserId = "UserId"
            };

            // act
            var response = _handler.Execute(command);

            // assert
            Assert.IsTrue(response != null);
            Assert.IsTrue(response.ValidationErrors.Count > 0);
        }

        private DbEntities.QuestionAnswer SetupQuestion()
        {
            return new DbEntities.QuestionAnswer()
            {
                Id = "123",
                Answer = "answer goes here",
                CreatedBy = "mrosario",
                QuestionId = "234"

            };
        }
    }
}
