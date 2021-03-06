﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            UpdateProjectMethodList();
            UpdateProjectList();
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

        // Methode zum Vorgehensmodell Liste updaten
        public void UpdateProjectMethodList()
        {
            DBGet dbGet = new DBGet();
            dtagrdProjectMethod = dbGet.GeneralGet("Project_method", 0);
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

            if (selectedProjectMethod == null)
            {
                MessageBox.Show("Um ein Vorgehensmodell zu öffnen, muss ein Vorgehensmodell ausgewählt werden.","Vorgehensmodell öffnen");
            } 
            else
            {
                // Windows ProjectMethodOverview instanzieren
                ProjectMethodOverview projectMethodOverview = new ProjectMethodOverview();

                // DataContext auslesen und dort die selectedProjectMethod setzen
                var contextProjectMethodOverviewView = (ProjectMethodOverviewViewModel)projectMethodOverview.DataContext;
                contextProjectMethodOverviewView.selectedProjectMethod = selectedProjectMethod;

                // Entsprechende ProjekteMethode Phasen setzen
                contextProjectMethodOverviewView.UpdatePhaseList();

                // Property lblProjectMethodName setzen, da selectedProjectMethod beim instanziern noch leer war (get)
                contextProjectMethodOverviewView.lblProjectMethodName = selectedProjectMethod.MethodName;
                projectMethodOverview.Show();
            }
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

        // Methode Projektliste updaten
        public void UpdateProjectList()
        {
            DBGet dbGet = new DBGet();
            lvProjectOverview = dbGet.GeneralGet("Project", 0);
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

            if (selectedProject == null)
            {
                MessageBox.Show("Um ein Projekt zu öffnen, muss ein Projekt erstellt und ausgewählt sein.","Projekt öffnen");
            }
            else
            {
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
        }

        // Button Projekterstellen Form öffnen
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
            contextCreateProjectView.SetEmployeeValues();
            createProjectView.Show();
        }
    }
}
