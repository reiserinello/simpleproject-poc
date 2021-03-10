using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Net;

namespace simpleproject_poc.Helper
{
    // Klasse für die DBConnection
    // Wird von den einzelnen DB Manipulationsklassen aufgerufen
    class DBConnection
    {
        public DataContext SetupDBConnection()
        {
            // Connectionstring
            String connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + "simpleproject-poc.mdf" + ";Integrated Security=True;User Instance=True";
            
            // DB Verbindung aufsetzen
            DataContext dbConnection = new DataContext(connectionString);
            return dbConnection;
        }
    }
}
