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
                var pm = new ProjectMethod(i.Id,i.Method_name);
                returnList.Add(pm);
            }

            //Close DB connection
            //dbConn.Dispose();

            return returnList;
        }

        public ObservableCollection<Phase> PhaseGet(int t_ProjectMethodId)
        {
            Table<DbPhase.MappingPhase> tblPhase = dbConn.GetTable<DbPhase.MappingPhase>();

            var returnList = new ObservableCollection<Phase>();

            var returnValue =
                               from i_u in tblPhase
                               where i_u.Project_method_id == t_ProjectMethodId
                               select i_u;

            foreach (var i in returnValue)
            {
                //var pm = new ProjectMethod(i.Id, i.Method_name);
                var pm = new Phase(i.Id, i.Phase_name, i.Project_method_id);
                returnList.Add(pm);
            }

            //Close DB connection
            //dbConn.Dispose();

            return returnList;
        }
        */

        public ObservableCollection<dynamic> GeneralGet(string t_table, int t_pkey_referencetable)
        {
            var obReturnList = new ObservableCollection<dynamic>();
            IQueryable<dynamic> filteredQuery;

            switch (t_table)
            {
                case "Project_method":
                    Table<DbProjectMethod.MappingProjectMethod> tblProjectMethod = dbConn.GetTable<DbProjectMethod.MappingProjectMethod>();
                    filteredQuery = from i_u in tblProjectMethod
                                      select i_u;
                    foreach (var i in filteredQuery)
                    {
                        var pm = new ProjectMethod(i.Id, i.Method_name);
                        obReturnList.Add(pm);
                    }
                    break;
                case "Phase":
                    Table<DbPhase.MappingPhase> tblPhase = dbConn.GetTable<DbPhase.MappingPhase>();
                    filteredQuery = from i_u in tblPhase
                                      where i_u.Project_method_id == t_pkey_referencetable
                                      select i_u;
                    foreach (var i in filteredQuery)
                    {
                        var phase = new Phase(i.Id, i.Phase_name, i.Project_method_id);
                        obReturnList.Add(phase);
                    }
                    break;
                case "Project":
                    Table<Project.dbProject> tblProject = dbConn.GetTable<Project.dbProject>();
                    filteredQuery = from entry in tblProject
                                        select entry;
                    foreach (var i in filteredQuery)
                    {
                        Project prj = new Project(i.Id,i.Project_name,i.Project_description,i.Approval_date,i.Priority,i.Project_state,i.Planned_startdate,i.Planned_enddate,i.Startdate,i.Enddate,i.Project_manager,i.Project_progress,i.Project_documents_link,i.Project_method_id);
                        obReturnList.Add(prj);
                    }
                    break;
                /*
                case "v_Project_Project_method":
                    Table<VProjectProjectMethod.dbVProjectProjectMethod> tblVProjectProjectMethod = dbConn.GetTable<VProjectProjectMethod.dbVProjectProjectMethod>();
                    filteredQuery = from entry in tblVProjectProjectMethod
                                        select entry;
                    foreach (var i in filteredQuery)
                    {
                        VProjectProjectMethod prj = new VProjectProjectMethod(i.Id, i.Project_name, i.Method_name, i.Priority, i.Project_progress);
                        obReturnList.Add(prj);
                    }
                    break;
                */
            }

            return obReturnList;
        }
    }
}
