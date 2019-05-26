using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Aggregates;
using App.Core.DbEntities;
using App.Core.Interfaces;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace App.Core.Test
{
    [TestClass]
    public class QuestionsTests
    {
        [TestMethod]
        public void Questions__SearchByKeyword__ItShouldSearchQuestionsContent()
        {
            // arrange
            var questionRepository = NSubstitute.Substitute.For<IRepository<Question>>();
            var questionsDataService = NSubstitute.Substitute.For<IQuestionsDataService>();
            var mapper = NSubstitute.Substitute.For<IMapper>();

            var questions = new Questions(questionRepository, questionsDataService, mapper);
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
    }
}
