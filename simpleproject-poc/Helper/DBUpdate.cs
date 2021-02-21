using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleproject_poc.Models;
using simpleproject_poc.ViewModels;

namespace simpleproject_poc.Helper
{
    class DBUpdate
    {
        private DataContext dbConn;
        public DBUpdate()
        {
            DBConnection dbConnObj = new DBConnection();
            dbConn = dbConnObj.SetupDBConnection();
        }

        public void SetProjectApprovalDate(ProjectViewViewModel t_contextProjectViewViewModel)
        {
            // Current date
            DateTime thisDay = DateTime.Today;

            Table<Project.dbProject> tblProject = dbConn.GetTable<Project.dbProject>();
            var selectedProject = from entry in tblProject
                                where entry.Id == t_contextProjectViewViewModel.lblProjectKey
                                select entry;
            foreach (var i in selectedProject)
            {
                i.Approval_date = thisDay;
            }
            dbConn.SubmitChanges();
            t_contextProjectViewViewModel.lblApprovalDate = thisDay;
        }
    }
}
