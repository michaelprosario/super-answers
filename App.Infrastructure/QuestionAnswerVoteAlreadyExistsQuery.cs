using Dapper;
using MySql.Data.MySqlClient;

namespace App.Infrastructure
{
    public class QuestionAnswerVoteAlreadyExistsQuery {  
        public int Execute (MySqlConnection connection, string userId, string questionAnswerId) {

            string sql = @"
                select 
                count(*)
                from QuestionAnswerVotes
                where questionAnswerId = @questionAnswerId  ";

            var commandDefinition = new CommandDefinition(sql, new { questionAnswerId, userId });
            return new DapperExecutor().QuerySingle<int>(connection, commandDefinition);
        }
    }
}