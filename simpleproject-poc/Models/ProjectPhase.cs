using simpleproject_poc.Helper;
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
        public State PhaseState { get; }
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

        public ProjectPhase (int t_Id, State t_PhaseState, int t_PhaseProgress, Nullable<DateTime> t_PlannedStartdate, Nullable<DateTime> t_PlannedEnddate, Nullable<DateTime> t_Startdate, Nullable<DateTime> t_Enddate, Nullable<DateTime> t_ApprovalDate, string t_Visum, Nullable<DateTime> t_PlannedReviewdate, Nullable<DateTime> t_Reviewdate, string t_PhaseDocumentsLink, int t_ProjectId, int t_PhaseId)
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

        public ProjectPhase() { }

        public void Define(Nullable<DateTime> t_plannedstartdate, Nullable<DateTime> t_plannedenddate, Nullable<DateTime> t_plannedreviewdate, string t_phasedocumentslink, string t_phasename)
        {
            DBUpdate dbUpdateObj = new DBUpdate();
            dbUpdateObj.DefineProjectPhase(Id,t_plannedstartdate,t_plannedenddate,t_plannedreviewdate,t_phasedocumentslink);

            DBGet dbGetObj = new DBGet();
            var checkMilestone = dbGetObj.GeneralGet("Milestone", Id);

            if (checkMilestone.Count == 0)
            {
                if (t_plannedenddate != null)
                {
                    string milestoneName = t_phasename + " Ende";

                    DBCreate dbCreateObj = new DBCreate();
                    dbCreateObj.MilestoneCreate(milestoneName, t_plannedenddate,Id);
                }
            }
        }

        public void Release(Nullable<DateTime> t_approvaldate, string t_visum, State t_projectphasestate)
        {
            DBUpdate dbUpdateObj = new DBUpdate();
            dbUpdateObj.SetPhaseApprovalDate(Id, t_approvaldate, t_visum, t_projectphasestate);
        }

        public void SetDates(Nullable<DateTime> t_StartDate, Nullable<DateTime> t_EndDate, Nullable<DateTime> t_ReviewDate)
        {
            DBUpdate dbUpdateObj = new DBUpdate();
            dbUpdateObj.SetPhaseDates(Id,t_StartDate,t_EndDate,t_ReviewDate);
        }

        public void SetState(int t_progress, State t_phasestate)
        {
            DBUpdate dbUpdateObj = new DBUpdate();
            dbUpdateObj.SetPhaseState(Id,t_progress,t_phasestate);
        }

        //SQL mapping
        [Table(Name = "Project_phase")]
        public class dbProjectPhase
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
        }
    }
}
