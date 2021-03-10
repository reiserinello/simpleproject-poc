using simpleproject_poc.Helper;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Models
{
    class ExternalCost
    {
        public int Id { get; }
        public int BudgetCost { get; }
        public Nullable<int> EffectiveCost { get; }
        public string Deviation { get; }
        public int CostTypeId { get; }
        public int ActivityId { get; }

        public ExternalCost(int t_Id, int t_BudgetCost, Nullable<int> t_EffectiveCost, string t_Deviation, int t_CostTypeId, int t_ActivityId)
        {
            Id = t_Id;
            BudgetCost = t_BudgetCost;
            EffectiveCost = t_EffectiveCost;
            Deviation = t_Deviation;
            CostTypeId = t_CostTypeId;
            ActivityId = t_ActivityId;
        }

        // Effektive Kosten setzen
        public void SetCost(Nullable<int> t_EffectiveCost, string t_Deviation)
        {
            DBUpdate dbUpdateObj = new DBUpdate();
            dbUpdateObj.SetExternalCost(Id,t_EffectiveCost,t_Deviation);
        }

        // SQL mapping
        [Table(Name = "External_cost")]
        public class dbExternalCost
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
            public int Budget_cost;

            [Column(CanBeNull = true)]
            public Nullable<int> Effective_cost;

            [Column]
            public string Deviation;

            [Column]
            public int Cost_type_id;

            [Column]
            public int Activity_id;
        }
    }
}
