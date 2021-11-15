using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CM.ZooLab.ClassLibrary
{
    public class Parrot : Bird
    {
        public override int RequiredSpaceSqFt
        {
            get;
        } = 5;
        public override string[] FavoriteFood
        {
            get;
        } = { "Grass" };
        public override string[] NeededMedicine
        {
            get;
        } = { "Antibiotics" };

        public override string[] FriendlyFor
        {
            get;
        } = { "Parrot", "Bison", "Elephant", "Turtle" };

        public override bool IsFriendlyWith(Animal animal)
        {
            return FriendlyFor.Contains(animal.GetType().Name);
        }

        public Parrot(List<int> feedSchedule, Zoo zoo)
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
            Console.Write($"parrot ID {ID} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("was created.");
            Console.ResetColor();
        }
        public Parrot()
        {
        }
    }
}
