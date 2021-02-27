using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Models
{
    class Department
    {
        public int Id { get; }
        public string DepartmentName { get; }

        public Department(int t_Id, string t_DepartmentName)
        {
            Id = t_Id;
            DepartmentName = t_DepartmentName;
        }

        //SQL mapping
        [Table(Name = "Department")]
        public class dbDepartment
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
            public string Department_name;
        }
    }
}
