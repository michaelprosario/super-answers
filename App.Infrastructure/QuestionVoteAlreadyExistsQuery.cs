using Dapper;
using MySql.Data.MySqlClient;

namespace App.Infrastructure
{
    public class QuestionVoteAlreadyExistsQuery {  
        public int Execute (MySqlConnection connection, string userId, string questionId) {
            string sql = @" SELECT 
                                COUNT(*) 
                                FROM QuestionVotes 
                                WHERE questionId = @questionId 
                                AND createdBy = @userId ";

            var commandDefinition = new CommandDefinition(sql, new { questionId, userId });
            return new DapperExecutor().QuerySingle<int>(connection, commandDefinition);
        }
    }
}