using App.Core.Entities;
using App.Infrastructure.Queries;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace App.Infrastructure.Queries
{
    public class SearchByKeywordQuery
    {
        public IList<Question> Execute(MySqlConnection connection, string searchPhrase)
        {
            var searchTerms = searchPhrase.Split(' ');
            string sql = CommonQueries.GetQuestionSql();
            var parameters = new DynamicParameters();
            int termCount = 0;

            sql += "AND (";
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
            sql += " ) ";


            sql += " limit 200 ";

            var command = new CommandDefinition(sql, parameters);
            var resultQuestions = QueryExe.Query<Question>(connection , command);
            return resultQuestions.AsList<Question>();
        }
    }
}
