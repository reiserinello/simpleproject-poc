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
        public DataContext SetupDBConnection()
        {
            DataContext dbConnection = new DataContext("Server=DESKTOP-PQKO1OR\\SQLEXPRESS;Database=simpleproject-poc;Connection timeout=30;Integrated Security=True");
            return dbConnection;
        }
    }
}
