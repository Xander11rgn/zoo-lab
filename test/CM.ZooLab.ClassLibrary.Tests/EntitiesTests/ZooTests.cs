using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary
{
    public class ZooTests
    {
        Zoo zoo = new Zoo("test");
        [Fact]
        public void ShouldBeAbleToCreateZooObject()
        {
            zoo.Enclosures = new List<Enclosure>();
            zoo.Employees = new List<IEmployee>();
            Assert.NotNull(zoo.Employees);
            Assert.NotNull(zoo.Enclosures);
            Assert.Equal("test", zoo.Location);
        }
        [Fact]
        public void ShouldBeAbleToFindAvailableEnclosure()
        {
            zoo.Enclosures = new List<Enclosure>();
            zoo.AddEnclosure("test", 5);
            zoo.AddEnclosure("test1", 10);
            zoo.AddEnclosure("test2", 50);
            Assert.Equal(zoo.Enclosures[0], zoo.FindAvailableEnclosure(new Snake()));
            Assert.Equal(zoo.Enclosures[1], zoo.FindAvailableEnclosure(new Penguin()));
            Assert.Throws<NoAvailableEnclosureException>(() => zoo.FindAvailableEnclosure(new Lion()));
        }

        [Fact]
        public void ShouldBeAbleToHireCorrectExperiences()
        {
            Veterinarian veterinarian = new Veterinarian("awdawd", "wadwad", new List<string> { "Elephant", "Parrot", "Bison", "Turtle" });
            ZooKeeper zooKeeper = new ZooKeeper("awdawd", "wadwad", new List<string> { "Elephant", "Parrot", "Bison", "Turtle" });
            zoo.HireEmployee(veterinarian);
            zoo.HireEmployee(zooKeeper);
            Assert.NotEmpty(zoo.Employees);
        }

        [Fact]
        public void ShouldBeAbleToHireIncorrectExperiences()
        {
            Veterinarian veterinarian = new Veterinarian("awdawd", "wadwad", new List<string> { "Elephant", "Parrot", "Bison", "Turtle", "Zebra" });
            ZooKeeper zooKeeper = new ZooKeeper("awdawd", "wadwad", new List<string> { "Elephant", "Parrot", "Bison", "Turtle", "Kangaroo" });
            Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(veterinarian));
            Assert.Throws<NoNeededExperienceException>(() => zoo.HireEmployee(zooKeeper));
            Assert.Throws<Exception>(() => zoo.HireEmployee(null));
        }

        [Fact]
        public void ShouldBeAbleToHeal()
        {
            Veterinarian veterinarian = new Veterinarian("awdawd", "wadwad", new List<string> { "Elephant", "Parrot", "Bison", "Turtle" });
            zoo.HireEmployee(veterinarian);
            zoo.HireEmployee(veterinarian);
            zoo.HireEmployee(veterinarian);
            zoo.AddEnclosure("wada", 2000);
            zoo.AddEnclosure("wada", 10000);
            Elephant elephant = new Elephant(new List<int> { 4, 5 }, zoo);
            elephant.IsSick = true;
            bool elephantIsSick = elephant.IsSick;
            Parrot parrot = new Parrot(new List<int> { 4, 5 }, zoo);
            parrot.IsSick = true;
            bool parrotIsSick = parrot.IsSick;
            Bison bison = new Bison(new List<int> { 4, 5 }, zoo);
            bison.IsSick = true;
            bool bisonIsSick = bison.IsSick;
            Turtle turtle = new Turtle(new List<int> { 4, 5 }, zoo);
            turtle.IsSick = true;
            bool turtleIsSick = turtle.IsSick;
            zoo.FindAvailableEnclosure(elephant).AddAnimals(elephant);
            zoo.FindAvailableEnclosure(parrot).AddAnimals(parrot);
            zoo.FindAvailableEnclosure(bison).AddAnimals(bison);
            zoo.FindAvailableEnclosure(turtle).AddAnimals(turtle);
            zoo.HealAnimals();
            Assert.True(elephantIsSick != elephant.IsSick);
            Assert.True(parrotIsSick != parrot.IsSick);
            Assert.True(bisonIsSick != bison.IsSick);
            Assert.True(turtleIsSick != turtle.IsSick);
        }

        [Fact]
        public void ShouldBeAbleToFeed()
        {
            zoo.Employees = new List<IEmployee>();
            ZooKeeper zooKeeper = new ZooKeeper("awdawd", "wadwad", new List<string> { "Elephant", "Parrot", "Bison", "Turtle"});
            zoo.HireEmployee(zooKeeper);
            zoo.HireEmployee(zooKeeper);
            zoo.HireEmployee(zooKeeper);
            zoo.AddEnclosure("wada", 2000);
            zoo.AddEnclosure("wada", 10000);
            Elephant elephant = new Elephant(new List<int> { 4, DateTime.Now.Hour }, zoo);
            Parrot parrot = new Parrot(new List<int> { 4, DateTime.Now.Hour }, zoo);
            Bison bison = new Bison(new List<int> { 4, DateTime.Now.Hour }, zoo);
            Turtle turtle = new Turtle(new List<int> { 4, DateTime.Now.Hour }, zoo);
            zoo.FindAvailableEnclosure(elephant).AddAnimals(elephant);
            zoo.FindAvailableEnclosure(parrot).AddAnimals(parrot);
            zoo.FindAvailableEnclosure(bison).AddAnimals(bison);
            zoo.FindAvailableEnclosure(turtle).AddAnimals(turtle);

            Assert.Empty(elephant.FeedTimes);
            Assert.Empty(parrot.FeedTimes);
            Assert.Empty(bison.FeedTimes);
            Assert.Empty(turtle.FeedTimes);
            zoo.FeedAnimals();
            Assert.NotEmpty(elephant.FeedTimes);
            Assert.NotEmpty(parrot.FeedTimes);
            Assert.NotEmpty(bison.FeedTimes);
            Assert.NotEmpty(turtle.FeedTimes);
        }
    }
}
