using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Helper
{
    class VProjectProjectMethod
    {
        public int Id { get; }
        public string ProjectName { get; }
        public string MethodName { get; }
        public string Priority { get; }
        public int ProjectProgress { get; }

        public VProjectProjectMethod (int t_Id, string t_ProjectName, string t_MethodName, string t_Priority, int t_ProjectProgress)
        {
            Id = t_Id;
            ProjectName = t_ProjectName;
            MethodName = t_MethodName;
            Priority = t_Priority;
            ProjectProgress = t_ProjectProgress;
        }

        [Table(Name = "v_Project_Project_method")]
        public class dbVProjectProjectMethod
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
            public string Project_name;

            [Column]
            public string Method_name;

            [Column]
            public string Priority;

            [Column]
            public int Project_progress;
        }
    }
}
