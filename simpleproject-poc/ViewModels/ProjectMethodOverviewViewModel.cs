using simpleproject_poc.Helper;
using simpleproject_poc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.ViewModels
{
    class ProjectMethodOverviewViewModel : MainViewModel
    {
        public ObservableCollection<Phase> _lvPhase;

        public ProjectMethodOverviewViewModel()
        {
            DBGet dbGet = new DBGet();
            _lvPhase = dbGet.PhaseGet(_selectedProjectMethod.Id);
        }

        ProjectMethod _selectedProjectMethod;
        public ProjectMethod selectedProjectMethod
        {
            get
            {
                return _selectedProjectMethod;
            }
            set
            {
                _selectedProjectMethod = value;
                OnPropertyChanged("selectedProjectMethod");
            }
        }

        public ObservableCollection<Phase> lvPhase
        {
            get
            {
                
                return _lvPhase;
            }
            set
            {
                _lvPhase = value;
                OnPropertyChanged("lvPhase");
            }
        }
    }
}
