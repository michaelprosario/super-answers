using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace App.Infrastructure
{
    public class QueryExe {

        public static T QuerySingle<T>(MySqlConnection mySqlConnection, CommandDefinition command) {
            T output;
            using (var connection = mySqlConnection) {
                connection.Open ();
                output = connection.QuerySingle<T> (command);
            }

            return output;
        }

        public static IEnumerable<T> Query<T>(MySqlConnection mySqlConnection, CommandDefinition command)
        {
            IEnumerable<T> output;
            using (var connection = mySqlConnection)
            {
                connection.Open();
                output = connection.Query<T>(command);
            }

            return output;
        }


    }
}