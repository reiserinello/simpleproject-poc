using Prism.Commands;
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
    class SetDatesViewViewModel : MainViewModel
    {
        public ProjectViewViewModel _contextProjectViewViewModel;

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
            datepickStartDate = contextProjectViewViewModel.lblStartdate;
            datepickEndDate = contextProjectViewViewModel.lblEnddate;

        }

        // Button Projekt freigeben
        public ICommand btnSetDates
        {
            get { return new DelegateCommand<object>(SetDates); }
        }

        private void SetDates(object context)
        {
            //var test = context;

            Project projectObj = new Project();
            projectObj.SetDates(_contextProjectViewViewModel, _datepickStartDate, _datepickEndDate);
        }
    }
}
