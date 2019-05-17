﻿using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using App.Core.Entities;
using App.Core.Interfaces;
using Dapper;

namespace App.Infrastructure
{
    public class QuestionsDataService : IQuestionsDataService
    {
        public QuestionsDataService()
        {

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
                Votes,
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
