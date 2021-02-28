using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleproject_poc.Models;
using simpleproject_poc.Helper;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using System.Windows;

namespace simpleproject_poc.ViewModels
{
    class ExternalCostViewViewModel : MainViewModel, ICloseWindows
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
            UpdateCostTypeList();

            if (selectedVExternalCost == null)
            {
                CreateFieldsEnabled = true;
                SetFieldsEnabled = false;

                btnCreateOrSetExternalCostName = "Erstellen";


            } else
            {
                CreateFieldsEnabled = false;
                SetFieldsEnabled = true;

                selectedExternalCost = new ExternalCost(selectedVExternalCost.Id, selectedVExternalCost.BudgetCost, selectedVExternalCost.EffectiveCost, selectedVExternalCost.Deviation, selectedVExternalCost.CostTypeId, selectedVExternalCost.ActivityId);

                txtCostPlanned = selectedExternalCost.BudgetCost;
                txtCostEffective = selectedExternalCost.EffectiveCost;
                txtDeviation = selectedExternalCost.Deviation;

                btnCreateOrSetExternalCostName = "Setzen";

            }
        }

        public void UpdateCostTypeList()
        {
            DBGet dbGetObj = new DBGet();
            lvCostType = dbGetObj.GeneralGet("Cost_type",0);
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

        #region Kostenart
        private ObservableCollection<dynamic> _lvCostType;
        public ObservableCollection<dynamic> lvCostType
        {
            get
            {
                return _lvCostType;
            }
            set
            {
                _lvCostType = value;
                OnPropertyChanged("lvCostType");
            }
        }

        private string _txtCostTypeToAdd;
        public string txtCostTypeToAdd
        {
            get
            {
                return _txtCostTypeToAdd;
            }
            set
            {
                _txtCostTypeToAdd = value;
                OnPropertyChanged("txtCostTypeToAdd");
            }
        }

        // Button Kostenart hinzufügen
        public ICommand btnAddCostType
        {
            get { return new DelegateCommand<object>(AddCostType, AddCostTypeIsEnabled); }
        }

        private void AddCostType(object context)
        {
            if (txtCostTypeToAdd == null)
            {
                MessageBox.Show("Um eine Kostenart zu erfassen, muss ein Kostenartname angegeben werden.","Kostenart erfassen");
            }
            else
            {
                DBCreate dbCreateObj = new DBCreate();
                dbCreateObj.CostTypeCreate(txtCostTypeToAdd);

                UpdateCostTypeList();

                txtCostTypeToAdd = null;
            }
        }

        // CanExecute Methode für btnAddCostType
        private bool AddCostTypeIsEnabled(object context)
        {
            if (selectedVExternalCost == null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        #endregion

        private int _txtCostPlanned;
        private Nullable<int> _txtCostEffective;
        private string _txtDeviation;

        public int txtCostPlanned
        {
            get
            {
                return _txtCostPlanned;
            }
            set
            {
                _txtCostPlanned = value;
                OnPropertyChanged("txtCostPlanned");
            }
        }

        public Nullable<int> txtCostEffective
        {
            get
            {
                return _txtCostEffective;
            }
            set
            {
                _txtCostEffective = value;
                OnPropertyChanged("txtCostEffective");
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
        public ICommand btnCreateOrSetExternalCost
        {
            get { return new DelegateCommand<object>(CreateOrSetExternalCost); }
        }

        private void CreateOrSetExternalCost(object context)
        {
            if (selectedVExternalCost == null)
            {
                var selectedCostType = (CostType)context;

                if (selectedCostType == null)
                {
                    MessageBox.Show("Um externe Kosten zu erstellen, muss eine Kostenart sowie die geplanten Kosten (Budget) angegeben werden.", "Externe Kosten erstellen");
                }
                else
                {
                    DBCreate dbCreateObj = new DBCreate();
                    dbCreateObj.ExternalCostCreate(txtCostPlanned, selectedCostType.Id, contextActivityViewViewModel.selectedActivity.Id);

                    contextActivityViewViewModel.UpdateExternalCost();

                    Close?.Invoke();
                }
            }
            else
            {
                if (txtCostEffective == null)
                {
                    MessageBox.Show("Um externe Kosten zu setzen, müssen mindestens die effektiven Kosten angegeben werden.", "Externe Kosten erstellen");
                }
                else
                {
                    selectedExternalCost.SetCost(txtCostEffective, txtDeviation);

                    contextActivityViewViewModel.UpdateExternalCost();

                    Close?.Invoke();
                }
            }
        }

        // Anzeigename des Buttons
        private string _btnCreateOrSetExternalCostName;
        public string btnCreateOrSetExternalCostName
        {
            get
            {
                return _btnCreateOrSetExternalCostName;
            }
            set
            {
                _btnCreateOrSetExternalCostName = value;
                OnPropertyChanged("btnCreateOrSetExternalCostName");
            }
        }

    }
}
