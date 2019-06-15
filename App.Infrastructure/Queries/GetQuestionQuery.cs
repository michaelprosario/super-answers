using App.Core.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System.Linq;

namespace App.Infrastructure.Queries
{
    public class GetQuestionsQuery
    {
        public Question Execute(MySqlConnection connection, string questionId)
        {
            string sql = CommonQueries.GetQuestionSql();
            sql += " and id = @questionId ";
            var command = new CommandDefinition(sql, new { questionId });
            var resultQuestions = QueryExe.Query<Question>(connection , command);
            return resultQuestions.Single();
        }
    }
}
