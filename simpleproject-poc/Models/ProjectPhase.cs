using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Models
{
    class ProjectPhase
    {
        public int Id { get; }
        public string PhaseState { get; }
        public int PhaseProgress { get; }
        public DateTime PlannedStartdate { get; }
        public DateTime PlannedEnddate { get; }
        public Nullable<DateTime> Startdate { get; }
        public Nullable<DateTime> Enddate { get; }
        public Nullable<DateTime> ApprovalDate { get; }
        public string Visum { get; }
        public DateTime PlannedReviewdate { get; }
        public Nullable<DateTime> Reviewdate { get; }
        public string PhaseDocumentsLink { get; }
        public int ProjectId { get; }
        public int PhaseId { get; }

        public ProjectPhase (int t_Id, string t_PhaseState, int t_PhaseProgress, DateTime t_PlannedStartdate, DateTime t_PlannedEnddate, Nullable<DateTime> t_Startdate, Nullable<DateTime> t_Enddate, Nullable<DateTime> t_ApprovalDate, string t_Visum, DateTime t_PlannedReviewdate, Nullable<DateTime> t_Reviewdate, string t_PhaseDocumentsLink, int t_ProjectId, int t_PhaseId)
        {
            Id = t_Id;
            PhaseState = t_PhaseState;
            PhaseProgress = t_PhaseProgress;
            PlannedStartdate = t_PlannedStartdate;
            PlannedEnddate = t_PlannedEnddate;
            Startdate = t_Startdate;
            Enddate = t_Enddate;
            ApprovalDate = t_ApprovalDate;
            Visum = t_Visum;
            PlannedReviewdate = t_PlannedReviewdate;
            Reviewdate = t_Reviewdate;
            PhaseDocumentsLink = t_PhaseDocumentsLink;
            ProjectId = t_ProjectId;
            PhaseId = t_PhaseId;
        }

        //SQL mapping
        [Table(Name = "Project_phase")]
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
            public string Phase_state;

            [Column]
            public int Phase_progress;

            [Column]
            public DateTime Planned_startdate;

            [Column]
            public DateTime Planned_enddate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Startdate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Enddate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Approval_date;

            [Column]
            public string Visum;

            [Column]
            public DateTime Planned_reviewdate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Reviewdate;

            [Column]
            public string Project_documents_link;

            [Column]
            public int Project_id;

            [Column]
            public int Phase_id;
        }
    }
}
