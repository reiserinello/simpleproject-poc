using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleproject_poc.Models;
using simpleproject_poc.ViewModels;

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

        public void ProjectMethodCreate(string t_method_name, ProjectOverviewViewModel t_contextProjectOverviewModel)
        {
            //return null;

            DbProjectMethod.MappingProjectMethod newProjectMethod = new DbProjectMethod.MappingProjectMethod
            {
                Method_name = t_method_name
            };

            Table<DbProjectMethod.MappingProjectMethod> projectMethodTable = dbConn.GetTable<DbProjectMethod.MappingProjectMethod>();
            projectMethodTable.InsertOnSubmit(newProjectMethod);
            dbConn.SubmitChanges();

            // Get new project method list and set it on context ProjectOverviewViewModel
            DBGet dbGetProjectMethod = new DBGet();
            var dbGetPM = dbGetProjectMethod.ProjectMethodGet();

            t_contextProjectOverviewModel.dtagrdProjectMethod = dbGetPM;
        }
    }
}
