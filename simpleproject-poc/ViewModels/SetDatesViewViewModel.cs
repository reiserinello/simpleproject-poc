﻿using Prism.Commands;
using simpleproject_poc.Helper;
using simpleproject_poc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Nullable<DateTime> _datepickStartDate;
        public Nullable<DateTime> _datepickEndDate;

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

        // Initial date setter
        public void InitialDateSetter()
        {
            if (contextProjectViewViewModel != null)
            {
                datepickStartDate = contextProjectViewViewModel.lblStartdate;
                datepickEndDate = contextProjectViewViewModel.lblEnddate;
            }
            
            if (contextPhaseViewViewModel != null)
            {
                datepickStartDate = contextPhaseViewViewModel.lblStartdate;
                datepickEndDate = contextPhaseViewViewModel.lblEnddate;
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

            if (contextProjectViewViewModel != null)
            {
                contextProjectViewViewModel.selectedProject.SetDates(datepickStartDate, datepickEndDate);

                contextProjectViewViewModel.lblStartdate = datepickStartDate;
                contextProjectViewViewModel.lblEnddate = datepickEndDate;

                contextProjectViewViewModel.UpdateProjectOverview();
            }

            if (contextPhaseViewViewModel != null)
            {
                contextPhaseViewViewModel.selectedProjectPhase.SetDates(datepickStartDate,datepickEndDate);

                contextPhaseViewViewModel.lblStartdate = datepickStartDate;
                contextPhaseViewViewModel.lblEnddate = datepickEndDate;

                contextPhaseViewViewModel.UpdatePhaseOverview();
            }

            Close?.Invoke();
        }
    }
}