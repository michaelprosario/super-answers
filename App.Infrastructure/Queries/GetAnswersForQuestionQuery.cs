using App.Core.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace App.Infrastructure.Queries
{
    public class GetAnswersForQuestionQuery
    {
        public IEnumerable<QuestionAnswer> Execute(MySqlConnection connection, string questionId)
        {
            string sql = @"
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
                where questionId = @questionId ";

            var commandDefinition = new CommandDefinition(sql, new { questionId });
            return QueryExe.Query<QuestionAnswer>(connection, commandDefinition);
        }
    }
}
