using System;
using System.Collections.Generic;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public class ZooKeeper : IEmployee
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
        public bool FeedAnimal(Animal animal)
        {
            List<Food> food = new List<Food> { new Grass(), new Meat(), new Vegetable() };
            FeedTime feedTime = new FeedTime(DateTime.Now, this);
            if ((HasAnimalExperience(animal)) && ((animal.FeedSchedule[0] == DateTime.Now.Hour) || (animal.FeedSchedule[1] == DateTime.Now.Hour)))
            {
                animal.Feed(food, feedTime);
                return true;
            }
            else
            {
                return false;
            }

                
        }

        public ZooKeeper(string firstName, string lastName, List<string> animalExperiences)
        {
            FirstName = firstName;
            LastName = lastName;
            AnimalExperiences = animalExperiences;
        }
        public ZooKeeper()
        {
        }
    }
}
