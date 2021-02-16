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
    class CreateProjectMethodViewModel : INotifyPropertyChanged
    {
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

        // Button neues Vorgehensmodell erstellen
        public ICommand btnCreateNewProjectMethod
        {
            get { return new DelegateCommand<object>(CreateProjectMethod, FuncToEvaluate); }
        }

        public void CreateProjectMethod(object context)
        {
            //this is called when the button is clicked
            DBCreate createProjectMethodObj = new DBCreate();
            createProjectMethodObj.ProjectMethodCreate(context.ToString(), contextProjectOverviewModel);
        }

        private bool FuncToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
