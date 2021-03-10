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
        private string _txtNewPhase;

        // Ausgewähltes Vorgehensmodell
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

        // Updaten der Phasenlistview
        public void UpdatePhaseList()
        {
            DBGet dbGet = new DBGet();
            lvPhase = dbGet.GeneralGet("Phase", _selectedProjectMethod.Id);
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

        public string txtNewPhase
        {
            get
            {
                return _txtNewPhase;
            }
            set
            {
                _txtNewPhase = value;
                OnPropertyChanged("txtNewPhase");
            }
        }

        // Kontext der Projektübersicht
        private ProjectOverviewViewModel _contextProjectOverviewModel;
        public ProjectOverviewViewModel contextProjectOverviewModel
        {
            get
            {
                return _contextProjectOverviewModel;
            }
            set
            {
                _contextProjectOverviewModel = value;
                OnPropertyChanged("contextProjectOverviewModel");
            }
        }

        // Button Phase hinzufügen
        public ICommand btnNewPhase
        {
            get { return new DelegateCommand<object>(CreateNewPhase); }
        }

        private void CreateNewPhase(object context)
        {
            if (txtNewPhase != null)
            {
                DBCreate dbCreateObj = new DBCreate();
                dbCreateObj.PhaseCreate(txtNewPhase, selectedProjectMethod.Id);

                // Phasenliste updaten
                UpdatePhaseList();

                // Phasentextbox leeren
                txtNewPhase = null;
            }
        }
    }
}
