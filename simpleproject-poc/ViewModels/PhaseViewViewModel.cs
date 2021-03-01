using simpleproject_poc.Models;
using simpleproject_poc.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using simpleproject_poc.Views;
using System.Collections.ObjectModel;
using System.Windows;

namespace simpleproject_poc.ViewModels
{
    class PhaseViewViewModel : MainViewModel
    {
        // Context PhaseViewViewModel
        private ProjectViewViewModel _contextProjectViewViewModel;
        public ProjectViewViewModel contextProjectViewViewModel
        {
            get
            {
                return _contextProjectViewViewModel;
            }
            set
            {
                _contextProjectViewViewModel = value;
                OnPropertyChanged("contextProjectViewViewModel");
            }
        }

        // Ausgewählte Projektphase des VProjectPhasePhase Objektes (spezielle SQL View)
        private VProjectPhasePhase _selectedVProjectPhasePhase;
        public VProjectPhasePhase selectedVProjectPhasePhase
        {
            get
            {
                return _selectedVProjectPhasePhase;
            }
            set
            {
                _selectedVProjectPhasePhase = value;
                OnPropertyChanged("selectedVProjectPhasePhase");
            }
        }

        // Ausgwählte Projektphase als richtiges Objekt (für Convert von VProjectPhasePhase)
        private ProjectPhase _selectedProjectPhase;
        public ProjectPhase selectedProjectPhase
        {
            get
            {
                return _selectedProjectPhase;
            }
            set
            {
                _selectedProjectPhase = value;
                OnPropertyChanged("selectedProjectPhase");
            }
        }

        public void SetPhaseValues()
        {
            // Eigenschaften von selectedVProjectPhasePhase and selectedProjectPhase zuweisen
            ProjectPhase convertToProjectPhase = new ProjectPhase(selectedVProjectPhasePhase.Id,selectedVProjectPhasePhase.PhaseState,selectedVProjectPhasePhase.PhaseProgress,selectedVProjectPhasePhase.PlannedStartdate,selectedVProjectPhasePhase.PlannedEnddate,selectedVProjectPhasePhase.Startdate,selectedVProjectPhasePhase.Enddate,selectedVProjectPhasePhase.ApprovalDate,selectedVProjectPhasePhase.Visum,selectedVProjectPhasePhase.PlannedReviewdate,selectedVProjectPhasePhase.Reviewdate,selectedVProjectPhasePhase.PhaseDocumentsLink,selectedVProjectPhasePhase.ProjectId,selectedVProjectPhasePhase.PhaseId);
            selectedProjectPhase = convertToProjectPhase;

            lblPhaseName = selectedVProjectPhasePhase.PhaseName;
            lblPhaseState = selectedProjectPhase.PhaseState;
            lblPhaseProgress = selectedProjectPhase.PhaseProgress;
            lblApprovalDate = selectedProjectPhase.ApprovalDate;
            lblStartdatePlanned = selectedProjectPhase.PlannedStartdate;
            lblEnddatePlanned = selectedProjectPhase.PlannedEnddate;
            lblStartdate = selectedProjectPhase.Startdate;
            lblEnddate = selectedProjectPhase.Enddate;
            txtPhaseDocumentsLink = selectedProjectPhase.PhaseDocumentsLink;
            lblVisum = selectedProjectPhase.Visum;
            lblReviewdatePlanned = selectedProjectPhase.PlannedReviewdate;
            lblReviewdate = selectedProjectPhase.Reviewdate;

            SetMilestoneView();
            SetActivityView();
        }

        // Methode um Phasenliste zu updaten auf der Projektansicht
        public void UpdatePhaseOverview()
        {
            DBGet dbGetObj = new DBGet();
            contextProjectViewViewModel.lvProjectPhase = dbGetObj.GeneralGet("v_Project_phase_Phase", contextProjectViewViewModel.selectedProject.Id);
        }

        public void SetMilestoneView()
        {
            DBGet dbGetObj = new DBGet();
            lvMilestoneOverview = dbGetObj.GeneralGet("Milestone",selectedProjectPhase.Id);
        }

        public void SetActivityView()
        {
            DBGet dbGetObj = new DBGet();
            lvActivity = dbGetObj.GeneralGet("Activity",selectedProjectPhase.Id);
        }

