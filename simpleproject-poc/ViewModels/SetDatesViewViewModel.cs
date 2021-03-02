using Prism.Commands;
using simpleproject_poc.Helper;
using simpleproject_poc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace simpleproject_poc.ViewModels
{
    class SetDatesViewViewModel : MainViewModel, ICloseWindows
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

        public Nullable<DateTime> _datepickStartDate;
        public Nullable<DateTime> _datepickEndDate;
        public Nullable<DateTime> _datepickReviewDate;

        public Nullable<DateTime> datepickStartDate
        {
            get
            {
                return _datepickStartDate;
            }
            set
            {
                _datepickStartDate = value;
                OnPropertyChanged("datepickStartDate");
            }
        }

        public Nullable<DateTime> datepickEndDate
        {
            get
            {
                return _datepickEndDate;
            }
            set
            {
                _datepickEndDate = value;
                OnPropertyChanged("datepickEndDate");
            }
        }

        public Nullable<DateTime> datepickReviewDate
        {
            get 
            {
                return _datepickReviewDate;
            }
            set
            {
                _datepickReviewDate = value;
                OnPropertyChanged("datepickReviewDate");
            }
        }

        private bool _ReviewDateIsEnabled;
        public bool ReviewDateIsEnabled
        {
            get { return _ReviewDateIsEnabled; }

            set
            {
                if (_ReviewDateIsEnabled == value)
                {
                    return;
                }

                _ReviewDateIsEnabled = value;
                OnPropertyChanged("ReviewDateIsEnabled");
            }
        }

        // Initial date setter
        public void InitialDateSetter()
        {
            if (contextProjectViewViewModel != null)
            {
                datepickStartDate = contextProjectViewViewModel.lblStartdate;
                datepickEndDate = contextProjectViewViewModel.lblEnddate;

                ReviewDateIsEnabled = false;
            }
            else if (contextPhaseViewViewModel != null)
            {
                datepickStartDate = contextPhaseViewViewModel.lblStartdate;
                datepickEndDate = contextPhaseViewViewModel.lblEnddate;

                ReviewDateIsEnabled = true;
            }
            else if (contextActivityViewViewModel != null)
            {
                datepickStartDate = contextActivityViewViewModel.lblStartdate;
                datepickEndDate = contextActivityViewViewModel.lblEnddate;

                ReviewDateIsEnabled = false;
            }
        }

        // Button Projekt freigeben
        public ICommand btnSetDates
        {
            get { return new DelegateCommand<object>(SetDates); }
        }

        private void SetDates(object context)
        {
            //var test = context;


            /*
            Project projectObj = new Project();
            projectObj.SetDates(datepickStartDate, datepickEndDate);
            */

            if (datepickEndDate < datepickStartDate)
            {
                MessageBox.Show("Das Enddatum kann nicht vor dem Startdatum liegen.","Datum setzen");
            } 
            else if (datepickReviewDate < datepickStartDate || datepickReviewDate > datepickEndDate)
            {
                MessageBox.Show("Das Reviewdatum muss zwischen Start- und Enddatum liegen.", "Datum setzen");
            }
            else 
            {
                if (contextProjectViewViewModel != null)
                {
                    contextProjectViewViewModel.selectedProject.SetDates(datepickStartDate, datepickEndDate);

                    contextProjectViewViewModel.lblStartdate = datepickStartDate;
                    contextProjectViewViewModel.lblEnddate = datepickEndDate;

                    contextProjectViewViewModel.UpdateProjectOverview();
                }
                else if (contextPhaseViewViewModel != null)
                {
                    contextPhaseViewViewModel.selectedProjectPhase.SetDates(datepickStartDate, datepickEndDate, datepickReviewDate);

                    contextPhaseViewViewModel.lblStartdate = datepickStartDate;
                    contextPhaseViewViewModel.lblEnddate = datepickEndDate;
                    contextPhaseViewViewModel.lblReviewdate = datepickReviewDate;

                    contextPhaseViewViewModel.UpdatePhaseOverview();
                }
                else if (contextActivityViewViewModel != null)
                {
                    contextActivityViewViewModel.selectedActivity.SetDates(datepickStartDate, datepickEndDate);

                    contextActivityViewViewModel.lblStartdate = datepickStartDate;
                    contextActivityViewViewModel.lblEnddate = datepickEndDate;

                    contextActivityViewViewModel.contextPhaseViewViewModel.SetActivityView();
                }

                Close?.Invoke();
            }
        }
    }
}
