using System.Collections.Generic;
using System.Linq;
using App.Core.Entities;
using App.Core.Interfaces;
using Dapper;
using App.Core.Utilities;
using System.Data;
using App.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using App.Infrastructure.Queries;

namespace App.Infrastructure
{
    public class QuestionsDataService : IQuestionsDataService
    {
        private readonly IOptions<AppSettings> settings;

        public QuestionsDataService(IOptions<AppSettings> settings)
        {
            this.settings = settings;
        }

        public bool AnswerVoteAlreadyExists(string userId, string questionAnswerId)
        {
            Require.NotNullOrEmpty(userId, "userId is required");
            Require.NotNullOrEmpty(questionAnswerId, "questionAnswerId is required");

            int count = new QuestionAnswerVoteAlreadyExistsQuery().Execute(DbConnection(), userId, questionAnswerId);
            return count > 0;
        }

        public IEnumerable<Question> GetMostRecentQuestions()
        {
            return new GetMostRecentQuestionsQuery().Execute(DbConnection());
        }

        public IList<QuestionAnswer> GetAnswersForQuestion(string questionId)
        {
            return new GetAnswersForQuestionQuery().Execute(DbConnection(), questionId).ToList();
        }

        public int GetQuestionVotes(string questionId)
        {
            return new GetQuestionVotesQuery().Execute(DbConnection(), questionId);
        }

        public bool QuestionVoteAlreadyExists(string userId, string questionId)
        {
            Require.NotNullOrEmpty(userId, "userId is required");
            Require.NotNullOrEmpty(questionId, "questionId is required");

            int count = new QuestionVoteAlreadyExistsQuery().Execute(DbConnection(), userId, questionId);
            return count > 0;
        }

        public IEnumerable<Question> SearchByKeyword(string searchPhrase)
        {
            return new SearchByKeywordQuery().Execute(DbConnection(), searchPhrase);
        }

        public MySql.Data.MySqlClient.MySqlConnection DbConnection()
        {
            return new MySql.Data.MySqlClient.MySqlConnection(settings.Value.ConnectionString);
        }
    }
}
