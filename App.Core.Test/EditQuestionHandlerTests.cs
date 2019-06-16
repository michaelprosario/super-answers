using App.Core.DbEntities;
using App.Core.Handlers;
using App.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace App.Core.Test
{
    [TestClass]
    public class EditQuestionHandlerTests
    {
        [TestInitialize]
        public void Intialize()
        {
            _handler = new EditQuestionHandler(_repository);
        }

        [TestMethod]
        public void HandlerShouldWorkWhenCommandIsFilledOut()
        {
            // arrange
            var _repository = Substitute.For<IRepository<Question>>();
            _repository.Update(Arg.Any<Question>());
            _repository.GetById(Arg.Any<string>()).Returns(getRecord());
            _handler = new EditQuestionHandler(_repository);

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
            command.Content = "";

            // act
            var response = _handler.Execute(command);

            // assert
            Assert.IsTrue(response != null);
            Assert.IsTrue(response.ValidationErrors.Count > 0);
        }

        private IRepository<Question> _repository;
        private EditQuestionHandler _handler;

        private Question getRecord()
        {
            return new Question()
            {
                Content = "thing",
                CreatedAt = DateTime.Now,
                CreatedBy = "mrosario",
                Id = "123",
                QuestionTitle = "title",
                Tags = "tag1,tag2"
            };
        }

        private static EditQuestionCommand getCommand()
        {
            return new EditQuestionCommand()
            {
                QuestionId = "123",
                Content = "What is 2 + 2",
                QuestionTitle = "What is 2 +2",
                Tags = "TAG1,TAG2",
                UserId = "mrosario",
                NotifyMeOnResponse = true
            };
        }
    }
}
