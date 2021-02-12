using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleproject_poc.Models;

namespace simpleproject_poc.Helper
{
    class DBCreate
    {
        private DataContext dbConn;
        public DBCreate()
        {
            DBConnection dbConnObj = new DBConnection();
            dbConn = dbConnObj.SetupDBConnection();
        }

        public void ProjectMethodCreate(string t_method_name)
        {
            //return null;

            DbProjectMethod.MappingProjectMethod newProjectMethod = new DbProjectMethod.MappingProjectMethod
            {
                Method_name = t_method_name
            };

            Table<DbProjectMethod.MappingProjectMethod> projectMethodTable = dbConn.GetTable<DbProjectMethod.MappingProjectMethod>();
            projectMethodTable.InsertOnSubmit(newProjectMethod);
            dbConn.SubmitChanges();
        }
    }
}
