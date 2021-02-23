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

        private VProjectPhasePhase _selectedProjectPhase;
        public VProjectPhasePhase selectedProjectPhase
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
            ProjectPhase projectPhase = new ProjectPhase();
            projectPhase.Define(selectedProjectPhase.Id,datepickPlannedStartdate,datepickPlannedEnddate,datepickPlannedReviewdate,txtPhaseDocumentsLink);
        }
    }
}
