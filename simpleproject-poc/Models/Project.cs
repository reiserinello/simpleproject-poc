using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Models
{
    class Project
    {
        public int Id { get; }
        public string ProjectName { get; }
        public string ProjectDescription { get; }
        public DateTime ApprovalDate { get; }
        public string Priority { get; }
        public string ProjectState { get; }
        public DateTime PlannedStartdate { get; }
        public DateTime PlannedEnddate { get; }
        public DateTime Startdate { get; }
        public DateTime Enddate { get; }
        public string ProjectManager { get; }
        public int ProjectProgress { get; }
        public string ProjectDocumentsLink { get; }
        public int ProjectMethodId { get; }

        public Project (int t_Id, string t_ProjectName, string t_ProjectDescription, DateTime t_ApprovalDate, string t_Priority, string t_ProjectState, DateTime t_PlannedStartdate, DateTime t_PlannedEnddate, DateTime t_Startdate, DateTime t_Enddate, string t_ProjectManager, int t_ProjectProgress, string t_ProjectDocumentsLink, int t_ProjectMethodId)
        {
            Id = t_Id;
            ProjectName = t_ProjectName;
            ProjectDescription = t_ProjectDescription;
            ApprovalDate = t_ApprovalDate;
            Priority = t_Priority;
            ProjectState = t_ProjectState;
            PlannedStartdate = t_PlannedStartdate;
            PlannedEnddate = t_PlannedEnddate;
            Startdate = t_Startdate;
            Enddate = t_Enddate;
            ProjectManager = t_ProjectManager;
            ProjectProgress = t_ProjectProgress;
            ProjectDocumentsLink = t_ProjectDocumentsLink;
            ProjectMethodId = t_ProjectMethodId;
        }
    }
}
