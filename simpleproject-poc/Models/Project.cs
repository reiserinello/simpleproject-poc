﻿using simpleproject_poc.Helper;
using simpleproject_poc.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Models
{
    class Project
    {
        private DBUpdate _dbUpdateObj;

        public int Id { get; }
        public string ProjectName { get; }
        public string ProjectDescription { get; }
        public Nullable<DateTime> ApprovalDate { get; }
        public Priority Priority { get; }
        public State ProjectState { get; }
        public DateTime PlannedStartdate { get; }
        public DateTime PlannedEnddate { get; }
        public Nullable<DateTime> Startdate { get; }
        public Nullable<DateTime> Enddate { get; }
        public int ProjectProgress { get; }
        public string ProjectDocumentsLink { get; }
        public int ProjectMethodId { get; }
        public int EmployeeId { get; }

        public Project (int t_Id, string t_ProjectName, string t_ProjectDescription, Nullable<DateTime> t_ApprovalDate, Priority t_Priority, State t_ProjectState, DateTime t_PlannedStartdate, DateTime t_PlannedEnddate, Nullable<DateTime> t_Startdate, Nullable<DateTime> t_Enddate, int t_ProjectProgress, string t_ProjectDocumentsLink, int t_ProjectMethodId, int t_EmployeeId)
        {
            Id = t_Id;
            ProjectName = t_ProjectName;
            ProjectDescription = t_ProjectDescription;
            ApprovalDate = t_ApprovalDate;
            Priority = t_Priority;
            ProjectState = t_ProjectState;
            PlannedStartdate = t_PlannedStartdate;
            PlannedEnddate = t_PlannedEnddate;
            Startdate = t_Startdate;
            Enddate = t_Enddate;
            ProjectProgress = t_ProjectProgress;
            ProjectDocumentsLink = t_ProjectDocumentsLink;
            ProjectMethodId = t_ProjectMethodId;
            EmployeeId = t_EmployeeId;

            _dbUpdateObj = new DBUpdate();
        }

        // Projektdatum setzen
        public void SetDates(Nullable<DateTime> t_StartDate, Nullable<DateTime> t_EndDate)
        {
            _dbUpdateObj.SetProjectDates(Id,t_StartDate,t_EndDate);
        }

        // Projekt freigeben
        public void Release(Nullable<DateTime> t_approvaldate, State t_projectstate)
        {
            _dbUpdateObj.SetProjectApprovalDate(Id,t_approvaldate,t_projectstate);
        }

        // Projektstatus setzen
        public void SetState(int t_progress, State t_state, Priority t_priority)
        {
            _dbUpdateObj.SetProjectState(Id, t_progress, t_state, t_priority);
        }

        // SQL mapping
        [Table(Name = "Project")]
        public class dbProject
        {
            // Mapper auf Primary Key
            [Column(Name = "Id", IsDbGenerated = true, IsPrimaryKey = true)]
            public int Id
            {
                get;
                set;
            }

            // Mapper auf Feld Name
            [Column]
            public string Project_name;

            [Column]
            public string Project_description;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Approval_date;

            [Column]
            public string Priority;

            [Column]
            public string Project_state;

            [Column]
            public DateTime Planned_startdate;

            [Column]
            public DateTime Planned_enddate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Startdate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Enddate;

            [Column]
            public int Project_progress;

            [Column]
            public string Project_documents_link;

            [Column]
            public int Project_method_id;

            [Column]
            public int Employee_id;
        }
    }
}
