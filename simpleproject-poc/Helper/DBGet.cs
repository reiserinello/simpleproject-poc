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

        // Allgemeine DBGet Funktion mit Datentyp dynamic
        public ObservableCollection<dynamic> GeneralGet(string t_table, int t_pkey_referencetable)
        {
            var obReturnList = new ObservableCollection<dynamic>();
            IQueryable<dynamic> filteredQuery;

            switch (t_table)
            {
                case "Project_method":
                    Table<DbProjectMethod.MappingProjectMethod> tblProjectMethod = dbConn.GetTable<DbProjectMethod.MappingProjectMethod>();
                    filteredQuery = from entry in tblProjectMethod
                                    select entry;
                    
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
                        State projectState = (State)Enum.Parse(typeof(State), i.Project_state);
                        Priority projectPriority = (Priority)Enum.Parse(typeof(Priority), i.Priority);
                        Project prj = new Project(i.Id,i.Project_name,i.Project_description,i.Approval_date, projectPriority, projectState, i.Planned_startdate,i.Planned_enddate,i.Startdate,i.Enddate,i.Project_manager,i.Project_progress,i.Project_documents_link,i.Project_method_id);
                        obReturnList.Add(prj);
                    }
                    break;
            }

            return obReturnList;
        }

        // Spezielle Methode fürs Auslesen des spezifischen Vorgehensmodell für ein Projekt
        public ObservableCollection<ProjectMethod> GetSpecificProjectMethod (int t_pkey)
        {
            var obReturnList = new ObservableCollection<ProjectMethod>();
            Table<DbProjectMethod.MappingProjectMethod> tblProjectMethod = dbConn.GetTable<DbProjectMethod.MappingProjectMethod>();

            var filteredQuery = from entry in tblProjectMethod
                                where entry.Id == t_pkey
                                select entry;
            foreach (var i in filteredQuery)
            {
                var pm = new ProjectMethod(i.Id, i.Method_name);
                obReturnList.Add(pm);
            }
            return obReturnList;
        }
    }
}
