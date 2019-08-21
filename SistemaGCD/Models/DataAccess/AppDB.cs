using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaGCD.Models.DataAccess
{
    public class AppDB
    {
        public SqlConnection Connection;

        public AppDB(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
