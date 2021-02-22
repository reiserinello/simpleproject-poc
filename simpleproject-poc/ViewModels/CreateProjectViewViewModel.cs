using Prism.Commands;
using simpleproject_poc.Helper;
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
    class CreateProjectViewViewModel : MainViewModel
    {
        /*
        public CreateProjectViewViewModel()
        {
            DBGet dbGetObj = new DBGet();
            var dbGetProjectMethods = dbGetObj.GeneralGet("Project_method",0);
        }
        */

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
                OnPropertyChanged("allProjectMethods");
            }
        }

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

        private string _txtProjectName;
        private Priority _cmbbxPriority;
        private string _txtProjectManager;
        private DateTime _datepickerPlannedStartDate;
        private DateTime _datepickerPlannedEndDate;
        private string _txtProjectDocumentsLink;
        private string _txtProjectDescripting;

        private ObservableCollection<dynamic> _lvProjectOverview;
        public ObservableCollection<dynamic> lvProjectOverview
        {
            get
            {
                return _lvProjectOverview;
            }
            set
            {
                _lvProjectOverview = value;
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
        }

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

        public string txtProjectDescripting
        {
            get
            {
                return _txtProjectDescripting;
            }
            set
            {
                _txtProjectDescripting = value;
                OnPropertyChanged("txtbProjectDescription");
            }
        }

        // Button Projekt erstellen
        public ICommand btnCreateProject
        {
            get { return new DelegateCommand<object>(CreateProject); }
        }

        private void CreateProject(object context)
        {
            Project projectObj = new Project();
            projectObj.CreateDBProject(txtProjectName,cmbbxPriority,txtProjectManager,datepickerPlannedStartDate,datepickerPlannedEndDate,txtProjectDocumentsLink,txtProjectDescripting,selectedProjectMethod.Id);

            DBGet dbGetObj = new DBGet();
            var dbGetProjects = dbGetObj.GeneralGet("Project", 0);
            lvProjectOverview = dbGetProjects;
        }
    }
}