        public void OpenNewestActivity()
        {
            var newestActivity = lvActivity.Last();
            OpenActivity(newestActivity);
        }

        #region Phaseninformationen
        private string _lblPhaseName;
        private State _lblPhaseState;
        private int _lblPhaseProgress;
        private Nullable<DateTime> _lblApprovalDate;
        private Nullable<DateTime> _lblStartdatePlanned;
        private Nullable<DateTime> _lblEnddatePlanned;
        private Nullable<DateTime> _lblStartdate;
        private Nullable<DateTime> _lblEnddate;
        private string _txtPhaseDocumentsLink;
        private string _lblVisum;
        private Nullable<DateTime> _lblReviewdatePlanned;
        private Nullable<DateTime> _lblReviewdate;

        public string lblPhaseName
        {
            get
            {
                return _lblPhaseName;
            }
            set
            {
                _lblPhaseName = value;
                OnPropertyChanged("lblPhaseName");
            }
        }

        public State lblPhaseState
        {
            get
            {
                return _lblPhaseState;
            }
            set
            {
                _lblPhaseState = value;
                OnPropertyChanged("lblPhaseState");
            }
        }

        public int lblPhaseProgress
        {
            get
            {
                return _lblPhaseProgress;
            }
            set
            {
                _lblPhaseProgress = value;
                OnPropertyChanged("lblPhaseProgress");
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

        public Nullable<DateTime> lblStartdatePlanned
        {
            get
            {
                return _lblStartdatePlanned;
            }
            set
            {
                _lblStartdatePlanned = value;
            }
        }

        public Nullable<DateTime> lblEnddatePlanned
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

        public string txtPhaseDocumentsLink
        {
            get
            {
                return _txtPhaseDocumentsLink;
            }
            set
            {
                _txtPhaseDocumentsLink = value;
                OnPropertyChanged("txtPhaseDocumentsLink");
            }
        }

        public string lblVisum
        {
            get
            {
                return _lblVisum;
            }
            set
            {
                _lblVisum = value;
                OnPropertyChanged("lblVisum");
            }
        }

        public Nullable<DateTime> lblReviewdatePlanned
        {
            get
            {
                return _lblReviewdatePlanned;
            }
            set
            {
                _lblReviewdatePlanned = value;
                OnPropertyChanged("lblReviewdatePlanned");
            }
        }

        public Nullable<DateTime> lblReviewdate
        {
            get
            {
                return _lblReviewdate;
            }
            set
            {
                _lblReviewdate = value;
                OnPropertyChanged("lblReviewdate");
            }
        }

        #region Milestone

        private ObservableCollection<dynamic> _lvMilestoneOverview;
        public ObservableCollection<dynamic> lvMilestoneOverview
        {
            get
            {
                return _lvMilestoneOverview;
            }
            set
            {
                _lvMilestoneOverview = value;
                OnPropertyChanged("lvMilestoneOverview");
            }
        }

        private string _txtMilestonename;
        private Nullable<DateTime> _datepickMilestonedate;

        public string txtMilestonename
        {
            get
            {
                return _txtMilestonename;
            }
            set
            {
                _txtMilestonename = value;
                OnPropertyChanged("txtMilestonename");
            }
        }

        public Nullable<DateTime> datepickMilestonedate
        {
            get
            {
                return _datepickMilestonedate;
            }
            set
            {
                _datepickMilestonedate = value;
                OnPropertyChanged("datepickMilestonedate");
            }
        }

        // Button Meilenstein hinzufügen
        public ICommand btnAddMilestone
        {
            get { return new DelegateCommand<object>(AddMilestone,IsPhaseReleasedTwo).ObservesProperty(() => lblApprovalDate); }
        }

        private void AddMilestone(object context)
        {
            DBCreate dbCreateObj = new DBCreate();
            if (txtMilestonename == null || datepickMilestonedate == null)
            {
                MessageBox.Show("Name sowie Datum müssen gesetzt sein, um einen Meilenstein zu erstellen.", "Meilenstein hinzufügen");
            }
            else
            {
                dbCreateObj.MilestoneCreate(txtMilestonename, datepickMilestonedate, selectedProjectPhase.Id);
                SetMilestoneView();

                txtMilestonename = null;
                datepickMilestonedate = null;
            }
        }

        #endregion


        // Button Phase freigeben
        public ICommand btnReleasePhase
        {
            get { return new DelegateCommand<object>(ReleasePhase, IsPhaseReleasedOne).ObservesProperty(() => lblApprovalDate); }
        }

        private void ReleasePhase(object context)
        {
            SetVisumView setVisumView = new SetVisumView();
            var contextSetVisumView = (SetVisumViewViewModel)setVisumView.DataContext;
            contextSetVisumView.contextPhaseViewViewModel = this;
            setVisumView.Show();

            //selectedProjectPhase.Release(selectedProjectPhase.Id,lblApprovalDate,lblVisum);
        }

        // CanExecute Methode für btnReleasePhase
        private bool IsPhaseReleasedOne(object context)
        {
            // Solange ApprovalDate der Phase nicht gesetzt ist, kann die Phase freigegeben werden
            if (lblApprovalDate == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Button Phase Datum setzen
        public ICommand btnSetPhaseDates
        {
            get { return new DelegateCommand<object>(SetPhaseDates, IsPhaseReleasedTwo).ObservesProperty(() => lblApprovalDate); }
        }

        private void SetPhaseDates(object context)
        {
            SetDatesView setDatesView = new SetDatesView();
            var contextSetDatesView = (SetDatesViewViewModel)setDatesView.DataContext;
            contextSetDatesView.contextPhaseViewViewModel = this;
            contextSetDatesView.InitialDateSetter();
            setDatesView.Show();
        }

        // Button Phase Status setzen
        public ICommand btnSetPhaseState
        {
            get { return new DelegateCommand<object>(SetPhaseState, IsPhaseReleasedTwo).ObservesProperty(() => lblApprovalDate); }
        }

        private void SetPhaseState(object context)
        {
            SetStateView setStateView = new SetStateView();
            var contextSetStateView = (SetStateViewViewModel)setStateView.DataContext;
            contextSetStateView.contextPhaseViewViewModel = this;
            contextSetStateView.InitialValuesSetter();
            setStateView.Show();
        }

        #endregion

        #region Aktivitäten
        private ObservableCollection<dynamic> _lvActivity;

        public ObservableCollection<dynamic> lvActivity
        {
            get
            {
                return _lvActivity;
            }
            set
            {
                _lvActivity = value;
                OnPropertyChanged("lvActivity");
            }
        }

        // Button Aktivität öffnen
        public ICommand btnOpenActivity
        {
            get { return new DelegateCommand<object>(OpenActivity, IsPhaseReleasedTwo).ObservesProperty(() => lblApprovalDate); }
        }

        private void OpenActivity(object context)
        {
            var selectedActivity = (Activity)context;
            if (selectedActivity == null)
            {
                MessageBox.Show("Um eine Aktivität zu öffnen, muss eine Aktivität erstellt und ausgewählt sein.", "Aktivität öffnen");
            }
            else
            {
                ActivityView activityView = new ActivityView();

                var contextActivityView = (ActivityViewViewModel)activityView.DataContext;
                contextActivityView.contextPhaseViewViewModel = this;
                contextActivityView.selectedActivity = selectedActivity;
                contextActivityView.SetActivityValues();
                activityView.Show();
            }
        }

        // Button Aktivität öffnen
        public ICommand btnCreateActivity
        {
            get { return new DelegateCommand<object>(CreateActivity, IsPhaseReleasedTwo).ObservesProperty(() => lblApprovalDate); }
        }

        private void CreateActivity(object context)
        {
            CreateActivityView createActivityView = new CreateActivityView();
            var contextCreateActivityView = (CreateActivityViewViewModel)createActivityView.DataContext;
            contextCreateActivityView.contextPhaseViewViewModel = this;
            contextCreateActivityView.SetEmployeeValues();
            createActivityView.Show();
        }

        // CanExecute Methode für btnOpenActivity & btnCreateActivity
        private bool IsPhaseReleasedTwo(object context)
        {
            // Solange ApprovalDate der Phase nicht gesetzt ist, kann keine Aktivität erstellt oder geöffnet werden
            if (lblApprovalDate == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        #endregion
    }
}
