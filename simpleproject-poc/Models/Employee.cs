using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Models
{
    class Employee
    {
        public int Id { get; }
        public int EmployeeNumber { get; }
        public string Name { get; }
        public string Surname { get; }
        public int Workload { get; }
        public string Functions { get; }
        public int DepartmentId { get; }

        public Employee (int t_Id, int t_EmployeeNumber, string t_Name, string t_Surname, int t_Workload, string t_Functions, int t_DepartmentId)
        {
            Id = t_Id;
            EmployeeNumber = t_EmployeeNumber;
            Name = t_Name;
            Surname = t_Surname;
            Workload = t_Workload;
            Functions = t_Functions;
            DepartmentId = t_DepartmentId;
        }

        //SQL mapping
        [Table(Name = "Employee")]
        public class dbEmployee
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
            public int Employee_number;

            [Column]
            public string Name;

            [Column]
            public string Surname;

            [Column]
            public int Workload;

            [Column]
            public string Functions;

            [Column]
            public int Department_id;
        }
    }
}
