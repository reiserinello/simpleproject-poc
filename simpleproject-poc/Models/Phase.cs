using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Models
{
    class Phase
    {
        public int Id { get; }
        public string PhaseName { get; }
        public int ProjectMethodId { get; }

        public Phase (int t_Id, string t_PhaseName, int t_ProjectMethodId)
        {
            Id = t_Id;
            PhaseName = t_PhaseName;
            ProjectMethodId = t_ProjectMethodId;
        }
    }

    class DbPhase
    {
        //SQL mapping
        [Table(Name = "Phase")]
        public class MappingPhase
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
            public string Phase_name;

            [Column]
            public int Project_method_id;
        }
    }
}
