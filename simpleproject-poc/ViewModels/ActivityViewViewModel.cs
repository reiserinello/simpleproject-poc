using Prism.Commands;
using simpleproject_poc.Helper;
using simpleproject_poc.Models;
using simpleproject_poc.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace simpleproject_poc.ViewModels
{
    class ActivityViewViewModel : MainViewModel
    {
        private PhaseViewViewModel _contextPhaseViewViewModel;
        public PhaseViewViewModel contextPhaseViewViewModel
        {
            get
            {
                return _contextPhaseViewViewModel;
            }
            set
            {
                _contextPhaseViewViewModel = value;
                OnPropertyChanged("contextPhaseViewViewModel");
            }
        }

        private Activity _selectedActivity;
        public Activity selectedActivity
        {
            get
            {
                return _selectedActivity;
            }
            set
            {
                _selectedActivity = value;
                OnPropertyChanged("selectedActivity");
            }
        }

        public void SetActivityValues()
        {
            DBGet dbGetObj = new DBGet();
            lvActivityEmployee = dbGetObj.GeneralGet("v_Employee_Department",selectedActivity.EmployeeId);

            lblActivityName = selectedActivity.ActivityName;
            lblPlannedStartdate = selectedActivity.PlannedStartdate;
            lblPlannedEnddate = selectedActivity.PlannedEnddate;
            lblStartdate = selectedActivity.Startdate;
            lblEnddate = selectedActivity.Enddate;
            lblActivityProgress = selectedActivity.ActivityProgress;
            txtActivityDocumentsLink = selectedActivity.ActivityDocumentsLink;

            UpdateExternalCost();
            UpdateEmployeeResource();
        }

        public void UpdateExternalCost()
        {
            DBGet dbGetObj = new DBGet();
            lvExternalCost = dbGetObj.GeneralGet("v_External_cost_Cost_type",selectedActivity.Id);
        }

        public void UpdateEmployeeResource()
        {
            DBGet dbGetObj = new DBGet();
            lvEmployeeResource = dbGetObj.GeneralGet("v_Employee_resource_Function", selectedActivity.Id);
        }

        #region Aktivitätsinformationen
        private string _lblActivityName;
        private DateTime _lblPlannedStartdate;
        private DateTime _lblPlannedEnddate;
        private Nullable<DateTime> _lblStartdate;
        private Nullable<DateTime> _lblEnddate;
        private int _lblActivityProgress;
        private string _txtActivityDocumentsLink;

        public string lblActivityName
        {
            get
            {
                return _lblActivityName;
            }
            set
            {
                _lblActivityName = value;
                OnPropertyChanged("lblActivityName");
            }
        }

        public DateTime lblPlannedStartdate
        {
            get
            {
                return _lblPlannedStartdate;
            }
            set
            {
                _lblPlannedStartdate = value;
                OnPropertyChanged("lblPlannedStartdate");
            }
        }

        public DateTime lblPlannedEnddate
        {
            get
            {
                return _lblPlannedEnddate;
            }
            set
            {
                _lblPlannedEnddate = value;
                OnPropertyChanged("lblPlannedEnddate");
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

        public int lblActivityProgress
        {
            get
            {
                return _lblActivityProgress;
            }
            set
            {
                _lblActivityProgress = value;
                OnPropertyChanged("lblActivityProgress");
            }
        }

        public string txtActivityDocumentsLink
        {
            get
            {
                return _txtActivityDocumentsLink;
            }
            set
            {
                _txtActivityDocumentsLink = value;
                OnPropertyChanged("txtActivityDocumentsLink");
            }
        }

        private ObservableCollection<dynamic> _lvActivityEmployee;
        public ObservableCollection<dynamic> lvActivityEmployee
        {
            get
            {
                return _lvActivityEmployee;
            }
            set
            {
                _lvActivityEmployee = value;
                OnPropertyChanged("lvActivityEmployee");
            }
        }

        // CanExecute Methode für wenn Aktivitätsfortschritt 100% ist
        private bool IsActivityCompleted(object context)
        {
            if (lblActivityProgress == 100)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        // Button Aktivitätsdatum setzen
        public ICommand btnSetActivityDates
        {
            get { return new DelegateCommand<object>(SetActivityDates,IsActivityCompleted).ObservesProperty(() => lblActivityProgress); }
        }

        private void SetActivityDates(object context)
        {
            SetDatesView setDatesView = new SetDatesView();
            var contextSetDatesView = (SetDatesViewViewModel)setDatesView.DataContext;
            contextSetDatesView.contextActivityViewViewModel = this;
            contextSetDatesView.InitialDateSetter();
            setDatesView.Show();
        }

        // Button Aktivitätsfortschritt setzen
        public ICommand btnSetActivityState
        {
            get { return new DelegateCommand<object>(SetActivityState,IsActivityCompleted).ObservesProperty(() => lblActivityProgress); }
        }

        private void SetActivityState(object context)
        {
            SetStateView setStateView = new SetStateView();
            var contextSetStateView = (SetStateViewViewModel)setStateView.DataContext;
            contextSetStateView.contextActivityViewViewModel = this;
            contextSetStateView.InitialValuesSetter();
            setStateView.Show();
        }
        #endregion

        #region Externe Kosten
        // Button neue externe Kosten
        public ICommand btnNewExternalCost
        {
            get { return new DelegateCommand<object>(NewExternalCost,IsActivityCompleted).ObservesProperty(() => lblActivityProgress); }
        }

        private void NewExternalCost(object context)
        {
            ExternalCostView externalCostView = new ExternalCostView();
            var contextExternalCostView = (ExternalCostViewViewModel)externalCostView.DataContext;
            contextExternalCostView.contextActivityViewViewModel = this;
            contextExternalCostView.InitialSet();
            externalCostView.Show();
        }

        // Button externe Kosten öffnen
        public ICommand btnOpenExternalCost
        {
            get { return new DelegateCommand<object>(OpenExternalCost,IsActivityCompleted).ObservesProperty(() => lblActivityProgress); }
        }

        private void OpenExternalCost(object context)
        {
            var selectedExternalCost = (VExternalCostCostType)context;

            if (selectedExternalCost == null)
            {
                MessageBox.Show("Um externe Kosten zu öffnen, muss eine der externe Kosten ausgewählt werden.","Externe Kosten öffnen");
            }
            else
            {
                ExternalCostView externalCostView = new ExternalCostView();
                var contextExternalCostView = (ExternalCostViewViewModel)externalCostView.DataContext;
                contextExternalCostView.contextActivityViewViewModel = this;
                contextExternalCostView.selectedVExternalCost = selectedExternalCost;
                contextExternalCostView.InitialSet();
                externalCostView.Show();
            }
        }

        private ObservableCollection<dynamic> _lvExternalCost;
        public ObservableCollection<dynamic> lvExternalCost
        {
            get
            {
                return _lvExternalCost;
            }
            set
            {
                _lvExternalCost = value;
                OnPropertyChanged("lvExternalCost");
            }
        }



        #endregion

        #region Personelle Ressourcen
        // Button neue personelle Ressource
        public ICommand btnNewEmployeeResource
        {
            get { return new DelegateCommand<object>(NewEmployeeResource,IsActivityCompleted).ObservesProperty(() => lblActivityProgress); }
        }

        private void NewEmployeeResource(object context)
        {
            EmployeeResourceView employeeResourceView = new EmployeeResourceView();
            var contextEmployeeResourceView = (EmployeeResourceViewViewModel)employeeResourceView.DataContext;
            contextEmployeeResourceView.contextActivityViewViewModel = this;
            contextEmployeeResourceView.InitialSet();
            employeeResourceView.Show();
        }

        // Button personelle Ressource öffnen
        public ICommand btnOpenEmployeeResource
        {
            get { return new DelegateCommand<object>(OpenEmployeeResource,IsActivityCompleted).ObservesProperty(() => lblActivityProgress); }
        }

        private void OpenEmployeeResource(object context)
        {
            var selectedEmployeeResource = (VEmployeeResourceFunction)context;

            if (selectedEmployeeResource == null)
            {
                MessageBox.Show("Um eine personelle Ressource zu öffnen, muss eine personelle Ressource ausgewählt werden.","Personelle Ressource öffnen");
            }
            else
            {
                EmployeeResourceView employeeResourceView = new EmployeeResourceView();
                var contextEmployeeResourceView = (EmployeeResourceViewViewModel)employeeResourceView.DataContext;
                contextEmployeeResourceView.contextActivityViewViewModel = this;
                contextEmployeeResourceView.selectedVEmployeeResource = selectedEmployeeResource;
                contextEmployeeResourceView.InitialSet();
                employeeResourceView.Show();
            }
        }

        private ObservableCollection<dynamic> _lvEmployeeResource;
        public ObservableCollection<dynamic> lvEmployeeResource
        {
            get
            {
                return _lvEmployeeResource;
            }
            set
            {
                _lvEmployeeResource = value;
                OnPropertyChanged("lvEmployeeResource");
            }
        }
        #endregion
    }
}
