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
    class SetStateViewViewModel : MainViewModel, ICloseWindows
    {
        public Action Close { get; set; }

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

        PhaseViewViewModel _contextPhaseViewViewModel;
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
            if (contextProjectViewViewModel != null)
            {
                cmbbxPriority = contextProjectViewViewModel.lblPriority;
                cmbbxState = contextProjectViewViewModel.lblProjectState;
                txtProgress = contextProjectViewViewModel.lblProjectProgress;

                PriorityIsEnabled = true;
            }
            
            if (contextPhaseViewViewModel != null)
            {
                cmbbxState = contextPhaseViewViewModel.lblPhaseState;
                txtProgress = contextPhaseViewViewModel.lblPhaseProgress;

                PriorityIsEnabled = false;
            }

            
        }

        private bool _PriorityIsEnabled;
        public bool PriorityIsEnabled
        {
            get { return _PriorityIsEnabled; }

            set
            {
                if (_PriorityIsEnabled == value)
                {
                    return;
                }

                _PriorityIsEnabled = value;
                OnPropertyChanged("PriorityIsEnabled");
            }
        }

        public ICommand btnSetState
        {
            get { return new DelegateCommand<object>(SetState); }
        }

        private void SetState(object context)
        {

            if (contextProjectViewViewModel != null)
            {
                contextProjectViewViewModel.selectedProject.SetState(txtProgress, cmbbxState, cmbbxPriority);
                contextProjectViewViewModel.lblProjectProgress = txtProgress;
                contextProjectViewViewModel.lblProjectState = cmbbxState;
                contextProjectViewViewModel.lblPriority = cmbbxPriority;

                contextProjectViewViewModel.UpdateProjectOverview();
            }

            if (contextPhaseViewViewModel != null)
            {
                contextPhaseViewViewModel.selectedProjectPhase.SetState(txtProgress,cmbbxState);
                contextPhaseViewViewModel.lblPhaseProgress = txtProgress;
                contextPhaseViewViewModel.lblPhaseState = cmbbxState;

                contextPhaseViewViewModel.UpdatePhaseOverview();
            }

            Close?.Invoke();
        }
    }

}
