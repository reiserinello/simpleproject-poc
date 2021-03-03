using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleproject_poc.Models;

namespace simpleproject_poc.Helper
{
    // Klasse für alle DB Auslesen (SELECT) Operationen
    class DBGet
    {
        // DB Verbindung erstellen im Kostruktor
        private DataContext dbConn;
        public DBGet()
        {
            DBConnection dbConnObj = new DBConnection();
            dbConn = dbConnObj.SetupDBConnection();
        }

        // Allgemeine DBGet Funktion mit Datentyp dynamic
        // Über den Paramter t_table wird entschieden, welche Tabelle / SQL View ausgelesen werden muss
        public ObservableCollection<dynamic> GeneralGet(string t_table, int t_pkey_referencetable)
        {
            var obReturnList = new ObservableCollection<dynamic>();
            IQueryable<dynamic> filteredQuery;

            switch (t_table)
            {
                case "Project_method":
                    Table<DbProjectMethod.MappingProjectMethod> tblProjectMethod = dbConn.GetTable<DbProjectMethod.MappingProjectMethod>();
                    filteredQuery = from entry in tblProjectMethod
                                    select entry;
                    
                    foreach (var i in filteredQuery)
                    {
                        var pm = new ProjectMethod(i.Id, i.Method_name);
                        obReturnList.Add(pm);
                    }
                    break;
                case "Phase":
                    Table<DbPhase.MappingPhase> tblPhase = dbConn.GetTable<DbPhase.MappingPhase>();
                    filteredQuery = from i_u in tblPhase
                                      where i_u.Project_method_id == t_pkey_referencetable
                                      select i_u;
                    foreach (var i in filteredQuery)
                    {
                        var phase = new Phase(i.Id, i.Phase_name, i.Project_method_id);
                        obReturnList.Add(phase);
                    }
                    break;
                case "Project":
                    Table<Project.dbProject> tblProject = dbConn.GetTable<Project.dbProject>();
                    filteredQuery = from entry in tblProject
                                        select entry;
                    foreach (var i in filteredQuery)
                    {
                        State projectState = (State)Enum.Parse(typeof(State), i.Project_state);
                        Priority projectPriority = (Priority)Enum.Parse(typeof(Priority), i.Priority);
                        Project prj = new Project(i.Id,i.Project_name,i.Project_description,i.Approval_date, projectPriority, projectState, i.Planned_startdate,i.Planned_enddate,i.Startdate,i.Enddate,i.Project_manager,i.Project_progress,i.Project_documents_link,i.Project_method_id);
                        obReturnList.Add(prj);
                    }
                    break;
                case "v_Project_phase_Phase":
                    Table<VProjectPhasePhase.dbVProjectPhasePhase> tblProjectPhasePhase = dbConn.GetTable<VProjectPhasePhase.dbVProjectPhasePhase>();
                    filteredQuery = from entry in tblProjectPhasePhase
                                    where entry.Project_id == t_pkey_referencetable
                                    select entry;
                    foreach (var i in filteredQuery)
                    {
                        State phaseState = (State)Enum.Parse(typeof(State), i.Phase_state);
                        var projectphase = new VProjectPhasePhase(i.Id, phaseState, i.Phase_progress,i.Planned_startdate,i.Planned_enddate,i.Startdate,i.Enddate,i.Approval_date,i.Visum,i.Planned_reviewdate,i.Reviewdate,i.Phase_documents_link,i.Project_id,i.Phase_id,i.Phase_name);
                        obReturnList.Add(projectphase);
                    }
                    break;
                case "Milestone":
                    Table<Milestone.dbMilestone> tblMilestone = dbConn.GetTable<Milestone.dbMilestone>();
                    filteredQuery = from entry in tblMilestone
                                    where entry.Project_phase_id == t_pkey_referencetable
                                    select entry;
                    foreach (var i in filteredQuery)
                    {
                        var ms = new Milestone(i.Id,i.Milestone_name,i.Date,i.Project_phase_id);
                        obReturnList.Add(ms);
                    }
                    break;
                case "Activity":
                    Table<Activity.dbActivity> tblActivity = dbConn.GetTable<Activity.dbActivity>();
                    filteredQuery = from entry in tblActivity
                                    where entry.Project_phase_id == t_pkey_referencetable
                                    select entry;
                    foreach (var i in filteredQuery)
                    {
                        var activity = new Activity(i.Id,i.Activity_name,i.Planned_startdate,i.Planned_enddate,i.Startdate,i.Enddate,i.Activity_progress,i.Activity_documents_link,i.Project_phase_id,i.Employee_id);
                        obReturnList.Add(activity);
                    }
                    break;
                case "Employee":
                    Table<Employee.dbEmployee> tblEmployee = dbConn.GetTable<Employee.dbEmployee>();
                    filteredQuery = from entry in tblEmployee
                                    select entry;
                    foreach (var i in filteredQuery)
                    {
                        var employee = new Employee(i.Id,i.Employee_number,i.Name,i.Surname,i.Workload,i.Functions,i.Department_id);
                        obReturnList.Add(employee);
                    }
                    break;
                case "v_Employee_Department":
                    Table<VEmployeeDepartment.dbVEmployeeDepartment> tblAssignedEmployeeDepartment = dbConn.GetTable<VEmployeeDepartment.dbVEmployeeDepartment>();
                    filteredQuery = from entry in tblAssignedEmployeeDepartment
                                    where entry.Id == t_pkey_referencetable
                                    select entry;
                    foreach (var i in filteredQuery)
                    {
                        var employee = new VEmployeeDepartment(i.Id, i.Employee_number, i.Name, i.Surname, i.Workload, i.Functions, i.Department_name);
                        obReturnList.Add(employee);
                    }
                    break;
                case "Department":
                    Table<Department.dbDepartment> tblDepartment = dbConn.GetTable<Department.dbDepartment>();
                    filteredQuery = from entry in tblDepartment
                                    select entry;
                    foreach (var i in filteredQuery)
                    {
                        var department = new Department(i.Id,i.Department_name);
                        obReturnList.Add(department);
                    }
                    break;
                case "Cost_type":
                    Table<CostType.dbCostType> tblCostType = dbConn.GetTable<CostType.dbCostType>();
                    filteredQuery = from entry in tblCostType
                                    select entry;
                    foreach (var i in filteredQuery)
                    {
                        var costtype = new CostType(i.Id,i.Cost_type_name);
                        obReturnList.Add(costtype);
                    }
                    break;
                case "v_External_cost_Cost_type":
                    Table<VExternalCostCostType.dbVExternalCostCostType> tblVExternalCost = dbConn.GetTable<VExternalCostCostType.dbVExternalCostCostType>();
                    filteredQuery = from entry in tblVExternalCost
                                    where entry.Activity_id == t_pkey_referencetable
                                    select entry;
                    foreach (var i in filteredQuery)
                    {
                        var externalcost = new VExternalCostCostType(i.Id,i.Budget_cost,i.Effective_cost,i.Deviation,i.Cost_type_name,i.Cost_type_id,i.Activity_id);
                        obReturnList.Add(externalcost);
                    }
                    break;
                case "Function":
                    Table<Function.dbFunction> tblFunction = dbConn.GetTable<Function.dbFunction>();
                    filteredQuery = from entry in tblFunction
                                    select entry;
                    foreach (var i in filteredQuery)
                    {
                        var function = new Function(i.Id, i.Function_name);
                        obReturnList.Add(function);
                    }
                    break;
                case "v_Employee_resource_Function":
                    Table<VEmployeeResourceFunction.dbVEmployeeResourceFunction> tblVEmployeeResource = dbConn.GetTable<VEmployeeResourceFunction.dbVEmployeeResourceFunction>();
                    filteredQuery = from entry in tblVEmployeeResource
                                    where entry.Activity_id == t_pkey_referencetable
                                    select entry;
                    foreach (var i in filteredQuery)
                    {
                        var employeeresource = new VEmployeeResourceFunction(i.Id, i.Budget_time, i.Effective_time, i.Deviation, i.Function_name, i.Function_id, i.Activity_id);
                        obReturnList.Add(employeeresource);
                    }
                    break;
            }

            return obReturnList;
        }

        // Spezielle Methode fürs Auslesen des spezifischen Vorgehensmodell für ein Projekt
        public ObservableCollection<ProjectMethod> GetSpecificProjectMethod (int t_pkey)
        {
            var obReturnList = new ObservableCollection<ProjectMethod>();
            Table<DbProjectMethod.MappingProjectMethod> tblProjectMethod = dbConn.GetTable<DbProjectMethod.MappingProjectMethod>();

            var filteredQuery = from entry in tblProjectMethod
                                where entry.Id == t_pkey
                                select entry;
            foreach (var i in filteredQuery)
            {
                var pm = new ProjectMethod(i.Id, i.Method_name);
                obReturnList.Add(pm);
            }
            return obReturnList;
        }
    }
}
