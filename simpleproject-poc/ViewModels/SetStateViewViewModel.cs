using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using simpleproject_poc.Helper;
using simpleproject_poc.Models;

namespace simpleproject_poc.ViewModels
{
    class SetStateViewViewModel : MainViewModel
    {
        ProjectViewViewModel _contextProjectViewViewModel;
        public ProjectViewViewModel contextProjectViewViewModel
        {
            get
            {
                return _contextProjectViewViewModel;
            }
            set
            {
                _contextProjectViewViewModel = value;
                OnPropertyChanged("contextProjectViewViewModel");
            }
        }

        
        private State _cmbbxState;
        public State cmbbxState
        {
            get 
            { 
                return _cmbbxState; 
            }
            set
            {
                _cmbbxState = value;
                OnPropertyChanged("cmbbxState");
            }
        }

        public IEnumerable<State> StateValues
        {
            get
            {
                return Enum.GetValues(typeof(State))
                    .Cast<State>();
            }
        }

        private Priority _cmbbxPriority;
        public Priority cmbbxPriority
        {
            get
            {
                return _cmbbxPriority;
            }
            set
            {
                _cmbbxPriority = value;
                OnPropertyChanged("cmbbxPriority");
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

        private int _txtProgress;
        public int txtProgress
        {
            get
            {
                return _txtProgress;
            }
            set
            {
                _txtProgress = value;
                OnPropertyChanged("txtProgress");
            }
        }

        public void InitialValuesSetter()
        {
            _cmbbxPriority = contextProjectViewViewModel.lblPriority;
            _cmbbxState = contextProjectViewViewModel.lblProjectState;
            _txtProgress = contextProjectViewViewModel.lblProjectProgress;
        }

        public ICommand btnSetState
        {
            get { return new DelegateCommand<object>(SetState); }
        }

        private void SetState(object context)
        {
            //var test = context;

            Project projectObj = new Project();
            projectObj.SetState(contextProjectViewViewModel.lblProjectKey, txtProgress, cmbbxState, cmbbxPriority);
            contextProjectViewViewModel.lblProjectProgress = txtProgress;
            contextProjectViewViewModel.lblProjectState = cmbbxState;
            contextProjectViewViewModel.lblPriority = cmbbxPriority;
        }
    }

}
