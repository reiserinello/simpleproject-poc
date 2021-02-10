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
        public int Id { get; }
        public string MethodName { get; }

        public ProjectMethod(int t_PK, string t_ProjectMethodName)
        {
            Id = t_PK;
            MethodName = t_ProjectMethodName;
        }

        public ProjectMethod()
        {
            //nothing
            
        }

        public List<ProjectMethod> Get()
        {
            /*
            DBConnection dbConnObj = new DBConnection();
            var dbConn = dbConnObj.SetupDBConnection();

            Table<dbProjectMethod.mappingProjectMethod> tblProjectMethod = dbConn.GetTable<dbProjectMethod.mappingProjectMethod>();

            var returnList = new List<ProjectMethod>();

            var returnValue =
                               from i_u in tblProjectMethod
                               //where i_u.Username == t_username
                               select i_u;

            foreach (var i in returnValue)
            {
                var pm = new ProjectMethod(i.Id, i.Method_name);
                returnList.Add(pm);
            }

            //Close DB connection
            dbConn.Dispose();

            return returnList;
            */

            DBGet dbGet = new DBGet();
            var dbGetProjectMethod = dbGet.ProjectMethodGet();
            return dbGetProjectMethod;
        }

    }

    class dbProjectMethod
    {
        //SQL mapping
        [Table(Name = "Project_method")]
        public class mappingProjectMethod
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
            public string Method_name;
        }
    }
}
