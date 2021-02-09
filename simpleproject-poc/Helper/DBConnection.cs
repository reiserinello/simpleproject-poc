using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace simpleproject_poc.Helper
{
    class DBConnection
    {
        public DBConnection()
        {
            SetupDBConnection();
        }

        public DataContext SetupDBConnection()
        {
            DataContext dbConnection = new DataContext("Server=DESKTOP-35P8P5I\\SQLEXPRESS;Database=Librarysystem;Connection timeout=30;Integrated Security=True");
            return dbConnection;
        }
    }
}
