using Prism.Commands;
using simpleproject_poc.Helper;
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

        // Button Projekt freigeben
        public ICommand btnSetDates
        {
            get { return new DelegateCommand<object>(SetDates); }
        }

        private void SetDates(object context)
        {
            DBUpdate dbUpdateObj = new DBUpdate();
            dbUpdateObj.SetProjectApprovalDate(this);
        }
    }
}
