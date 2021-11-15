using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary
{
    public class ElephantTests
    {
        Zoo zoo;
        Elephant elephant;
        public ElephantTests()
        {
            zoo = new Zoo("test");
            zoo.AddEnclosure("zoo", 10000);
            elephant = new Elephant(new List<int> { 6, 18 }, zoo);
            elephant.FeedTimes = new List<FeedTime>();
        }

        [Fact]
        public void ShouldBeAbleToCreateElephantObject()
        {
            Assert.Equal("Elephant", elephant.GetType().Name);
            Assert.Equal(1000, elephant.RequiredSpaceSqFt);
            Assert.Equal(new string[] { "Grass", "Vegetable" }, elephant.FavoriteFood);
            Assert.Equal(new string[] { "Antibiotics", "AntiDepression", "AntiInflammatory" }, elephant.NeededMedicine);
            Assert.Equal(new string[] { "Bison", "Parrots", "Turtle" }, elephant.FriendlyFor);
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForUnfriendlyAnimal()
        {
            Assert.False(elephant.IsFriendlyWith(new Lion()));
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForFriendlyAnimal()
        {
            Assert.True(elephant.IsFriendlyWith(new Bison()));
        }
    }
}
