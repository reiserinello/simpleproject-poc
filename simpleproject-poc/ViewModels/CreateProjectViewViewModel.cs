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
    class CreateProjectViewViewModel : MainViewModel, ICloseWindows
    {
        public CreateProjectViewViewModel()
        {
            // Datepicker auf heutiges Datum setzen
            datepickerPlannedStartDate = DateTime.Today;
            datepickerPlannedEndDate = DateTime.Today;
        }

        // Liste mit allen Vorgehensmodellen für Combobox
        private ObservableCollection<dynamic> _cmbbxProjectMethod;
        public ObservableCollection<dynamic> cmbbxProjectMethod
        {
            get
            {
                return _cmbbxProjectMethod;
            }
            set
            {
                _cmbbxProjectMethod = value;
                OnPropertyChanged("cmbbxProjectMethod");
            }
        }

        // Ausgewähltes Vorgehensmodell
        private dynamic _selectedProjectMethod;
        public dynamic selectedProjectMethod
        {
            get
            {
                return _selectedProjectMethod;
            }
            set
            {
                _selectedProjectMethod = value;
                OnPropertyChanged("selectedProjectMethod");
            }
        }

        // Alle möglichen Mitarbeiter/innen als Projektleiter/in anzeigen
        public void SetEmployeeValues()
        {
            DBGet dbGetObj = new DBGet();
            lvProjectmanager = dbGetObj.GeneralGet("Employee", 0);
        }

        public Action Close { get; set; }
        private string _txtProjectName;
        private Priority _cmbbxPriority;
        //private string _txtProjectManager;
        private DateTime _datepickerPlannedStartDate;
        private DateTime _datepickerPlannedEndDate;
        private string _txtProjectDocumentsLink;
        private string _txtProjectDescription;

        // Kontext der Projektübersicht
        private ProjectOverviewViewModel _contextProjectOverviewModel;
        public ProjectOverviewViewModel contextProjectOverviewModel
        {
            get
            {
                return _contextProjectOverviewModel;
            }
            set
            {
                _contextProjectOverviewModel = value;
                OnPropertyChanged("lvProjectOverview");
            }
        }

        public string txtProjectName
        {
            get
            {
                return _txtProjectName;
            }
            set
            {
                _txtProjectName = value;
                OnPropertyChanged("lblProjectName");
            }
        }

        public Priority cmbbxPriority
        {
            get
            {
                return _cmbbxPriority;
            }
            set
            {
                _cmbbxPriority = value;
                OnPropertyChanged("lblPriority");
            }
        }

        public IEnumerable<Priority> PriorityValues
        {
            get
            {
                return Enum.GetValues(typeof(Priority))
                    .Cast<Priority>();
            }
        }

        /*
        public string txtProjectManager
        {
            get
            {
                return _txtProjectManager;
            }
            set
            {
                _txtProjectManager = value;
                OnPropertyChanged("lblProjectManager");
            }
        }*/

        public DateTime datepickerPlannedStartDate
        {
            get
            {
                return _datepickerPlannedStartDate;
            }
            set
            {
                _datepickerPlannedStartDate = value;
                OnPropertyChanged("lblStartdatePlanned");
            }
        }

        public DateTime datepickerPlannedEndDate
        {
            get
            {
                return _datepickerPlannedEndDate;
            }
            set
            {
                _datepickerPlannedEndDate = value;
                OnPropertyChanged("lblEnddatePlanned");
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

        public string txtProjectDescription
        {
            get
            {
                return _txtProjectDescription;
            }
            set
            {
                _txtProjectDescription = value;
                OnPropertyChanged("txtProjectDescription");
            }
        }

        #region Projectmanager
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

        // Button Mitarbeiter erstellen, um Projektleiter zu kreieren
        public ICommand btnOpenCreateEmployeeView
        {
            get { return new DelegateCommand<object>(OpenCreateEmployeeView); }
        }

        private void OpenCreateEmployeeView(object context)
        {
            CreateEmployeeView createEmployeeView = new CreateEmployeeView();
            var contextCreateEmployeeView = (CreateEmployeeViewViewModel)createEmployeeView.DataContext;
            contextCreateEmployeeView.contextCreateProjectViewViewModel = this;
            contextCreateEmployeeView.SetDepartments();
            createEmployeeView.Show();
        }

        #endregion

        // Button Projekt erstellen
        public ICommand btnCreateProject
        {
            get { return new DelegateCommand<object>(CreateProject); }
        }

        private void CreateProject(object context)
        {
            var selectedProjectmanager = (Employee)context;

            if (String.IsNullOrWhiteSpace(txtProjectName) || selectedProjectMethod == null || selectedProjectmanager == null || datepickerPlannedStartDate == null || datepickerPlannedEndDate == null || String.IsNullOrWhiteSpace(txtProjectDocumentsLink) || String.IsNullOrWhiteSpace(txtProjectDescription))
            {
                MessageBox.Show("Um ein Projekt zu erstellen, müssen alle Felder ausgefüllt und ein/e Projektleiter/in ausgewählt sein.","Projekt erstellen");
            } 
            else if (datepickerPlannedEndDate < datepickerPlannedStartDate) 
            {
                MessageBox.Show("Das geplante Enddatum kann nicht vor dem geplanten Startdatum liegen.", "Projekt erstellen");
            } 
            else
            {
                DBGet dbGetObj = new DBGet();
                var dbGetPhase = dbGetObj.GeneralGet("Phase", selectedProjectMethod.Id);

                if (dbGetPhase.Count == 0)
                {
                    MessageBox.Show("Es wurde ein Vorgehensmodell ausgewählt, welche keine Phasen enthält. Bitte ein Vorgehensmodell mit Phasen auswählen oder dem aktuellen Vorgehensmodell Phasen hinzufügen.", "Projekt erstellen");
                }
                else
                {
                    DBCreate dbCreateObj = new DBCreate();
                    dbCreateObj.ProjectCreate(txtProjectName, cmbbxPriority, datepickerPlannedStartDate, datepickerPlannedEndDate, txtProjectDocumentsLink, txtProjectDescription, selectedProjectMethod.Id, selectedProjectmanager.Id);

                    var dbGetProjects = dbGetObj.GeneralGet("Project", 0);
                    contextProjectOverviewModel.lvProjectOverview = dbGetProjects;

                    // Neustes Projekt in List abgreifen und ProjektView öffnen
                    var createdProject = contextProjectOverviewModel.lvProjectOverview.Last();
                    contextProjectOverviewModel.OpenProject(createdProject);

                    Close?.Invoke();
                }
            }            
        }
    }
}
