using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace MVC7Days.RepositoryData
{
    public class ConnectionStrings
    {
        private static string _dbConnection = ConfigurationManager.ConnectionStrings["ConStr"].ToString();

        public static SqlConnection GetDBConnection()
        {
            return new SqlConnection(_dbConnection);
        }
    }
}