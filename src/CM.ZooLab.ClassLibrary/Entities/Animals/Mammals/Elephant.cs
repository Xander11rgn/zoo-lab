using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public class Elephant : Mammal
    {
        public override int RequiredSpaceSqFt
        {
            get;
        } = 1000;
        public override string[] FavoriteFood
        {
            get;
        } = { "Grass", "Vegetable" };
        public override string[] NeededMedicine
        {
            get;
        } = { "Antibiotics", "AntiDepression", "AntiInflammatory" };

        public override string[] FriendlyFor
        {
            get;
        } = { "Bison", "Parrots", "Turtle" };

        public override bool IsFriendlyWith(Animal animal)
        {
            return FriendlyFor.Contains(animal.GetType().Name);
        }

        public Elephant(List<int> feedSchedule, Zoo zoo)
        {
            AddFeedSchedule(feedSchedule);
            IsSick = new bool[2] { true, false }[new Random().Next(0, 2)];
            ID = 0;
            foreach (Enclosure enclosure in zoo.Enclosures)
            {
                ID += enclosure.Animals.Count;
            }
            Console.Write("The ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"elephant ID {ID} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("was created.");
            Console.ResetColor();
        }
        public Elephant()
        {
        }
    }
}
