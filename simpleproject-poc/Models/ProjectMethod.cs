using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using simpleproject_poc.Helper;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using simpleproject_poc.ViewModels;

namespace simpleproject_poc.Models
{
    class ProjectMethod
    {        
        public int Id { get; }
        public string MethodName { get; }

        public ProjectMethod(int t_Id, string t_MethodName)
        {
            Id = t_Id;
            MethodName = t_MethodName;
        }
    }

    class DbProjectMethod
    {
        // SQL mapping
        [Table(Name = "Project_method")]
        public class MappingProjectMethod
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
            public string Method_name;
        }
    }
}