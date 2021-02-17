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

            // Neue Projektmethode Liste holen und auf die Property in ProjectOverviewViewModel setzen
            DBGet dbGetObj = new DBGet();
            var dbProjectMethodGet = dbGetObj.ProjectMethodGet();
            t_contextProjectOverviewModel.dtagrdProjectMethod = dbProjectMethodGet;
        }

        public void PhaseCreate(string t_Phase_name, int t_Project_method_id,ProjectMethodOverviewViewModel t_contextProjectMethodOverviewViewModel)
        {
            DbPhase.MappingPhase newPhase = new DbPhase.MappingPhase
            {
                Phase_name = t_Phase_name,
                Project_method_id = t_Project_method_id
            };

            Table<DbPhase.MappingPhase> phaseTable = dbConn.GetTable<DbPhase.MappingPhase>();
            phaseTable.InsertOnSubmit(newPhase);
            dbConn.SubmitChanges();

            DBGet dbGetObj = new DBGet();
            var dbPhaseGet = dbGetObj.PhaseGet(t_Project_method_id);
            t_contextProjectMethodOverviewViewModel.lvPhase = dbPhaseGet;
        }
    }
}
