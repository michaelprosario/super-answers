using App.Core;
using App.Core.Entities;
using App.Core.Interfaces;
using App.Core.Utilities;
using App.Infrastructure.Queries;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

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

        public MySqlConnection DbConnection()
        {
            return new MySqlConnection(settings.Value.ConnectionString);
        }

        public Question GetQuestion(string id)
        {
            return new GetQuestionsQuery().Execute(DbConnection(), id);
        }
    }
}
