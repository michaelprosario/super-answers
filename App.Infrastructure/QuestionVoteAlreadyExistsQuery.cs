using System.Collections.Generic;
using System.Data;
using System.Linq;
using App.Core;
using App.Core.Entities;
using App.Core.Interfaces;
using App.Core.Utilities;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace App.Infrastructure {
    public class QuestionVoteAlreadyExistsQuery {  
        public int Execute (MySqlConnection connection, string questionId, string userId) {

            System.Console.WriteLine(questionId);
            System.Console.WriteLine(userId);
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