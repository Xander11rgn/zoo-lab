using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary
{
    public class LionTests
    {
        Zoo zoo;
        Lion lion;
        public LionTests()
        {
            zoo = new Zoo("test");
            zoo.AddEnclosure("zoo", 10000);
            lion = new Lion(new List<int> { 6, 18 }, zoo);
            lion.FeedTimes = new List<FeedTime>();
        }

        [Fact]
        public void ShouldBeAbleToCreateLionObject()
        {
            Assert.Equal("Lion", lion.GetType().Name);
            Assert.Equal(1000, lion.RequiredSpaceSqFt);
            Assert.Equal(new string[] { "Meat" }, lion.FavoriteFood);
            Assert.Equal(new string[] { "AntiDepression", "AntiInflammatory" }, lion.NeededMedicine);
            Assert.Equal(new string[] { "Lion" }, lion.FriendlyFor);
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForUnfriendlyAnimal()
        {
            Assert.False(lion.IsFriendlyWith(new Parrot()));
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForFriendlyAnimal()
        {
            Assert.True(lion.IsFriendlyWith(new Lion()));
        }
    }
}
