using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary.Tests
{
    public class ParrotTests
    {
        Zoo zoo;
        Parrot parrot;
        public ParrotTests()
        {
            zoo = new Zoo("test");
            zoo.AddEnclosure("zoo", 10000);
            parrot = new Parrot(new List<int> { 6, 18 }, zoo);
            parrot.FeedTimes = new List<FeedTime>();
        }


        [Fact]
        public void ShouldBeAbleToCreateParrotObject()
        {
            Assert.Equal("Parrot", parrot.GetType().Name);
            Assert.Equal(5, parrot.RequiredSpaceSqFt);
            Assert.Equal(new string[] { "Grass" }, parrot.FavoriteFood);
            Assert.Equal(new string[] { "Antibiotics" }, parrot.NeededMedicine);
            Assert.Equal(new string[]{ "Parrot", "Bison", "Elephant", "Turtle"}, parrot.FriendlyFor);
            Assert.Equal(new List<int> { 6, 18 }, parrot.FeedSchedule);
            Assert.NotNull(parrot.IsSick);
            Assert.Equal(0, parrot.ID);
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForUnfriendlyAnimal()
        {
            Assert.False(parrot.IsFriendlyWith(new Lion()));
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultForFriendlyAnimal()
        {
            Assert.True(parrot.IsFriendlyWith(new Parrot()));
        }


        [Fact]
        public void ShouldBeAbleToFeedWithСorrectFood()
        {
            List<Food> food = new List<Food> { new Grass(), new Meat(), new Vegetable() };
            parrot.Feed(food, new FeedTime(new DateTime(), new ZooKeeper()));
            Assert.NotEmpty(parrot.FeedTimes);
        }

        [Fact]
        public void ShouldBeAbleToAddFeedTime()
        {
            parrot.FeedTimes.Add(new FeedTime(new DateTime(), new ZooKeeper()));
            Assert.NotEmpty(parrot.FeedTimes);
        }

        [Fact]
        public void ShouldBeAbleToHealAnimalIfSick()
        {
            parrot.IsSick = true;
            bool oldIsSick = parrot.IsSick;
            parrot.Heal(new List<Medicine> { new Antibiotics() });
            Assert.Equal(oldIsSick, !parrot.IsSick);
        }
        [Fact]
        public void ShouldNotBeAbleToHealAnimalIfNotSick()
        {
            parrot.IsSick = false;
            bool oldIsSick = parrot.IsSick;
            parrot.Heal(new List<Medicine> { new Antibiotics() });
            Assert.Equal(oldIsSick, parrot.IsSick);
        }

    }
}
