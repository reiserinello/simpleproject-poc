using simpleproject_poc.Helper;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Models
{
    class EmployeeResource
    {
        public int Id { get; }
        public int BudgetTime { get; }
        public Nullable<int> EffectiveTime { get; }
        public string Deviation { get; }
        public int FunctionId { get; }
        public int ActivityId { get; }

        public EmployeeResource(int t_Id, int t_BudgetTime, Nullable<int> t_EffectiveTime, string t_Deviation, int t_FunctionId, int t_ActivityId)
        {
            Id = t_Id;
            BudgetTime = t_BudgetTime;
            EffectiveTime = t_EffectiveTime;
            Deviation = t_Deviation;
            FunctionId = t_FunctionId;
            ActivityId = t_ActivityId;
        }

        // Effektive Zeit setzen
        public void SetTime(Nullable<int> t_EffectiveTime, string t_Deviation)
        {
            DBUpdate dbUpdateObj = new DBUpdate();
            dbUpdateObj.SetEmployeeResource(Id, t_EffectiveTime, t_Deviation);
        }

        // SQL mapping
        [Table(Name = "Employee_resource")]
        public class dbEmployeeResource
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
            public int Budget_time;

            [Column(CanBeNull = true)]
            public Nullable<int> Effective_time;

            [Column]
            public string Deviation;

            [Column]
            public int Function_id;

            [Column]
            public int Activity_id;
        }
    }
}
