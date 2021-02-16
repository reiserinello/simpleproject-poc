using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Net;

namespace simpleproject_poc.Helper
{
    class DBConnection
    {
        public DataContext SetupDBConnection()
        {
            // Get hostname and build connectionString
            String hostname = Dns.GetHostName();
            String connectionString = "Server=" + hostname + "\\SQLEXPRESS;Database=simpleproject-poc;Connection timeout=30;Integrated Security=True";

            // Setup db connection
            DataContext dbConnection = new DataContext(connectionString);
            return dbConnection;
        }
    }
}
