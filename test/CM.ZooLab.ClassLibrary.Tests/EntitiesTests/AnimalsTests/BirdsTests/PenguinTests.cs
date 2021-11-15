using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary
{
    public class PenguinTests
    {
        Zoo zoo;
        Penguin penguin;
        public PenguinTests()
        {
            zoo = new Zoo("test");
            zoo.AddEnclosure("zoo", 10000);
            penguin = new Penguin(new List<int> { 6, 18 }, zoo);
            penguin.FeedTimes = new List<FeedTime>();
        }

        [Fact]
        public void ShouldBeAbleToCreatePenguineObject()
        {
            Assert.Equal("Penguin", penguin.GetType().Name);
            Assert.Equal(10, penguin.RequiredSpaceSqFt);
            Assert.Equal(new string[] { "Grass", "Vegetable" }, penguin.FavoriteFood);
            Assert.Equal(new string[] { "Antibiotics", "AntiDepression" }, penguin.NeededMedicine);
            Assert.Equal(new string[] { "Penguin" }, penguin.FriendlyFor);
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForUnfriendlyAnimal()
        {
            Assert.False(penguin.IsFriendlyWith(new Lion()));
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForFriendlyAnimal()
        {
            Assert.True(penguin.IsFriendlyWith(new Penguin()));
        }
    }
}
