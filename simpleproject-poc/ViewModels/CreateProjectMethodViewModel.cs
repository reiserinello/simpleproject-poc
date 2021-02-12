using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using simpleproject_poc.Models;
using simpleproject_poc.Helper;
using simpleproject_poc.Views;
//using System.Windows;

namespace simpleproject_poc.ViewModels
{
    class CreateProjectMethodViewModel : MainViewModel
    {
        // Button neues Vorgehensmodell erstellen
        public ICommand btnCreateNewProjectMethod
        {
            get { return new DelegateCommand<object>(CreateProjectMethod, FuncToEvaluate); }
        }

        private void CreateProjectMethod(object context)
        {
            //this is called when the button is clicked
            DBCreate createProjectMethodObj = new DBCreate();
            createProjectMethodObj.ProjectMethodCreate(context.ToString());

            

            CreateProjectMethod frmCreateProjectMethod = new CreateProjectMethod();
            frmCreateProjectMethod.Hide();
        }

        private bool FuncToEvaluate(object context)
        {
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }
    }
}
