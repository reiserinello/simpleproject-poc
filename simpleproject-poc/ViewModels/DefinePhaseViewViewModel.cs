using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using simpleproject_poc.Models;
using simpleproject_poc.Helper;

namespace simpleproject_poc.ViewModels
{
    class DefinePhaseViewViewModel : MainViewModel, ICloseWindows
    {
        public Action Close { get; set; }

        // Context PhaseViewViewModel
        private ProjectViewViewModel _contextProjectViewViewModel;
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

        // Ausgewählte Projektphase des VProjectPhasePhase Objektes (spezielle SQL View)
        private VProjectPhasePhase _selectedVProjectPhasePhase;
        public VProjectPhasePhase selectedVProjectPhasePhase
        {
            get
            {
                return _selectedVProjectPhasePhase;
            }
            set
            {
                _selectedVProjectPhasePhase = value;
                OnPropertyChanged("selectedProjectPhase");
            }
        }

        // Ausgwählte Projektphase als richtiges Objekt (für Convert von VProjectPhasePhase)
        private ProjectPhase _selectedProjectPhase;
        public ProjectPhase selectedProjectPhase
        {
            get
            {
                return _selectedProjectPhase;
            }
            set
            {
                _selectedProjectPhase = value;
                OnPropertyChanged("selectedProjectPhase");
            }
        }

        public void SetPhaseValues()
        {
            ProjectPhase convertToProjectPhase = new ProjectPhase(selectedVProjectPhasePhase.Id, selectedVProjectPhasePhase.PhaseState, selectedVProjectPhasePhase.PhaseProgress, selectedVProjectPhasePhase.PlannedStartdate, selectedVProjectPhasePhase.PlannedEnddate, selectedVProjectPhasePhase.Startdate, selectedVProjectPhasePhase.Enddate, selectedVProjectPhasePhase.ApprovalDate, selectedVProjectPhasePhase.Visum, selectedVProjectPhasePhase.PlannedReviewdate, selectedVProjectPhasePhase.Reviewdate, selectedVProjectPhasePhase.PhaseDocumentsLink, selectedVProjectPhasePhase.ProjectId, selectedVProjectPhasePhase.PhaseId);
            selectedProjectPhase = convertToProjectPhase;

            datepickPlannedStartdate = selectedProjectPhase.PlannedStartdate;
            datepickPlannedEnddate = selectedProjectPhase.PlannedEnddate;
            datepickPlannedReviewdate = selectedProjectPhase.PlannedReviewdate;
            txtPhaseDocumentsLink = selectedProjectPhase.PhaseDocumentsLink;
        }

        private Nullable<DateTime> _datepickPlannedStartdate;
        private Nullable<DateTime> _datepickPlannedEnddate;
        private Nullable<DateTime> _datepickPlannedReviewdate;
        private string _txtPhaseDocumentsLink;

        public Nullable<DateTime> datepickPlannedStartdate
        {
            get
            {
                return _datepickPlannedStartdate;
            }
            set
            {
                _datepickPlannedStartdate = value;
                OnPropertyChanged("datepickPlannedStartdate");
            }
        }

        public Nullable<DateTime> datepickPlannedEnddate
        {
            get
            {
                return _datepickPlannedEnddate;
            }
            set
            {
                _datepickPlannedEnddate = value;
                OnPropertyChanged("datepickPlannedEnddate");
            }
        }

        public Nullable<DateTime> datepickPlannedReviewdate
        {
            get
            {
                return _datepickPlannedReviewdate;
            }
            set
            {
                _datepickPlannedReviewdate = value;
                OnPropertyChanged("datepickPlannedReviewdate");
            }
        }

        public string txtPhaseDocumentsLink
        {
            get
            {
                return _txtPhaseDocumentsLink;
            }
            set
            {
                _txtPhaseDocumentsLink = value;
                OnPropertyChanged("txtPhaseDocumentsLink");
            }
        }

        public ICommand btnDefinePhase
        {
            get { return new DelegateCommand<object>(DefinePhase); }
        }

        private void DefinePhase(object context)
        {
            selectedProjectPhase.Define(datepickPlannedStartdate,datepickPlannedEnddate,datepickPlannedReviewdate,txtPhaseDocumentsLink,selectedVProjectPhasePhase.PhaseName);

            DBGet dbGetObj = new DBGet();
            var dbGetVProjectPhasePhase = dbGetObj.GeneralGet("v_Project_phase_Phase",contextProjectViewViewModel.lblProjectKey);
            contextProjectViewViewModel.lvProjectPhase = dbGetVProjectPhasePhase;

            Close?.Invoke();
        }
    }
}
