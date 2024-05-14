using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi14_BTVN.CommonLib
{
    public static class DbHelper
    {
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection sqlConnection = null;

            string connectionString = "Data Source=ZUNGBII-LAPTOP\\SQLEXPRESS;Initial Catalog=BE.NET2402;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True;";

            sqlConnection = new SqlConnection(connectionString);

            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            return sqlConnection;
        }
    }
}
