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
//using System.Windows;

namespace simpleproject_poc.ViewModels
{
    class CreateProjectMethodViewModel : MainViewModel, ICloseWindows
    {
        /* Kontext des ProjectOverviewViewModel
         * Wird verwendet, um Daten auf vorheriger View zu aktualisieren
         */

        ProjectOverviewViewModel _contextProjectOverViewModel;
        public Action Close { get; set; }

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

        // Button neues Vorgehensmodell erstellen
        public ICommand btnCreateNewProjectMethod
        {
            get { return new DelegateCommand<object>(CreateProjectMethod); }
        }

        public void CreateProjectMethod(object context)
        {
            // Neues Vorgehensmodell erstellen
            ProjectMethod projectMethod = new ProjectMethod(context.ToString(), contextProjectOverviewModel);

            // Neuste ProjectMethod in List abgreifen und Phasenbearbeitung öffnen
            var createdProjectMethod = contextProjectOverviewModel.dtagrdProjectMethod.Last();
            contextProjectOverviewModel.OpenProjectMethod(createdProjectMethod);

            Close?.Invoke();
        }

        /*
         * Beispiel einer Evaluation Funktion, kann, muss aber nicht verwendet werden
         *
        private bool FuncToEvaluate(object context)
        {
            //this is called to evaluate whether CreateProjectMethod can be called
            //for example you can return true or false based on some validation logic
            return false;
        }
        */

        
    }
}
