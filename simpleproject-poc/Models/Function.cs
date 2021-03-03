using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Models
{
    class Function
    {
        public int Id { get; }
        public string FunctionName { get; }

        public Function(int t_Id, string t_FunctionName)
        {
            Id = t_Id;
            FunctionName = t_FunctionName;
        }

        // SQL mapping
        [Table(Name = "Function")]
        public class dbFunction
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
            public string Function_name;
        }
    }
}
