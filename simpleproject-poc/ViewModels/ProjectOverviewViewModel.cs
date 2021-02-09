using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleproject_poc.Models;

namespace simpleproject_poc.ViewModels
{
    class ProjectOverviewViewModel : MainViewModel
    {
        List<ProjectMethod> _dtagrdProjectMethod;
        public List<ProjectMethod> dtagrdProjectMethod
        {
            get
            {
                ProjectMethod projectMethod = new ProjectMethod();
                _dtagrdProjectMethod = projectMethod.Get();
                return _dtagrdProjectMethod;
            }
        }
    }
}
