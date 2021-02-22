﻿using System;
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
            var dbProjectMethodGet = dbGetObj.GeneralGet("Project_method",0);
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
            var dbPhaseGet = dbGetObj.GeneralGet("Phase",t_Project_method_id);
            t_contextProjectMethodOverviewViewModel.lvPhase = dbPhaseGet;
        }

        public void ProjectCreate(string t_projectname, Priority t_priority, string t_projectmanager, DateTime t_plannedstartdate, DateTime t_plannedenddate, string t_projectdocumentslink, string t_projectdescription, int t_projectmethodid)
        {
            Project.dbProject newProject = new Project.dbProject
            {
                Project_name = t_projectname,
                Priority = t_priority.ToString(),
                Project_state = "WaitingForRelease",
                Project_manager = t_projectmanager,
                Planned_startdate = t_plannedstartdate,
                Planned_enddate = t_plannedenddate,
                Project_progress = 0,
                Project_documents_link = t_projectdocumentslink,
                Project_description = t_projectdescription,
                Project_method_id = t_projectmethodid
            };

            Table<Project.dbProject> tblProject = dbConn.GetTable<Project.dbProject>();
            tblProject.InsertOnSubmit(newProject);
            dbConn.SubmitChanges();
        }
    }
}
