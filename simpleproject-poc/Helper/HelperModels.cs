using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Helper
{
    class VProjectPhasePhase
    {
        public int Id { get; }
        public State PhaseState { get; }
        public int PhaseProgress { get; }
        public Nullable<DateTime> PlannedStartdate { get; }
        public Nullable<DateTime> PlannedEnddate { get; }
        public Nullable<DateTime> Startdate { get; }
        public Nullable<DateTime> Enddate { get; }
        public Nullable<DateTime> ApprovalDate { get; }
        public string Visum { get; }
        public Nullable<DateTime> PlannedReviewdate { get; }
        public Nullable<DateTime> Reviewdate { get; }
        public string PhaseDocumentsLink { get; }
        public int ProjectId { get; }
        public int PhaseId { get; }
        public string PhaseName { get; }

        public VProjectPhasePhase(int t_Id, State t_PhaseState, int t_PhaseProgress, Nullable<DateTime> t_PlannedStartdate, Nullable<DateTime> t_PlannedEnddate, Nullable<DateTime> t_Startdate, Nullable<DateTime> t_Enddate, Nullable<DateTime> t_ApprovalDate, string t_Visum, Nullable<DateTime> t_PlannedReviewdate, Nullable<DateTime> t_Reviewdate, string t_PhaseDocumentsLink, int t_ProjectId, int t_PhaseId, string t_PhaseName)
        {
            Id = t_Id;
            PhaseState = t_PhaseState;
            PhaseProgress = t_PhaseProgress;
            PlannedStartdate = t_PlannedStartdate;
            PlannedEnddate = t_PlannedEnddate;
            Startdate = t_Startdate;
            Enddate = t_Enddate;
            ApprovalDate = t_ApprovalDate;
            Visum = t_Visum;
            PlannedReviewdate = t_PlannedReviewdate;
            Reviewdate = t_Reviewdate;
            PhaseDocumentsLink = t_PhaseDocumentsLink;
            ProjectId = t_ProjectId;
            PhaseId = t_PhaseId;
            PhaseName = t_PhaseName;
        }

        //SQL mapping
        [Table(Name = "v_Project_phase_Phase")]
        public class dbVProjectPhasePhase
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
            public string Phase_state;

            [Column]
            public int Phase_progress;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Planned_startdate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Planned_enddate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Startdate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Enddate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Approval_date;

            [Column]
            public string Visum;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Planned_reviewdate;

            [Column(CanBeNull = true)]
            public Nullable<DateTime> Reviewdate;

            [Column]
            public string Phase_documents_link;

            [Column]
            public int Project_id;

            [Column]
            public int Phase_id;

            [Column]
            public string Phase_name;
        }
    }

    class VEmployeeDepartment
    {
        public int Id { get; }
        public int EmployeeNumber { get; }
        public string Name { get; }
        public string Surname { get; }
        public int Workload { get; }
        public string Functions { get; }
        public string DepartmentName { get; }

        public VEmployeeDepartment(int t_Id, int t_EmployeeNumber, string t_Name, string t_Surname, int t_Workload, string t_Functions, string t_DepartmentName)
        {
            Id = t_Id;
            EmployeeNumber = t_EmployeeNumber;
            Name = t_Name;
            Surname = t_Surname;
            Workload = t_Workload;
            Functions = t_Functions;
            DepartmentName = t_DepartmentName;
        }

        //SQL mapping
        [Table(Name = "v_Employee_Department")]
        public class dbVEmployeeDepartment
        {
            //Mapper auf Primary Key
            [Column(Name = "Id", IsDbGenerated = true, IsPrimaryKey = true)]
            public int Id
            {
                get;
                set;
            }

            //Mapper auf Eigenschaftsname
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
            public string Department_name;
        }
    }

    class VExternalCostCostType
    {
        public int Id { get; }
        public int BudgetCost { get; }
        public Nullable<int> EffectiveCost { get; }
        public string Deviation { get; }
        public string CostTypeName { get; }
        public int CostTypeId { get; }
        public int ActivityId { get; }

        public VExternalCostCostType(int t_Id, int t_BudgetCost, Nullable<int> t_EffectiveCost, string t_Deviation, string t_CostTypeName, int t_CostTypeId, int t_ActivityId)
        {
            Id = t_Id;
            BudgetCost = t_BudgetCost;
            EffectiveCost = t_EffectiveCost;
            Deviation = t_Deviation;
            CostTypeName = t_CostTypeName;
            CostTypeId = t_CostTypeId;
            ActivityId = t_ActivityId;
        }

        //SQL mapping
        [Table(Name = "v_External_cost_Cost_type")]
        public class dbVExternalCostCostType
        {
            //Mapper auf Primary Key
            [Column(Name = "Id", IsDbGenerated = true, IsPrimaryKey = true)]
            public int Id
            {
                get;
                set;
            }

            //Mapper auf Eigenschaftsname
            [Column]
            public int Budget_cost;

            [Column(CanBeNull = true)]
            public Nullable<int> Effective_cost;

            [Column]
            public string Deviation;

            [Column]
            public string Cost_type_name;

            [Column]
            public int Cost_type_id;

            [Column]
            public int Activity_id;
        }
    }
}
