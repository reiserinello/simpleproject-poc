using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleproject_poc.Models;
using simpleproject_poc.Helper;
using System.Windows.Input;
using Prism.Commands;

namespace simpleproject_poc.ViewModels
{
    class ProjectViewViewModel : MainViewModel
    {
        #region Project
        public int _lblProjectKey;
        public string _lblProjectName;
        public string _lblPriority;
        public string _lblProjectMethod;
        public string _lblProjectState;
        public int _lblProjectProgress;
        public string _lblProjectManager;
        public Nullable<DateTime> _lblApprovalDate;
        public DateTime _lblStartdatePlanned;
        public DateTime _lblEnddatePlanned;
        public Nullable<DateTime> _lblStartdate;
        public Nullable<DateTime> _lblEnddate;
        public string _txtProjectDocumentsLink;
        public string _txtbProjectDescription;

        Project _selectedProject;
        public Project selectedProject
        {
            get
            {
                return _selectedProject;
            }
            set
            {
                _selectedProject = value;
                OnPropertyChanged("selectedProjectMethod");
            }
        }

        public int lblProjectKey
        {
            get
            {
                return _lblProjectKey;
            }
            set
            {
                _lblProjectKey = value;
                OnPropertyChanged("lblProjectKey");
            }
        }

        public string lblProjectName
        {
            get
            {
                return _lblProjectName;
            }
            set
            {
                _lblProjectName = value;
                OnPropertyChanged("lblProjectName");
            }
        }

        public string lblPriority
        {
            get
            {
                return _lblPriority;
            }
            set
            {
                _lblPriority = value;
                OnPropertyChanged("lblPriority");
            }
        }

        public string lblProjectMethod
        {
            get
            {
                return _lblProjectMethod;
            }
            set
            {
                _lblProjectMethod = value;
                OnPropertyChanged("lblProjectMethod");
            }
        }

        public string lblProjectState
        {
            get
            {
                return _lblProjectState;
            }
            set
            {
                _lblProjectState = value;
                OnPropertyChanged("lblProjectState");
            }
        }

        public int lblProjectProgress
        {
            get
            {
                return _lblProjectProgress;
            }
            set
            {
                _lblProjectProgress = value;
                OnPropertyChanged("lblProjectProgress");
            }
        }

        public string lblProjectManager
        {
            get
            {
                return _lblProjectManager;
            }
            set
            {
                _lblProjectManager = value;
                OnPropertyChanged("lblProjectManager");
            }
        }

        public Nullable<DateTime> lblApprovalDate
        {
            get
            {
                return _lblApprovalDate;
            }
            set
            {
                _lblApprovalDate = value;
                OnPropertyChanged("lblApprovalDate");
            }
        }

        public DateTime lblStartdatePlanned
        {
            get
            {
                return _lblStartdatePlanned;
            }
            set
            {
                _lblStartdatePlanned = value;
                OnPropertyChanged("lblStartdatePlanned");
            }
        }

        public DateTime lblEnddatePlanned
        {
            get
            {
                return _lblEnddatePlanned;
            }
            set
            {
                _lblEnddatePlanned = value;
                OnPropertyChanged("lblEnddatePlanned");
            }
        }

        public Nullable<DateTime> lblStartdate
        {
            get
            {
                return _lblStartdate;
            }
            set
            {
                _lblStartdate = value;
                OnPropertyChanged("lblStartdate");
            }
        }

        public Nullable<DateTime> lblEnddate
        {
            get
            {
                return _lblEnddate;
            }
            set
            {
                _lblEnddate = value;
                OnPropertyChanged("lblEnddate");
            }
        }

        public string txtProjectDocumentsLink
        {
            get
            {
                return _txtProjectDocumentsLink;
            }
            set
            {
                _txtProjectDocumentsLink = value;
                OnPropertyChanged("txtProjectDocumentsLink");
            }
        }

        public string txtbProjectDescription
        {
            get
            {
                return _txtbProjectDescription;
            }
            set
            {
                _txtbProjectDescription = value;
                OnPropertyChanged("txtbProjectDescription");
            }
        }

        public void SetProjectValues()
        {
            DBGet dbGetObj = new DBGet();
            var dbGetProjectMethod = dbGetObj.GetSpecificProjectMethod(_selectedProject.ProjectMethodId);

            lblProjectKey = _selectedProject.Id;
            lblProjectName = _selectedProject.ProjectName;
            lblPriority = _selectedProject.Priority;
            lblProjectMethod = dbGetProjectMethod[0].MethodName;
            lblProjectState = _selectedProject.ProjectState;
            lblProjectProgress = _selectedProject.ProjectProgress;
            lblProjectManager = _selectedProject.ProjectManager;
            lblApprovalDate = _selectedProject.ApprovalDate;
            lblStartdatePlanned = _selectedProject.PlannedStartdate;
            lblEnddatePlanned = _selectedProject.PlannedEnddate;
            lblStartdate = _selectedProject.Startdate;
            lblEnddate = _selectedProject.Enddate;
            txtProjectDocumentsLink = _selectedProject.ProjectDocumentsLink;
            txtbProjectDescription = _selectedProject.ProjectDescription;
        }

        // Button Projekt freigeben
        public ICommand btnReleaseProject
        {
            get { return new DelegateCommand<object>(ReleaseProject,IsProjectReleasedOne).ObservesProperty(() => lblApprovalDate); }
        }

        private void ReleaseProject(object context)
        {
            DBUpdate dbUpdateObj = new DBUpdate();
            dbUpdateObj.SetProjectApprovalDate(this);
        }

        // CanExecute Methode für btnOpenProjectPhase & btnCreateProjectPhase
        private bool IsProjectReleasedOne(object context)
        {
            // Solange ApprovalDate des Projektes nicht gesetzt ist, kann keine ProjectPhase angelegt oder geöffnet werden
            if (lblApprovalDate == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region ProjectPhase
        // Button Projekt Phase erstellen
        public ICommand btnOpenProjectPhase
        {
            get { return new DelegateCommand<object>(OpenProjectPhase, IsProjectReleasedTwo).ObservesProperty(() => lblApprovalDate); }
            set { }
        }

        private void OpenProjectPhase(object context)
        {
            
        }

        // Button Projekt Phase öffnen
        public ICommand btnCreateProjectPhase
        {
            get { return new DelegateCommand<object>(CreateProjectPhase, IsProjectReleasedTwo).ObservesProperty(() => lblApprovalDate); }
            set { }
        }

        private void CreateProjectPhase(object context)
        {
            
        }

        // CanExecute Methode für btnOpenProjectPhase & btnCreateProjectPhase
        private bool IsProjectReleasedTwo(object context)
        {
            // Solange ApprovalDate des Projektes nicht gesetzt ist, kann keine ProjectPhase angelegt oder geöffnet werden
            if (lblApprovalDate == null)
            {
                return false;
            } else
            {
                return true;
            }
            
        }
        #endregion
    }
}
