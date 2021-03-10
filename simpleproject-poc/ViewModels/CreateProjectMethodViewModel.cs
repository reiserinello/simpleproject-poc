using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using simpleproject_poc.Models;
using simpleproject_poc.Helper;
using simpleproject_poc.Views;
using System.ComponentModel;
using System.Windows;
//using System.Windows;

namespace simpleproject_poc.ViewModels
{
    class CreateProjectMethodViewModel : MainViewModel, ICloseWindows
    {
        public Action Close { get; set; }

        // Kontext der Projektübersicht
        ProjectOverviewViewModel _contextProjectOverViewModel;
        public ProjectOverviewViewModel contextProjectOverviewModel
        {
            get
            {
                return _contextProjectOverViewModel;
            }
            set
            {
                _contextProjectOverViewModel = value;
                OnPropertyChanged("contextProjectOverviewModel");
            }
        }

        private string _txtMethodName;
        public string txtMethodName
        {
            get
            {
                return _txtMethodName;
            }
            set
            {
                _txtMethodName = value;
                OnPropertyChanged("txtMethodName");
            }
        }

        // Button neues Vorgehensmodell erstellen
        public ICommand btnCreateNewProjectMethod
        {
            get { return new DelegateCommand<object>(CreateProjectMethod); }
        }

        public void CreateProjectMethod(object context)
        {
            if (String.IsNullOrWhiteSpace(txtMethodName))
            {
                MessageBox.Show("Um ein Vorgehensmodell zu erstellen, muss ein Vorgehensmodell-Name angegeben werden.","Vorgehensmodell erstellen");
            } 
            else
            {
                DBCreate dbCreateObj = new DBCreate();
                dbCreateObj.ProjectMethodCreate(txtMethodName);

                // Vorgehensmodellübersicht updaten
                contextProjectOverviewModel.UpdateProjectMethodList();

                // Neustes Vorgehensmodell in List abgreifen und Phasenbearbeitung öffnen
                var createdProjectMethod = contextProjectOverviewModel.dtagrdProjectMethod.Last();
                contextProjectOverviewModel.OpenProjectMethod(createdProjectMethod);

                Close?.Invoke();
            }
        }
    }
}
