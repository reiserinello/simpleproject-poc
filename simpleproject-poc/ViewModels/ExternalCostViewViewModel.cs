using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleproject_poc.Models;
using simpleproject_poc.Helper;

namespace simpleproject_poc.ViewModels
{
    class ExternalCostViewViewModel : MainViewModel
    {
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

        private VExternalCostCostType _selectedVExternalCost;
        public VExternalCostCostType selectedVExternalCost
        {
            get
            {
                return _selectedVExternalCost;
            }
            set
            {
                _selectedVExternalCost = value;
                OnPropertyChanged("selectedExternalCost");
            }
        }

        private ExternalCost _selectedExternalCost;
        public ExternalCost selectedExternalCost
        {
            get
            {
                return _selectedExternalCost;
            }
            set
            {
                _selectedExternalCost = value;
                OnPropertyChanged("selectedExternalCost");
            }
        }

        public void InitialSet()
        {

        }


    }
}
