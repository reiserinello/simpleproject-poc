using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace simpleproject_poc.ViewModels
{
    class CreateActivityViewViewModel : MainViewModel
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

        public void SetEmployeeValues()
        {

        }

        private string _txtActivityName;
        private DateTime _datepickPlannedStartdate;
        private DateTime _datepickPlannedEnddate;
        private string _txtActivityDocumentsLink;

        public string txtActivityName
        {
            get
            {
                return _txtActivityName;
            }
            set
            {
                _txtActivityName = value;
            }
        }

        public DateTime datepickPlannedStartdate
        {
            get
            {
                return _datepickPlannedStartdate;
            }
            set
            {
                _datepickPlannedStartdate = value;
                OnPropertyChanged("datepickPlannedStartdate");
            }
        }

        public DateTime datepickPlannedEnddate
        {
            get
            {
                return _datepickPlannedEnddate;
            }
            set
            {
                _datepickPlannedEnddate = value;
                OnPropertyChanged("datepickPlannedEnddate");
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

        private ObservableCollection<dynamic> _lvEmployee;
        public ObservableCollection<dynamic> lvEmployee
        {
            get
            {
                return _lvEmployee;
            }
            set
            {
                _lvEmployee = value;
                OnPropertyChanged("lvEmployee");
            }
        }

        // Button Mitarbeiter-hinzufügen-Form öffnen
        public ICommand btnOpenCreateEmployeeView
        {
            get { return new DelegateCommand<object>(OpenCreateEmployeeView); }
        }

        private void OpenCreateEmployeeView(object context)
        {

        }

        // Button Mitarbeiter-hinzufügen-Form öffnen
        public ICommand btnCreateActivity
        {
            get { return new DelegateCommand<object>(CreateActivity); }
        }

        private void CreateActivity(object context)
        {

        }

    }
}
