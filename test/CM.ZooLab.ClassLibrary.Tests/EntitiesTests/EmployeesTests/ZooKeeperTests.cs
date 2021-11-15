using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary
{
    public class ZooKeeperTests
    {
        ZooKeeper zooKeeper = new ZooKeeper("name", "surname", new List<string> { new Elephant().GetType().Name });
        [Fact]
        public void ShouldBeAbleToCreateZooKeeperObject()
        {
            
            Assert.Equal("name", zooKeeper.FirstName);
            Assert.Equal("surname", zooKeeper.LastName);
            Assert.NotNull(zooKeeper.AnimalExperiences);
        }

        [Fact]
        public void ShouldBeAbleToAddAnimalExperience()
        {
            Lion lion = new Lion();
            zooKeeper.AddAnimalExperience(lion);
            Assert.Contains(lion.GetType().Name, zooKeeper.AnimalExperiences);
        }

        [Fact]
        public void ShouldBeAbleToReturnCorrectResultHasAnimalExperience()
        {
            Lion lion = new Lion();
            zooKeeper.AddAnimalExperience(lion);
            Assert.True(zooKeeper.HasAnimalExperience(new Lion()));
        }
        [Fact]
        public void ShouldBeAbleToReturnCorrectResultHasNotAnimalExperience()
        {
            Lion lion = new Lion();
            zooKeeper.AddAnimalExperience(lion);
            Assert.Throws<NoNeededExperienceException>(() => zooKeeper.HasAnimalExperience(new Turtle()));
        }

        [Fact]
        public void ShouldBeAbleToFeedAnimalAtRelevantTime()
        {
            Elephant elephant = new Elephant();
            elephant.AddFeedSchedule(new List<int>{ 12, DateTime.Now.Hour });
            Assert.True(zooKeeper.FeedAnimal(elephant));
        }
        [Fact]
        public void ShouldBeAbleToFeedAnimalAtIrrelevantTime()
        {
            Elephant elephant = new Elephant();
            elephant.AddFeedSchedule(new List<int> { 11, DateTime.Now.Hour-1 });
            Assert.False(zooKeeper.FeedAnimal(elephant));
        }
    }
}
