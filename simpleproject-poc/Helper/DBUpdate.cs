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
    class DBUpdate
    {
        private DataContext dbConn;
        public DBUpdate()
        {
            DBConnection dbConnObj = new DBConnection();
            dbConn = dbConnObj.SetupDBConnection();
        }

        public void SetProjectDates(int t_pkey, Nullable<DateTime> t_StartDate, Nullable<DateTime> t_EndDate)
        {
            Table<Project.dbProject> tblProject = dbConn.GetTable<Project.dbProject>();
            var selectedProject = from entry in tblProject
                                  where entry.Id == t_pkey
                                  select entry;

            foreach (var i in selectedProject)
            {
                i.Startdate = t_StartDate;
                i.Enddate = t_EndDate;
            }

            dbConn.SubmitChanges();
        }

        public void SetProjectApprovalDate(int t_pkey, Nullable<DateTime> t_approvaldate)
        {
            Table<Project.dbProject> tblProject = dbConn.GetTable<Project.dbProject>();
            var selectedProject = from entry in tblProject
                                where entry.Id == t_pkey
                                  select entry;
            foreach (var i in selectedProject)
            {
                i.Approval_date = t_approvaldate;
            }
            dbConn.SubmitChanges();
        }

        public void SetProjectState(int t_pkey, int t_progress, State t_state, Priority t_priority)
        {
            Table<Project.dbProject> tblProject = dbConn.GetTable<Project.dbProject>();
            var selectedProject = from entry in tblProject
                                  where entry.Id == t_pkey
                                  select entry;
            foreach (var i in selectedProject)
            {
                i.Project_progress = t_progress;
                i.Project_state = t_state.ToString();
                i.Priority = t_priority.ToString();
            }
            dbConn.SubmitChanges();
        }

        public void DefineProjectPhase(int t_pkey, Nullable<DateTime> t_plannedstartdate, Nullable<DateTime> t_plannedenddate, Nullable<DateTime> t_plannedreviewdate, string t_phasedocumentslink)
        {
            Table<ProjectPhase.dbProjectPhase> tblProjectPhase = dbConn.GetTable<ProjectPhase.dbProjectPhase>();
            var selectedProjectPhase = from entry in tblProjectPhase
                                  where entry.Id == t_pkey
                                  select entry;
            foreach (var i in selectedProjectPhase)
            {
                i.Planned_startdate = t_plannedstartdate;
                i.Planned_enddate = t_plannedenddate;
                i.Planned_reviewdate = t_plannedreviewdate;
                i.Phase_documents_link = t_phasedocumentslink;
            }
            dbConn.SubmitChanges();
        }

        public void SetPhaseApprovalDate(int t_pkey, Nullable<DateTime> t_approvaldate, string t_visum)
        {
            // Current date
            //DateTime thisDay = DateTime.Today;

            Table<ProjectPhase.dbProjectPhase> tblProjectPhase = dbConn.GetTable<ProjectPhase.dbProjectPhase>();
            var selectedProjectPhase = from entry in tblProjectPhase
                                       where entry.Id == t_pkey
                                       select entry;
            foreach (var i in selectedProjectPhase)
            {
                i.Approval_date = t_approvaldate;
                i.Visum = t_visum;
            }
            dbConn.SubmitChanges();
        }
    }
}
