using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        /*
        Test Genereic returnlist
        public List<T> CreateList<T>(params T[] elements)
        {
            
        }
        */

        public ObservableCollection<ProjectMethod> ProjectMethodGet()
        {
            Table<DbProjectMethod.MappingProjectMethod> tblProjectMethod = dbConn.GetTable<DbProjectMethod.MappingProjectMethod>();

            var returnList = new ObservableCollection<ProjectMethod>();

            var returnValue =
                               from i_u in tblProjectMethod
                                   //where i_u.Username == t_username
                               select i_u;

            foreach (var i in returnValue)
            {
                //var pm = new ProjectMethod(i.Id, i.Method_name);
                var pm = new ProjectMethod { Id = i.Id, MethodName = i.Method_name };
                returnList.Add(pm);
            }

            //Close DB connection
            //dbConn.Dispose();

            return returnList;
        }
    }
}
