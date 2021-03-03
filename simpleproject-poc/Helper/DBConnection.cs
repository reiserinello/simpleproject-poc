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
            // Hostname auslesen und Connectionstring zusammensetzen
            String hostname = Dns.GetHostName();
            String connectionString = "Server=" + hostname + "\\SQLEXPRESS;Database=simpleproject-poc;Connection timeout=30;Integrated Security=True";

            // DB Verbindung aufsetzen
            DataContext dbConnection = new DataContext(connectionString);
            return dbConnection;
        }
    }
}
