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