using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace rmanager
{
    public static class Connect
    {
        public static string CnnString(string dbName)
        {
            return ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
        }

        public static readonly MySqlConnection con = new MySqlConnection(CnnString("rmdb"));
    }
}
