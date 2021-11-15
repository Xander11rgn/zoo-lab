using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public class Snake : Reptile
    {
        public override int RequiredSpaceSqFt
        {
            get;
        } = 2;
        public override string[] FavoriteFood
        {
            get;
        } = { "Grass", "Vegetable", "Meat" };
        public override string[] NeededMedicine
        {
            get;
        } = { "AntiDepression" };

        public override string[] FriendlyFor
        {
            get;
        } = { "Snake" };

        public override bool IsFriendlyWith(Animal animal)
        {
            return FriendlyFor.Contains(animal.GetType().Name);
        }

        public Snake(List<int> feedSchedule, Zoo zoo)
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
            Console.Write($"snake ID {ID} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("was created.");
            Console.ResetColor();
        }
        public Snake()
        {
        }
    }
}
