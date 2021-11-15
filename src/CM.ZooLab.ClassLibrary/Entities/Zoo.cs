using System;
using System.Collections.Generic;
using System.Linq;

namespace CM.ZooLab.ClassLibrary
{
    public class Zoo
    {
        public List<Enclosure> Enclosures
        {
            get;
            set;
        } = new List<Enclosure>();
        public List<IEmployee> Employees
        {
            get;
            set;
        } = new List<IEmployee>();
        public string Location
        {
            get;
            private set;
        }

        public Zoo(string location)
        {
            Location = location;
            Console.Write("The zoo ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("was created ");
            Console.ResetColor();
            Console.Write("in ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Location}.");
            Console.ResetColor();
        }
        public void AddEnclosure(string name, int squareFeet)
        {
            Enclosures.Add(new Enclosure(name, this, squareFeet));
            Console.Write($"The enclosure \"{name}\" ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("was added ");
            Console.ResetColor();
            Console.Write("to the ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{Location}'s Zoo. ");
            Console.ResetColor();
            Console.Write("Its square equals ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{squareFeet} ");
            Console.ResetColor();
            Console.WriteLine("sq.ft.");
        }
        public Enclosure FindAvailableEnclosure(Animal animal)
        {
            bool isAvailableSpace = false;
            bool isUnfriendly = false;
            Enclosure enclosureToReturn = new Enclosure();
            foreach (Enclosure enclosure in Enclosures)
            {
                if ((isAvailableSpace) && (!isUnfriendly)) continue;
                isAvailableSpace = false;
                isUnfriendly = false;
                
                foreach (Animal _animal in enclosure.Animals)
                {
                    if (isUnfriendly) continue;
                    if (!animal.IsFriendlyWith(_animal))
                    {
                        isUnfriendly = true;
                    }
                }
                if (enclosure.SquareFeet >= animal.RequiredSpaceSqFt)
                {
                    isAvailableSpace = true;
                    enclosureToReturn = enclosure;
                }
            }
            if ((isAvailableSpace) && (!isUnfriendly))
            {
                Console.Write($"The enclosure \"{enclosureToReturn.Name}\" for the ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{animal.GetType().Name.ToLower()} ID {animal.ID} ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("was found.");
                Console.ResetColor();
                return enclosureToReturn;
            }
            else
            {
                Console.Write("The acceptable enclosure for the ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{animal.GetType().Name.ToLower()} ID {animal.ID} ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("wasn't found.");
                Console.ResetColor();
                throw new NoAvailableEnclosureException();
            }
        }
        public void HireEmployee(IEmployee? employee)
        {
            IHireValidator validator = HireValidatorProvider.GetHireValidator(employee);
            List<ValidationError> errors = validator.ValidateEmployee(employee);
            if (errors.Count == 0)
            {
                Employees.Add(employee);
                Console.Write($"The {employee.GetType().Name.ToLower()} {employee.FirstName} {employee.LastName} ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("was hired ");
                Console.ResetColor();
                Console.Write($"to the ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{Location}'s Zoo.");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"The {employee.GetType().Name.ToLower()} {employee.FirstName} {employee.LastName} ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("wasn't hired ");
                Console.ResetColor();
                Console.Write("because of ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("no needed experience.");
                Console.ResetColor();
                throw new NoNeededExperienceException();
            }
        }
        public void FeedAnimals ()
        {
            List<IEmployee> zooKeepers = Employees.Where(employee => employee.GetType().Name == "ZooKeeper").ToList();
            int groupCount = zooKeepers.Count;

            List<List<Animal>> animalGroups = buildAnimalGroups(groupCount);

            for (int i = 0; i < groupCount; i++)
            {
                foreach (Animal animal in animalGroups[i])
                {
                    if ((zooKeepers[i] as ZooKeeper).FeedAnimal(animal))
                    {
                        Console.Write($"{animal.GetType().Name} ID {animal.ID} ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("was fed ");
                        Console.ResetColor();
                        Console.Write("by the zookeeper ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{zooKeepers[i].FirstName} {zooKeepers[i].LastName}.");
                        Console.ResetColor();
                    }
                }
            }
        }
        public void HealAnimals ()
        {
            List<IEmployee> veterinarians = Employees.Where(employee => employee.GetType().Name == "Veterinarian").ToList();
            int groupCount = veterinarians.Count;

            List<List<Animal>> animalGroups = buildAnimalGroups(groupCount);

            for (int i = 0; i < groupCount; i++)
            {
                foreach (Animal animal in animalGroups[i])
                {
                    if ((veterinarians[i] as Veterinarian).HealAnimal(animal))
                    {
                        Console.Write($"{animal.GetType().Name} ID {animal.ID} ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("was healed ");
                        Console.ResetColor();
                        Console.Write("by the veterinarian ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{veterinarians[i].FirstName} {veterinarians[i].LastName}.");
                        Console.ResetColor();
                    }
                }
            }

        }


        private List<List<Animal>> buildAnimalGroups(int groupCount)
        {
            int animalCount = 0;
            List<Animal> animalTotal = new List<Animal>();
            foreach (Enclosure enclosure in Enclosures)
            {
                foreach (Animal animal in enclosure.Animals)
                {
                    animalCount++;
                    animalTotal.Add(animal);
                }
            }
            List<List<Animal>> animalGroups = new List<List<Animal>>();
            for (int i = 0; i < groupCount; i++)
            {
                animalGroups.Add(new List<Animal>());
            }
            int topIndex = Convert.ToInt32(animalCount / groupCount);
            for (int i = 0; i < topIndex; i++)
            {
                for (int j = 0; j < groupCount; j++)
                {
                    animalGroups[j].Add(animalTotal[i * groupCount + j]);
                }
            }
            topIndex = animalTotal.Count - groupCount * topIndex;
            for (int i = 0; i < topIndex; i++)
            {
                animalGroups[i].Add(animalTotal[groupCount * topIndex + i]);
            }
            return animalGroups;
        }
    }
}
