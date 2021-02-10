using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleproject_poc.Models;

namespace simpleproject_poc.Helper
{
    class DBGet
    {
        private DataContext dbConn;
        public DBGet()
        {
            DBConnection dbConnObj = new DBConnection();
            dbConn = dbConnObj.SetupDBConnection();
        }

        public List<ProjectMethod> ProjectMethodGet()
        {
            Table<dbProjectMethod.mappingProjectMethod> tblProjectMethod = dbConn.GetTable<dbProjectMethod.mappingProjectMethod>();

            var returnList = new List<ProjectMethod>();

            var returnValue =
                               from i_u in tblProjectMethod
                                   //where i_u.Username == t_username
                               select i_u;

            foreach (var i in returnValue)
            {
                var pm = new ProjectMethod(i.Id, i.Method_name);
                returnList.Add(pm);
            }

            //Close DB connection
            //dbConn.Dispose();

            return returnList;
        }
    }
}
