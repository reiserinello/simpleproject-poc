using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleproject_poc.Models;
using simpleproject_poc.Helper;
using System.Windows.Input;
using Prism.Commands;
using simpleproject_poc.Views;
using System.Collections.ObjectModel;
using System.Windows;

namespace simpleproject_poc.ViewModels
{
    class ProjectViewViewModel : MainViewModel
    {
        //private DBGet _dbGetObj;
        public ProjectViewViewModel ()
        {
            //_dbGetObj = new DBGet();
        }

        private ProjectOverviewViewModel _contextProjectOverviewViewModel;
        public ProjectOverviewViewModel contextProjectOverviewViewModel
        {
            get
            {
                return _contextProjectOverviewViewModel;
            }
            set
            {
                _contextProjectOverviewViewModel = value;
                OnPropertyChanged("contextProjectOverviewViewModel");
            }
        }

        #region Project
        public int _lblProjectKey;
        public string _lblProjectName;
        public Priority _lblPriority;
        public string _lblProjectMethod;
        public State _lblProjectState;
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

        public Priority lblPriority
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

        public State lblProjectState
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

            lvProjectPhase = dbGetObj.GeneralGet("v_Project_phase_Phase",_selectedProject.Id);
        }

        public void UpdateProjectOverview()
        {
            DBGet dbGetObj = new DBGet();
            contextProjectOverviewViewModel.lvProjectOverview = dbGetObj.GeneralGet("Project", 0);
        }

        // Button Projekt freigeben
        public ICommand btnReleaseProject
        {
            get { return new DelegateCommand<object>(ReleaseProject,IsProjectReleasedOne).ObservesProperty(() => lblApprovalDate); }
        }

        private void ReleaseProject(object context)
        {
            // Today as approvaldate
            DateTime thisDay = DateTime.Today;
            lblProjectState = State.Released;
            lblApprovalDate = thisDay;

            selectedProject.Release(thisDay,lblProjectState);

            UpdateProjectOverview();
        }

        // CanExecute Methode für btnReleaseProject
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

        // Button Projekt Datum setzen
        public ICommand btnSetProjectDates
        {
            get { return new DelegateCommand<object>(SetProjectDates,IsProjectReleasedTwo).ObservesProperty(() => lblApprovalDate); }
        }

        private void SetProjectDates(object context)
        {
            SetDatesView setDatesView = new SetDatesView();
            var contextSetDatesView = (SetDatesViewViewModel)setDatesView.DataContext;
            contextSetDatesView.contextProjectViewViewModel = this;
            contextSetDatesView.InitialDateSetter();
            setDatesView.Show();
        }

        // Button Status setzen
        public ICommand btnSetProjectState
        {
            get { return new DelegateCommand<object>(SetProjectState,IsProjectReleasedTwo).ObservesProperty(() => lblApprovalDate); }
        }

        private void SetProjectState(object context)
        {
            SetStateView setStateView = new SetStateView();
            var contextSetStateView = (SetStateViewViewModel)setStateView.DataContext;
            contextSetStateView.contextProjectViewViewModel = this;
            contextSetStateView.InitialValuesSetter();
            setStateView.Show();
        }
        #endregion

        #region ProjectPhase
        // Button Projekt Phase erstellen
        public ICommand btnOpenProjectPhase
        {
            get { return new DelegateCommand<object>(OpenProjectPhase, IsProjectReleasedTwo).ObservesProperty(() => lblApprovalDate); }
            //set { }
        }

        private void OpenProjectPhase(object context)
        {
            VProjectPhasePhase selectedProjectPhase = (VProjectPhasePhase)context;
            
            if (selectedProjectPhase == null)
            {
                MessageBox.Show("Um eine Phase zu öffnen, muss eine Phase ausgewählt sein.", "Phase öffnen");
            }
            else if (selectedProjectPhase.PlannedStartdate == null || selectedProjectPhase.PlannedEnddate == null || selectedProjectPhase.PlannedReviewdate == null || String.IsNullOrWhiteSpace(selectedProjectPhase.PhaseDocumentsLink))
            {
                MessageBox.Show("Phase muss zuerst definiert und alle Werte gesetzt werden.","Phase öffnen");
            }
            else
            {
                PhaseView phaseView = new PhaseView();
                var contextPhaseView = (PhaseViewViewModel)phaseView.DataContext;
                contextPhaseView.contextProjectViewViewModel = this;
                contextPhaseView.selectedVProjectPhasePhase = selectedProjectPhase;
                contextPhaseView.SetPhaseValues();
                phaseView.Show();
            }
        }

        // Button Projekt Phase definieren
        public ICommand btnDefineProjectPhase
        {
            get { return new DelegateCommand<object>(DefineProjectPhase, IsProjectReleasedTwo).ObservesProperty(() => lblApprovalDate); }
            //set { }
        }

        private void DefineProjectPhase(object context)
        {
            VProjectPhasePhase selectedProjectPhase = (VProjectPhasePhase)context;

            if (selectedProjectPhase == null)
            {
                MessageBox.Show("Um eine Projektphase zu definieren, muss eine Projektphase ausgewählt werden.","Phase definieren");
            }
            else
            {
                DefinePhaseView definePhaseView = new DefinePhaseView();
                var contextDefinePhaseView = (DefinePhaseViewViewModel)definePhaseView.DataContext;
                contextDefinePhaseView.contextProjectViewViewModel = this;
                contextDefinePhaseView.selectedVProjectPhasePhase = selectedProjectPhase;
                contextDefinePhaseView.SetPhaseValues();
                definePhaseView.Show();
            }
        }

        // CanExecute Methode für btnOpenProjectPhase & btnDefineProjectPhase
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

        // Listview Projektphase
        private ObservableCollection<dynamic> _lvProjectPhase;
        public ObservableCollection<dynamic> lvProjectPhase
        {
            get
            {
                return _lvProjectPhase;
            }
            set
            {
                _lvProjectPhase = value;
                OnPropertyChanged("");
            }
        }
        #endregion
    }
}
