using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using simpleproject_poc.Helper;
using simpleproject_poc.Models;
using simpleproject_poc.Views;

namespace simpleproject_poc.ViewModels
{
    class ProjectOverviewViewModel : MainViewModel
    {
        public ObservableCollection<dynamic> _dtagrdProjectMethod;
        public ObservableCollection<dynamic> _lvProjectOverview;
        public ProjectOverviewViewModel ()
        {
            DBGet dbGet = new DBGet();
            _dtagrdProjectMethod = dbGet.GeneralGet("Project_method",0);
            _lvProjectOverview = dbGet.GeneralGet("Project", 0);
        }

        // Vorgehensmodell Listview
        
        public ObservableCollection<dynamic> dtagrdProjectMethod
        {
            get
            {
                return _dtagrdProjectMethod;
            }
            set
            {
                _dtagrdProjectMethod = value;
                OnPropertyChanged("dtagrdProjectMethod");
            }
        }
        
        // Button neues Vorgehensmodell
        public ICommand btnNewProjectMethod
        {
            get { return new DelegateCommand<object>(OpenCreateProjectMethod); }
        }

        private void OpenCreateProjectMethod(object context)
        {
            //this is called when the button is clicked
            CreateProjectMethod createProjectMethod = new CreateProjectMethod();
            var contextCreateProjectMethodView = (CreateProjectMethodViewModel)createProjectMethod.DataContext;
            contextCreateProjectMethodView.contextProjectOverviewModel = (ProjectOverviewViewModel)this;
            createProjectMethod.Show();
        }

        // Button Vorgehensmodell öffnen
        public ICommand btnOpenProjectMethod
        {
            get { return new DelegateCommand<object>(OpenProjectMethod); }
        }

        public void OpenProjectMethod(object context)
        {
            // object context zu ProjectMethod casten
            ProjectMethod selectedProjectMethod = (ProjectMethod)context;

            // Windows ProjectMethodOverview instanzieren
            ProjectMethodOverview projectMethodOverview = new ProjectMethodOverview();

            // DataContext auslesen und dort die selectedProjectMethod setzen
            var contextProjectMethodOverviewView = (ProjectMethodOverviewViewModel)projectMethodOverview.DataContext;
            contextProjectMethodOverviewView.selectedProjectMethod = selectedProjectMethod;

            // Phasen auslesen und auf die ListView setzen, da selectedProjectMethod beim instanzieren noch leer war (get)
            var getPhase = contextProjectMethodOverviewView.GetPhase();
            contextProjectMethodOverviewView.lvPhase = getPhase;

            // Property lblProjectMethodName setzen, da selectedProjectMethod beim instanziern noch leer war (get)
            contextProjectMethodOverviewView.lblProjectMethodName = selectedProjectMethod.MethodName;
            projectMethodOverview.Show();
        }

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

        // Button Projekt öffnen
        public ICommand btnOpenProject
        {
            get { return new DelegateCommand<object>(OpenProject); }
        }

        public void OpenProject(object context)
        {
            // object context zu Project casten
            Project selectedProject = (Project)context;

            // Window ProjectView instanzieren
            ProjectView projectView = new ProjectView();

            // DataContext auslesen und dort die selectedProject setzen
            var contextProjectView = (ProjectViewViewModel)projectView.DataContext;
            contextProjectView.contextProjectOverviewViewModel = this;
            contextProjectView.selectedProject = selectedProject;

            // Methode ausführen, welches die Values neu setzt
            contextProjectView.SetProjectValues();

            projectView.Show();
        }

        // Button Projekt öffnen
        public ICommand btnCreateProjectForm
        {
            get { return new DelegateCommand<object>(CreateProjectForm); }
        }

        public void CreateProjectForm(object context)
        {
            CreateProjectView createProjectView = new CreateProjectView();
            var contextCreateProjectView = (CreateProjectViewViewModel)createProjectView.DataContext;
            contextCreateProjectView.contextProjectOverviewModel = this;
            contextCreateProjectView.cmbbxProjectMethod = dtagrdProjectMethod;
            createProjectView.Show();
        }

        /*
        private bool FuncToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }
        */
    }
}
