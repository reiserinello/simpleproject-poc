using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Helper
{
    class VProjectProjectMethod
    {
        public int Id { get; }
        public string ProjectName { get; }
        public string MethodName { get; }
        public string Priority { get; }
        public int ProjectProgress { get; }

        public VProjectProjectMethod (int t_Id, string t_ProjectName, string t_MethodName, string t_Priority, int t_ProjectProgress)
        {
            Id = t_Id;
            ProjectName = t_ProjectName;
            MethodName = t_MethodName;
            Priority = t_Priority;
            ProjectProgress = t_ProjectProgress;
        }

        [Table(Name = "v_Project_Project_method")]
        public class dbVProjectProjectMethod
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
            public string Method_name;

            [Column]
            public string Priority;

            [Column]
            public int Project_progress;
        }
    }

    class VProjectPhasePhase
    {
        public int Id { get; }
        public string PhaseState { get; }
        public int PhaseProgress { get; }
        public Nullable<DateTime> PlannedStartdate { get; }
        public Nullable<DateTime> PlannedEnddate { get; }
        public Nullable<DateTime> Startdate { get; }
        public Nullable<DateTime> Enddate { get; }
        public Nullable<DateTime> ApprovalDate { get; }
        public string Visum { get; }
        public Nullable<DateTime> PlannedReviewdate { get; }
        public Nullable<DateTime> Reviewdate { get; }
        public string PhaseDocumentsLink { get; }
        public int ProjectId { get; }
        public int PhaseId { get; }
        public string PhaseName { get; }

        public VProjectPhasePhase(int t_Id, string t_PhaseState, int t_PhaseProgress, Nullable<DateTime> t_PlannedStartdate, Nullable<DateTime> t_PlannedEnddate, Nullable<DateTime> t_Startdate, Nullable<DateTime> t_Enddate, Nullable<DateTime> t_ApprovalDate, string t_Visum, Nullable<DateTime> t_PlannedReviewdate, Nullable<DateTime> t_Reviewdate, string t_PhaseDocumentsLink, int t_ProjectId, int t_PhaseId, string t_PhaseName)
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
            PhaseName = t_PhaseName;
        }

        //SQL mapping
        [Table(Name = "v_Project_phase_Phase")]
        public class dbVProjectPhasePhase
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

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Planned_startdate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Planned_enddate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Startdate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Enddate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Approval_date;

            [Column]
            public string Visum;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Planned_reviewdate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Reviewdate;

            [Column]
            public string Phase_documents_link;

            [Column]
            public int Project_id;

            [Column]
            public int Phase_id;

            [Column]
            public string Phase_name;
        }
    }
}
