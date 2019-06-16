using App.Core.DbEntities;
using App.Core.Handlers;
using App.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace App.Core.Test
{
    [TestClass]
    public class EditQuestionAnswerHandlerTests
    {
        [TestInitialize]
        public void Intialize()
        {
            _handler = new EditQuestionAnswerHandler(_repository);
        }

        [TestMethod]
        public void HandlerShouldWorkWhenCommandIsFilledOut()
        {
            // arrange
            var _repository = Substitute.For<IRepository<QuestionAnswer>>();
            _repository.Update(Arg.Any<QuestionAnswer>());
            _repository.GetById(Arg.Any<string>()).Returns(getRecord());
            _handler = new EditQuestionAnswerHandler(_repository);

            var command = getCommand();

            // act
            var response = _handler.Execute(command);

            // assert
            Assert.IsTrue(response.Code == Enums.ResponseCode.Success);
        }

        [TestMethod]
        public void HandlerShouldFailWhenContentNotProvided()
        {
            // arrange
            var questionRepository = Substitute.For<IRepository<DbEntities.Question>>();
            questionRepository.Update(Arg.Any<DbEntities.Question>());
            var command = getCommand();
            command.Answer = "";

            // act
            var response = _handler.Execute(command);

            // assert
            Assert.IsTrue(response != null);
            Assert.IsTrue(response.ValidationErrors.Count > 0);
        }

        private IRepository<QuestionAnswer> _repository;
        private EditQuestionAnswerHandler _handler;

        private QuestionAnswer getRecord()
        {
            return new QuestionAnswer()
            {
                Answer = "answer",
                CreatedAt = DateTime.Now,
                CreatedBy = "mrosario",
                Id = "123",
                QuestionId = "234"
            };
        }

        private static EditQuestionAnswerCommand getCommand()
        {
            return new EditQuestionAnswerCommand()
            {
                Answer = "answer",
                Id = "123",
                UserId = "mrosario"
            };
        }
    }
}
