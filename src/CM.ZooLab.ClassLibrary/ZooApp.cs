using System;
using System.Collections.Generic;
using System.Text;

namespace CM.ZooLab.ClassLibrary
{
    public class ZooApp
    {
        public static List<Zoo> Zoos = new List<Zoo>();
        public static void AddZoos(List<Zoo> zoos)
        {
            Zoos.AddRange(zoos);
        }
        public static void ZooInit()
        {
            //create 2 zoos
            Zoo zooTokyo = new Zoo("Tokyo");
            Zoo zooSingapore = new Zoo("Singapore");
            AddZoos(new List<Zoo> { zooTokyo, zooSingapore });

            Console.WriteLine("-----------------------------");

            //add enclosures for the first zoo
            zooTokyo.AddEnclosure("Mixed enclosure №1 (Tokyo)", 2500);
            zooTokyo.AddEnclosure("Mixed enclosure №2 (Tokyo)", 300);
            zooTokyo.AddEnclosure("Mixed enclosure №3 (Tokyo)", 3000);
            zooTokyo.AddEnclosure("Mixed enclosure №4 (Tokyo)", 20);

            Console.WriteLine("-----------------------------");

            //add enclosures for the second zoo
            zooSingapore.AddEnclosure("Mixed enclosure №1 (Singapore)", 200);
            zooSingapore.AddEnclosure("Mixed enclosure №2 (Singapore)", 150);
            zooSingapore.AddEnclosure("Mixed enclosure №3 (Singapore)", 1500);
            zooSingapore.AddEnclosure("Mixed enclosure №4 (Singapore)", 20);

            Console.WriteLine("-----------------------------");

            //create and add animals for the first zoo
            List<Parrot> parrotsTokyo = new List<Parrot>();
            for (int i = 0; i < 5; i++)
            {
                parrotsTokyo.Add(new Parrot(new List<int> { 3, DateTime.Now.Hour }, zooTokyo));
                try { zooTokyo.FindAvailableEnclosure(parrotsTokyo[i]).AddAnimals(parrotsTokyo[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            List<Penguin> penguinsTokyo = new List<Penguin>();
            for (int i = 0; i < 3; i++)
            {
                penguinsTokyo.Add(new Penguin(new List<int> { 3, DateTime.Now.Hour }, zooTokyo));
                try { zooTokyo.FindAvailableEnclosure(penguinsTokyo[i]).AddAnimals(penguinsTokyo[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            List<Lion> lionsTokyo = new List<Lion>();
            for (int i = 0; i < 4; i++)
            {
                lionsTokyo.Add(new Lion(new List<int> { 3, DateTime.Now.Hour }, zooTokyo));
                try { zooTokyo.FindAvailableEnclosure(lionsTokyo[i]).AddAnimals(lionsTokyo[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            List<Bison> bisonsTokyo = new List<Bison>();
            for (int i = 0; i < 2; i++)
            {
                bisonsTokyo.Add(new Bison(new List<int> { 3, DateTime.Now.Hour }, zooTokyo));
                try { zooTokyo.FindAvailableEnclosure(bisonsTokyo[i]).AddAnimals(bisonsTokyo[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            List<Elephant> elephantsTokyo = new List<Elephant>();
            for (int i = 0; i < 2; i++)
            {
                elephantsTokyo.Add(new Elephant(new List<int> { 3, DateTime.Now.Hour }, zooTokyo));
                try { zooTokyo.FindAvailableEnclosure(elephantsTokyo[i]).AddAnimals(elephantsTokyo[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            List<Snake> snakesTokyo = new List<Snake>();
            for (int i = 0; i < 7; i++)
            {
                snakesTokyo.Add(new Snake(new List<int> { 3, DateTime.Now.Hour }, zooTokyo));
                try { zooTokyo.FindAvailableEnclosure(snakesTokyo[i]).AddAnimals(snakesTokyo[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            List<Turtle> turtlesTokyo = new List<Turtle>();
            for (int i = 0; i < 5; i++)
            {
                turtlesTokyo.Add(new Turtle(new List<int> { 3, DateTime.Now.Hour }, zooTokyo));
                try { zooTokyo.FindAvailableEnclosure(turtlesTokyo[i]).AddAnimals(turtlesTokyo[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            //create and add animals for the second zoo
            List<Parrot> parrotsSingapore = new List<Parrot>();
            for (int i = 0; i < 5; i++)
            {
                parrotsSingapore.Add(new Parrot(new List<int> { 3, DateTime.Now.Hour }, zooSingapore));
                try { zooSingapore.FindAvailableEnclosure(parrotsSingapore[i]).AddAnimals(parrotsSingapore[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            List<Penguin> penguinsSingapore = new List<Penguin>();
            for (int i = 0; i < 3; i++)
            {
                penguinsSingapore.Add(new Penguin(new List<int> { 3, DateTime.Now.Hour }, zooSingapore));
                try { zooSingapore.FindAvailableEnclosure(penguinsSingapore[i]).AddAnimals(penguinsSingapore[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            List<Lion> lionsSingapore = new List<Lion>();
            for (int i = 0; i < 4; i++)
            {
                lionsSingapore.Add(new Lion(new List<int> { 3, DateTime.Now.Hour }, zooSingapore));
                try { zooSingapore.FindAvailableEnclosure(lionsSingapore[i]).AddAnimals(lionsSingapore[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            List<Bison> bisonsSingapore = new List<Bison>();
            for (int i = 0; i < 2; i++)
            {
                bisonsSingapore.Add(new Bison(new List<int> { 3, DateTime.Now.Hour }, zooSingapore));
                try { zooSingapore.FindAvailableEnclosure(bisonsSingapore[i]).AddAnimals(bisonsSingapore[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            List<Elephant> elephantsSingapore = new List<Elephant>();
            for (int i = 0; i < 2; i++)
            {
                elephantsSingapore.Add(new Elephant(new List<int> { 3, DateTime.Now.Hour }, zooSingapore));
                try { zooSingapore.FindAvailableEnclosure(elephantsSingapore[i]).AddAnimals(elephantsSingapore[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            List<Snake> snakesSingapore = new List<Snake>();
            for (int i = 0; i < 7; i++)
            {
                snakesSingapore.Add(new Snake(new List<int> { 3, DateTime.Now.Hour }, zooSingapore));
                try { zooSingapore.FindAvailableEnclosure(snakesSingapore[i]).AddAnimals(snakesSingapore[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            List<Turtle> turtlesSingapore = new List<Turtle>();
            for (int i = 0; i < 5; i++)
            {
                turtlesSingapore.Add(new Turtle(new List<int> { 3, DateTime.Now.Hour }, zooSingapore));
                try { zooSingapore.FindAvailableEnclosure(turtlesSingapore[i]).AddAnimals(turtlesSingapore[i]); } catch { }
            }

            Console.WriteLine("-----------------------------");

            //try to add 2 ZooKeepers with correct experiences to the first zoo
            List<string> experienceCorrect = new List<string> { "Parrot", "Penguin", "Lion", "Elephant", "Bison", "Snake", "Turtle" };
            ZooKeeper zooKeeperTokyo1 = new ZooKeeper("Masashi", "Momota", experienceCorrect);
            ZooKeeper zooKeeperTokyo2 = new ZooKeeper("Kanabana", "Kotoru", experienceCorrect);
            try { zooTokyo.HireEmployee(zooKeeperTokyo1); } catch { }
            try { zooTokyo.HireEmployee(zooKeeperTokyo2); } catch { }

            //try to add 2 ZooKeepers with incorrect experiences to the first zoo
            List<string> experienceIncorrect = new List<string> { "Parrot", "Penguin", "Lion", "Snake", "Turtle", "Zebra", "Unicorn" };
            ZooKeeper zooKeeperTokyo3 = new ZooKeeper("Kanji", "Aoi", experienceIncorrect);
            ZooKeeper zooKeeperTokyo4 = new ZooKeeper("Junya", "Hashibira", experienceIncorrect);
            try { zooTokyo.HireEmployee(zooKeeperTokyo3); } catch { }
            try { zooTokyo.HireEmployee(zooKeeperTokyo4); } catch { }

            //try to add 2 Veterinarians with correct experiences to the first zoo
            Veterinarian veterinarianTokyo1 = new Veterinarian("Izumi", "Ropona", experienceCorrect);
            Veterinarian veterinarianTokyo2 = new Veterinarian("Kimi", "Kochibira", experienceCorrect);
            try { zooTokyo.HireEmployee(veterinarianTokyo1); } catch { }
            try { zooTokyo.HireEmployee(veterinarianTokyo2); } catch { }

            //try to add 2 Veterinarians with incorrect experiences to the first zoo
            Veterinarian veterinarianTokyo3 = new Veterinarian("Saito", "Sonoba", experienceIncorrect);
            Veterinarian veterinarianTokyo4 = new Veterinarian("Megumi", "Tanaka", experienceIncorrect);
            try { zooTokyo.HireEmployee(veterinarianTokyo3); } catch { }
            try { zooTokyo.HireEmployee(veterinarianTokyo4); } catch { }

            Console.WriteLine("-----------------------------");

            //try to add 2 ZooKeepers with correct experiences to the second zoo
            ZooKeeper zooKeeperSingapore1 = new ZooKeeper("Yong", "Kang", experienceCorrect);
            ZooKeeper zooKeeperSingapore2 = new ZooKeeper("Mei", "Tan", experienceCorrect);
            try { zooSingapore.HireEmployee(zooKeeperSingapore1); } catch { }
            try { zooSingapore.HireEmployee(zooKeeperSingapore2); } catch { }

            //try to add 2 ZooKeepers with incorrect experiences to the second zoo
            ZooKeeper zooKeeperSingapore3 = new ZooKeeper("Li", "Tang", experienceIncorrect);
            ZooKeeper zooKeeperSingapore4 = new ZooKeeper("Wei", "Cheng", experienceIncorrect);
            try { zooSingapore.HireEmployee(zooKeeperSingapore3); } catch { }
            try { zooSingapore.HireEmployee(zooKeeperSingapore4); } catch { }

            //try to add 2 Veterinarians with correct experiences to the second zoo
            Veterinarian veterinarianSingapore1 = new Veterinarian("Neo", "Chen", experienceCorrect);
            Veterinarian veterinarianSingapore2 = new Veterinarian("Hy", "Sun", experienceCorrect);
            try { zooSingapore.HireEmployee(veterinarianSingapore1); } catch { }
            try { zooSingapore.HireEmployee(veterinarianSingapore2); } catch { }

            //try to add 2 Veterinarians with incorrect experiences to the second zoo
            Veterinarian veterinarianSingapore3 = new Veterinarian("Yu", "Wei", experienceIncorrect);
            Veterinarian veterinarianSingapore4 = new Veterinarian("Lei", "Tan", experienceIncorrect);
            try { zooSingapore.HireEmployee(veterinarianSingapore3); } catch { }
            try { zooSingapore.HireEmployee(veterinarianSingapore4); } catch { }

            Console.WriteLine("-----------------------------");

            //try to feed all animals in the zoos
            zooTokyo.FeedAnimals();
            Console.WriteLine("-----------------------------");
            zooSingapore.FeedAnimals();

            Console.WriteLine("-----------------------------");

            //try to feed all animals in the zoos
            zooTokyo.HealAnimals();
            Console.WriteLine("-----------------------------");
            zooSingapore.HealAnimals();
        }
    }
}
