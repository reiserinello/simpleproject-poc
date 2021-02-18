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
        public int Id { get; }
        public string ProjectName { get; }
        public string ProjectDescription { get; }
        public Nullable<DateTime> ApprovalDate { get; }
        public string Priority { get; }
        public string ProjectState { get; }
        public DateTime PlannedStartdate { get; }
        public DateTime PlannedEnddate { get; }
        public Nullable<DateTime> Startdate { get; }
        public Nullable<DateTime> Enddate { get; }
        public string ProjectManager { get; }
        public int ProjectProgress { get; }
        public string ProjectDocumentsLink { get; }
        public int ProjectMethodId { get; }

        public Project (int t_Id, string t_ProjectName, string t_ProjectDescription, Nullable<DateTime> t_ApprovalDate, string t_Priority, string t_ProjectState, DateTime t_PlannedStartdate, DateTime t_PlannedEnddate, Nullable<DateTime> t_Startdate, Nullable<DateTime> t_Enddate, string t_ProjectManager, int t_ProjectProgress, string t_ProjectDocumentsLink, int t_ProjectMethodId)
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
            ProjectManager = t_ProjectManager;
            ProjectProgress = t_ProjectProgress;
            ProjectDocumentsLink = t_ProjectDocumentsLink;
            ProjectMethodId = t_ProjectMethodId;
        }

        //SQL mapping
        [Table(Name = "Project")]
        public class dbProject
        {
            //Mapper auf Primary Key
            [Column(Name = "Id", IsDbGenerated = true, IsPrimaryKey = true)]
            public int Id
            {
                get;
                set;
            }

            //Mapper auf Feld Name der Gruppe
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
            public string Project_manager;

            [Column]
            public int Project_progress;

            [Column]
            public string Project_documents_link;

            [Column]
            public int Project_method_id;
        }
    }
}
