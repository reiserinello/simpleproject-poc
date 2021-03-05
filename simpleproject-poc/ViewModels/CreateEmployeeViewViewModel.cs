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
    class CreateEmployeeViewViewModel : MainViewModel, ICloseWindows
    {
        public Action Close { get; set; }

        // Kontext Aktivität erstellen
        private CreateActivityViewViewModel _contextCreateActivityViewViewModel;
        public CreateActivityViewViewModel contextCreateActivityViewViewModel
        {
            get
            {
                return _contextCreateActivityViewViewModel;
            }
            set
            {
                _contextCreateActivityViewViewModel = value;
                OnPropertyChanged("contextCreateActivityViewViewModel");
            }
        }

        // Kontext Projekt erstellen
        private CreateProjectViewViewModel _contextCreateProjectViewViewModel;
        public CreateProjectViewViewModel contextCreateProjectViewViewModel
        {
            get
            {
                return _contextCreateProjectViewViewModel;
            }
            set
            {
                _contextCreateProjectViewViewModel = value;
                OnPropertyChanged("contextCreateProjectViewViewModel");
            }
        }

        // Alle Abteilungen anzeigen
        public void SetDepartments()
        {
            DBGet dbGetObj = new DBGet();
            lvDepartment = dbGetObj.GeneralGet("Department",0);
        }

        #region Employeeinfo
        private string _txtName;
        private string _txtSurname;
        private int _txtEmployeeNumber;
        private int _txtWorkload;
        private string _txtFunctions;

        public string txtName
        {
            get
            {
                return _txtName;
            }
            set
            {
                _txtName = value;
                OnPropertyChanged("txtName");
            }
        }

        public string txtSurname
        {
            get
            {
                return _txtSurname;
            }
            set
            {
                _txtSurname = value;
                OnPropertyChanged("txtSurname");
            }
        }

        public int txtEmployeeNumber
        {
            get
            {
                return _txtEmployeeNumber;
            }
            set
            {
                _txtEmployeeNumber = value;
                OnPropertyChanged("txtEmployeeNumber");
            }
        }

        public int txtWorkload
        {
            get
            {
                return _txtWorkload;
            }
            set
            {
                _txtWorkload = value;
                OnPropertyChanged("txtWorkload");
            }
        }

        public string txtFunctions
        {
            get
            {
                return _txtFunctions;
            }
            set
            {
                _txtFunctions = value;
                OnPropertyChanged("txtFunctions");
            }
        }
        #endregion

        #region Departmentinfo

        private ObservableCollection<dynamic> _lvDepartment;
        public ObservableCollection<dynamic> lvDepartment
        {
            get
            {
                return _lvDepartment;
            }
            set
            {
                _lvDepartment = value;
                OnPropertyChanged("lvDepartment");
            }
        }

        private string _txtDepartmentName;
        public string txtDepartmentName
        {
            get
            {
                return _txtDepartmentName;
            }
            set
            {
                _txtDepartmentName = value;
                OnPropertyChanged("txtDepartmentName");
            }
        }

        // Button Abteilung hinzufügen
        public ICommand btnAddDepartment
        {
            get { return new DelegateCommand<object>(AddDepartment); }
        }

        private void AddDepartment(object context)
        {
            if (!(String.IsNullOrWhiteSpace(txtDepartmentName))) 
            {
                DBCreate dbCreateObj = new DBCreate();
                dbCreateObj.DepartmentCreate(txtDepartmentName);

                // Abteilungsübersicht updaten
                SetDepartments();

                // Abteilungs-Textbox leeren
                txtDepartmentName = null;
            }
            
        }
        #endregion

        // Button Mitarbeiter erstellen
        public ICommand btnCreateEmployee
        {
            get { return new DelegateCommand<object>(CreateEmployee); }
        }

        private void CreateEmployee(object context)
        {
            var selectedDepartment = (Department)context;
            if (selectedDepartment == null || txtName == null || txtSurname == null || txtFunctions == null)
            {
                MessageBox.Show("Bitte alle Felder ausfüllen und eine Abteilung auswählen", "Mitarbeiter erstellen");
            } 
            else
            {
                DBCreate dbCreateObj = new DBCreate();
                dbCreateObj.EmployeeCreate(txtName, txtSurname, txtEmployeeNumber, txtWorkload, txtFunctions, selectedDepartment.Id);

                // Mitarbeiterübersicht in Aktivitäterstellen View updaten
                if (contextCreateActivityViewViewModel != null)
                {
                    contextCreateActivityViewViewModel.SetEmployeeValues();
                }

                // Mitarbeiterübersicht in Projekterstellen View updaten
                if (contextCreateProjectViewViewModel != null)
                {
                    contextCreateProjectViewViewModel.SetEmployeeValues();
                }

                Close?.Invoke();
            }
        }
    }
}
