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
    class DBCreate
    {
        private DataContext dbConn;
        public DBCreate()
        {
            DBConnection dbConnObj = new DBConnection();
            dbConn = dbConnObj.SetupDBConnection();
        }

        public void ProjectMethodCreate(string t_method_name, ProjectOverviewViewModel t_contextProjectOverviewModel)
        {
            //return null;

            DbProjectMethod.MappingProjectMethod newProjectMethod = new DbProjectMethod.MappingProjectMethod
            {
                Method_name = t_method_name
            };

            Table<DbProjectMethod.MappingProjectMethod> projectMethodTable = dbConn.GetTable<DbProjectMethod.MappingProjectMethod>();
            projectMethodTable.InsertOnSubmit(newProjectMethod);
            dbConn.SubmitChanges();

            // Neue Projektmethode Liste holen und auf die Property in ProjectOverviewViewModel setzen
            DBGet dbGetObj = new DBGet();
            var dbProjectMethodGet = dbGetObj.GeneralGet("Project_method",0);
            t_contextProjectOverviewModel.dtagrdProjectMethod = dbProjectMethodGet;
        }

        public void PhaseCreate(string t_Phase_name, int t_Project_method_id,ProjectMethodOverviewViewModel t_contextProjectMethodOverviewViewModel)
        {
            DbPhase.MappingPhase newPhase = new DbPhase.MappingPhase
            {
                Phase_name = t_Phase_name,
                Project_method_id = t_Project_method_id
            };

            Table<DbPhase.MappingPhase> phaseTable = dbConn.GetTable<DbPhase.MappingPhase>();
            phaseTable.InsertOnSubmit(newPhase);
            dbConn.SubmitChanges();

            DBGet dbGetObj = new DBGet();
            var dbPhaseGet = dbGetObj.GeneralGet("Phase",t_Project_method_id);
            t_contextProjectMethodOverviewViewModel.lvPhase = dbPhaseGet;
        }

        public void ProjectCreate(string t_projectname, Priority t_priority, string t_projectmanager, DateTime t_plannedstartdate, DateTime t_plannedenddate, string t_projectdocumentslink, string t_projectdescription, int t_projectmethodid)
        {
            Project.dbProject newProject = new Project.dbProject
            {
                Project_name = t_projectname,
                Priority = t_priority.ToString(),
                Project_state = "WaitingForRelease",
                Project_manager = t_projectmanager,
                Planned_startdate = t_plannedstartdate,
                Planned_enddate = t_plannedenddate,
                Project_progress = 0,
                Project_documents_link = t_projectdocumentslink,
                Project_description = t_projectdescription,
                Project_method_id = t_projectmethodid
            };

            Table<Project.dbProject> tblProject = dbConn.GetTable<Project.dbProject>();
            tblProject.InsertOnSubmit(newProject);
            dbConn.SubmitChanges();

            DBGet dbGetObj = new DBGet();
            var dbGetPhase = dbGetObj.GeneralGet("Phase", t_projectmethodid);
            var dbGetProject = dbGetObj.GeneralGet("Project", 0).Last();

            foreach (var i in dbGetPhase)
            {
                ProjectPhase.dbProjectPhase newProjectPhase = new ProjectPhase.dbProjectPhase
                {
                    Phase_progress = 0,
                    Phase_state = "WaitingForRelease",
                    Project_id = dbGetProject.Id,
                    Phase_id = i.Id
                };

                Table<ProjectPhase.dbProjectPhase> tblProjectPhase = dbConn.GetTable<ProjectPhase.dbProjectPhase>();
                tblProjectPhase.InsertOnSubmit(newProjectPhase);
                dbConn.SubmitChanges();
            }
        }

        public void MilestoneCreate(string t_milestonename, Nullable<DateTime> t_date, int t_projectphaseid)
        {
            Milestone.dbMilestone newMilestone = new Milestone.dbMilestone
            {
                Milestone_name = t_milestonename,
                Date = t_date,
                Project_phase_id = t_projectphaseid
            };

            Table<Milestone.dbMilestone> tblMilestone = dbConn.GetTable<Milestone.dbMilestone>();
            tblMilestone.InsertOnSubmit(newMilestone);
            dbConn.SubmitChanges();
        }

        public void ActivityCreate(string t_activityname, DateTime t_plannedstartdate, DateTime t_plannedenddate, string t_activitydocumentslink, int t_projectphaseid, int t_employeeid)
        {
            Activity.dbActivity newActivity = new Activity.dbActivity
            {
                Activity_name = t_activityname,
                Planned_startdate = t_plannedstartdate,
                Planned_enddate = t_plannedenddate,
                Activity_documents_link = t_activitydocumentslink,
                Activity_progress = 0,
                Project_phase_id = t_projectphaseid,
                Employee_id = t_employeeid
            };

            Table<Activity.dbActivity> tblActivity = dbConn.GetTable<Activity.dbActivity>();
            tblActivity.InsertOnSubmit(newActivity);
            dbConn.SubmitChanges();
        }

        public void DepartmentCreate(string t_departmentname)
        {
            Department.dbDepartment newDepartment = new Department.dbDepartment
            {
                Department_name = t_departmentname
            };

            Table<Department.dbDepartment> tblDepartment = dbConn.GetTable<Department.dbDepartment>();
            tblDepartment.InsertOnSubmit(newDepartment);
            dbConn.SubmitChanges();
        }

        public void EmployeeCreate(string t_name, string t_surname, int t_employeenumber, int t_workload, string t_functions, int t_departmentid)
        {
            Employee.dbEmployee newEmployee = new Employee.dbEmployee
            {
                Name = t_name,
                Surname = t_surname,
                Employee_number = t_employeenumber,
                Workload = t_workload,
                Functions = t_functions,
                Department_id = t_departmentid
            };

            Table<Employee.dbEmployee> tblEmployee = dbConn.GetTable<Employee.dbEmployee>();
            tblEmployee.InsertOnSubmit(newEmployee);
            dbConn.SubmitChanges();
        }
    }
}
