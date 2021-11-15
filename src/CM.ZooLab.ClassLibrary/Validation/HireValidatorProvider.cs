using System;
using System.Collections.Generic;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public class HireValidatorProvider
    {
        public static IHireValidator GetHireValidator(IEmployee? employee)
        {
            if (employee?.GetType().Name == typeof(ZooKeeper).Name)
            {
                return new ZooKeeperHireValidator();
            }
            if (employee?.GetType().Name == typeof(Veterinarian).Name)
            {
                return new VeterinarianHireValidator();
            }
            throw new Exception();
        }
    }
}
