using System;
using System.Collections.Generic;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public interface IHireValidator
    {
        public List<ValidationError> ValidateEmployee(IEmployee employee);
    }
}
