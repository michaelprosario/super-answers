using Dapper;
using MySql.Data.MySqlClient;

namespace App.Infrastructure
{
    public class GetQuestionVotesQuery
    {
        public int Execute(MySqlConnection connection, string questionId)
        {
            string sql = @" SELECT 
                                COUNT(*) 
                                FROM QuestionVotes 
                                WHERE questionId = @questionId 
                                 ";

            var commandDefinition = new CommandDefinition(sql, new { questionId });
            return new DapperExecutor().QuerySingle<int>(connection, commandDefinition);
        }
    }
}