using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary
{
    public class TurtleTests
    {
        Zoo zoo;
        Turtle turtle;
        public TurtleTests()
        {
            zoo = new Zoo("test");
            zoo.AddEnclosure("zoo", 10000);
            turtle = new Turtle(new List<int> { 6, 18 }, zoo);
            turtle.FeedTimes = new List<FeedTime>();
        }

        [Fact]
        public void ShouldBeAbleToCreateTurtleObject()
        {
            Assert.Equal("Turtle", turtle.GetType().Name);
            Assert.Equal(5, turtle.RequiredSpaceSqFt);
            Assert.Equal(new string[] { "Grass" }, turtle.FavoriteFood);
            Assert.Equal(new string[] { "Antibiotics", "AntiInflammatory" }, turtle.NeededMedicine);
            Assert.Equal(new string[] { "Parrot", "Bison", "Elephant", "Turtle" }, turtle.FriendlyFor);
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForUnfriendlyAnimal()
        {
            Assert.False(turtle.IsFriendlyWith(new Lion()));
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForFriendlyAnimal()
        {
            Assert.True(turtle.IsFriendlyWith(new Turtle()));
        }
    }
}
