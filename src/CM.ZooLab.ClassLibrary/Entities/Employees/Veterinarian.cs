using System;
using System.Collections.Generic;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public class Veterinarian : IEmployee
    {
        public string FirstName
        {
            get;
            private set;
        }
        public string LastName
        {
            get;
            private set;
        }
        public List<string> AnimalExperiences
        {
            get;
            private set;
        }

        public void AddAnimalExperience(Animal animal)
        {
            if (!AnimalExperiences.Contains(animal.GetType().Name))
            {
                AnimalExperiences.Add(animal.GetType().Name);
            }

        }
        public bool HasAnimalExperience(Animal animal)
        {
            if (AnimalExperiences.Contains(animal.GetType().Name))
            {
                return true;
            }
            else
            {
                throw new NoNeededExperienceException();
            }

        }
        public bool HealAnimal(Animal animal)
        { 
            List<Medicine> medicine = new List<Medicine> { new Antibiotics(), new AntiDepression(), new AntiInflammatory() };
            if ((HasAnimalExperience(animal)) && (animal.IsSick))
            {
                animal.Heal(medicine);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Veterinarian(string firstName, string lastName, List<string> animalExperiences)
        {
            FirstName = firstName;
            LastName = lastName;
            AnimalExperiences = animalExperiences;
        }
    }
}
