using System;
using System.Collections.Generic;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public class ZooKeeperHireValidator : HireValidator, IHireValidator
    {
        public override List<ValidationError> ValidateEmployee(IEmployee employee)
        {
            List<ValidationError> errors = new List<ValidationError>();
            ZooKeeper zooKeeper = employee as ZooKeeper;
            List<string> neededExperience = new List<string> { "Lion", "Elephant", "Bison", "Parrot", "Penguin", "Snake", "Turtle" };
            bool isError = false;
            foreach (string experience in zooKeeper.AnimalExperiences)
            {
                if (isError) continue;
                if (!neededExperience.Contains(experience))
                {
                    errors.Add(new ValidationError($"Zookeeper {zooKeeper.FirstName} {zooKeeper.LastName} doesn't correspond to needed experiences of the Zoo."));
                    isError = true;
                }
            }
            return errors;
        }
    }
}
