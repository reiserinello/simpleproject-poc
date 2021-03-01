using simpleproject_poc.Helper;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Models
{
    class Activity
    {
        public int Id { get; }
        public string ActivityName { get; }
        public DateTime PlannedStartdate { get; }
        public DateTime PlannedEnddate { get; }
        public Nullable<DateTime> Startdate { get; }
        public Nullable<DateTime> Enddate { get; }
        public int ActivityProgress { get; }
        public string ActivityDocumentsLink { get; }
        public int ProjectPhaseId { get; }
        public int EmployeeId { get; }

        public Activity(int t_Id, string t_ActivityName, DateTime t_PlannedStartdate, DateTime t_PlannedEnddate, Nullable<DateTime> t_Startdate, Nullable<DateTime> t_Enddate, int t_ActivityProgress, string t_ActivityDocumentsLink, int t_ProjectPhaseId, int t_EmployeeId)
        {
            Id = t_Id;
            ActivityName = t_ActivityName;
            PlannedStartdate = t_PlannedStartdate;
            PlannedEnddate = t_PlannedEnddate;
            Startdate = t_Startdate;
            Enddate = t_Enddate;
            ActivityProgress = t_ActivityProgress;
            ActivityDocumentsLink = t_ActivityDocumentsLink;
            ProjectPhaseId = t_ProjectPhaseId;
            EmployeeId = t_EmployeeId;
        }

        public void SetDates(Nullable<DateTime> t_Startdate, Nullable<DateTime> t_Enddate)
        {
            DBUpdate dbUpdateObj = new DBUpdate();
            dbUpdateObj.SetActivityDates(Id,t_Startdate,t_Enddate);
        }

        public void SetState(int t_ActivityProgress)
        {
            DBUpdate dbUpdateObj = new DBUpdate();
            dbUpdateObj.SetActivityState(Id,t_ActivityProgress);
        }

        //SQL mapping
        [Table(Name = "Activity")]
        public class dbActivity
        {
            //Mapper auf Primary Key
            [Column(Name = "Id", IsDbGenerated = true, IsPrimaryKey = true)]
            public int Id
            {
                get;
                set;
            }

            //Mapper auf Feld Name
            [Column]
            public string Activity_name;

            [Column]
            public DateTime Planned_startdate;

            [Column]
            public DateTime Planned_enddate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Startdate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Enddate;

            [Column]
            public int Activity_progress;

            [Column]
            public string Activity_documents_link;

            [Column]
            public int Project_phase_id;

            [Column]
            public int Employee_id;
        }
    }
}
