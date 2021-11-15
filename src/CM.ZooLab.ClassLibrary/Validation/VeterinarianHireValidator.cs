using System;
using System.Collections.Generic;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public class VeterinarianHireValidator : HireValidator, IHireValidator
    {
        public override List<ValidationError> ValidateEmployee(IEmployee employee)
        {
            List<ValidationError> errors = new List<ValidationError>();
            Veterinarian veterinarian = employee as Veterinarian;
            List<string> neededExperience = new List<string> { "Lion", "Elephant", "Bison", "Parrot", "Penguin", "Snake", "Turtle" };
            bool isError = false;
            foreach(string experience in veterinarian.AnimalExperiences)
            {
                if (isError) continue;
                if (!neededExperience.Contains(experience))
                {
                    errors.Add(new ValidationError($"Veterinarian {veterinarian.FirstName} {veterinarian.LastName} doesn't correspond to needed experiences of the Zoo."));
                    isError = true;
                }
            }
            return errors;
        }
    }
}
