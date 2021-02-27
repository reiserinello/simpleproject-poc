using Prism.Commands;
using simpleproject_poc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            lblActivityName = selectedActivity.ActivityName;
            lblPlannedStartdate = selectedActivity.PlannedStartdate;
            lblPlannedEnddate = selectedActivity.PlannedEnddate;
            lblStartdate = selectedActivity.Startdate;
            lblEnddate = selectedActivity.Enddate;
            lblActivityProgress = selectedActivity.ActivityProgress;
            txtActivityDocumentsLink = selectedActivity.ActivityDocumentsLink;
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

        // Button Aktivitätsdatum setzen
        public ICommand btnSetActivityDates
        {
            get { return new DelegateCommand<object>(SetActivityDates); }
        }

        private void SetActivityDates(object context)
        {

        }

        // Button Aktivitätsfortschritt setzen
        public ICommand btnSetActivityState
        {
            get { return new DelegateCommand<object>(SetActivityState); }
        }

        private void SetActivityState(object context)
        {

        }
        #endregion

        #region Externe Kosten
        // Button neue externe Kosten
        public ICommand btnNewExternalCost
        {
            get { return new DelegateCommand<object>(NewExternalCost); }
        }

        private void NewExternalCost(object context)
        {

        }

        // Button externe Kosten öffnen
        public ICommand btnOpenExternalCost
        {
            get { return new DelegateCommand<object>(OpenExternalCost); }
        }

        private void OpenExternalCost(object context)
        {

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
            get { return new DelegateCommand<object>(NewEmployeeResource); }
        }

        private void NewEmployeeResource(object context)
        {

        }

        // Button personelle Ressource öffnen
        public ICommand btnOpenEmployeeResource
        {
            get { return new DelegateCommand<object>(OpenEmployeeResource); }
        }

        private void OpenEmployeeResource(object context)
        {

        }
        #endregion
    }
}
