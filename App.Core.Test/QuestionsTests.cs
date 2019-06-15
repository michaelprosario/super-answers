using App.Core.Aggregates;
using App.Core.DbEntities;
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
        public void Questions__SearchByKeyword__ItShouldSearchQuestionsContent()
        {
            // arrange
            var questionRepository = Substitute.For<IRepository<Question>>();
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
    }
}
