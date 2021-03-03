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
    // Klasse für alle DB Updaten Operationen
    class DBUpdate
    {
        // DB Verbindung erstellen im Kostruktor
        private DataContext dbConn;
        public DBUpdate()
        {
            DBConnection dbConnObj = new DBConnection();
            dbConn = dbConnObj.SetupDBConnection();
        }

        // Projektdatum setzen
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

        // Projektfreigabe, Freigabedatum und Projektstatus setzen
        public void SetProjectApprovalDate(int t_pkey, Nullable<DateTime> t_approvaldate, State t_projectstate)
        {
            Table<Project.dbProject> tblProject = dbConn.GetTable<Project.dbProject>();
            var selectedProject = from entry in tblProject
                                where entry.Id == t_pkey
                                  select entry;
            foreach (var i in selectedProject)
            {
                i.Approval_date = t_approvaldate;
                i.Project_state = t_projectstate.ToString();
            }
            dbConn.SubmitChanges();
        }

        // Projektstatus setzen
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

        // Projektphasen definieren (nachdem diese aus dem Projekt-Erstellen Vorgang erstellt wurden)
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

        // Phasenfreigabe, Freigabedatum, Visum und Status setzen
        public void SetPhaseApprovalDate(int t_pkey, Nullable<DateTime> t_approvaldate, string t_visum, State t_phasestate)
        {
            Table<ProjectPhase.dbProjectPhase> tblProjectPhase = dbConn.GetTable<ProjectPhase.dbProjectPhase>();
            var selectedProjectPhase = from entry in tblProjectPhase
                                       where entry.Id == t_pkey
                                       select entry;
            foreach (var i in selectedProjectPhase)
            {
                i.Approval_date = t_approvaldate;
                i.Visum = t_visum;
                i.Phase_state = t_phasestate.ToString();
            }
            dbConn.SubmitChanges();
        }

        // Phasendatum setzen
        public void SetPhaseDates(int t_pkey, Nullable<DateTime> t_StartDate, Nullable<DateTime> t_EndDate, Nullable<DateTime> t_ReviewDate)
        {
            Table<ProjectPhase.dbProjectPhase> tblProjectPhase = dbConn.GetTable<ProjectPhase.dbProjectPhase>();
            var selectedProjectPhase = from entry in tblProjectPhase
                                       where entry.Id == t_pkey
                                       select entry;
            foreach (var i in selectedProjectPhase)
            {
                i.Startdate = t_StartDate;
                i.Enddate = t_EndDate;
                i.Reviewdate = t_ReviewDate;
            }
            dbConn.SubmitChanges();
        }

        // Phasenstatus setzen
        public void SetPhaseState(int t_pkey, int t_progress, State t_state)
        {
            Table<ProjectPhase.dbProjectPhase> tblProjectPhase = dbConn.GetTable<ProjectPhase.dbProjectPhase>();
            var selectedProjectPhase = from entry in tblProjectPhase
                                       where entry.Id == t_pkey
                                       select entry;
            foreach (var i in selectedProjectPhase)
            {
                i.Phase_progress = t_progress;
                i.Phase_state = t_state.ToString();
            }
            dbConn.SubmitChanges();
        }

        // Aktivitätsdatum setzen
        public void SetActivityDates(int t_pkey, Nullable<DateTime> t_StartDate, Nullable<DateTime> t_EndDate)
        {
            Table<Activity.dbActivity> tblActivity = dbConn.GetTable<Activity.dbActivity>();
            var selectedActivity = from entry in tblActivity
                                   where entry.Id == t_pkey
                                       select entry;
            foreach (var i in selectedActivity)
            {
                i.Startdate = t_StartDate;
                i.Enddate = t_EndDate;
            }
            dbConn.SubmitChanges();
        }

        // Aktivitätsstatus setzen
        public void SetActivityState(int t_pkey, int t_progress)
        {
            Table<Activity.dbActivity> tblActivity = dbConn.GetTable<Activity.dbActivity>();
            var selectedActivity = from entry in tblActivity
                                       where entry.Id == t_pkey
                                       select entry;
            foreach (var i in selectedActivity)
            {
                i.Activity_progress = t_progress;
            }
            dbConn.SubmitChanges();
        }

        // Externe Kosten setzen (effektiv)
        public void SetExternalCost(int t_pkey, Nullable<int> t_effectivecost, string t_deviation)
        {
            Table<ExternalCost.dbExternalCost> tblExternalCost = dbConn.GetTable<ExternalCost.dbExternalCost>();
            var selectedExternalCost = from entry in tblExternalCost
                                       where entry.Id == t_pkey
                                       select entry;
            foreach (var i in selectedExternalCost)
            {
                i.Effective_cost = t_effectivecost;
                i.Deviation = t_deviation;
            }
            dbConn.SubmitChanges();
        }

        // Personelle Ressourcen setzen (effektiv)
        public void SetEmployeeResource(int t_pkey, Nullable<int> t_effectivetime, string t_deviation)
        {
            Table<EmployeeResource.dbEmployeeResource> tblEmployeeResource = dbConn.GetTable<EmployeeResource.dbEmployeeResource>();
            var selectedExternalCost = from entry in tblEmployeeResource
                                       where entry.Id == t_pkey
                                       select entry;
            foreach (var i in selectedExternalCost)
            {
                i.Effective_time = t_effectivetime;
                i.Deviation = t_deviation;
            }
            dbConn.SubmitChanges();
        }
    }
}
