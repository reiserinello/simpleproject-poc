using simpleproject_poc.Models;
using simpleproject_poc.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using simpleproject_poc.Views;

namespace simpleproject_poc.ViewModels
{
    class PhaseViewViewModel : MainViewModel
    {
        // Context PhaseViewViewModel
        private ProjectViewViewModel _contextPhaseViewViewModel;
        public ProjectViewViewModel contextPhaseViewViewModel
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
                OnPropertyChanged("selectedVProjectPhasePhase");
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
            // Eigenschaften von selectedVProjectPhasePhase and selectedProjectPhase zuweisen
            ProjectPhase convertToProjectPhase = new ProjectPhase(selectedVProjectPhasePhase.Id,selectedVProjectPhasePhase.PhaseState,selectedVProjectPhasePhase.PhaseProgress,selectedVProjectPhasePhase.PlannedStartdate,selectedVProjectPhasePhase.PlannedEnddate,selectedVProjectPhasePhase.Startdate,selectedVProjectPhasePhase.Enddate,selectedVProjectPhasePhase.ApprovalDate,selectedVProjectPhasePhase.Visum,selectedVProjectPhasePhase.PlannedReviewdate,selectedVProjectPhasePhase.Reviewdate,selectedVProjectPhasePhase.PhaseDocumentsLink,selectedVProjectPhasePhase.ProjectId,selectedVProjectPhasePhase.PhaseId);
            selectedProjectPhase = convertToProjectPhase;

            lblPhaseName = selectedVProjectPhasePhase.PhaseName;
            lblPhaseState = selectedProjectPhase.PhaseState;
            lblPhaseProgress = selectedProjectPhase.PhaseProgress;
            lblApprovalDate = selectedProjectPhase.ApprovalDate;
            lblStartdatePlanned = selectedProjectPhase.PlannedStartdate;
            lblEnddatePlanned = selectedProjectPhase.PlannedEnddate;
            lblStartdate = selectedProjectPhase.Startdate;
            lblEnddate = selectedProjectPhase.Enddate;
            txtPhaseDocumentsLink = selectedProjectPhase.PhaseDocumentsLink;
            lblVisum = selectedProjectPhase.Visum;
            lblReviewdatePlanned = selectedProjectPhase.PlannedReviewdate;
            lblReviewdate = selectedProjectPhase.Reviewdate;
        }

        #region Phaseninformationen
        private string _lblPhaseName;
        private State _lblPhaseState;
        private int _lblPhaseProgress;
        private Nullable<DateTime> _lblApprovalDate;
        private Nullable<DateTime> _lblStartdatePlanned;
        private Nullable<DateTime> _lblEnddatePlanned;
        private Nullable<DateTime> _lblStartdate;
        private Nullable<DateTime> _lblEnddate;
        private string _txtPhaseDocumentsLink;
        private string _lblVisum;
        private Nullable<DateTime> _lblReviewdatePlanned;
        private Nullable<DateTime> _lblReviewdate;

        public string lblPhaseName
        {
            get
            {
                return _lblPhaseName;
            }
            set
            {
                _lblPhaseName = value;
                OnPropertyChanged("lblPhaseName");
            }
        }

        public State lblPhaseState
        {
            get
            {
                return _lblPhaseState;
            }
            set
            {
                _lblPhaseState = value;
                OnPropertyChanged("lblPhaseState");
            }
        }

        public int lblPhaseProgress
        {
            get
            {
                return _lblPhaseProgress;
            }
            set
            {
                _lblPhaseProgress = value;
                OnPropertyChanged("lblPhaseProgress");
            }
        }

        public Nullable<DateTime> lblApprovalDate
        {
            get
            {
                return _lblApprovalDate;
            }
            set
            {
                _lblApprovalDate = value;
                OnPropertyChanged("lblApprovalDate");
            }
        }

        public Nullable<DateTime> lblStartdatePlanned
        {
            get
            {
                return _lblStartdatePlanned;
            }
            set
            {
                _lblStartdatePlanned = value;
            }
        }

        public Nullable<DateTime> lblEnddatePlanned
        {
            get
            {
                return _lblEnddatePlanned;
            }
            set
            {
                _lblEnddatePlanned = value;
                OnPropertyChanged("lblEnddatePlanned");
            }
        }

        public Nullable<DateTime> lblStartdate
        {
            get
            {
                return _lblStartdate;
            }
            set
            {
                _lblStartdate = value;
                OnPropertyChanged("lblStartdate");
            }
        }

        public Nullable<DateTime> lblEnddate
        {
            get
            {
                return _lblEnddate;
            }
            set
            {
                _lblEnddate = value;
                OnPropertyChanged("lblEnddate");
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

        public string lblVisum
        {
            get
            {
                return _lblVisum;
            }
            set
            {
                _lblVisum = value;
                OnPropertyChanged("lblVisum");
            }
        }

        public Nullable<DateTime> lblReviewdatePlanned
        {
            get
            {
                return _lblReviewdatePlanned;
            }
            set
            {
                _lblReviewdatePlanned = value;
                OnPropertyChanged("lblReviewdatePlanned");
            }
        }

        public Nullable<DateTime> lblReviewdate
        {
            get
            {
                return _lblReviewdate;
            }
            set
            {
                _lblReviewdate = value;
                OnPropertyChanged("lblReviewdate");
            }
        }

        // Button Phase freigeben
        public ICommand btnReleasePhase
        {
            get { return new DelegateCommand<object>(ReleasePhase, IsPhaseReleasedOne).ObservesProperty(() => lblApprovalDate); }
        }

        private void ReleasePhase(object context)
        {
            SetVisumView setVisumView = new SetVisumView();
            var contextSetVisumView = (SetVisumViewViewModel)setVisumView.DataContext;
            contextSetVisumView.contextPhaseViewViewModel = this;
            setVisumView.Show();

            //selectedProjectPhase.Release(selectedProjectPhase.Id,lblApprovalDate,lblVisum);
        }

        // CanExecute Methode für btnReleasePhase
        private bool IsPhaseReleasedOne(object context)
        {
            // Solange ApprovalDate der Phase nicht gesetzt ist, kann die Phase freigegeben werden
            if (lblApprovalDate == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        #endregion

        #region Aktivitäten

        #endregion
    }
}
