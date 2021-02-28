using Prism.Commands;
using simpleproject_poc.Helper;
using simpleproject_poc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace simpleproject_poc.ViewModels
{
    class ProjectMethodOverviewViewModel : MainViewModel
    {
        public ObservableCollection<dynamic> _lvPhase;
        public string _lblProjectMethodName;

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

        public ObservableCollection<dynamic> GetPhase()
        {
            DBGet dbGet = new DBGet();
            return dbGet.GeneralGet("Phase",_selectedProjectMethod.Id);
        }

        public ObservableCollection<dynamic> lvPhase
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

        public string lblProjectMethodName
        {
            get
            {
                return _lblProjectMethodName;
            }
            set
            {
                _lblProjectMethodName = value;
                OnPropertyChanged("lblProjectMethodName");
            }
        }

        // Button Phase hinzufügen
        public ICommand btnNewPhase
        {
            get { return new DelegateCommand<object>(CreateNewPhase); }
        }

        private void CreateNewPhase(object context)
        {
            DBCreate dbCreateObj = new DBCreate();
            dbCreateObj.PhaseCreate((String)context, _selectedProjectMethod.Id,this);
        }
    }
}
