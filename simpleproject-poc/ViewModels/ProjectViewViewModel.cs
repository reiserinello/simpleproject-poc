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
        // Kontext der Projektübersicht
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
        private int _lblProjectKey;
        private string _lblProjectName;
        private Priority _lblPriority;
        private string _lblProjectMethod;
        private State _lblProjectState;
        private int _lblProjectProgress;
        private Nullable<DateTime> _lblApprovalDate;
        private DateTime _lblStartdatePlanned;
        private DateTime _lblEnddatePlanned;
        private Nullable<DateTime> _lblStartdate;
        private Nullable<DateTime> _lblEnddate;
        private string _txtProjectDocumentsLink;
        private string _txtbProjectDescription;

        // Ausgewähltes Projekt
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

        // Projektleiter/in listview
        private ObservableCollection<dynamic> _lvProjectmanager;
        public ObservableCollection<dynamic> lvProjectmanager
        {
            get
            {
                return _lvProjectmanager;
            }
            set
            {
                _lvProjectmanager = value;
                OnPropertyChanged("lvProjectmanager");
            }
        }

        // Projektwerte setzen
        public void SetProjectValues()
        {
            // Vorgehensmodell auslesen
            DBGet dbGetObj = new DBGet();
            var dbGetProjectMethod = dbGetObj.GetSpecificProjectMethod(_selectedProject.ProjectMethodId);

            lblProjectKey = _selectedProject.Id;
            lblProjectName = _selectedProject.ProjectName;
            lblPriority = _selectedProject.Priority;
            lblProjectMethod = dbGetProjectMethod[0].MethodName;
            lblProjectState = _selectedProject.ProjectState;
            lblProjectProgress = _selectedProject.ProjectProgress;
            lblApprovalDate = _selectedProject.ApprovalDate;
            lblStartdatePlanned = _selectedProject.PlannedStartdate;
            lblEnddatePlanned = _selectedProject.PlannedEnddate;
            lblStartdate = _selectedProject.Startdate;
            lblEnddate = _selectedProject.Enddate;
            txtProjectDocumentsLink = _selectedProject.ProjectDocumentsLink;
            txtbProjectDescription = _selectedProject.ProjectDescription;

            lvProjectmanager = dbGetObj.GeneralGet("v_Employee_Department", selectedProject.EmployeeId);
            lvProjectPhase = dbGetObj.GeneralGet("v_Project_phase_Phase",_selectedProject.Id);
        }

        // Projektübersicht updaten
        public void UpdateProjectOverview()
        {
            DBGet dbGetObj = new DBGet();
            contextProjectOverviewViewModel.lvProjectOverview = dbGetObj.GeneralGet("Project", 0);
        }

        // Button Projekt freigeben
        public ICommand btnReleaseProject
        {
            get { return new DelegateCommand<object>(ReleaseProject,IsProjectReleased).ObservesProperty(() => lblApprovalDate); }
        }

        private void ReleaseProject(object context)
        {
            // Heutiges Datum als Freigabedatum
            DateTime thisDay = DateTime.Today;
            lblProjectState = State.Released;
            lblApprovalDate = thisDay;

            selectedProject.Release(thisDay,lblProjectState);

            UpdateProjectOverview();
        }

        // CanExecute Methode für btnReleaseProject
        private bool IsProjectReleased(object context)
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
            get { return new DelegateCommand<object>(SetProjectDates, CanExecuteSetProjectDates).ObservesProperty(() => lblProjectState); }
        }

        private void SetProjectDates(object context)
        {
            SetDatesView setDatesView = new SetDatesView();
            var contextSetDatesView = (SetDatesViewViewModel)setDatesView.DataContext;
            contextSetDatesView.contextProjectViewViewModel = this;
            contextSetDatesView.InitialDateSetter();
            setDatesView.Show();
        }

        // CanExecute Methode für btnSetProjectDates
        private bool CanExecuteSetProjectDates(object context)
        {
            if (lblProjectState == State.WorkInProgress)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Button Status setzen
        public ICommand btnSetProjectState
        {
            get { return new DelegateCommand<object>(SetProjectState, CanExecuteSetProjectState).ObservesProperty(() => lblProjectState); }
        }

        private void SetProjectState(object context)
        {
            SetStateView setStateView = new SetStateView();
            var contextSetStateView = (SetStateViewViewModel)setStateView.DataContext;
            contextSetStateView.contextProjectViewViewModel = this;
            contextSetStateView.InitialValuesSetter();
            setStateView.Show();
        }

        // CanExecute Methode für btnSetProjectState
        private bool CanExecuteSetProjectState(object context)
        {
            if (lblProjectState != State.Created && lblProjectState != State.Closed)
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
        // Button Projekt Phase öffnen
        public ICommand btnOpenProjectPhase
        {
            get { return new DelegateCommand<object>(OpenProjectPhase, CanExecuteOpenPhase).ObservesProperty(() => lblProjectState); }
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
            get { return new DelegateCommand<object>(DefineProjectPhase, CanExecuteDefinePhase).ObservesProperty(() => lblProjectState); }
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

        // CanExecute Methode für btnDefineProjectPhase
        private bool CanExecuteDefinePhase(object context)
        {
            if (lblProjectState == State.InPlanning)
            {
                return true;
            } else
            {
                return false;
            }
        }

        // CanExecute Methode für btnOpenProjectPhase
        private bool CanExecuteOpenPhase(object context)
        {
            if (lblProjectState == State.WorkInProgress || lblProjectState == State.Closed)
            {
                return true;
            }
            else
            {
                return false;
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
