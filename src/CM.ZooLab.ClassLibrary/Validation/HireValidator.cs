using System;
using System.Collections.Generic;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public abstract class HireValidator
    {
        public abstract List<ValidationError> ValidateEmployee(IEmployee employee);
    }
}
