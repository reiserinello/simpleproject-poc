using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private ActivityViewViewModel _contextActivityViewViewModel;
        public ActivityViewViewModel contextActivityViewViewModel
        {
            get
            {
                return _contextActivityViewViewModel;
            }
            set
            {
                _contextActivityViewViewModel = value;
                OnPropertyChanged("contextActivityViewViewModel");
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

        public IEnumerable<dynamic> StateValues
        {
            get
            {
                string[] StateNames = Enum.GetNames(typeof(State));
                IEnumerable<dynamic> list = from state in StateNames where (state != "WaitingForRelease") && (state != "Released") select Enum.Parse(typeof(State), state);

                return list;
                /*return Enum.GetValues(typeof(State))
                    .Cast<State>();*/
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
                StateIsEnabled = true;
            }
            
            if (contextPhaseViewViewModel != null)
            {
                cmbbxState = contextPhaseViewViewModel.lblPhaseState;
                txtProgress = contextPhaseViewViewModel.lblPhaseProgress;

                PriorityIsEnabled = false;
                StateIsEnabled = true;
            }

            if (contextActivityViewViewModel != null)
            {
                txtProgress = contextActivityViewViewModel.lblActivityProgress;

                PriorityIsEnabled = false;
                StateIsEnabled = false;
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

        private bool _StateIsEnabled;
        public bool StateIsEnabled
        {
            get { return _StateIsEnabled; }

            set
            {
                if (_StateIsEnabled == value)
                {
                    return;
                }

                _StateIsEnabled = value;
                OnPropertyChanged("StateIsEnabled");
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
                /*if (cmbbxState == State.WaitingForRelease || cmbbxState == State.Released)
                {
                    MessageBox.Show("Der Status WaitingForRelease und Released sind Zustände, welche vom System automatischen generiert werden je nach ");
                }*/
                contextProjectViewViewModel.selectedProject.SetState(txtProgress, cmbbxState, cmbbxPriority);
                contextProjectViewViewModel.lblProjectProgress = txtProgress;
                contextProjectViewViewModel.lblProjectState = cmbbxState;
                contextProjectViewViewModel.lblPriority = cmbbxPriority;

                contextProjectViewViewModel.UpdateProjectOverview();

                Close?.Invoke();
            }

            if (contextPhaseViewViewModel != null)
            {
                contextPhaseViewViewModel.selectedProjectPhase.SetState(txtProgress,cmbbxState);
                contextPhaseViewViewModel.lblPhaseProgress = txtProgress;
                contextPhaseViewViewModel.lblPhaseState = cmbbxState;

                contextPhaseViewViewModel.UpdatePhaseOverview();

                Close?.Invoke();
            }

            if (contextActivityViewViewModel != null)
            {
                Boolean StateCanBeSet = true;

                if (txtProgress > 100)
                {
                    MessageBox.Show("100% ist der maximale Projektfortschritt, welcher gesetzt werden kann.","Status setzen");
                    StateCanBeSet = false;
                } 
                else if (txtProgress == 100)
                {
                    // Prüfen ob alle externen Kosten sowie personellen Ressourcen (effektiv) eingetragen sind
                    Boolean allExternalCostCompleted = true;
                    foreach (var extCost in contextActivityViewViewModel.lvExternalCost)
                    {
                        VExternalCostCostType extCostObj = (VExternalCostCostType)extCost;
                        if (extCostObj.EffectiveCost == null)
                        {
                            allExternalCostCompleted = false;
                        }
                    }

                    Boolean allEmployeeResourceCompleted = true;
                    foreach (var empRes in contextActivityViewViewModel.lvEmployeeResource)
                    {
                        VEmployeeResourceFunction empResObj = (VEmployeeResourceFunction)empRes;
                        if (empResObj.EffectiveTime == null)
                        {
                            allEmployeeResourceCompleted = false;
                        }
                    }

                    if (allExternalCostCompleted == false || allEmployeeResourceCompleted == false)
                    {
                        MessageBox.Show("Um den Aktivitätsfortschritt auf 100% zu setzen, müssen alle effektiven Kosten der externen Kosten und effektiven Zeiten der personellen Ressoucen gesetzt sein.","Status setzen");
                        StateCanBeSet = false;
                    }
                    else if (contextActivityViewViewModel.lblStartdate == null || contextActivityViewViewModel.lblEnddate == null)
                    {
                        MessageBox.Show("Um den Aktivitätsfortschritt auf 100% zu setzen, müssen Start- sowie Enddatum gesetzt sein.", "Status setzen");
                        StateCanBeSet = false;
                    }
                }

                if (StateCanBeSet == true)
                {
                    contextActivityViewViewModel.selectedActivity.SetState(txtProgress);
                    contextActivityViewViewModel.lblActivityProgress = txtProgress;

                    contextActivityViewViewModel.contextPhaseViewViewModel.SetActivityView();

                    Close?.Invoke();
                }   
            }
        }
    }
}
