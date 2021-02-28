using Prism.Commands;
using simpleproject_poc.Helper;
using simpleproject_poc.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace simpleproject_poc.ViewModels
{
    class EmployeeResourceViewViewModel: MainViewModel, ICloseWindows
    {
        public Action Close { get; set; }

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

        private VEmployeeResourceFunction _selectedVEmployeeResource;
        public VEmployeeResourceFunction selectedVEmployeeResource
        {
            get
            {
                return _selectedVEmployeeResource;
            }
            set
            {
                _selectedVEmployeeResource = value;
                OnPropertyChanged("selectedVEmployeeResource");
            }
        }

        private EmployeeResource _selectedEmployeeResource;
        public EmployeeResource selectedEmployeeResource
        {
            get
            {
                return _selectedEmployeeResource;
            }
            set
            {
                _selectedEmployeeResource = value;
                OnPropertyChanged("selectedEmployeeResource");
            }
        }

        public void InitialSet()
        {
            UpdateFunctionList();

            if (selectedVEmployeeResource == null)
            {
                CreateFieldsEnabled = true;
                SetFieldsEnabled = false;

                btnCreateOrSetEmployeeResourceName = "Erstellen";


            }
            else
            {
                CreateFieldsEnabled = false;
                SetFieldsEnabled = true;

                selectedEmployeeResource = new EmployeeResource(selectedVEmployeeResource.Id, selectedVEmployeeResource.BudgetTime, selectedVEmployeeResource.EffectiveTime, selectedVEmployeeResource.Deviation, selectedVEmployeeResource.FunctionId, selectedVEmployeeResource.ActivityId);

                txtPlannedTime= selectedEmployeeResource.BudgetTime;
                txtEffectiveTime = selectedEmployeeResource.EffectiveTime;
                txtDeviation = selectedEmployeeResource.Deviation;

                btnCreateOrSetEmployeeResourceName = "Setzen";

            }
        }

        public void UpdateFunctionList()
        {
            DBGet dbGetObj = new DBGet();
            lvFunction = dbGetObj.GeneralGet("Function", 0);
        }

        // Alle Felder für Erstellen der Kosten aktivieren / deaktivieren
        private bool _CreateFieldsEnabled;
        public bool CreateFieldsEnabled
        {
            get { return _CreateFieldsEnabled; }

            set
            {
                if (_CreateFieldsEnabled == value)
                {
                    return;
                }

                _CreateFieldsEnabled = value;
                OnPropertyChanged("CreateFieldsEnabled");
            }
        }

        // Alle Felder für Setzen der bestehenden Kosten aktivieren / deaktivieren
        private bool _SetFieldsEnabled;
        public bool SetFieldsEnabled
        {
            get { return _SetFieldsEnabled; }

            set
            {
                if (_SetFieldsEnabled == value)
                {
                    return;
                }

                _SetFieldsEnabled = value;
                OnPropertyChanged("SetFieldsEnabled");
            }
        }

        #region Funktion
        private ObservableCollection<dynamic> _lvFunction;
        public ObservableCollection<dynamic> lvFunction
        {
            get
            {
                return _lvFunction;
            }
            set
            {
                _lvFunction = value;
                OnPropertyChanged("lvFunction");
            }
        }

        private string _txtFunctionToAdd;
        public string txtFunctionToAdd
        {
            get
            {
                return _txtFunctionToAdd;
            }
            set
            {
                _txtFunctionToAdd = value;
                OnPropertyChanged("txtFunctionToAdd");
            }
        }

        // Button Funktion hinzufügen
        public ICommand btnAddFunction
        {
            get { return new DelegateCommand<object>(AddFunction, AddFunctionIsEnabled); }
        }

        private void AddFunction(object context)
        {
            if (txtFunctionToAdd == null)
            {
                MessageBox.Show("Um eine Kostenart zu erfassen, muss ein Kostenartname angegeben werden.", "Kostenart erfassen");
            }
            else
            {
                DBCreate dbCreateObj = new DBCreate();
                dbCreateObj.FunctionCreate(txtFunctionToAdd);

                UpdateFunctionList();

                txtFunctionToAdd = null;
            }
        }

        // CanExecute Methode für btnAddFunction
        private bool AddFunctionIsEnabled(object context)
        {
            if (selectedVEmployeeResource == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        private int _txtPlannedTime;
        private Nullable<int> _txtEffectiveTime;
        private string _txtDeviation;

        public int txtPlannedTime
        {
            get
            {
                return _txtPlannedTime;
            }
            set
            {
                _txtPlannedTime = value;
                OnPropertyChanged("txtPlannedTime");
            }
        }

        public Nullable<int> txtEffectiveTime
        {
            get
            {
                return _txtEffectiveTime;
            }
            set
            {
                _txtEffectiveTime = value;
                OnPropertyChanged("txtEffectiveTime");
            }
        }

        public string txtDeviation
        {
            get
            {
                return _txtDeviation;
            }
            set
            {
                _txtDeviation = value;
                OnPropertyChanged("txtDeviation");
            }
        }

        // Button Externe Kosten erstellen oder setzen
        public ICommand btnCreateOrSetEmployeeResource
        {
            get { return new DelegateCommand<object>(CreateOrSetEmployeeResource); }
        }

        private void CreateOrSetEmployeeResource(object context)
        {
            if (selectedVEmployeeResource == null)
            {
                var selectedFunction = (Function)context;

                if (selectedFunction == null)
                {
                    MessageBox.Show("Um eine personelle Ressource zu erstellen, muss eine Funktion sowie die geplante Zeit (Budget) angegeben werden.", "Personelle Ressource erstellen");
                }
                else 
                {
                    DBCreate dbCreateObj = new DBCreate();
                    dbCreateObj.EmployeeResourceCreate(txtPlannedTime, selectedFunction.Id, contextActivityViewViewModel.selectedActivity.Id);

                    contextActivityViewViewModel.UpdateEmployeeResource();

                    Close?.Invoke();
                }
            }
            else
            {
                if (txtEffectiveTime == null)
                {
                    MessageBox.Show("Um eine personelle Ressource zu setzen, muss mindestens die effektive Zeit angegeben werden.", "Personelle Ressource erstellen");
                }
                else
                {
                    selectedEmployeeResource.SetTime(txtEffectiveTime, txtDeviation);

                    contextActivityViewViewModel.UpdateEmployeeResource();

                    Close?.Invoke();
                }
            }

            

        }

        // Anzeigename des Buttons
        private string _btnCreateOrSetEmployeeResourceName;
        public string btnCreateOrSetEmployeeResourceName
        {
            get
            {
                return _btnCreateOrSetEmployeeResourceName;
            }
            set
            {
                _btnCreateOrSetEmployeeResourceName = value;
                OnPropertyChanged("btnCreateOrSetEmployeeResourceName");
            }
        }
    }
}
