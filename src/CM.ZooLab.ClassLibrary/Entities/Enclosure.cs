using System;
using System.Collections.Generic;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public class Enclosure
    {
        public string Name 
        {
            get;
            private set;
        }
        public List<Animal> Animals
        {
            get;
            set;
        } = new List<Animal>();
        public Zoo ParentZoo
        {
            get;
            private set;
        }
        public int SquareFeet
        {
            get;
            private set;
        }

        public void AddAnimals (Animal animal)
        {
            if (animal.RequiredSpaceSqFt <= SquareFeet)
            {
                foreach (Animal _animal in Animals)
                {
                    if (!animal.IsFriendlyWith(_animal))
                    {
                        throw new NotFriendlyAnimalException();
                    }
                }
                Animals.Add(animal);
                SquareFeet -= animal.RequiredSpaceSqFt;
                Console.Write($"The {animal.GetType().Name.ToLower()} ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"ID {animal.ID} ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("was added ");
                Console.ResetColor();
                Console.Write("to the enclosure ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\"{Name}\".");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"The {animal.GetType().Name} wasn't added to the enclosure because of no available space.");
                Console.Write($"The {animal.GetType().Name.ToLower()} ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("wasn't added ");
                Console.ResetColor();
                Console.Write("to the enclosure because of ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("no available space.");
                Console.ResetColor();
                throw new NoAvailableSpaceException();
            }
            
        }

        public Enclosure(string name, Zoo parentZoo, int squareFeet)
        {
            Name = name;
            ParentZoo = parentZoo;
            SquareFeet = squareFeet;
        }
        public Enclosure()
        {
        }

    }
}
