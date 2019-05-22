using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using App.Core.Entities;
using App.Core.Interfaces;
using Dapper;
using App.Core.Utilities;

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
