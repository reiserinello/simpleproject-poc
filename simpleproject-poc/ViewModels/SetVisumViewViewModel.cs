using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace simpleproject_poc.ViewModels
{
    class SetVisumViewViewModel : MainViewModel, ICloseWindows
    {
        public Action Close { get; set; }

        private PhaseViewViewModel _contextPhaseViewViewModel;
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

        private string _txtVisum;
        public string txtVisum
        {
            get
            {
                return _txtVisum;
            }
            set
            {
                _txtVisum = value;
                OnPropertyChanged("txtVisum");
            }
        }

        // Button Phase freigeben mit Visum
        public ICommand btnReleasePhaseWithVisum
        {
            get { return new DelegateCommand<object>(ReleasePhaseWithVisum); }
        }

        private void ReleasePhaseWithVisum(object context)
        {
            // Get todays date for approvaldate
            Nullable<DateTime> thisDay = DateTime.Today;

            // Set properties in PhaseView
            contextPhaseViewViewModel.lblApprovalDate = thisDay;
            contextPhaseViewViewModel.lblVisum = txtVisum;
            contextPhaseViewViewModel.lblPhaseState = Helper.State.Released;

            // Release phase
            contextPhaseViewViewModel.selectedProjectPhase.Release(thisDay, txtVisum, contextPhaseViewViewModel.lblPhaseState);

            contextPhaseViewViewModel.UpdatePhaseOverview();

            Close?.Invoke();
        }
    }
}
