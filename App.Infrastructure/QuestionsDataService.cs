using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using App.Core.Entities;
using App.Core.Interfaces;
using Dapper;
using App.Core.Utilities;
using System.Data;

namespace App.Infrastructure
{
    public class QuestionsDataService : IQuestionsDataService
    {
        public QuestionsDataService()
        {

        }

        public bool QuestionVoteAlreadyExists(string userId, string questionId){
            Require.NotNullOrEmpty(userId, "userId is required");
            Require.NotNullOrEmpty(questionId, "questionId is required");

            int count = 0;
            using (var connection = DbConnection())
            {
                connection.Open();
                count = connection.QuerySingle<int>(
                @"
                select 
                count(*)
                from QuestionVotes where questionId = @questionId and createdBy = @userId
                ",
                new { questionId, userId });
            }

            return count > 0;
        }

        public bool AnswerVoteAlreadyExists(string userId, string questionAnswerId){
            Require.NotNullOrEmpty(userId, "userId is required");
            Require.NotNullOrEmpty(questionAnswerId, "questionAnswerId is required");

            int count = 0;
            using (var connection = DbConnection())
            {
                connection.Open();
                count = connection.QuerySingle<int>(
                @"
                select 
                count(*)
                from QuestionAnswerVotes where questionAnswerId = @questionAnswerId and createdBy = @userId
                ",
                new { questionAnswerId, userId });
            }

            return count > 0;
        }

        public IEnumerable<Question> GetMostRecentQuestions()
        {
            using (var connection = DbConnection())
            {
                connection.Open();
                string sql = GetQuestionSql();
                sql += " (1=1) order by CreatedAt desc limit 30 ";
                var resultsQuestions = connection.Query<Question>(sql);
                return resultsQuestions.ToList();
            }
        }

        public IEnumerable<Question> SearchByKeyword(string searchPhrase)
        {
            Require.NotNullOrEmpty(searchPhrase, "Search term should not be empty");
            var searchTerms = searchPhrase.Split(' ');
            using (var connection = DbConnection())
            {
                connection.Open();
                string sql = GetQuestionSql();

                var parameters = new DynamicParameters();
                int termCount = 0;
                foreach (var term in searchTerms)
                {
                    var searchTerm = $"%{term}%";
                    var searchTermName = $"@term{termCount}";
                    string searchTermSql = $@" 
                    (questionTitle like {searchTermName} or content like {searchTermName})
                    or id in ( select QuestionId from QuestionAnswers where (answer like {searchTermName}) ) ";

                    if (termCount > 0)
                    {
                        searchTermSql = " or " + searchTermSql;
                    }
                    sql += searchTermSql;
                    parameters.Add(searchTermName, searchTerm, DbType.String, ParameterDirection.Input);
                    termCount++;
                }

                sql += " limit 200 ";

                var resultsQuestions = connection.Query<Question>(sql, parameters);
                return resultsQuestions.ToList();
            }
        }

        private static string GetQuestionSql()
        {
            return @"
                    select distinct
                    Id,
                    QuestionTitle,
                    Tags,
                    Content,
                    CreatedBy,
                    CreatedAt,
                    UpdatedBy,
                    UpdatedAt,
                    (select count(*) from QuestionVotes qv where qv.QuestionId = questions.Id) Votes,
                    (select count(*) from QuestionAnswers qa where qa.QuestionId = questions.Id) AnswerCount
                    from questions
                    where
                    ";
        }

        public IList<QuestionAnswer> GetAnswersForQuestion(string questionId)
        {
            using (var connection = DbConnection())
            {
                connection.Open();
                var resultsQuestionAnswers = connection.Query<QuestionAnswer>(
                @"
                select 
                QuestionId,
                Answer,
                CreatedAt,
                CreatedBy,
                UpdatedAt,
                UpdatedBy,
                (select count(*) from QuestionAnswerVotes where QuestionAnswerId = QuestionAnswers.Id  ) Votes,
                Id
                from QuestionAnswers
                where questionId = @questionId ",
                    new
                    {
                        questionId
                    });

                return resultsQuestionAnswers.ToList();
            }
        }

        public static string DbFile => "app.db";

        public static SQLiteConnection DbConnection()
        {
            return new SQLiteConnection("Data Source=" + DbFile);
        }

        public int GetQuestionVotes(string questionId)
        {
            int voteCount;
            using (var connection = DbConnection())
            {
                connection.Open();
                voteCount = connection.QuerySingle<int>(
                @"
                select 
                count(*)
                from QuestionVotes
                where questionId = @questionId ",
                    new
                    {
                        questionId
                    });
            }

            return voteCount;
        }
    }
}
