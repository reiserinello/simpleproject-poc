using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleproject_poc.Helper
{
    class StateHelper
    {
        //nothing
    }
    public enum Priority
    {
        Major,
        High,
        Medium,
        Low
    }

    public enum State
    {
        Created,
        Released,
        InPlanning,
        WorkInProgress,
        Closed
    }
}
