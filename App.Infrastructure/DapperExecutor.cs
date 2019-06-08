using Dapper;
using MySql.Data.MySqlClient;

namespace App.Infrastructure
{
    public class DapperExecutor {

        public DapperExecutor () {
            
        }

        public T QuerySingle<T>(MySqlConnection mySqlConnection, CommandDefinition command) {
            T output;
            using (var connection = mySqlConnection) {
                connection.Open ();
                output = connection.QuerySingle<T> (command);
            }

            return output;
        }        

    }
}