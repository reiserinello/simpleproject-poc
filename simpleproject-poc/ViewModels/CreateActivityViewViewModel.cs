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
    class CreateActivityViewViewModel : MainViewModel, ICloseWindows
    {
        public CreateActivityViewViewModel()
        {
            datepickPlannedStartdate = DateTime.Today;
            datepickPlannedEnddate = DateTime.Today;
        }

        public Action Close { get; set; }

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
            DBGet dbGetObj = new DBGet();
            lvEmployee = dbGetObj.GeneralGet("Employee",0);
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
            CreateEmployeeView createEmployeeView = new CreateEmployeeView();
            var contextCreateEmployeeView = (CreateEmployeeViewViewModel)createEmployeeView.DataContext;
            contextCreateEmployeeView.contextCreateActivityViewViewModel = this;
            contextCreateEmployeeView.SetDepartments();
            createEmployeeView.Show();
        }

        // Button Mitarbeiter-hinzufügen-Form öffnen
        public ICommand btnCreateActivity
        {
            get { return new DelegateCommand<object>(CreateActivity); }
        }

        private void CreateActivity(object context)
        {
            var selectedEmployee = (Employee)context;

            if (txtActivityName == null || datepickPlannedStartdate == null || datepickPlannedEnddate == null || txtActivityDocumentsLink == null || selectedEmployee == null)
            {
                MessageBox.Show("Bitte alle Felder ausfüllen und einen Mitarbeiter auswählen.", "Aktivität erstellen");
            } 
            else
            {
                DBCreate dbCreateObj = new DBCreate();
                dbCreateObj.ActivityCreate(txtActivityName,datepickPlannedStartdate,datepickPlannedEnddate,txtActivityDocumentsLink,contextPhaseViewViewModel.selectedProjectPhase.Id,selectedEmployee.Id);

                contextPhaseViewViewModel.SetActivityView();

                contextPhaseViewViewModel.OpenNewestActivity();

                Close?.Invoke();
            }
        }

    }
}
