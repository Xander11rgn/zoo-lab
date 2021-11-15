using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary
{
    public class BisonTests
    {
        Zoo zoo;
        Bison bison;
        public BisonTests()
        {
            zoo = new Zoo("test");
            zoo.AddEnclosure("zoo", 10000);
            bison = new Bison(new List<int> { 6, 18 }, zoo);
            bison.FeedTimes = new List<FeedTime>();
        }

        
        [Fact]
        public void ShouldBeAbleToCreateBisonObject()
        {
            Assert.Equal("Bison", bison.GetType().Name);
            Assert.Equal(1000, bison.RequiredSpaceSqFt);
            Assert.Equal(new string[] { "Grass", "Vegetable" }, bison.FavoriteFood);
            Assert.Equal(new string[] { "Antibiotics", "AntiDepression" }, bison.NeededMedicine);
            Assert.Equal(new string[] { "Elephant" }, bison.FriendlyFor);
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForUnfriendlyAnimal()
        {
            Assert.False(bison.IsFriendlyWith(new Lion()));
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForFriendlyAnimal()
        {
            Assert.True(bison.IsFriendlyWith(new Elephant()));
        }
    }
}
