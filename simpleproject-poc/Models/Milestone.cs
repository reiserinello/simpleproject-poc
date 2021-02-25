using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Models
{
    class Milestone
    {
        public int Id { get; }
        public string MilestoneName { get; }
        public Nullable<DateTime> Date { get; }
        public int ProjectPhaseId { get; }

        public Milestone (int t_Id, string t_MilestoneName, DateTime t_Date, int t_ProjectPhaseId)
        {
            Id = t_Id;
            MilestoneName = t_MilestoneName;
            Date = t_Date;
            ProjectPhaseId = t_ProjectPhaseId;
        }

        //SQL mapping
        [Table(Name = "Milestone")]
        public class dbMilestone
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
            public string Milestone_name;

            [Column]
            public Nullable<DateTime> Date;

            [Column]
            public int Project_phase_id;
        }
    }
}
