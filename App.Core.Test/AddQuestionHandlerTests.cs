using App.Core.Entities;
using App.Core.Interfaces;
using App.Core.Requests;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace App.Core.Test
{
    [TestClass]
    public class AddQuestionHandlerTests
    {
        ServiceProvider _serviceProvider;
        IMediator _mediator;

        [TestInitialize]
        public void Intialize()
        {
            _serviceProvider = ServiceProviderUtility.GetServiceProvider();
            _mediator = _serviceProvider.GetRequiredService<IMediator>();
        }

        [TestInitialize]
        public void AddQuestionHandler__Handle__HappyCase() {
            // arrange
            var questionRepository = Substitute.For<IRepository<Question>>();
            questionRepository.Add(SetupQuestion());
            var request = SetupRequest();

            // act
            var reseponse = _mediator.Send(request);

            // assert
            Assert.IsTrue(reseponse != null);
        }

        private AddQuestionRequest SetupRequest()
        {
            return new AddQuestionRequest()
            {
                Content = "What is 2 + 2",
                QuestionTitle = "What is 2 +2",
                Tags = "TAG1,TAG2",
                UserId = "mrosario",
                NotifyMeOnResponse = true
            };
        }

        private Question SetupQuestion()
        {
            return new Question()
            {
                Content = "What is 2+2?",
                QuestionTitle = "What is 2+2",
                CreatedBy = "mrosario",
                CreatedAt = DateTime.Now
            };
        }
    }
}
