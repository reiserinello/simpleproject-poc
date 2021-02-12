using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using simpleproject_poc.Models;
using simpleproject_poc.Views;

namespace simpleproject_poc.ViewModels
{
    class ProjectOverviewViewModel : MainViewModel
    {
        // Vorgehensmodell Listview
        ObservableCollection<ProjectMethod> _dtagrdProjectMethod;
        public ObservableCollection<ProjectMethod> dtagrdProjectMethod
        {
            get
            {
                ProjectMethod projectMethod = new ProjectMethod();
                _dtagrdProjectMethod = projectMethod.Get();
                return _dtagrdProjectMethod;
            }
        }

        // Button neues Vorgehensmodell
        public ICommand btnNewProjectMethod
        {
            get { return new DelegateCommand<object>(OpenCreateProjectMethod, FuncToEvaluate); }
        }

        private void OpenCreateProjectMethod(object context)
        {
            //this is called when the button is clicked
            CreateProjectMethod createProjectMethod = new CreateProjectMethod();
            createProjectMethod.Show();
        }

        private bool FuncToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }

    }
}
