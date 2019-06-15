using App.Core.Entities;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace App.Infrastructure.Queries
{
    public class GetMostRecentQuestionsQuery
    {
        public IList<Question> Execute(MySqlConnection connection)
        {
            string sql = CommonQueries.GetQuestionSql();
            sql += " order by CreatedAt desc limit 30 ";
            var command = new CommandDefinition(sql);
            var resultQuestions = QueryExe.Query<Question>(connection , command);
            return resultQuestions.AsList<Question>();
        }
    }
}
