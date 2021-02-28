using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Models
{
    class CostType
    {
        public int Id { get; }
        public string CostTypeName { get; }

        public CostType (int t_Id, string t_CostTypeName)
        {
            Id = t_Id;
            CostTypeName = t_CostTypeName;
        }

        //SQL mapping
        [Table(Name = "Cost_type")]
        public class dbCostType
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
            public string Cost_type_name;
        }
    }
}
