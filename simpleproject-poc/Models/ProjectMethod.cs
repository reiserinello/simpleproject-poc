using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using simpleproject_poc.Helper;

namespace simpleproject_poc.Models
{
    class ProjectMethod
    {
        public int PK { get; }
        public string ProjectMethodName { get; }

        public ProjectMethod(int t_PK, string t_ProjectMethodName)
        {
            PK = t_PK;
            ProjectMethodName = t_ProjectMethodName;
        }

        public void Create()
        {
            DBConnection dbConnObj = new DBConnection();
            
        }

    }

    class dbProjectMethod
    {
        //SQL mapping
        [Table(Name = "Project_method")]
        public class mappingProjectMethod
        {
            //Mapper auf Primary Key
            [Column(Name = "PKey", IsDbGenerated = true, IsPrimaryKey = true)]
            public int Pkey_1
            {
                get;
                set;
            }

            //Mapper auf Feld Name der Gruppe
            [Column]
            public string Project_method_name;
        }
    }
}
